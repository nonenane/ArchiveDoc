namespace ArchiveDocaTypeDoc
{
    partial class frmAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdd));
            this.lNpp = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.tbNpp = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.chbViewArchive = new System.Windows.Forms.CheckBox();
            this.chbViewAdd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lNpp
            // 
            this.lNpp.AutoSize = true;
            this.lNpp.Location = new System.Drawing.Point(7, 17);
            this.lNpp.Name = "lNpp";
            this.lNpp.Size = new System.Drawing.Size(100, 13);
            this.lNpp.TabIndex = 6;
            this.lNpp.Text = "Номер по порядку";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(113, 38);
            this.tbName.MaxLength = 31;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(402, 20);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(24, 42);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(83, 13);
            this.lName.TabIndex = 6;
            this.lName.Text = "Наименование";
            // 
            // tbNpp
            // 
            this.tbNpp.Location = new System.Drawing.Point(113, 13);
            this.tbNpp.MaxLength = 10;
            this.tbNpp.Name = "tbNpp";
            this.tbNpp.Size = new System.Drawing.Size(402, 20);
            this.tbNpp.TabIndex = 1;
            this.tbNpp.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            this.tbNpp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNpp_KeyPress);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::ArchiveDocaTypeDoc.Properties.Resources.Save;
            this.btSave.Location = new System.Drawing.Point(445, 118);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 2;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::ArchiveDocaTypeDoc.Properties.Resources.Exit;
            this.btClose.Location = new System.Drawing.Point(483, 118);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 3;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // chbViewArchive
            // 
            this.chbViewArchive.AutoSize = true;
            this.chbViewArchive.Location = new System.Drawing.Point(225, 64);
            this.chbViewArchive.Name = "chbViewArchive";
            this.chbViewArchive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbViewArchive.Size = new System.Drawing.Size(290, 17);
            this.chbViewArchive.TabIndex = 7;
            this.chbViewArchive.Text = "Отображение архивных документов у руководителя";
            this.chbViewArchive.UseVisualStyleBackColor = true;
            // 
            // chbViewAdd
            // 
            this.chbViewAdd.AutoSize = true;
            this.chbViewAdd.Location = new System.Drawing.Point(286, 87);
            this.chbViewAdd.Name = "chbViewAdd";
            this.chbViewAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbViewAdd.Size = new System.Drawing.Size(229, 17);
            this.chbViewAdd.TabIndex = 7;
            this.chbViewAdd.Text = "Отображать при добавлении документа";
            this.chbViewAdd.UseVisualStyleBackColor = true;
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 162);
            this.Controls.Add(this.chbViewAdd);
            this.Controls.Add(this.chbViewArchive);
            this.Controls.Add(this.tbNpp);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lNpp);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdd_FormClosing);
            this.Load += new System.EventHandler(this.frmAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lNpp;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.TextBox tbNpp;
        private System.Windows.Forms.CheckBox chbViewArchive;
        private System.Windows.Forms.CheckBox chbViewAdd;
    }
}