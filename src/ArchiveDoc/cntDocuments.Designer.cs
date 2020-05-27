namespace ArchiveDoc
{
    partial class cntDocuments
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
            this.chbUnActivePost = new System.Windows.Forms.CheckBox();
            this.trvDeps = new System.Windows.Forms.TreeView();
            this.trvPost = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btViewHisroty = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btDelDoc = new System.Windows.Forms.Button();
            this.btEditDoc = new System.Windows.Forms.Button();
            this.btAddDoc = new System.Windows.Forms.Button();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.btDictonaryTypeDoc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbUnActivePost
            // 
            this.chbUnActivePost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbUnActivePost.AutoSize = true;
            this.chbUnActivePost.Checked = true;
            this.chbUnActivePost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUnActivePost.Location = new System.Drawing.Point(45, 627);
            this.chbUnActivePost.Name = "chbUnActivePost";
            this.chbUnActivePost.Size = new System.Drawing.Size(165, 17);
            this.chbUnActivePost.TabIndex = 0;
            this.chbUnActivePost.Text = "недействующая должность";
            this.chbUnActivePost.UseVisualStyleBackColor = true;
            this.chbUnActivePost.CheckedChanged += new System.EventHandler(this.chbUnActivePost_CheckedChanged);
            // 
            // trvDeps
            // 
            this.trvDeps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trvDeps.Location = new System.Drawing.Point(20, 139);
            this.trvDeps.Name = "trvDeps";
            this.trvDeps.Size = new System.Drawing.Size(382, 467);
            this.trvDeps.TabIndex = 2;
            this.trvDeps.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // trvPost
            // 
            this.trvPost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvPost.Location = new System.Drawing.Point(408, 139);
            this.trvPost.Name = "trvPost";
            this.trvPost.Size = new System.Drawing.Size(499, 467);
            this.trvPost.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 130);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(344, 72);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 32);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(344, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 32);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(87, 84);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(251, 20);
            this.textBox3.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(87, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(251, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "по документу";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "по должности";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "по отделу";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(153)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(20, 626);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(19, 19);
            this.panel1.TabIndex = 6;
            // 
            // btViewHisroty
            // 
            this.btViewHisroty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btViewHisroty.BackgroundImage = global::ArchiveDoc.Properties.Resources.news;
            this.btViewHisroty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btViewHisroty.Location = new System.Drawing.Point(911, 189);
            this.btViewHisroty.Name = "btViewHisroty";
            this.btViewHisroty.Size = new System.Drawing.Size(44, 44);
            this.btViewHisroty.TabIndex = 7;
            this.btViewHisroty.UseVisualStyleBackColor = true;
            this.btViewHisroty.Click += new System.EventHandler(this.btViewHisroty_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(911, 561);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(44, 44);
            this.button7.TabIndex = 7;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Location = new System.Drawing.Point(911, 612);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(44, 44);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Location = new System.Drawing.Point(911, 510);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(44, 44);
            this.button9.TabIndex = 7;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // btDelDoc
            // 
            this.btDelDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelDoc.BackgroundImage = global::ArchiveDoc.Properties.Resources.Trash;
            this.btDelDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btDelDoc.Location = new System.Drawing.Point(862, 612);
            this.btDelDoc.Name = "btDelDoc";
            this.btDelDoc.Size = new System.Drawing.Size(44, 44);
            this.btDelDoc.TabIndex = 7;
            this.btDelDoc.UseVisualStyleBackColor = true;
            this.btDelDoc.Click += new System.EventHandler(this.btDelDoc_Click);
            // 
            // btEditDoc
            // 
            this.btEditDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEditDoc.BackgroundImage = global::ArchiveDoc.Properties.Resources.Edit;
            this.btEditDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btEditDoc.Location = new System.Drawing.Point(813, 612);
            this.btEditDoc.Name = "btEditDoc";
            this.btEditDoc.Size = new System.Drawing.Size(44, 44);
            this.btEditDoc.TabIndex = 7;
            this.btEditDoc.UseVisualStyleBackColor = true;
            this.btEditDoc.Click += new System.EventHandler(this.btEditDoc_Click);
            // 
            // btAddDoc
            // 
            this.btAddDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddDoc.BackgroundImage = global::ArchiveDoc.Properties.Resources.Add;
            this.btAddDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAddDoc.Location = new System.Drawing.Point(764, 612);
            this.btAddDoc.Name = "btAddDoc";
            this.btAddDoc.Size = new System.Drawing.Size(44, 44);
            this.btAddDoc.TabIndex = 7;
            this.btAddDoc.UseVisualStyleBackColor = true;
            this.btAddDoc.Click += new System.EventHandler(this.btAddDoc_Click);
            // 
            // btOpenFile
            // 
            this.btOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenFile.BackgroundImage = global::ArchiveDoc.Properties.Resources.click;
            this.btOpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btOpenFile.Location = new System.Drawing.Point(911, 139);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(44, 44);
            this.btOpenFile.TabIndex = 7;
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // btDictonaryTypeDoc
            // 
            this.btDictonaryTypeDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDictonaryTypeDoc.BackgroundImage = global::ArchiveDoc.Properties.Resources.folder_Dictonary;
            this.btDictonaryTypeDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btDictonaryTypeDoc.Location = new System.Drawing.Point(879, 31);
            this.btDictonaryTypeDoc.Name = "btDictonaryTypeDoc";
            this.btDictonaryTypeDoc.Size = new System.Drawing.Size(66, 66);
            this.btDictonaryTypeDoc.TabIndex = 7;
            this.btDictonaryTypeDoc.UseVisualStyleBackColor = true;
            this.btDictonaryTypeDoc.Click += new System.EventHandler(this.btDictonaryTypeDoc_Click);
            // 
            // cntDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btAddDoc);
            this.Controls.Add(this.btEditDoc);
            this.Controls.Add(this.btDelDoc);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btViewHisroty);
            this.Controls.Add(this.btOpenFile);
            this.Controls.Add(this.btDictonaryTypeDoc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trvPost);
            this.Controls.Add(this.trvDeps);
            this.Controls.Add(this.chbUnActivePost);
            this.Name = "cntDocuments";
            this.Size = new System.Drawing.Size(960, 662);
            this.Load += new System.EventHandler(this.cntDocuments_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbUnActivePost;
        private System.Windows.Forms.TreeView trvDeps;
        private System.Windows.Forms.TreeView trvPost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDictonaryTypeDoc;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.Button btViewHisroty;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btDelDoc;
        private System.Windows.Forms.Button btEditDoc;
        private System.Windows.Forms.Button btAddDoc;
    }
}
