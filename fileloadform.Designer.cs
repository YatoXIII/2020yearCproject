namespace WindowsFormsApp5
{
    partial class fileloadform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fileloadform));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.homebutton = new System.Windows.Forms.Button();
            this.buttonroll = new System.Windows.Forms.Button();
            this.buttonfullscreen = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(17, 52);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(544, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(416, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "Перетащите файл в эту область";
            // 
            // textBox2
            // 
            this.textBox2.AllowDrop = true;
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.HideSelection = false;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(544, 239);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox2_DragDrop);
            this.textBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox2_DragEnter);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(16, 322);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(509, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Либо задайте ссылку вручную или с помощью кнопки";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(469, 351);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "Загрузить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 28, 0, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(573, 48);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolStrip1_MouseDown);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(107, 17);
            this.toolStripLabel1.Text = "Привязать файл";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.BackgroundImage = global::WindowsFormsApp5.Properties.Resources.folder;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(531, 322);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 22);
            this.button3.TabIndex = 16;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // homebutton
            // 
            this.homebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.homebutton.BackgroundImage = global::WindowsFormsApp5.Properties.Resources.down_arrow;
            this.homebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homebutton.Cursor = System.Windows.Forms.Cursors.Default;
            this.homebutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.homebutton.FlatAppearance.BorderSize = 0;
            this.homebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homebutton.Location = new System.Drawing.Point(5, 5);
            this.homebutton.Name = "homebutton";
            this.homebutton.Size = new System.Drawing.Size(21, 21);
            this.homebutton.TabIndex = 15;
            this.homebutton.UseVisualStyleBackColor = false;
            // 
            // buttonroll
            // 
            this.buttonroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.buttonroll.BackgroundImage = global::WindowsFormsApp5.Properties.Resources.minus;
            this.buttonroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonroll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.buttonroll.FlatAppearance.BorderSize = 0;
            this.buttonroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonroll.Location = new System.Drawing.Point(520, 5);
            this.buttonroll.Name = "buttonroll";
            this.buttonroll.Size = new System.Drawing.Size(21, 21);
            this.buttonroll.TabIndex = 14;
            this.buttonroll.UseVisualStyleBackColor = false;
            this.buttonroll.Click += new System.EventHandler(this.Buttonroll_Click);
            // 
            // buttonfullscreen
            // 
            this.buttonfullscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonfullscreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.buttonfullscreen.BackgroundImage = global::WindowsFormsApp5.Properties.Resources.expand;
            this.buttonfullscreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonfullscreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonfullscreen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.buttonfullscreen.FlatAppearance.BorderSize = 0;
            this.buttonfullscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonfullscreen.Location = new System.Drawing.Point(493, 5);
            this.buttonfullscreen.Name = "buttonfullscreen";
            this.buttonfullscreen.Size = new System.Drawing.Size(21, 21);
            this.buttonfullscreen.TabIndex = 13;
            this.buttonfullscreen.UseVisualStyleBackColor = false;
            this.buttonfullscreen.Visible = false;
            this.buttonfullscreen.Click += new System.EventHandler(this.Buttonfullscreen_Click);
            // 
            // buttonclose
            // 
            this.buttonclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.buttonclose.BackgroundImage = global::WindowsFormsApp5.Properties.Resources.cancelred;
            this.buttonclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonclose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.buttonclose.FlatAppearance.BorderSize = 0;
            this.buttonclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonclose.Location = new System.Drawing.Point(547, 5);
            this.buttonclose.Name = "buttonclose";
            this.buttonclose.Size = new System.Drawing.Size(21, 21);
            this.buttonclose.TabIndex = 12;
            this.buttonclose.UseVisualStyleBackColor = false;
            this.buttonclose.Click += new System.EventHandler(this.Buttonclose_Click);
            // 
            // fileloadform
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(573, 389);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.homebutton);
            this.Controls.Add(this.buttonroll);
            this.Controls.Add(this.buttonfullscreen);
            this.Controls.Add(this.buttonclose);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fileloadform";
            this.Text = "Прикерпить файл";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Fileloadform_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Fileloadform_DragOver);
            this.DragLeave += new System.EventHandler(this.Fileloadform_DragLeave);
            this.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.Fileloadform_QueryContinueDrag);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Button homebutton;
        private System.Windows.Forms.Button buttonroll;
        private System.Windows.Forms.Button buttonfullscreen;
        private System.Windows.Forms.Button buttonclose;
        private System.Windows.Forms.Button button3;
    }
}