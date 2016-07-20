namespace WLMMailRulesMover {
    partial class MatchForm {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.lRule = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bOk = new System.Windows.Forms.Button();
            this.vsc = new System.Windows.Forms.SplitContainer();
            this.tv6 = new System.Windows.Forms.TreeView();
            this.tvw = new System.Windows.Forms.TreeView();
            this.bSkip = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.vsc.Panel1.SuspendLayout();
            this.vsc.Panel2.SuspendLayout();
            this.vsc.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "メッセージルールのフォルダを選択してください：";
            // 
            // lRule
            // 
            this.lRule.AutoSize = true;
            this.lRule.Location = new System.Drawing.Point(12, 33);
            this.lRule.Name = "lRule";
            this.lRule.Size = new System.Drawing.Size(11, 12);
            this.lRule.TabIndex = 5;
            this.lRule.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Outlook Express 5～ フォルダ：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Windows Live Mail フォルダ：";
            // 
            // bOk
            // 
            this.bOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.bOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOk.Location = new System.Drawing.Point(12, 454);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(362, 23);
            this.bOk.TabIndex = 2;
            this.bOk.Text = "選択したフォルダに変更";
            this.bOk.UseVisualStyleBackColor = true;
            // 
            // vsc
            // 
            this.vsc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vsc.Location = new System.Drawing.Point(12, 58);
            this.vsc.Name = "vsc";
            // 
            // vsc.Panel1
            // 
            this.vsc.Panel1.Controls.Add(this.tv6);
            this.vsc.Panel1.Controls.Add(this.label2);
            // 
            // vsc.Panel2
            // 
            this.vsc.Panel2.Controls.Add(this.tvw);
            this.vsc.Panel2.Controls.Add(this.label3);
            this.vsc.Size = new System.Drawing.Size(537, 363);
            this.vsc.SplitterDistance = 259;
            this.vsc.SplitterWidth = 6;
            this.vsc.TabIndex = 0;
            // 
            // tv6
            // 
            this.tv6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv6.HideSelection = false;
            this.tv6.Location = new System.Drawing.Point(0, 12);
            this.tv6.Name = "tv6";
            this.tv6.Size = new System.Drawing.Size(259, 351);
            this.tv6.TabIndex = 1;
            // 
            // tvw
            // 
            this.tvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvw.HideSelection = false;
            this.tvw.Location = new System.Drawing.Point(0, 12);
            this.tvw.Name = "tvw";
            this.tvw.Size = new System.Drawing.Size(272, 351);
            this.tvw.TabIndex = 1;
            // 
            // bSkip
            // 
            this.bSkip.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bSkip.Location = new System.Drawing.Point(380, 454);
            this.bSkip.Name = "bSkip";
            this.bSkip.Size = new System.Drawing.Size(169, 23);
            this.bSkip.TabIndex = 3;
            this.bSkip.Text = "未設定のままにする";
            this.bSkip.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "※ 赤いフォルダには設定しない方が良いです。";
            // 
            // MatchForm
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bSkip;
            this.ClientSize = new System.Drawing.Size(561, 489);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bSkip);
            this.Controls.Add(this.vsc);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.lRule);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(260, 228);
            this.Name = "MatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MatchForm";
            this.Load += new System.EventHandler(this.MatchForm_Load);
            this.Shown += new System.EventHandler(this.MatchForm_Shown);
            this.vsc.Panel1.ResumeLayout(false);
            this.vsc.Panel1.PerformLayout();
            this.vsc.Panel2.ResumeLayout(false);
            this.vsc.Panel2.PerformLayout();
            this.vsc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lRule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.SplitContainer vsc;
        internal System.Windows.Forms.TreeView tv6;
        internal System.Windows.Forms.TreeView tvw;
        private System.Windows.Forms.Button bSkip;
        private System.Windows.Forms.Label label4;
    }
}