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
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using WLMMailRulesMover.OLEXPDbx;
using Microsoft.Isam.Esent.Interop;
using System.Xml;
using System.Runtime.InteropServices;

namespace WLMMailRulesMover {
    public partial class WForm : Form {
        public WForm() {
            InitializeComponent();
        }

        private void WForm_Load(object sender, EventArgs e) {
            cbId.Items.Clear();
            RegistryKey rkIdRoot = Registry.CurrentUser.OpenSubKey("Identities", false);
            if (rkIdRoot == null) return;
            foreach (String userId in rkIdRoot.GetSubKeyNames()) {
                RegistryKey rkUser = rkIdRoot.OpenSubKey(userId, false);
                if (rkUser == null) continue;
                UserId ui = new UserId();
                ui.rk = rkUser;
                ui.Disp = Convert.ToString(rkUser.GetValue("Username"));
                cbId.Items.Add(ui);
            }

            bUpW_Click(sender, e);

            bUpFoW_Click(sender, e);
        }

        class UserId {
            public String Disp;
            public RegistryKey rk;

            public override string ToString() {
                return Disp;
            }
        }

        private void cbId_SelectedIndexChanged(object sender, EventArgs e) {
            UserId ui = cbId.SelectedItem as UserId;
            if (ui == null) return;

            Read6Rules(ui.rk);

            RegistryKey rk50 = ui.rk.OpenSubKey(@"Software\Microsoft\Outlook Express\5.0", false);
            if (rk50 != null) {
                String StoreRoot = Convert.ToString(rk50.GetValue("Store Root"));
                if (StoreRoot != null && Directory.Exists(StoreRoot)) {
                    String fp = Path.Combine(StoreRoot, "Folders.dbx");
                    if (File.Exists(fp)) {
                        ReadFoldersDbx(fp);
                    }
                }
            }
        }

        /// <summary>
        /// Read Outlook 6 folders.dbx folder tree
        /// </summary>
        /// <param name="e4"></param>
        private void Read6t(DbxTre e4) {
            foreach (DbxTreent te in e4.Entries) {
                if (te.ChildNode != null) {
                    Read6t(te.ChildNode);
                }
                DbxII ii = te.IndexedInfo;
                alFotre6.Add(new Fotre6(ii));
            }
            if (e4.ChildNode != null) {
                Read6t(e4.ChildNode);
            }
        }

        byte[] StoreID6 = new byte[0];

        private void Walkw(Int64 parent, TreeNodeCollection tnc) {
            foreach (Fotrew f in alFotrew) {
                if (f.FLDCOL_PARENT == parent) {
                    TreeNode tn = tnc.Add(f.FLDCOL_NAME);
                    tn.Tag = f;
                    tn.Name = f.FLDCOL_ID.ToString();
                    if (0 != (f.FLDCOL_FLAGS & (0x100000 | 0x400000))) tn.BackColor = Color.Red;
                    Walkw(f.FLDCOL_ID, tn.Nodes);
                }
            }
        }

        class Fotrew {
            public Int64 FLDCOL_ID, FLDCOL_PARENT;
            public int FLDCOL_FLAGS;
            public String FLDCOL_NAME;

            public override string ToString() {
                return FLDCOL_ID + " " + FLDCOL_NAME;
            }
        }
        List<Fotrew> alFotrew = new List<Fotrew>();

        class CCol {
            internal JET_COLUMNID FLDCOL_ID, FLDCOL_PARENT, FLDCOL_NAME, FLDCOL_FLAGS;

            internal JET_COLUMNID Data, Table; // UserDataTable
        }

        CCol C = new CCol();

        class EUt {
            internal static void Check(JET_wrn wrn, String message) {
                if (wrn == JET_wrn.Success) return;
                throw new ApplicationException(message + " " + wrn);
            }
        }

        private void Walk6(int parent, TreeNodeCollection tnc) {
            Render6(parent, tnc, alFotre6);
        }

        private void Render6(int parent, TreeNodeCollection tnc, List<Fotre6> alFotre6) {
            foreach (Fotre6 f in alFotre6) {
                if (f.ParentKey == parent) {
                    TreeNode tn = tnc.Add(f.Disp);
                    tn.Tag = f;
                    tn.Name = f.Key.ToString();
                    tn.ImageKey = "";
                    Render6(f.Key, tn.Nodes, alFotre6);
                }
            }
        }

        List<Fotre6> alFotre6 = new List<Fotre6>();

        class Rule6 {
            public RegistryKey rk;

            public override string ToString() {
                return (rk != null) ? Convert.ToString(rk.GetValue("Name")) : "?";
            }
        }

        class RuleW {
            public RegistryKey rk;


            public override string ToString() {
                return (rk != null) ? Convert.ToString(rk.GetValue("Name")) : "?";
            }
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
                REGUt.Copy(rkW, r6.rk);

                if (!Migrate(rkW, cId, "" + r6.rk.GetValue("Name", ""), alFotre6, StoreID6)) {
                    MessageBox.Show(this, "途中で転写を止めました。", null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                bUpW_Click(sender, e);
            }

            MessageBox.Show(this, "転写しました。", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal bool Migrate(RegistryKey rkW, String cId, String ruleName, List<Fotre6> alFotre6, byte[] StoreID6) {
            RegistryKey rkC = rkW.OpenSubKey("Criteria", true);
            if (rkC != null) {
                foreach (String cnum in rkC.GetSubKeyNames()) {
                    RegistryKey rkCrit = rkC.OpenSubKey(cnum, true);
                    if (rkCrit != null) {
                        int vt = Convert.ToInt32(rkCrit.GetValue("ValueType"));
                        if (vt == 0x41) {
                            rkCrit.SetValue("Value", Encoding.Unicode.GetBytes(Encoding.Default.GetString(((byte[])rkCrit.GetValue("Value")))));
                        }
                    }
                }
            }
            RegistryKey rkA = rkW.OpenSubKey("Actions", true);
            if (rkA != null) {
                foreach (String anum in rkA.GetSubKeyNames()) {
                    RegistryKey rkAction = rkA.OpenSubKey(anum, true);
                    if (rkAction != null) {
                        // http://peizo.at.webry.info/200809/article_1.html
                        int type = Convert.ToInt32(rkAction.GetValue("Type", 0));
                        switch (type) {
                            case 1:
                            case 6: {
                                    Fotre6 f6 = null;

                                    int vt = Convert.ToInt32(rkAction.GetValue("ValueType", 0));
                                    if (vt == 0x41) {
                                        byte[] binTar = (byte[])rkAction.GetValue("Value");
                                        if (binTar.Length == 12 && StoreID6.Length >= 8) {
                                            int t;
                                            for (t = 0; t < 8 && binTar[t] == StoreID6[t]; t++) { }
                                            if (t == 8) {
                                                int fldId = BitConverter.ToInt32(binTar, 8);
                                                f6 = alFotre6.Find(delegate(Fotre6 test) { return test.Key == fldId; });
                                            }
                                        }
                                    }

                                    List<Fotrew> fws = new List<Fotrew>();
                                    if (f6 != null) {
                                        fws = alFotrew.FindAll(delegate(Fotrew test) { return test.FLDCOL_NAME == f6.Disp; });
                                    }

                                    Fotrew fw = null;
                                    {
                                        MatchForm form = new MatchForm();
                                        form.lRule.Text = "" + ruleName;

                                        Render6(-1, form.tv6.Nodes, alFotre6);
                                        if (f6 != null)
                                            foreach (TreeNode tn6 in form.tv6.Nodes.Find(f6.Key + "", true)) {
                                                form.tv6.SelectedNode = tn6;
                                                break;
                                            }
                                        form.tv6.ExpandAll();

                                        Walkw(-1, form.tvw.Nodes);
                                        if (fws.Count != 0) {
                                            foreach (TreeNode tnw in form.tvw.Nodes.Find(fws[0].FLDCOL_ID + "", true)) {
                                                form.tvw.SelectedNode = tnw;
                                                break;
                                            }
                                        }
                                        form.tvw.ExpandAll();

                                        while (true) {
                                            DialogResult res = form.ShowDialog(this);
                                            if (res == DialogResult.OK) {
                                                fw = form.tvw.SelectedNode.Tag as Fotrew;
                                                break;
                                            }
                                            else if (res == DialogResult.No) {
                                                fw = null;
                                                break;
                                            }
                                            else if (MessageBox.Show(this, "中止しますか?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                                                bUpW_Click(null, null);
                                                return false;
                                            }
                                        }

                                    }

                                    if (fw != null && StoreIDW.Length >= 8) {
                                        byte[] newval = new byte[16];
                                        using (MemoryStream os = new MemoryStream(newval, true)) {
                                            os.Write(StoreIDW, 0, 8);
                                            new BinaryWriter(os).Write(fw.FLDCOL_ID);
                                        }

                                        rkAction.SetValue("Value", newval);
                                    }
                                    break;
                                }
                        }
                    }
                }
            }

            {
                RegistryKey rkMail = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows Live Mail\Rules\Mail", true);
                rkMail.SetValue("Order", (Convert.ToString(rkMail.GetValue("Order", "")) + " " + cId).Trim());
            }

            return true;
        }

        class REGUt {
            internal static void Copy(RegistryKey rkto, RegistryKey rkfrm) {
                foreach (String name in rkfrm.GetValueNames()) {
                    rkto.SetValue(name, rkfrm.GetValue(name), rkfrm.GetValueKind(name));
                }
                foreach (String name in rkfrm.GetSubKeyNames()) {
                    RegistryKey rkfrm2 = rkfrm.OpenSubKey(name);
                    RegistryKey rkto2 = rkto.CreateSubKey(name);
                    Copy(rkto2, rkfrm2);
                }
            }
        }

        private void lvW_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete && !e.Alt && !e.Control && !e.Shift && !e.Handled) {
                e.Handled = true;

                bDelW_Click(sender, e);
            }
        }

        private void bUpW_Click(object sender, EventArgs e) {
            RegistryKey rkMail = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows Live Mail\Rules\Mail", false);
            if (rkMail == null) return;

            lvW.Items.Clear();

            foreach (String num in rkMail.GetSubKeyNames()) {
                RuleW rule = new RuleW();
                rule.rk = rkMail.OpenSubKey(num, false);
                ListViewItem lvi = new ListViewItem(rule.ToString());
                lvi.Tag = rule;
                lvi.ImageKey = "P";
                lvW.Items.Add(lvi);
            }
        }

        private void bDelW_Click(object sender, EventArgs e) {
            ListView.SelectedListViewItemCollection lvsel = lvW.SelectedItems;
            if (lvsel.Count == 0) return;
            if (MessageBox.Show(this, "選択した、" + lvsel.Count + "件のメッセージルールを削除しますか?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                RegistryKey rkMail = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows Live Mail\Rules\Mail", true);
                foreach (ListViewItem lvi in lvsel) {
                    RuleW rw = (RuleW)lvi.Tag;
                    String cnum = Path.GetFileName(rw.rk.Name);

                    rkMail.DeleteSubKeyTree(cnum);

                    rkMail.SetValue("Order", (Convert.ToString(rkMail.GetValue("Order", "")).Replace(cnum, "").Replace("  ", " ")).Trim());
                }

                bUpW_Click(sender, e);

                MessageBox.Show(this, "削除しました。", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bUpFoW_Click(object sender, EventArgs e) {
            RegistryKey rkW = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows Live Mail", false);
            if (rkW != null) {
                String StoreRoot = Convert.ToString(rkW.GetValue("Store Root"));
                if (StoreRoot != null && Directory.Exists(StoreRoot)) {
                    String fp = Path.Combine(StoreRoot, "Mail.MSMessageStore");
                    if (File.Exists(fp)) {
                        Readwt(fp);
                    }
                }
            }
        }

        /// <summary>
        /// Read Windows live mail folder tree
        /// </summary>
        /// <param name="fp"></param>
        private void Readwt(String fp) {
            alFotrew.Clear(); tvw.Nodes.Clear();

            bool isReadOnly = true;
            String dir = Path.GetDirectoryName(fp);
            using (Instance inst = new Instance("WLMFolderMover", "WLMFolderMover")) {
                inst.Parameters.LogFileDirectory = dir;
                inst.Parameters.TempDirectory = dir;
                inst.Parameters.SystemDirectory = dir;
                inst.Init();
                using (Session ses = new Session(inst)) {
                    JET_DBID dbid;
                    EUt.Check(Api.JetAttachDatabase(ses.JetSesid, fp, isReadOnly ? AttachDatabaseGrbit.ReadOnly : AttachDatabaseGrbit.None), "JetAttachDatabase");
                    EUt.Check(Api.JetOpenDatabase(ses.JetSesid, fp, null, out dbid, isReadOnly ? OpenDatabaseGrbit.ReadOnly : OpenDatabaseGrbit.None), "JetOpenDatabase");

                    try {
                        using (Table UserDataTable = new Table(ses.JetSesid, dbid, "UserDataTable", isReadOnly ? OpenTableGrbit.ReadOnly : OpenTableGrbit.None)) {
                            C.Data = Api.GetTableColumnid(ses.JetSesid, UserDataTable.JetTableid, "Data");
                            C.Table = Api.GetTableColumnid(ses.JetSesid, UserDataTable.JetTableid, "Table");

                            Trace.Assert(Api.TryMoveFirst(ses.JetSesid, UserDataTable.JetTableid));
                            for (int y = 0; ; y++) {
                                byte[] Data = Api.RetrieveColumn(ses.JetSesid, UserDataTable.JetTableid, C.Data);
                                String Table = Api.RetrieveColumnAsString(ses.JetSesid, UserDataTable.JetTableid, C.Table, Encoding.Unicode).TrimEnd('\0');
                                if (Table == "Folders") StoreIDW = Data;

                                if (Api.TryMoveNext(ses.JetSesid, UserDataTable.JetTableid))
                                    continue;
                                break;
                            }
                        }
                        using (Table Folders = new Table(ses.JetSesid, dbid, "Folders", isReadOnly ? OpenTableGrbit.ReadOnly : OpenTableGrbit.None)) {
                            C.FLDCOL_ID = Api.GetTableColumnid(ses.JetSesid, Folders.JetTableid, "FLDCOL_ID");
                            C.FLDCOL_PARENT = Api.GetTableColumnid(ses.JetSesid, Folders.JetTableid, "FLDCOL_PARENT");
                            C.FLDCOL_NAME = Api.GetTableColumnid(ses.JetSesid, Folders.JetTableid, "FLDCOL_NAME");
                            C.FLDCOL_FLAGS = Api.GetTableColumnid(ses.JetSesid, Folders.JetTableid, "FLDCOL_FLAGS");

                            Trace.Assert(Api.TryMoveFirst(ses.JetSesid, Folders.JetTableid));

                            for (int y = 0; ; y++) {
                                Fotrew w = new Fotrew();
                                if (true
                                    && Api.RetrieveColumnAsInt64(ses.JetSesid, Folders.JetTableid, C.FLDCOL_ID).HasValue
                                    && Api.RetrieveColumnAsInt64(ses.JetSesid, Folders.JetTableid, C.FLDCOL_PARENT).HasValue
                                    && Api.RetrieveColumnAsString(ses.JetSesid, Folders.JetTableid, C.FLDCOL_NAME, Encoding.Default) != null
                                    && Api.RetrieveColumnAsInt32(ses.JetSesid, Folders.JetTableid, C.FLDCOL_FLAGS).HasValue
                                ) {
                                    w.FLDCOL_ID = Api.RetrieveColumnAsInt64(ses.JetSesid, Folders.JetTableid, C.FLDCOL_ID).Value;
                                    w.FLDCOL_PARENT = Api.RetrieveColumnAsInt64(ses.JetSesid, Folders.JetTableid, C.FLDCOL_PARENT).Value;
                                    w.FLDCOL_NAME = Api.RetrieveColumnAsString(ses.JetSesid, Folders.JetTableid, C.FLDCOL_NAME, Encoding.Default).TrimEnd('\0');
                                    w.FLDCOL_FLAGS = Api.RetrieveColumnAsInt32(ses.JetSesid, Folders.JetTableid, C.FLDCOL_FLAGS).Value;
                                    alFotrew.Add(w);
                                }
                                if (Api.TryMoveNext(ses.JetSesid, Folders.JetTableid))
                                    continue;
                                break;
                            }

                        }
                    }
                    finally {
                        Api.JetCloseDatabase(ses.JetSesid, dbid, CloseDatabaseGrbit.None);
                    }
                }
            }
            Walkw(-1, tvw.Nodes);
            tvw.ExpandAll();
        }

        byte[] StoreIDW = new byte[0];

        class HUt {
            internal static String GetHex(byte[] bin, int off, int len) {
                String s = "";
                for (int x = 0; x < len; x++) {
                    if (x != 0) s += " ";
                    s += bin[off + x].ToString("X2");
                }
                return s;
            }
        }

        private void bCopy6_Click(object sender, EventArgs e) {
            bool is6 = object.ReferenceEquals(bCopy6, sender);
            StringWriter wr = new StringWriter();
            byte[] bin = is6 ? StoreID6 : StoreIDW;
            wr.WriteLine("名称,深さ,ID,親ID," + HUt.GetHex(bin, 0, Math.Min(8, bin.Length)));
            CopyWalk(wr, is6 ? tv6.Nodes : tvw.Nodes, 0);
            Clipboard.SetText(wr.ToString());
            MessageBox.Show(this, "Copyしました。", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopyWalk(StringWriter wr, TreeNodeCollection tnc, int indent) {
            foreach (TreeNode tn in tnc) {
                String K = "", PK = "";
                Fotre6 f6 = tn.Tag as Fotre6;
                Fotrew fw = tn.Tag as Fotrew;
                if (f6 != null) {
                    K = f6.Key.ToString();
                    PK = f6.ParentKey.ToString();
                }
                else if (fw != null) {
                    K = fw.FLDCOL_ID.ToString();
                    PK = fw.FLDCOL_PARENT.ToString();
                }
                wr.WriteLine(CSVUt.E(tn.Text) + "," + indent + "," + K + "," + PK);
                CopyWalk(wr, tn.Nodes, indent + 1);
            }
        }

        class CSVUt {
            internal static string E(string p) {
                return (p.IndexOfAny(new char[] { '"', ',', '\r', '\n', '\t' }) >= 0) ? "\"" + p.Replace("\"", "\"\"") : p;
            }
        }

        private void bSave6tof_Click(object sender, EventArgs e) {
            if (cbId.SelectedItem == null) {
                cbId.Select();
                cbId.DroppedDown = true;
                return;
            }

            XmlDocument xmlo = new XmlDocument();
            XmlElement elroot = xmlo.CreateElement("WLMMailRulesMover");
            xmlo.AppendChild(elroot);
            UserId ui = (UserId)cbId.SelectedItem;
            RegistryKey rkRules = ui.rk.OpenSubKey(@"Software\Microsoft\Outlook Express\5.0\Rules", false);
            if (rkRules != null) {
                XmlElement elr = xmlo.CreateElement("Rules");
                elroot.AppendChild(elr);
                RUt.Save(elr, rkRules);
            }
            foreach (Fotre6 f6 in alFotre6) {
                XmlElement elr = xmlo.CreateElement("Folder");
                elroot.AppendChild(elr);
                elr.SetAttribute("Disp", f6.Disp);
                elr.SetAttribute("Key", "" + f6.Key);
                elr.SetAttribute("ParentKey", "" + f6.ParentKey);
            }
            if (StoreID6 != null) elroot.SetAttribute("StoreID6", Convert.ToBase64String(StoreID6));

            if (sfdXml.ShowDialog(this) != DialogResult.OK)
                return;
            xmlo.Save(sfdXml.FileName);
            MessageBox.Show(this, "保存しました", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        class RUt {
            internal static void Save(XmlElement elr, RegistryKey rk) {
                foreach (String a in rk.GetSubKeyNames()) {
                    XmlElement el = elr.OwnerDocument.CreateElement("Key");
                    elr.AppendChild(el);
                    el.SetAttribute("Name", a);
                    Save(el, rk.OpenSubKey(a, false));
                }
                foreach (String a in rk.GetValueNames()) {
                    Object val = rk.GetValue(a, null, RegistryValueOptions.DoNotExpandEnvironmentNames);
                    XmlElement el = elr.OwnerDocument.CreateElement("Value");
                    elr.AppendChild(el);
                    el.SetAttribute("Name", a);
                    el.SetAttribute("ValueKind", "" + rk.GetValueKind(a));
                    if (val is byte[]) {
                        el.AppendChild(el.OwnerDocument.CreateTextNode(Convert.ToBase64String((byte[])val, Base64FormattingOptions.InsertLineBreaks)));
                    }
                    else if (val is int || val is uint || val is byte || val is sbyte || val is short || val is ushort || val is long || val is ulong || val is string) {
                        el.AppendChild(el.OwnerDocument.CreateTextNode("" + val));
                    }
                }
            }
        }

        private void bLoadwfrmf_Click(object sender, EventArgs e) {
            if (ofdXml.ShowDialog(this) != DialogResult.OK)
                return;

            SelfForm form = new SelfForm();
            form.fpxml = ofdXml.FileName;
            form.parent = this;
            form.ShowDialog();

            bUpW_Click(sender, e);
        }

        private void bLoadFoldersDbx_Click(object sender, EventArgs e) {
            if (ofdFoldersDbx.ShowDialog(this) == DialogResult.OK) {
                ReadFoldersDbx(ofdFoldersDbx.FileName);
            }
        }

        private void ReadFoldersDbx(String fp) {
            alFotre6.Clear();
            tv6.Nodes.Clear();

            using (FileStream fs = File.OpenRead(fp)) {
                int cb = Convert.ToInt32(fs.Length);
                byte[] bin = new byte[cb];
                if (fs.Read(bin, 0, cb) != cb) throw new EndOfStreamException();
                DbxFH fh = new DbxFH(bin, 0);
                if (fh.IsFolderDatabase) {
                    DbxTre e4 = fh.E4;
                    StoreID6 = new byte[8];
                    fs.Position = 0x24BC;
                    fs.Read(StoreID6, 0, 8);
                    Read6t(e4);
                }
            }

            Walk6(-1, tv6.Nodes);
            tv6.ExpandAll();
        }

        private void bLoadMailMSMessageStore_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(ofdMailMSMessageStore.FileName)) {
                ofdMailMSMessageStore.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft\\Windows Live Mail\\Mail.MSMessageStore");
            }
            if (ofdMailMSMessageStore.ShowDialog(this) == DialogResult.OK) {
                Readwt(ofdMailMSMessageStore.FileName);
            }
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern Int32 RegLoadKey(UInt32 hKey, String lpSubKey, String lpFile);

        public enum HKEY : uint {
            LOCAL_MACHINE = 0x80000002,
            USERS = 0x80000003
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        static extern Int32 RegUnLoadKey(
            UInt32 hKey,
            string lpSubKey);

        private void bReadNtuserdat_Click(object sender, EventArgs e) {
            if (ofdNtuserdat.ShowDialog(this) == DialogResult.OK) {
                String fp = ofdNtuserdat.FileName;
                String hash = "";
                foreach (byte b in System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(fp))) hash += b.ToString("x2");
                UtPriv.EnablePriv(UtPriv.SE_RESTORE_NAME);
                int r = RegLoadKey((uint)HKEY.USERS, hash, fp);
                if (r != 0) throw new Win32Exception(r);
                try {
                    using (RegistryKey rk = Registry.Users.OpenSubKey(hash, false)) {
                        Read6Rules(rk);
                    }
                }
                finally {
                    RegUnLoadKey((uint)HKEY.USERS, hash);
                }
            }
        }

        void Read6Rules(RegistryKey rk) {
            lv6.Items.Clear();
            if (rk == null) return;
            RegistryKey rkMail = rk.OpenSubKey(@"Software\Microsoft\Outlook Express\5.0\Rules\Mail", false);
            if (rkMail == null) return;
            foreach (String rId in rkMail.GetSubKeyNames()) {
                Rule6 rule = new Rule6();
                rule.rk = rkMail.OpenSubKey(rId, false);
                ListViewItem lvi = new ListViewItem(rule.ToString());
                lvi.Tag = rule;
                lvi.ImageKey = "P";
                lv6.Items.Add(lvi);
            }
        }
    }

    class Fotre6 { // folder tree OLEXP6
        DbxII ii;

        public Fotre6(DbxII ii) {
            this.ii = ii;
        }

        public virtual int Key {
            get {
                DbxIF f = Array.Find<DbxIF>(ii.Fields, delegate(DbxIF tar) { return tar.Index == 0; });
                return (f != null) ? f.Int32Value : 0;
            }
        }

        public virtual int ParentKey {
            get {
                DbxIF f = Array.Find<DbxIF>(ii.Fields, delegate(DbxIF tar) { return tar.Index == 1; });
                return (f != null) ? f.Int32Value : -1;
            }
        }

        public virtual String Disp {
            get {
                DbxIF f = Array.Find<DbxIF>(ii.Fields, delegate(DbxIF tar) { return tar.Index == 2; });
                return (f != null) ? f.StringValue : String.Empty;
            }
        }

        public override string ToString() {
            return Key + " " + Disp;
        }
    }
}