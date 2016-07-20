namespace WLMMailRulesMover {
    partial class WForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cbId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lv6 = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.il16 = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lvW = new System.Windows.Forms.ListView();
            this.chWDisp = new System.Windows.Forms.ColumnHeader();
            this.bCopy = new System.Windows.Forms.Button();
            this.tv6 = new System.Windows.Forms.TreeView();
            this.tvw = new System.Windows.Forms.TreeView();
            this.bUpFoW = new System.Windows.Forms.Button();
            this.bCopy6 = new System.Windows.Forms.Button();
            this.bCopyW = new System.Windows.Forms.Button();
            this.sfdXml = new System.Windows.Forms.SaveFileDialog();
            this.bLoadwfrmf = new System.Windows.Forms.Button();
            this.bSave6tof = new System.Windows.Forms.Button();
            this.bDelW = new System.Windows.Forms.Button();
            this.bUpW = new System.Windows.Forms.Button();
            this.ofdXml = new System.Windows.Forms.OpenFileDialog();
            this.bLoadFoldersDbx = new System.Windows.Forms.Button();
            this.ofdFoldersDbx = new System.Windows.Forms.OpenFileDialog();
            this.bLoadMailMSMessageStore = new System.Windows.Forms.Button();
            this.ofdMailMSMessageStore = new System.Windows.Forms.OpenFileDialog();
            this.bReadNtuserdat = new System.Windows.Forms.Button();
            this.ofdNtuserdat = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Outlook Express 5～";
            // 
            // cbId
            // 
            this.cbId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbId.FormattingEnabled = true;
            this.cbId.Location = new System.Drawing.Point(12, 24);
            this.cbId.Name = "cbId";
            this.cbId.Size = new System.Drawing.Size(262, 20);
            this.cbId.TabIndex = 1;
            this.cbId.SelectedIndexChanged += new System.EventHandler(this.cbId_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "メッセージルール";
            // 
            // lv6
            // 
            this.lv6.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName});
            this.lv6.FullRowSelect = true;
            this.lv6.GridLines = true;
            this.lv6.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv6.Location = new System.Drawing.Point(12, 97);
            this.lv6.Name = "lv6";
            this.lv6.Size = new System.Drawing.Size(199, 202);
            this.lv6.SmallImageList = this.il16;
            this.lv6.TabIndex = 5;
            this.lv6.UseCompatibleStateImageBehavior = false;
            this.lv6.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "名称";
            this.chName.Width = 160;
            // 
            // il16
            // 
            this.il16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il16.ImageStream")));
            this.il16.TransparentColor = System.Drawing.Color.Transparent;
            this.il16.Images.SetKeyName(0, "P");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Windows Live Mail";
            // 
            // lvW
            // 
            this.lvW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chWDisp});
            this.lvW.FullRowSelect = true;
            this.lvW.GridLines = true;
            this.lvW.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvW.Location = new System.Drawing.Point(298, 97);
            this.lvW.Name = "lvW";
            this.lvW.Size = new System.Drawing.Size(204, 202);
            this.lvW.SmallImageList = this.il16;
            this.lvW.TabIndex = 13;
            this.lvW.UseCompatibleStateImageBehavior = false;
            this.lvW.View = System.Windows.Forms.View.Details;
            this.lvW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvW_KeyDown);
            // 
            // chWDisp
            // 
            this.chWDisp.Text = "名称";
            this.chWDisp.Width = 150;
            // 
            // bCopy
            // 
            this.bCopy.Location = new System.Drawing.Point(217, 211);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(75, 23);
            this.bCopy.TabIndex = 9;
            this.bCopy.Text = "→";
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // tv6
            // 
            this.tv6.Location = new System.Drawing.Point(12, 349);
            this.tv6.Name = "tv6";
            this.tv6.Size = new System.Drawing.Size(199, 165);
            this.tv6.TabIndex = 7;
            // 
            // tvw
            // 
            this.tvw.Location = new System.Drawing.Point(298, 349);
            this.tvw.Name = "tvw";
            this.tvw.Size = new System.Drawing.Size(204, 165);
            this.tvw.TabIndex = 16;
            // 
            // bUpFoW
            // 
            this.bUpFoW.Location = new System.Drawing.Point(427, 520);
            this.bUpFoW.Name = "bUpFoW";
            this.bUpFoW.Size = new System.Drawing.Size(75, 23);
            this.bUpFoW.TabIndex = 18;
            this.bUpFoW.Text = "再読み込み";
            this.bUpFoW.UseVisualStyleBackColor = true;
            this.bUpFoW.Click += new System.EventHandler(this.bUpFoW_Click);
            // 
            // bCopy6
            // 
            this.bCopy6.Location = new System.Drawing.Point(12, 520);
            this.bCopy6.Name = "bCopy6";
            this.bCopy6.Size = new System.Drawing.Size(75, 23);
            this.bCopy6.TabIndex = 8;
            this.bCopy6.Text = "&Copy csv";
            this.bCopy6.UseVisualStyleBackColor = true;
            this.bCopy6.Click += new System.EventHandler(this.bCopy6_Click);
            // 
            // bCopyW
            // 
            this.bCopyW.Location = new System.Drawing.Point(298, 520);
            this.bCopyW.Name = "bCopyW";
            this.bCopyW.Size = new System.Drawing.Size(75, 23);
            this.bCopyW.TabIndex = 17;
            this.bCopyW.Text = "Copy c&sv";
            this.bCopyW.UseVisualStyleBackColor = true;
            this.bCopyW.Click += new System.EventHandler(this.bCopy6_Click);
            // 
            // sfdXml
            // 
            this.sfdXml.DefaultExt = "WLMRules";
            this.sfdXml.Filter = "*.WLMRules|*.WLMRules";
            // 
            // bLoadwfrmf
            // 
            this.bLoadwfrmf.AutoSize = true;
            this.bLoadwfrmf.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bLoadwfrmf.Image = global::WLMMailRulesMover.Properties.Resources.openfolderHS;
            this.bLoadwfrmf.Location = new System.Drawing.Point(508, 53);
            this.bLoadwfrmf.Name = "bLoadwfrmf";
            this.bLoadwfrmf.Size = new System.Drawing.Size(91, 38);
            this.bLoadwfrmf.TabIndex = 11;
            this.bLoadwfrmf.Text = "ファイルから読込";
            this.bLoadwfrmf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bLoadwfrmf.UseVisualStyleBackColor = true;
            this.bLoadwfrmf.Click += new System.EventHandler(this.bLoadwfrmf_Click);
            // 
            // bSave6tof
            // 
            this.bSave6tof.AutoSize = true;
            this.bSave6tof.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bSave6tof.Image = global::WLMMailRulesMover.Properties.Resources.saveHS;
            this.bSave6tof.Location = new System.Drawing.Point(128, 53);
            this.bSave6tof.Name = "bSave6tof";
            this.bSave6tof.Size = new System.Drawing.Size(83, 38);
            this.bSave6tof.TabIndex = 2;
            this.bSave6tof.Text = "ファイルへ保存";
            this.bSave6tof.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bSave6tof.UseVisualStyleBackColor = true;
            this.bSave6tof.Click += new System.EventHandler(this.bSave6tof_Click);
            // 
            // bDelW
            // 
            this.bDelW.AutoSize = true;
            this.bDelW.Image = global::WLMMailRulesMover.Properties.Resources.DeleteHS;
            this.bDelW.Location = new System.Drawing.Point(508, 203);
            this.bDelW.Name = "bDelW";
            this.bDelW.Size = new System.Drawing.Size(78, 38);
            this.bDelW.TabIndex = 14;
            this.bDelW.Text = "ルールを削除";
            this.bDelW.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bDelW.UseVisualStyleBackColor = true;
            this.bDelW.Click += new System.EventHandler(this.bDelW_Click);
            // 
            // bUpW
            // 
            this.bUpW.AutoSize = true;
            this.bUpW.Image = global::WLMMailRulesMover.Properties.Resources.RefreshDocViewHS;
            this.bUpW.Location = new System.Drawing.Point(427, 53);
            this.bUpW.Name = "bUpW";
            this.bUpW.Size = new System.Drawing.Size(75, 38);
            this.bUpW.TabIndex = 10;
            this.bUpW.Text = "更新";
            this.bUpW.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bUpW.UseVisualStyleBackColor = true;
            this.bUpW.Click += new System.EventHandler(this.bUpW_Click);
            // 
            // ofdXml
            // 
            this.ofdXml.Filter = "*.WLMRules|*.WLMRules";
            // 
            // bLoadFoldersDbx
            // 
            this.bLoadFoldersDbx.AutoSize = true;
            this.bLoadFoldersDbx.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bLoadFoldersDbx.Image = global::WLMMailRulesMover.Properties.Resources.openfolderHS;
            this.bLoadFoldersDbx.Location = new System.Drawing.Point(12, 305);
            this.bLoadFoldersDbx.Name = "bLoadFoldersDbx";
            this.bLoadFoldersDbx.Size = new System.Drawing.Size(137, 38);
            this.bLoadFoldersDbx.TabIndex = 6;
            this.bLoadFoldersDbx.Text = "Folders.dbxから読み込み";
            this.bLoadFoldersDbx.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bLoadFoldersDbx.UseVisualStyleBackColor = true;
            this.bLoadFoldersDbx.Click += new System.EventHandler(this.bLoadFoldersDbx_Click);
            // 
            // ofdFoldersDbx
            // 
            this.ofdFoldersDbx.DefaultExt = "*.dbx";
            this.ofdFoldersDbx.Filter = "folders.dbx|folders.dbx";
            // 
            // bLoadMailMSMessageStore
            // 
            this.bLoadMailMSMessageStore.AutoSize = true;
            this.bLoadMailMSMessageStore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bLoadMailMSMessageStore.Image = global::WLMMailRulesMover.Properties.Resources.openfolderHS;
            this.bLoadMailMSMessageStore.Location = new System.Drawing.Point(298, 305);
            this.bLoadMailMSMessageStore.Name = "bLoadMailMSMessageStore";
            this.bLoadMailMSMessageStore.Size = new System.Drawing.Size(190, 38);
            this.bLoadMailMSMessageStore.TabIndex = 15;
            this.bLoadMailMSMessageStore.Text = "Mail.MSMessageStoreから読み込み";
            this.bLoadMailMSMessageStore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bLoadMailMSMessageStore.UseVisualStyleBackColor = true;
            this.bLoadMailMSMessageStore.Click += new System.EventHandler(this.bLoadMailMSMessageStore_Click);
            // 
            // ofdMailMSMessageStore
            // 
            this.ofdMailMSMessageStore.DefaultExt = "MSMessageStore";
            this.ofdMailMSMessageStore.Filter = "Mail.MSMessageStore|Mail.MSMessageStore";
            // 
            // bReadNtuserdat
            // 
            this.bReadNtuserdat.AutoSize = true;
            this.bReadNtuserdat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bReadNtuserdat.Image = global::WLMMailRulesMover.Properties.Resources.openfolderHS;
            this.bReadNtuserdat.Location = new System.Drawing.Point(217, 53);
            this.bReadNtuserdat.Name = "bReadNtuserdat";
            this.bReadNtuserdat.Size = new System.Drawing.Size(65, 38);
            this.bReadNtuserdat.TabIndex = 3;
            this.bReadNtuserdat.Text = "ntuser.dat";
            this.bReadNtuserdat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bReadNtuserdat.UseVisualStyleBackColor = true;
            this.bReadNtuserdat.Click += new System.EventHandler(this.bReadNtuserdat_Click);
            // 
            // ofdNtuserdat
            // 
            this.ofdNtuserdat.DefaultExt = "dat";
            this.ofdNtuserdat.Filter = "NTUSER.DAT|NTUSER.DAT";
            // 
            // WForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 557);
            this.Controls.Add(this.bReadNtuserdat);
            this.Controls.Add(this.bLoadMailMSMessageStore);
            this.Controls.Add(this.bLoadFoldersDbx);
            this.Controls.Add(this.bLoadwfrmf);
            this.Controls.Add(this.bSave6tof);
            this.Controls.Add(this.bCopyW);
            this.Controls.Add(this.bCopy6);
            this.Controls.Add(this.bUpFoW);
            this.Controls.Add(this.tvw);
            this.Controls.Add(this.tv6);
            this.Controls.Add(this.bDelW);
            this.Controls.Add(this.bUpW);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.lvW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lv6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbId);
            this.Controls.Add(this.label1);
            this.Name = "WForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WLM Mail Rules Mover";
            this.Load += new System.EventHandler(this.WForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lv6;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ImageList il16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvW;
        private System.Windows.Forms.ColumnHeader chWDisp;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.Button bUpW;
        private System.Windows.Forms.Button bDelW;
        private System.Windows.Forms.TreeView tv6;
        private System.Windows.Forms.TreeView tvw;
        private System.Windows.Forms.Button bUpFoW;
        private System.Windows.Forms.Button bCopy6;
        private System.Windows.Forms.Button bCopyW;
        private System.Windows.Forms.Button bSave6tof;
        private System.Windows.Forms.SaveFileDialog sfdXml;
        private System.Windows.Forms.Button bLoadwfrmf;
        private System.Windows.Forms.OpenFileDialog ofdXml;
        private System.Windows.Forms.Button bLoadFoldersDbx;
        private System.Windows.Forms.OpenFileDialog ofdFoldersDbx;
        private System.Windows.Forms.Button bLoadMailMSMessageStore;
        private System.Windows.Forms.OpenFileDialog ofdMailMSMessageStore;
        private System.Windows.Forms.Button bReadNtuserdat;
        private System.Windows.Forms.OpenFileDialog ofdNtuserdat;
    }
}

