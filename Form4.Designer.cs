namespace WindowsFormsApp5
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.TB_Num = new System.Windows.Forms.TextBox();
            this.label_num = new System.Windows.Forms.Label();
            this.homebutton = new System.Windows.Forms.Button();
            this.buttonroll = new System.Windows.Forms.Button();
            this.buttonfullscreen = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_PName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Mtime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Quan = new System.Windows.Forms.TextBox();
            this.TB_ATime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_Other = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.TB_PName = new System.Windows.Forms.TextBox();
            this.TB_Date = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripLabel1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 31, 5, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(775, 54);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolStrip1_MouseDown);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(96, 20);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 20);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // TB_Num
            // 
            this.TB_Num.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TB_Num.Location = new System.Drawing.Point(91, 57);
            this.TB_Num.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_Num.MaxLength = 250;
            this.TB_Num.Name = "TB_Num";
            this.TB_Num.ReadOnly = true;
            this.TB_Num.Size = new System.Drawing.Size(154, 23);
            this.TB_Num.TabIndex = 17;
            // 
            // label_num
            // 
            this.label_num.AutoSize = true;
            this.label_num.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_num.Location = new System.Drawing.Point(36, 60);
            this.label_num.Name = "label_num";
            this.label_num.Size = new System.Drawing.Size(49, 17);
            this.label_num.TabIndex = 18;
            this.label_num.Text = "Номер";
            // 
            // homebutton
            // 
            this.homebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.homebutton.BackgroundImage = global::WindowsFormsApp5.Properties.Resources.study;
            this.homebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homebutton.Cursor = System.Windows.Forms.Cursors.Default;
            this.homebutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.homebutton.FlatAppearance.BorderSize = 0;
            this.homebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homebutton.Location = new System.Drawing.Point(5, 5);
            this.homebutton.Name = "homebutton";
            this.homebutton.Size = new System.Drawing.Size(21, 21);
            this.homebutton.TabIndex = 22;
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
            this.buttonroll.Location = new System.Drawing.Point(722, 5);
            this.buttonroll.Name = "buttonroll";
            this.buttonroll.Size = new System.Drawing.Size(21, 21);
            this.buttonroll.TabIndex = 21;
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
            this.buttonfullscreen.Location = new System.Drawing.Point(695, 5);
            this.buttonfullscreen.Name = "buttonfullscreen";
            this.buttonfullscreen.Size = new System.Drawing.Size(21, 21);
            this.buttonfullscreen.TabIndex = 20;
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
            this.buttonclose.Location = new System.Drawing.Point(749, 5);
            this.buttonclose.Name = "buttonclose";
            this.buttonclose.Size = new System.Drawing.Size(21, 21);
            this.buttonclose.TabIndex = 19;
            this.buttonclose.UseVisualStyleBackColor = false;
            this.buttonclose.Click += new System.EventHandler(this.Buttonclose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Наименование изделия";
            // 
            // CB_PName
            // 
            this.CB_PName.BackColor = System.Drawing.Color.White;
            this.CB_PName.FormattingEnabled = true;
            this.CB_PName.Location = new System.Drawing.Point(173, 87);
            this.CB_PName.Name = "CB_PName";
            this.CB_PName.Size = new System.Drawing.Size(314, 25);
            this.CB_PName.TabIndex = 24;
            this.CB_PName.TextChanged += new System.EventHandler(this.CB_PName_TextChanged);
            this.CB_PName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CB_PName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Добавить количество";
            // 
            // TB_Mtime
            // 
            this.TB_Mtime.Location = new System.Drawing.Point(640, 87);
            this.TB_Mtime.Name = "TB_Mtime";
            this.TB_Mtime.ReadOnly = true;
            this.TB_Mtime.Size = new System.Drawing.Size(124, 23);
            this.TB_Mtime.TabIndex = 26;
            this.TB_Mtime.TextChanged += new System.EventHandler(this.TB_Mtime_TextChanged);
            this.TB_Mtime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Mtime_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(260, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Количество";
            this.label3.Visible = false;
            // 
            // TB_Quan
            // 
            this.TB_Quan.Location = new System.Drawing.Point(345, 124);
            this.TB_Quan.Name = "TB_Quan";
            this.TB_Quan.Size = new System.Drawing.Size(142, 23);
            this.TB_Quan.TabIndex = 28;
            this.TB_Quan.Visible = false;
            this.TB_Quan.TextChanged += new System.EventHandler(this.TB_Quan_TextChanged);
            this.TB_Quan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Quan_KeyPress);
            // 
            // TB_ATime
            // 
            this.TB_ATime.Location = new System.Drawing.Point(639, 124);
            this.TB_ATime.Name = "TB_ATime";
            this.TB_ATime.ReadOnly = true;
            this.TB_ATime.Size = new System.Drawing.Size(124, 23);
            this.TB_ATime.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Итоговое количество";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(173, 124);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(314, 23);
            this.dateTimePicker1.TabIndex = 31;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(131, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 32;
            this.label5.Text = "Дата";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "Примечание*";
            // 
            // TB_Other
            // 
            this.TB_Other.Location = new System.Drawing.Point(104, 153);
            this.TB_Other.Multiline = true;
            this.TB_Other.Name = "TB_Other";
            this.TB_Other.Size = new System.Drawing.Size(660, 100);
            this.TB_Other.TabIndex = 34;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.Location = new System.Drawing.Point(641, 259);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(123, 23);
            this.AddButton.TabIndex = 35;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // TB_PName
            // 
            this.TB_PName.Location = new System.Drawing.Point(173, 87);
            this.TB_PName.Name = "TB_PName";
            this.TB_PName.ReadOnly = true;
            this.TB_PName.Size = new System.Drawing.Size(314, 23);
            this.TB_PName.TabIndex = 36;
            this.TB_PName.Visible = false;
            // 
            // TB_Date
            // 
            this.TB_Date.Location = new System.Drawing.Point(173, 124);
            this.TB_Date.Name = "TB_Date";
            this.TB_Date.ReadOnly = true;
            this.TB_Date.Size = new System.Drawing.Size(314, 23);
            this.TB_Date.TabIndex = 37;
            this.TB_Date.Visible = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 294);
            this.Controls.Add(this.TB_Date);
            this.Controls.Add(this.TB_PName);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.TB_Other);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.TB_ATime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Quan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_Mtime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CB_PName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.homebutton);
            this.Controls.Add(this.buttonroll);
            this.Controls.Add(this.buttonfullscreen);
            this.Controls.Add(this.buttonclose);
            this.Controls.Add(this.TB_Num);
            this.Controls.Add(this.label_num);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form4";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox TB_Num;
        private System.Windows.Forms.Label label_num;
        private System.Windows.Forms.Button homebutton;
        private System.Windows.Forms.Button buttonroll;
        private System.Windows.Forms.Button buttonfullscreen;
        private System.Windows.Forms.Button buttonclose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_PName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Mtime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Quan;
        private System.Windows.Forms.TextBox TB_ATime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_Other;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox TB_PName;
        private System.Windows.Forms.TextBox TB_Date;
    }
}