// WLMMailRulesMover:
//   Uses ESENT Managed Interop (http://managedesent.codeplex.com/)
//        Licensed under Microsoft Public License (MS-PL)
//   Developed by HIRAOKA HYPERS TOOLS, Inc.
//   Licensed under Microsoft Public License (MS-PL)

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text;
using Microsoft.Isam.Esent.Interop;

namespace WLMMailRulesMover {
    static class Program {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main() {
            Api.JetSetSystemParameter(JET_INSTANCE.Nil, JET_SESID.Nil, JET_param.DatabasePageSize, 8192, null);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WForm());
        }
    }

}