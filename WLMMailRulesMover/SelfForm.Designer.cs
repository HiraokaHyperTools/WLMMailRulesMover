namespace WLMMailRulesMover {
    partial class SelfForm {
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
            this.label2 = new System.Windows.Forms.Label();
            this.lv6 = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.tv6 = new System.Windows.Forms.TreeView();
            this.bCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "メッセージルールを選択してください：";
            // 
            // lv6
            // 
            this.lv6.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName});
            this.lv6.FullRowSelect = true;
            this.lv6.GridLines = true;
            this.lv6.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv6.Location = new System.Drawing.Point(12, 24);
            this.lv6.Name = "lv6";
            this.lv6.Size = new System.Drawing.Size(199, 246);
            this.lv6.TabIndex = 4;
            this.lv6.UseCompatibleStateImageBehavior = false;
            this.lv6.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "名称";
            this.chName.Width = 160;
            // 
            // tv6
            // 
            this.tv6.Location = new System.Drawing.Point(10, 276);
            this.tv6.Name = "tv6";
            this.tv6.Size = new System.Drawing.Size(201, 165);
            this.tv6.TabIndex = 5;
            // 
            // bCopy
            // 
            this.bCopy.Location = new System.Drawing.Point(217, 148);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(75, 23);
            this.bCopy.TabIndex = 7;
            this.bCopy.Text = "→";
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // SelfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 455);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.tv6);
            this.Controls.Add(this.lv6);
            this.Controls.Add(this.label2);
            this.Name = "SelfForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ファイルから読込";
            this.Load += new System.EventHandler(this.SelfForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lv6;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.TreeView tv6;
        private System.Windows.Forms.Button bCopy;
    }
}