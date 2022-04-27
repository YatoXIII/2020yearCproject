using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp5
{
    public partial class fileloadform : Form
    {
        string fileway = "";
        string filenam = "";
        //string file = "";
        string fext = "";

        Color color1;
        Color colorf;
        Color color2;
        Color colorf1;
        bool stylemode;

        private void colorstyle() // Процедура подключение стилей цвета
        {
            if (!stylemode)
            {
                buttonfullscreen.BackgroundImage = Properties.Resources.expandl;
                buttonroll.BackgroundImage = Properties.Resources.minusi;
                homebutton.BackgroundImage = Properties.Resources.down_arrowl;
                button3.BackgroundImage = Properties.Resources.folderl;

                toolStrip1.BackColor = color1;

                buttonfullscreen.BackColor = toolStrip1.BackColor;
                buttonroll.BackColor = toolStrip1.BackColor;
                buttonclose.BackColor = toolStrip1.BackColor;
                homebutton.BackColor = toolStrip1.BackColor;

                for (int i = 0; i < toolStrip1.Items.Count; i++)
                {
                    toolStrip1.Items[i].ForeColor = colorf;
                }
            }
            else
            {
                buttonfullscreen.BackgroundImage = Properties.Resources.expand;
                buttonroll.BackgroundImage = Properties.Resources.minus;
                homebutton.BackgroundImage = Properties.Resources.down_arrow;
                button3.BackgroundImage = Properties.Resources.folder;

                toolStrip1.BackColor = color2;

                buttonfullscreen.BackColor = toolStrip1.BackColor;
                buttonroll.BackColor = toolStrip1.BackColor;
                buttonclose.BackColor = toolStrip1.BackColor;
                homebutton.BackColor = toolStrip1.BackColor;

                for (int i = 0; i < toolStrip1.Items.Count; i++)
                {
                    toolStrip1.Items[i].ForeColor = colorf1;
                }
            }
        }



        // <-------------------------------------------------------------------------------------------------------------->
        //
        // <--------------------------------------------------------------------------------------------------------------> 



        public fileloadform(string fw, bool lightcolor, Color tcolor, Color fcolor, Color tcolor2, Color fcolor2)
        {
            InitializeComponent();

            fileway = fw;

            color1 = tcolor;
            colorf = fcolor;
            color2 = tcolor2;
            colorf1 = fcolor2;
            stylemode = lightcolor;
            colorstyle();
        }

        

        private void Fileloadform_DragOver(object sender, DragEventArgs e) // Событие когда перетаскиываемый файл попадает в область формы
        {
            textBox2.BackColor = Color.Silver;
            label3.BackColor = textBox2.BackColor;
        }

        private void Fileloadform_DragLeave(object sender, EventArgs e) // Событие когда перетаскиываемый файл пропадает из области
        {
            textBox2.BackColor = Color.White;
            label3.BackColor = textBox2.BackColor;
        }

        private void Fileloadform_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void Fileloadform_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {

        }

        private void TextBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))

                e.Effect = DragDropEffects.Move;
                textBox2.BackColor = Color.Gray;
            label3.Visible = false;
        }

        private void TextBox2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                textBox1.Text = null;
                textBox1.Text += objects[0];
                if(objects.Length >= 2)
                {
                    MessageBox.Show(
                        $"Загружать файлы можно только по одному. Файл {objects[0]} добавен в очередь на загрузка.",
                        "Внимание",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                }


                filenam = System.IO.Path.GetFileNameWithoutExtension(textBox1.Text);
                fext = Path.GetExtension(textBox1.Text);
                label3.Visible = true;
                textBox2.BackColor = Color.White;
                label3.BackColor = textBox2.BackColor;
            }
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //if(textBox1.Text == )
                FileInfo fileInf = new FileInfo(textBox1.Text);
                if (fileInf.Exists)
                {

                    FileInfo fileInf1 = new FileInfo(fileway + @"\" + filenam + fext);
                    if (!fileInf1.Exists)
                    {
                        string copyfile = textBox1.Text;
                        File.Copy(copyfile, fileway + @"\" + filenam + fext, true);
                        MessageBox.Show(
                        $"Файл {filenam} скопирован!",
                        "Внимание",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                        Properties.Settings.Default.fileadd = true;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show(
                        $"Файл с названием {filenam} уже существует в данных изделия! Открыть папку файлов изделия?",
                        "Внимание",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            Process PrFolder = new Process();
                            ProcessStartInfo psi = new ProcessStartInfo();
                            string n = fileway + @"\" + filenam + fext;
                            psi.CreateNoWindow = true;
                            psi.WindowStyle = ProcessWindowStyle.Normal;
                            psi.FileName = "explorer";
                            psi.Arguments = @"/n, /select, " + n;
                            PrFolder.StartInfo = psi;
                            PrFolder.Start();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                        $"Файл по ссылке {textBox1.Text} не существует. Укажите правильную ссылку на файл!",
                        "Внимание!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show(
                $"Ссылка на файл не может быть пустой строкой",
                "Внимание!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            }
        }

        private void Buttonclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Buttonfullscreen_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                buttonfullscreen.BackgroundImage = Properties.Resources.expand;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                buttonfullscreen.BackgroundImage = Properties.Resources.minimize;
            }
        }

        private void ToolStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void Buttonroll_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All files(*.*)|*.*";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            openFileDialog1.FileName = null;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                textBox1.Text = null;
                textBox1.Text = filename;
                filenam = System.IO.Path.GetFileNameWithoutExtension(filename);
                fext = Path.GetExtension(filename);
            }
            return;
        }
    }
}
