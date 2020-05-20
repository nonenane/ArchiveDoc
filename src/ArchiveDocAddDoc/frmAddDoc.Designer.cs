namespace ArchiveDocAddDoc
{
    partial class frmAddDoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddDoc));
            this.lTypeDoc = new System.Windows.Forms.Label();
            this.cmbTypeDoc = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.lFileName = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btAddDoc = new System.Windows.Forms.Button();
            this.lDeps = new System.Windows.Forms.Label();
            this.cmbDeps = new System.Windows.Forms.ComboBox();
            this.lPost = new System.Windows.Forms.Label();
            this.cmbPost = new System.Windows.Forms.ComboBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lNameDoc = new System.Windows.Forms.Label();
            this.tbNameDoc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lTypeDoc
            // 
            this.lTypeDoc.AutoSize = true;
            this.lTypeDoc.Location = new System.Drawing.Point(12, 16);
            this.lTypeDoc.Name = "lTypeDoc";
            this.lTypeDoc.Size = new System.Drawing.Size(83, 13);
            this.lTypeDoc.TabIndex = 0;
            this.lTypeDoc.Text = "Тип документа";
            // 
            // cmbTypeDoc
            // 
            this.cmbTypeDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeDoc.FormattingEnabled = true;
            this.cmbTypeDoc.Location = new System.Drawing.Point(101, 12);
            this.cmbTypeDoc.Name = "cmbTypeDoc";
            this.cmbTypeDoc.Size = new System.Drawing.Size(502, 21);
            this.cmbTypeDoc.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(405, 39);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(106, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "из базы данных";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Источник документа";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(521, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(82, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "компьютер";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // lFileName
            // 
            this.lFileName.AutoSize = true;
            this.lFileName.Location = new System.Drawing.Point(12, 66);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(93, 13);
            this.lFileName.TabIndex = 0;
            this.lFileName.Text = "Файл документа";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(111, 62);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(454, 20);
            this.tbFileName.TabIndex = 3;
            // 
            // btAddDoc
            // 
            this.btAddDoc.Location = new System.Drawing.Point(571, 62);
            this.btAddDoc.Name = "btAddDoc";
            this.btAddDoc.Size = new System.Drawing.Size(32, 20);
            this.btAddDoc.TabIndex = 4;
            this.btAddDoc.Text = "...";
            this.btAddDoc.UseVisualStyleBackColor = true;
            // 
            // lDeps
            // 
            this.lDeps.AutoSize = true;
            this.lDeps.Location = new System.Drawing.Point(12, 145);
            this.lDeps.Name = "lDeps";
            this.lDeps.Size = new System.Drawing.Size(38, 13);
            this.lDeps.TabIndex = 0;
            this.lDeps.Text = "Отдел";
            // 
            // cmbDeps
            // 
            this.cmbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeps.FormattingEnabled = true;
            this.cmbDeps.Location = new System.Drawing.Point(53, 141);
            this.cmbDeps.Name = "cmbDeps";
            this.cmbDeps.Size = new System.Drawing.Size(173, 21);
            this.cmbDeps.TabIndex = 1;
            // 
            // lPost
            // 
            this.lPost.AutoSize = true;
            this.lPost.Location = new System.Drawing.Point(241, 145);
            this.lPost.Name = "lPost";
            this.lPost.Size = new System.Drawing.Size(65, 13);
            this.lPost.TabIndex = 0;
            this.lPost.Text = "Должность";
            // 
            // cmbPost
            // 
            this.cmbPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPost.FormattingEnabled = true;
            this.cmbPost.Location = new System.Drawing.Point(312, 141);
            this.cmbPost.Name = "cmbPost";
            this.cmbPost.Size = new System.Drawing.Size(291, 21);
            this.cmbPost.TabIndex = 1;
            // 
            // btClose
            // 
            this.btClose.BackgroundImage = global::ArchiveDocAddDoc.Properties.Resources.Exit;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btClose.Location = new System.Drawing.Point(571, 589);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 4;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSave
            // 
            this.btSave.BackgroundImage = global::ArchiveDocAddDoc.Properties.Resources.Save;
            this.btSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSave.Location = new System.Drawing.Point(533, 589);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 4;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDep,
            this.cPost,
            this.cSelect});
            this.dgvData.Location = new System.Drawing.Point(12, 168);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(591, 415);
            this.dgvData.TabIndex = 5;
            // 
            // cDep
            // 
            this.cDep.HeaderText = "Отдел";
            this.cDep.Name = "cDep";
            this.cDep.ReadOnly = true;
            // 
            // cPost
            // 
            this.cPost.HeaderText = "Должность";
            this.cPost.Name = "cPost";
            this.cPost.ReadOnly = true;
            // 
            // cSelect
            // 
            this.cSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cSelect.HeaderText = "V";
            this.cSelect.MinimumWidth = 45;
            this.cSelect.Name = "cSelect";
            this.cSelect.ReadOnly = true;
            this.cSelect.Width = 45;
            // 
            // lNameDoc
            // 
            this.lNameDoc.AutoSize = true;
            this.lNameDoc.Location = new System.Drawing.Point(47, 92);
            this.lNameDoc.Name = "lNameDoc";
            this.lNameDoc.Size = new System.Drawing.Size(58, 13);
            this.lNameDoc.TabIndex = 0;
            this.lNameDoc.Text = "Документ";
            // 
            // tbNameDoc
            // 
            this.tbNameDoc.Location = new System.Drawing.Point(111, 88);
            this.tbNameDoc.MaxLength = 150;
            this.tbNameDoc.Name = "tbNameDoc";
            this.tbNameDoc.Size = new System.Drawing.Size(454, 20);
            this.tbNameDoc.TabIndex = 3;
            // 
            // frmAddDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 633);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAddDoc);
            this.Controls.Add(this.tbNameDoc);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.cmbPost);
            this.Controls.Add(this.cmbDeps);
            this.Controls.Add(this.cmbTypeDoc);
            this.Controls.Add(this.lNameDoc);
            this.Controls.Add(this.lPost);
            this.Controls.Add(this.lFileName);
            this.Controls.Add(this.lDeps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lTypeDoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddDoc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddDoc_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTypeDoc;
        private System.Windows.Forms.ComboBox cmbTypeDoc;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btAddDoc;
        private System.Windows.Forms.Label lDeps;
        private System.Windows.Forms.ComboBox cmbDeps;
        private System.Windows.Forms.Label lPost;
        private System.Windows.Forms.ComboBox cmbPost;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.Label lNameDoc;
        private System.Windows.Forms.TextBox tbNameDoc;
    }
}

