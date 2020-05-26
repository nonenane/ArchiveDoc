namespace ArchiveDocSettings
{
    partial class settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNameDeps = new System.Windows.Forms.TextBox();
            this.cmbDeps = new System.Windows.Forms.ComboBox();
            this.lDeps = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbTypeDoc = new System.Windows.Forms.ComboBox();
            this.lTypeDoc = new System.Windows.Forms.Label();
            this.dgvExtension = new System.Windows.Forms.DataGridView();
            this.cExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btExtension = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).BeginInit();
            this.SuspendLayout();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDep,
            this.cSelect});
            this.dgvData.Location = new System.Drawing.Point(6, 87);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(217, 424);
            this.dgvData.TabIndex = 6;
            this.dgvData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEndEdit);
            // 
            // cDep
            // 
            this.cDep.DataPropertyName = "name";
            this.cDep.HeaderText = "Отдел";
            this.cDep.MinimumWidth = 120;
            this.cDep.Name = "cDep";
            this.cDep.ReadOnly = true;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.tbNameDeps);
            this.groupBox1.Controls.Add(this.cmbDeps);
            this.groupBox1.Controls.Add(this.lDeps);
            this.groupBox1.Controls.Add(this.dgvData);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 517);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройка прав доступа отделов";
            // 
            // tbNameDeps
            // 
            this.tbNameDeps.Location = new System.Drawing.Point(6, 62);
            this.tbNameDeps.MaxLength = 150;
            this.tbNameDeps.Name = "tbNameDeps";
            this.tbNameDeps.Size = new System.Drawing.Size(217, 20);
            this.tbNameDeps.TabIndex = 9;
            this.tbNameDeps.TextChanged += new System.EventHandler(this.tbNameDeps_TextChanged);
            // 
            // cmbDeps
            // 
            this.cmbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeps.FormattingEnabled = true;
            this.cmbDeps.Location = new System.Drawing.Point(6, 35);
            this.cmbDeps.Name = "cmbDeps";
            this.cmbDeps.Size = new System.Drawing.Size(217, 21);
            this.cmbDeps.TabIndex = 8;
            this.cmbDeps.SelectionChangeCommitted += new System.EventHandler(this.cmbDeps_SelectionChangeCommitted);
            // 
            // lDeps
            // 
            this.lDeps.AutoSize = true;
            this.lDeps.Location = new System.Drawing.Point(95, 19);
            this.lDeps.Name = "lDeps";
            this.lDeps.Size = new System.Drawing.Size(38, 13);
            this.lDeps.TabIndex = 7;
            this.lDeps.Text = "Отдел";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox2.Controls.Add(this.btExtension);
            this.groupBox2.Controls.Add(this.cmbTypeDoc);
            this.groupBox2.Controls.Add(this.lTypeDoc);
            this.groupBox2.Controls.Add(this.dgvExtension);
            this.groupBox2.Location = new System.Drawing.Point(265, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 517);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Настройки расширения файлов";
            // 
            // cmbTypeDoc
            // 
            this.cmbTypeDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeDoc.FormattingEnabled = true;
            this.cmbTypeDoc.Location = new System.Drawing.Point(6, 35);
            this.cmbTypeDoc.Name = "cmbTypeDoc";
            this.cmbTypeDoc.Size = new System.Drawing.Size(217, 21);
            this.cmbTypeDoc.TabIndex = 8;
            this.cmbTypeDoc.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeDoc_SelectionChangeCommitted);
            // 
            // lTypeDoc
            // 
            this.lTypeDoc.AutoSize = true;
            this.lTypeDoc.Location = new System.Drawing.Point(84, 19);
            this.lTypeDoc.Name = "lTypeDoc";
            this.lTypeDoc.Size = new System.Drawing.Size(61, 13);
            this.lTypeDoc.TabIndex = 7;
            this.lTypeDoc.Text = "Тип файла";
            // 
            // dgvExtension
            // 
            this.dgvExtension.AllowUserToAddRows = false;
            this.dgvExtension.AllowUserToDeleteRows = false;
            this.dgvExtension.AllowUserToResizeRows = false;
            this.dgvExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExtension.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExtension.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvExtension.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExtension.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cExtension,
            this.cUse});
            this.dgvExtension.Location = new System.Drawing.Point(6, 62);
            this.dgvExtension.MultiSelect = false;
            this.dgvExtension.Name = "dgvExtension";
            this.dgvExtension.RowHeadersVisible = false;
            this.dgvExtension.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExtension.Size = new System.Drawing.Size(217, 413);
            this.dgvExtension.TabIndex = 6;
            this.dgvExtension.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExtension_CellEndEdit);
            // 
            // cExtension
            // 
            this.cExtension.DataPropertyName = "Extension";
            this.cExtension.HeaderText = "Расширение файла";
            this.cExtension.Name = "cExtension";
            this.cExtension.ReadOnly = true;
            // 
            // cUse
            // 
            this.cUse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cUse.DataPropertyName = "isUse";
            this.cUse.HeaderText = "V";
            this.cUse.MinimumWidth = 45;
            this.cUse.Name = "cUse";
            this.cUse.Width = 45;
            // 
            // btExtension
            // 
            this.btExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExtension.BackgroundImage = global::ArchiveDocSettings.Properties.Resources.iconfinder_ic_extension_48px_352339;
            this.btExtension.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btExtension.Location = new System.Drawing.Point(191, 479);
            this.btExtension.Name = "btExtension";
            this.btExtension.Size = new System.Drawing.Size(32, 32);
            this.btExtension.TabIndex = 9;
            this.btExtension.UseVisualStyleBackColor = true;
            this.btExtension.Click += new System.EventHandler(this.btExtension_Click);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "settings";
            this.Size = new System.Drawing.Size(519, 549);
            this.Load += new System.EventHandler(this.settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExtension)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvExtension;
        private System.Windows.Forms.ComboBox cmbDeps;
        private System.Windows.Forms.Label lDeps;
        private System.Windows.Forms.ComboBox cmbTypeDoc;
        private System.Windows.Forms.Label lTypeDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cExtension;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDep;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.TextBox tbNameDeps;
        private System.Windows.Forms.Button btExtension;
    }
}
