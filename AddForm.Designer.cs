namespace WindowsFormsApp5
{
    partial class AddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            this.textbox_num = new System.Windows.Forms.TextBox();
            this.label_num = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.textbox_name = new System.Windows.Forms.TextBox();
            this.label_manufacturer = new System.Windows.Forms.Label();
            this.textbox_manufacturer = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.AddButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.homebutton = new System.Windows.Forms.Button();
            this.buttonroll = new System.Windows.Forms.Button();
            this.buttonfullscreen = new System.Windows.Forms.Button();
            this.buttonclose = new System.Windows.Forms.Button();
            this.textbox_other = new System.Windows.Forms.TextBox();
            this.textbox_qua = new System.Windows.Forms.TextBox();
            this.label_qua = new System.Windows.Forms.Label();
            this.label_other = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textbox_num
            // 
            this.textbox_num.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textbox_num.Location = new System.Drawing.Point(123, 18);
            this.textbox_num.MaxLength = 250;
            this.textbox_num.Name = "textbox_num";
            this.textbox_num.ReadOnly = true;
            this.textbox_num.Size = new System.Drawing.Size(133, 23);
            this.textbox_num.TabIndex = 0;
            // 
            // label_num
            // 
            this.label_num.AutoSize = true;
            this.label_num.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_num.Location = new System.Drawing.Point(57, 21);
            this.label_num.Name = "label_num";
            this.label_num.Size = new System.Drawing.Size(49, 17);
            this.label_num.TabIndex = 1;
            this.label_num.Text = "Номер";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.Location = new System.Drawing.Point(8, 48);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(101, 17);
            this.label_name.TabIndex = 3;
            this.label_name.Text = "Наименование";
            // 
            // textbox_name
            // 
            this.textbox_name.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textbox_name.Location = new System.Drawing.Point(123, 45);
            this.textbox_name.MaxLength = 100;
            this.textbox_name.Name = "textbox_name";
            this.textbox_name.Size = new System.Drawing.Size(341, 23);
            this.textbox_name.TabIndex = 2;
            // 
            // label_manufacturer
            // 
            this.label_manufacturer.AutoSize = true;
            this.label_manufacturer.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_manufacturer.Location = new System.Drawing.Point(4, 75);
            this.label_manufacturer.Name = "label_manufacturer";
            this.label_manufacturer.Size = new System.Drawing.Size(103, 17);
            this.label_manufacturer.TabIndex = 5;
            this.label_manufacturer.Text = "Производитель";
            // 
            // textbox_manufacturer
            // 
            this.textbox_manufacturer.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textbox_manufacturer.Location = new System.Drawing.Point(123, 72);
            this.textbox_manufacturer.MaxLength = 100;
            this.textbox_manufacturer.Name = "textbox_manufacturer";
            this.textbox_manufacturer.Size = new System.Drawing.Size(341, 23);
            this.textbox_manufacturer.TabIndex = 4;
            this.textbox_manufacturer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_manufacturer_KeyPress);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripLabel1,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 28, 0, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(485, 51);
            this.toolStrip1.TabIndex = 6;
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
            this.toolStripButton1.Image = global::WindowsFormsApp5.Properties.Resources.eye;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton1.Text = "Проверить номер на совпадение";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::WindowsFormsApp5.Properties.Resources.eye;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton2.Text = "Проверить поля \"Наименвоание\" и \"Производитель\" на совпадение";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.Location = new System.Drawing.Point(341, 207);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(123, 23);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textbox_other);
            this.groupBox1.Controls.Add(this.textbox_qua);
            this.groupBox1.Controls.Add(this.label_qua);
            this.groupBox1.Controls.Add(this.label_other);
            this.groupBox1.Controls.Add(this.textbox_manufacturer);
            this.groupBox1.Controls.Add(this.textbox_num);
            this.groupBox1.Controls.Add(this.label_num);
            this.groupBox1.Controls.Add(this.textbox_name);
            this.groupBox1.Controls.Add(this.label_name);
            this.groupBox1.Controls.Add(this.AddButton);
            this.groupBox1.Controls.Add(this.label_manufacturer);
            this.groupBox1.Location = new System.Drawing.Point(5, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 238);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
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
            this.homebutton.TabIndex = 11;
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
            this.buttonroll.Location = new System.Drawing.Point(432, 5);
            this.buttonroll.Name = "buttonroll";
            this.buttonroll.Size = new System.Drawing.Size(21, 21);
            this.buttonroll.TabIndex = 10;
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
            this.buttonfullscreen.Location = new System.Drawing.Point(405, 5);
            this.buttonfullscreen.Name = "buttonfullscreen";
            this.buttonfullscreen.Size = new System.Drawing.Size(21, 21);
            this.buttonfullscreen.TabIndex = 9;
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
            this.buttonclose.Location = new System.Drawing.Point(459, 5);
            this.buttonclose.Name = "buttonclose";
            this.buttonclose.Size = new System.Drawing.Size(21, 21);
            this.buttonclose.TabIndex = 8;
            this.buttonclose.UseVisualStyleBackColor = false;
            this.buttonclose.Click += new System.EventHandler(this.Buttonclose_Click);
            // 
            // textbox_other
            // 
            this.textbox_other.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textbox_other.Location = new System.Drawing.Point(123, 101);
            this.textbox_other.MaxLength = 100;
            this.textbox_other.Multiline = true;
            this.textbox_other.Name = "textbox_other";
            this.textbox_other.Size = new System.Drawing.Size(341, 100);
            this.textbox_other.TabIndex = 10;
            // 
            // textbox_qua
            // 
            this.textbox_qua.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textbox_qua.Location = new System.Drawing.Point(347, 18);
            this.textbox_qua.MaxLength = 100;
            this.textbox_qua.Name = "textbox_qua";
            this.textbox_qua.Size = new System.Drawing.Size(117, 23);
            this.textbox_qua.TabIndex = 8;
            this.textbox_qua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Textbox_qua_KeyPress);
            // 
            // label_qua
            // 
            this.label_qua.AutoSize = true;
            this.label_qua.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_qua.Location = new System.Drawing.Point(262, 21);
            this.label_qua.Name = "label_qua";
            this.label_qua.Size = new System.Drawing.Size(79, 17);
            this.label_qua.TabIndex = 9;
            this.label_qua.Text = "Количество";
            // 
            // label_other
            // 
            this.label_other.AutoSize = true;
            this.label_other.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_other.Location = new System.Drawing.Point(18, 104);
            this.label_other.Name = "label_other";
            this.label_other.Size = new System.Drawing.Size(91, 17);
            this.label_other.TabIndex = 11;
            this.label_other.Text = "Примечание*";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(485, 296);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.homebutton);
            this.Controls.Add(this.buttonroll);
            this.Controls.Add(this.buttonfullscreen);
            this.Controls.Add(this.buttonclose);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddForm_FormClosed);
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_num;
        private System.Windows.Forms.Label label_num;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.TextBox textbox_name;
        private System.Windows.Forms.Label label_manufacturer;
        private System.Windows.Forms.TextBox textbox_manufacturer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Button buttonroll;
        private System.Windows.Forms.Button buttonfullscreen;
        private System.Windows.Forms.Button buttonclose;
        private System.Windows.Forms.Button homebutton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.TextBox textbox_other;
        private System.Windows.Forms.TextBox textbox_qua;
        private System.Windows.Forms.Label label_qua;
        private System.Windows.Forms.Label label_other;
    }
}