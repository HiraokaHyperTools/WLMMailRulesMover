// WLMMailRulesMover:
//   Uses ESENT Managed Interop (http://managedesent.codeplex.com/)
//        Licensed under Microsoft Public License (MS-PL)
//   Developed by HIRAOKA HYPERS TOOLS, Inc.
//   Licensed under Microsoft Public License (MS-PL)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

namespace WLMMailRulesMover {
    public partial class SelfForm : Form {
        public SelfForm() {
            InitializeComponent();
        }

        internal String fpxml;

        internal WForm parent;

        XmlDocument xmlo = new XmlDocument();

        private void SelfForm_Load(object sender, EventArgs e) {
            xmlo.Load(fpxml);

            foreach (XmlElement elr in xmlo.SelectNodes("/WLMMailRulesMover/Rules/Key[@Name='Mail']/Key")) {
                Rule6 r6 = new Rule6();
                r6.elr = elr;
                String name = elr.SelectSingleNode("Value[@Name='Name']/text()").Value;
                ListViewItem lvi = new ListViewItem(name);
                lvi.Tag = r6;
                lv6.Items.Add(lvi);
            }

            foreach (XmlElement elf in xmlo.SelectNodes("/WLMMailRulesMover/Folder")) {
                Fo6 f6 = new Fo6();
                f6.elf = elf;
                alFo6.Add(f6);
            }

            Walk6(-1, tv6.Nodes);
        }

        private void Walk6(int parent, TreeNodeCollection tnc) {
            foreach (Fo6 f in alFo6) {
                if (f.ParentKey == parent) {
                    TreeNode tn = tnc.Add(f.Disp);
                    tn.Tag = f;
                    tn.Name = f.Key.ToString();
                    Walk6(f.Key, tn.Nodes);
                }
            }
        }

        List<Fotre6> alFo6 = new List<Fotre6>();

        class Fo6 : Fotre6 {
            internal XmlElement elf;

            public Fo6() : base(null) { }

            public override int Key {
                get {
                    return Convert.ToInt32(elf.GetAttribute("Key"));
                }
            }

            public override int ParentKey {
                get {
                    return Convert.ToInt32(elf.GetAttribute("ParentKey"));
                }
            }

            public override String Disp {
                get {
                    return (elf.GetAttribute("Disp"));
                }
            }

            public override string ToString() {
                return Key + " " + Disp;
            }
        }

        class Rule6 {
            internal XmlElement elr;
        }

        private void bCopy_Click(object sender, EventArgs e) {
            int n = lv6.SelectedItems.Count;
            if (n == 0) return;
            if (MessageBox.Show(this, "選択した" + n + "件のメッセージルールを、Windows Live Mailに転写します。", null, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                return;

            RegistryKey rkMail = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows Live Mail\Rules\Mail", true);
            int num = 0;
            foreach (ListViewItem lviSrc in lv6.SelectedItems) {
                Rule6 r6 = lviSrc.Tag as Rule6;
                if (r6 == null) continue;

                String cId;
                while (true) {
                    cId = num.ToString("000");
                    if (rkMail.OpenSubKey(cId) == null) break;
                    num++;
                    if (num == 1000) throw new ApplicationException("Windows Live Mail メッセージルールが既に1000個有ります。もう追加できません");
                }

                RegistryKey rkW = rkMail.CreateSubKey(cId);
                REGUt.Copy(rkW, r6.elr);

                byte[] StoreID6 = Convert.FromBase64String(xmlo.DocumentElement.GetAttribute("StoreID6"));

                if (!parent.Migrate(rkW, cId, r6.elr.SelectSingleNode("Value[@Name='Name']/text()").Value, alFo6, StoreID6)) {
                    MessageBox.Show(this, "途中で転写を止めました。", null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            MessageBox.Show(this, "転写しました。", null, MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        class REGUt {
            internal static void Copy(RegistryKey rkto, XmlElement elr) {
                foreach (XmlElement el in elr.SelectNodes("Value")) {
                    String name = el.GetAttribute("Name");
                    Object val = el.SelectSingleNode("text()").Value;
                    RegistryValueKind k = (RegistryValueKind)Enum.Parse(typeof(RegistryValueKind), el.GetAttribute("ValueKind"));
                    if (k == RegistryValueKind.Binary) {
                        val = Convert.FromBase64String((String)val);
                    }
                    rkto.SetValue(name, val, k);
                }
                foreach (XmlElement el in elr.SelectNodes("Key")) {
                    String name = el.GetAttribute("Name");
                    RegistryKey rkto2 = rkto.CreateSubKey(name);
                    Copy(rkto2, el);
                }
            }
        }
    }
}