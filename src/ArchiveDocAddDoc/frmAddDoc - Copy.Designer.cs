namespace ArchiveDocAddDoc
{
    partial class frmAddDoc_copy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddDoc_copy));
            this.lTypeDoc = new System.Windows.Forms.Label();
            this.cmbTypeDoc = new System.Windows.Forms.ComboBox();
            this.rbDataBase = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rbPC = new System.Windows.Forms.RadioButton();
            this.lFileName = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btAddDoc = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.lNameDoc = new System.Windows.Forms.Label();
            this.tbNameDoc = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // rbDataBase
            // 
            this.rbDataBase.AutoSize = true;
            this.rbDataBase.Checked = true;
            this.rbDataBase.Location = new System.Drawing.Point(405, 39);
            this.rbDataBase.Name = "rbDataBase";
            this.rbDataBase.Size = new System.Drawing.Size(106, 17);
            this.rbDataBase.TabIndex = 2;
            this.rbDataBase.TabStop = true;
            this.rbDataBase.Text = "из базы данных";
            this.rbDataBase.UseVisualStyleBackColor = true;
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
            // rbPC
            // 
            this.rbPC.AutoSize = true;
            this.rbPC.Location = new System.Drawing.Point(521, 39);
            this.rbPC.Name = "rbPC";
            this.rbPC.Size = new System.Drawing.Size(82, 17);
            this.rbPC.TabIndex = 2;
            this.rbPC.Text = "компьютер";
            this.rbPC.UseVisualStyleBackColor = true;
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
            this.btAddDoc.Click += new System.EventHandler(this.btAddDoc_Click);
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
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            this.cSelect});
            this.dgvData.Location = new System.Drawing.Point(12, 168);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(275, 415);
            this.dgvData.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewCheckBoxColumn1});
            this.dataGridView1.Location = new System.Drawing.Point(328, 168);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(275, 415);
            this.dataGridView1.TabIndex = 5;
            // 
            // cDep
            // 
            this.cDep.HeaderText = "Отдел";
            this.cDep.Name = "cDep";
            this.cDep.ReadOnly = true;
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
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCheckBoxColumn1.HeaderText = "V";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 45;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 45;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 142);
            this.textBox1.MaxLength = 150;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(328, 142);
            this.textBox2.MaxLength = 150;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(230, 20);
            this.textBox2.TabIndex = 3;
            // 
            // frmAddDoc_copy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 633);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btAddDoc);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tbNameDoc);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.rbPC);
            this.Controls.Add(this.rbDataBase);
            this.Controls.Add(this.cmbTypeDoc);
            this.Controls.Add(this.lNameDoc);
            this.Controls.Add(this.lFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lTypeDoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddDoc_copy";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddDoc_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTypeDoc;
        private System.Windows.Forms.ComboBox cmbTypeDoc;
        private System.Windows.Forms.RadioButton rbDataBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbPC;
        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btAddDoc;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lNameDoc;
        private System.Windows.Forms.TextBox tbNameDoc;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDep;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

