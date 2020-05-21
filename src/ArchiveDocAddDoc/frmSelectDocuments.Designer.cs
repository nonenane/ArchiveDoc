namespace ArchiveDocAddDoc
{
    partial class frmSelectDocuments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectDocuments));
            this.cmbPost = new System.Windows.Forms.ComboBox();
            this.cmbDeps = new System.Windows.Forms.ComboBox();
            this.lPost = new System.Windows.Forms.Label();
            this.lDeps = new System.Windows.Forms.Label();
            this.tbNameDoc = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPost
            // 
            this.cmbPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPost.FormattingEnabled = true;
            this.cmbPost.Location = new System.Drawing.Point(319, 12);
            this.cmbPost.Name = "cmbPost";
            this.cmbPost.Size = new System.Drawing.Size(291, 21);
            this.cmbPost.TabIndex = 4;
            this.cmbPost.SelectionChangeCommitted += new System.EventHandler(this.cmbDeps_SelectionChangeCommitted);
            // 
            // cmbDeps
            // 
            this.cmbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeps.FormattingEnabled = true;
            this.cmbDeps.Location = new System.Drawing.Point(60, 12);
            this.cmbDeps.Name = "cmbDeps";
            this.cmbDeps.Size = new System.Drawing.Size(173, 21);
            this.cmbDeps.TabIndex = 5;
            this.cmbDeps.SelectionChangeCommitted += new System.EventHandler(this.cmbDeps_SelectionChangeCommitted);
            // 
            // lPost
            // 
            this.lPost.AutoSize = true;
            this.lPost.Location = new System.Drawing.Point(248, 16);
            this.lPost.Name = "lPost";
            this.lPost.Size = new System.Drawing.Size(65, 13);
            this.lPost.TabIndex = 2;
            this.lPost.Text = "Должность";
            // 
            // lDeps
            // 
            this.lDeps.AutoSize = true;
            this.lDeps.Location = new System.Drawing.Point(19, 16);
            this.lDeps.Name = "lDeps";
            this.lDeps.Size = new System.Drawing.Size(38, 13);
            this.lDeps.TabIndex = 3;
            this.lDeps.Text = "Отдел";
            // 
            // tbNameDoc
            // 
            this.tbNameDoc.Location = new System.Drawing.Point(319, 39);
            this.tbNameDoc.MaxLength = 150;
            this.tbNameDoc.Name = "tbNameDoc";
            this.tbNameDoc.Size = new System.Drawing.Size(291, 20);
            this.tbNameDoc.TabIndex = 6;
            this.tbNameDoc.TextChanged += new System.EventHandler(this.tbNameDoc_TextChanged);
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
            this.cType,
            this.cNameDoc});
            this.dgvData.Location = new System.Drawing.Point(12, 65);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(598, 448);
            this.dgvData.TabIndex = 7;
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            this.dgvData.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvData_ColumnWidthChanged);
            // 
            // cType
            // 
            this.cType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cType.DataPropertyName = "nameTypeDoc";
            this.cType.HeaderText = "Тип документа";
            this.cType.MinimumWidth = 150;
            this.cType.Name = "cType";
            this.cType.ReadOnly = true;
            this.cType.Width = 150;
            // 
            // cNameDoc
            // 
            this.cNameDoc.DataPropertyName = "cName";
            this.cNameDoc.HeaderText = "Наименование документа";
            this.cNameDoc.Name = "cNameDoc";
            this.cNameDoc.ReadOnly = true;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackgroundImage = global::ArchiveDocAddDoc.Properties.Resources.Exit;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btClose.Location = new System.Drawing.Point(578, 519);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 8;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.BackgroundImage = global::ArchiveDocAddDoc.Properties.Resources.Save;
            this.btSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btSave.Location = new System.Drawing.Point(540, 519);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 9;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Visible = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // frmSelectDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 556);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.tbNameDoc);
            this.Controls.Add(this.cmbPost);
            this.Controls.Add(this.cmbDeps);
            this.Controls.Add(this.lPost);
            this.Controls.Add(this.lDeps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectDocuments";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSelectDocuments";
            this.Load += new System.EventHandler(this.frmSelectDocuments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPost;
        private System.Windows.Forms.ComboBox cmbDeps;
        private System.Windows.Forms.Label lPost;
        private System.Windows.Forms.Label lDeps;
        private System.Windows.Forms.TextBox tbNameDoc;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn cType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameDoc;
        private System.Windows.Forms.Button btSave;
    }
}