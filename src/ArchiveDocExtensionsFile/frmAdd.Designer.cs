namespace ArchiveDocExtensionsFile
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
            this.tbExtension = new System.Windows.Forms.TextBox();
            this.lExtension = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.cmbTypeDoc = new System.Windows.Forms.ComboBox();
            this.lTypeDoc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbExtension
            // 
            this.tbExtension.Location = new System.Drawing.Point(96, 38);
            this.tbExtension.MaxLength = 31;
            this.tbExtension.Name = "tbExtension";
            this.tbExtension.Size = new System.Drawing.Size(202, 20);
            this.tbExtension.TabIndex = 0;
            this.tbExtension.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lExtension
            // 
            this.lExtension.AutoSize = true;
            this.lExtension.Location = new System.Drawing.Point(20, 42);
            this.lExtension.Name = "lExtension";
            this.lExtension.Size = new System.Drawing.Size(70, 13);
            this.lExtension.TabIndex = 6;
            this.lExtension.Text = "Расширение";
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::ArchiveDocExtensionsFile.Properties.Resources.Save;
            this.btSave.Location = new System.Drawing.Point(235, 76);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 2;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::ArchiveDocExtensionsFile.Properties.Resources.Exit;
            this.btClose.Location = new System.Drawing.Point(273, 76);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 3;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // cmbTypeDoc
            // 
            this.cmbTypeDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeDoc.FormattingEnabled = true;
            this.cmbTypeDoc.Location = new System.Drawing.Point(96, 12);
            this.cmbTypeDoc.Name = "cmbTypeDoc";
            this.cmbTypeDoc.Size = new System.Drawing.Size(202, 21);
            this.cmbTypeDoc.TabIndex = 8;
            // 
            // lTypeDoc
            // 
            this.lTypeDoc.AutoSize = true;
            this.lTypeDoc.Location = new System.Drawing.Point(29, 16);
            this.lTypeDoc.Name = "lTypeDoc";
            this.lTypeDoc.Size = new System.Drawing.Size(61, 13);
            this.lTypeDoc.TabIndex = 7;
            this.lTypeDoc.Text = "Тип файла";
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 120);
            this.Controls.Add(this.cmbTypeDoc);
            this.Controls.Add(this.lTypeDoc);
            this.Controls.Add(this.lExtension);
            this.Controls.Add(this.tbExtension);
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
        private System.Windows.Forms.TextBox tbExtension;
        private System.Windows.Forms.Label lExtension;
        private System.Windows.Forms.ComboBox cmbTypeDoc;
        private System.Windows.Forms.Label lTypeDoc;
    }
}