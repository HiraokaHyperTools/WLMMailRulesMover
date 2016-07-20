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

namespace WLMMailRulesMover {
    public partial class MatchForm : Form {
        public MatchForm() {
            InitializeComponent();
        }

        private void MatchForm_Load(object sender, EventArgs e) {
        }

        private void MatchForm_Shown(object sender, EventArgs e) {
            tvw.Select();
        }
    }
}