namespace ArchiveDocAddDoc.justification
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdd));
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.lNumber = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lComment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(11, 25);
            this.tbNumber.MaxLength = 150;
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(489, 20);
            this.tbNumber.TabIndex = 7;
            // 
            // lNumber
            // 
            this.lNumber.AutoSize = true;
            this.lNumber.Location = new System.Drawing.Point(11, 9);
            this.lNumber.Name = "lNumber";
            this.lNumber.Size = new System.Drawing.Size(190, 13);
            this.lNumber.TabIndex = 8;
            this.lNumber.Text = "Номер и дата документа основания";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(11, 51);
            this.tbComment.MaxLength = 500;
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbComment.Size = new System.Drawing.Size(488, 69);
            this.tbComment.TabIndex = 7;
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::ArchiveDocAddDoc.Properties.Resources.Save;
            this.btSave.Location = new System.Drawing.Point(470, 472);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 4;
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::ArchiveDocAddDoc.Properties.Resources.Exit;
            this.btClose.Location = new System.Drawing.Point(470, 472);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 5;
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Visible = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
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
            this.cStatus,
            this.cSelect});
            this.dgvData.Location = new System.Drawing.Point(11, 126);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(488, 340);
            this.dgvData.TabIndex = 9;
            // 
            // cDep
            // 
            this.cDep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cDep.DataPropertyName = "nameDeps";
            this.cDep.HeaderText = "Отдел";
            this.cDep.MinimumWidth = 120;
            this.cDep.Name = "cDep";
            this.cDep.ReadOnly = true;
            this.cDep.Width = 190;
            // 
            // cPost
            // 
            this.cPost.DataPropertyName = "namePost";
            this.cPost.HeaderText = "Должность";
            this.cPost.Name = "cPost";
            this.cPost.ReadOnly = true;
            // 
            // cStatus
            // 
            this.cStatus.DataPropertyName = "nameStatus";
            this.cStatus.HeaderText = "Статус";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            // 
            // cSelect
            // 
            this.cSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cSelect.DataPropertyName = "isSelect";
            this.cSelect.HeaderText = "V";
            this.cSelect.MinimumWidth = 45;
            this.cSelect.Name = "cSelect";
            this.cSelect.Width = 45;
            // 
            // lComment
            // 
            this.lComment.AutoSize = true;
            this.lComment.Location = new System.Drawing.Point(422, 9);
            this.lComment.Name = "lComment";
            this.lComment.Size = new System.Drawing.Size(77, 13);
            this.lComment.TabIndex = 10;
            this.lComment.Text = "Комментарий";
            this.lComment.Visible = false;
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 516);
            this.Controls.Add(this.lComment);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.lNumber);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод обоснования перевода в архив";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdd_FormClosing);
            this.Load += new System.EventHandler(this.frmAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label lNumber;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
    }
}