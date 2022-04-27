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

namespace WindowsFormsApp5
{
    public partial class AddForm : Form
    {
        string usefile;
        byte b;
        int maxcount = 0;
        string holderfile;
        string cuttinginsertfile;
        string productnamefile;
        string reportfile;
        string productname;

        string folderpathmain = @"Storage";
        string folderpathglobaldata = @"\GlobalData";

        bool datastatus = true; 

        bool editmode = false;

        string editdata = "";

        Color color1 = ColorTranslator.FromHtml("#7CAA2D");
        Color colorf = Color.Black;
        Color color2;
        Color colorf1;
        bool lightstyle = false;

        string ffile;

        // <-------------------------------------------------------------------------------------------------------------->





        MainForm MainForm = new MainForm();

        private void maxcountcheck() // Процедура проверки максимального числа в строке Номер
        {
            StreamReader sr = new StreamReader(usefile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                int colnum = Convert.ToInt32(col[0].TrimStart("hi ".ToCharArray()));
                if (colnum > maxcount) maxcount = colnum;
            }
            sr.Close();
        }

        private void numcoincidencecheck() // Процедура проверки совпадения номера с числами 
        {
            StreamReader sr = new StreamReader(usefile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                int colnum = Convert.ToInt32(col[0]);
                if (colnum == Convert.ToInt32(textbox_num.Text))
                {
                    MessageBox.Show(
                    $"Номер не может совпадать. Номер {textbox_num.Text} уже использовался.",
                    "Внимание!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                    //MessageBoxOptions.DefaultDesktopOnly);
                    sr.Close();
                    return;
                }
            }
                    MessageBox.Show(
                    $"Номер {textbox_num.Text} ранее не использовался",
                    "Внимание!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            //MessageBoxOptions.DefaultDesktopOnly);
            sr.Close();
            return;
        }

        private bool emptytextboxcheck() // Функция проверки полей на заполненность
        {
            if (b == 3)
            {
                if (textbox_manufacturer.Text == "" || textbox_num.Text == "" || textbox_name.Text == "")
                {
                    MessageBox.Show(
                         "Все поля должны быть заполнены!",
                         "Ошибка",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error,
                         MessageBoxDefaultButton.Button1);
                    //MessageBoxOptions.DefaultDesktopOnly);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (textbox_manufacturer.Text == "" || textbox_num.Text == "" || textbox_name.Text == "" || textbox_qua.Text == "")
                {
                    MessageBox.Show(
                         "Все поля должны быть заполнены!",
                         "Ошибка",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error,
                         MessageBoxDefaultButton.Button1);
                    //MessageBoxOptions.DefaultDesktopOnly);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void productnamereplace(string name, string newname)
        {
            if (filescheck(reportfile))
            {
                string text = File.ReadAllText(reportfile);
                text = text.Replace(name, newname);
                File.WriteAllText(reportfile, text);
            }
        }

        private bool filescheck(string filename) // Функция проверки наличия файлов
        {
            FileInfo fileInf = new FileInfo(filename);
            if (fileInf.Exists)
            {
                return true;
            }
            else // Если файла не существует, то выводится сообщение с ошибкой
            {
                if (b == 1) filename = "holder.txt";
                if (b == 2) filename = "cuttinginsert.txt";
                if (b == 3) filename = "product.txt";
                fileInf = new FileInfo(filename);
                DialogResult result = MessageBox.Show(
                $"Файла {filename} не существует. Создать новый?",
                "Ошибка",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                //MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    FileStream fs = fileInf.Create();
                    fs.Close();
                }
                if (result == DialogResult.No)
                {
                    this.Close();
                }
                return false;
            }
        }

        private bool nmcoincidencecheck(string filename, bool a) // Функция проверки совпданий в полях Наименование и Производитель
        {
            if (filescheck(filename))
            {
                StreamReader sr = new StreamReader(usefile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    if (b == 3)
                    {
                        if (col[1] == textbox_name.Text && col[2] == textbox_manufacturer.Text)
                        {
                            MessageBox.Show(
                            $"Эти данные уже имеются в базе",
                            "Внимание!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                            //MessageBoxOptions.DefaultDesktopOnly);
                            sr.Close();
                            return false;
                        }
                        else if(col[1] == textbox_name.Text)
                        {
                            MessageBox.Show(
                            $"Это изделие уже есть в базе",
                            "Внимание!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                            //MessageBoxOptions.DefaultDesktopOnly);
                            sr.Close();
                            return false;
                        }
                    }
                    else
                    {
                        if (col[1] == textbox_name.Text && col[2] == textbox_manufacturer.Text && col[4] == textbox_qua.Text && col[5] == textbox_other.Text)
                        {
                            MessageBox.Show(
                            $"Эти данные уже имеются в базе",
                            "Внимание!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                            //MessageBoxOptions.DefaultDesktopOnly);
                            sr.Close();
                            return false;
                        }
                    }
                }
                sr.Close();
                if (!editmode)
                {
                    StreamReader sr1 = new StreamReader(usefile);
                    while (!sr1.EndOfStream)
                    {
                        string line = sr1.ReadLine();
                        string[] col = line.Split("|".ToCharArray());
                        if (b != 3)
                        {
                            if (col[1] == textbox_name.Text)
                            {
                                DialogResult result = MessageBox.Show(
                                $"Наименование {textbox_name.Text} совпадает с уже имеющимся в базе. Продолжить?",
                                "Внимание!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                                //MessageBoxOptions.DefaultDesktopOnly);
                                sr1.Close();
                                if (result == DialogResult.Yes)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            if (col[1] == textbox_name.Text)
                            {
                                MessageBox.Show(
                                $"Наименование {textbox_name.Text} совпадает с уже имеющимся в базе!",
                                "Внимание!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                                //MessageBoxOptions.DefaultDesktopOnly);
                                sr1.Close();
                                return false;
                            }
                        }
                    }
                    sr1.Close();
                }
            }
            if (a) MessageBox.Show(
                             $"Совпадений нет",
                             "Внимание!",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information,
                             MessageBoxDefaultButton.Button1);;
            
            return true;
        }


        private void colorstyle() // Процедура подключение стилей цвета
        {
            for (int i = 0; i < toolStrip1.Items.Count; i++)
            {
                toolStrip1.Items[i].ForeColor = colorf;
            }

            if (!lightstyle)
            {
                buttonfullscreen.BackgroundImage = Properties.Resources.expandl;
                buttonroll.BackgroundImage = Properties.Resources.minusi;
                homebutton.BackgroundImage = Properties.Resources.studyi;

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
                homebutton.BackgroundImage = Properties.Resources.study;

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

        private void productfolder(string prodname, string prodname2) // Процедура создания папки для каждого изделия
        {
            if (prodname != prodname2)
            {
                string folderpathproductdata = @"\ProductData";

                prodname = prodname.Replace("~", "_");
                prodname = prodname.Replace("#", "_");
                prodname = prodname.Replace("%", "_");
                prodname = prodname.Replace("&", "_");
                prodname = prodname.Replace("*", "_");
                prodname = prodname.Replace("{", "_");
                prodname = prodname.Replace("}", "_");
                prodname = prodname.Replace("|", "_");
                prodname = prodname.Replace(@"\", "_");
                prodname = prodname.Replace("/", "_");
                prodname = prodname.Replace(">", "_");
                prodname = prodname.Replace("<", "_");
                prodname = prodname.Replace("?", "_");
                prodname = prodname.Replace("+", "_");
                prodname = prodname.Replace("\"", "_");


                prodname2 = prodname2.Replace("~", "_");
                prodname2 = prodname2.Replace("#", "_");
                prodname2 = prodname2.Replace("%", "_");
                prodname2 = prodname2.Replace("&", "_");
                prodname2 = prodname2.Replace("*", "_");
                prodname2 = prodname2.Replace("{", "_");
                prodname2 = prodname2.Replace("}", "_");
                prodname2 = prodname2.Replace("|", "_");
                prodname2 = prodname2.Replace(@"\", "_");
                prodname2 = prodname2.Replace("/", "_");
                prodname2 = prodname2.Replace(">", "_");
                prodname2 = prodname2.Replace("<", "_");
                prodname2 = prodname2.Replace("?", "_");
                prodname2 = prodname2.Replace("+", "_");
                prodname2 = prodname2.Replace("\"", "_");

                string file = folderpathmain + folderpathproductdata + @"\" + prodname;
                string file1 = folderpathmain + folderpathproductdata + @"\" + prodname2;
                DirectoryInfo f = new DirectoryInfo(file1);
                if (!f.Exists)
                {
                    Directory.Move(file, file1);
                }
            }
        }

        // <-------------------------------------------------------------------------------------------------------------->





        public AddForm(byte a, string Fname, string toolStripName, string data, bool lightcolor, Color tcolor, Color fcolor, Color tcolor1, Color fcolor2)
        {
            InitializeComponent();
            toolStripButton1.Visible = false;

            

            holderfile = "holder.txt";
            cuttinginsertfile = "cuttinginsert.txt";
            productnamefile = "product.txt";
            reportfile = "report.txt";
            holderfile = folderpathmain + folderpathglobaldata + "/" + holderfile;
            cuttinginsertfile = folderpathmain + folderpathglobaldata + "/" + cuttinginsertfile;
            productnamefile = folderpathmain + folderpathglobaldata + "/" + productnamefile;
            reportfile = folderpathmain + folderpathglobaldata + "/" + reportfile;

            //toolStrip1.BackColor = Color.White;
            color1 = tcolor;
            colorf = fcolor;
            color2 = tcolor1;
            colorf1 = fcolor2;
            lightstyle = lightcolor;

            colorstyle();


            b = a;
            toolStripLabel2.Text = Fname;
            this.Text = Fname;
            toolStripLabel1.Text = toolStripName;
            if(a == 1) usefile = holderfile;
            else if (a == 2) usefile = cuttinginsertfile;
            else if (a == 3)
            {
                usefile = productnamefile;
                label_manufacturer.Text = "Машинное время";
                toolStripButton2.Text = "Проверить поле \"Наименвоание\" на совпадение";
                textbox_qua.Visible = false;
                label_qua.Visible = false;
                textbox_other.Visible = false;
                label_other.Visible = false;
                this.Width = 425;
                this.Height = 187;
                groupBox1.Width = 415;
                groupBox1.Height = 128;
                textbox_name.Width = 285;
                textbox_name.Height = 23;
                textbox_manufacturer.Width = 285;
                textbox_manufacturer.Height = 23;
                AddButton.Location = new Point(285, 99);
            }

            if (filescheck(usefile))
            {
                maxcountcheck();
                if(data == "") textbox_num.Text = Convert.ToString(maxcount + 1);
            }

            if(data != "")
            {
                string[] col1 = data.Split("|".ToCharArray());
                editdata = data.Replace(col1[0]+"|" + col1[1],$"{col1[1]}");
                if (col1.Length > 5) editdata = editdata.Replace($"|{col1[5]}|{col1[6]}", $"|{col1[5]}");
                editmode = true;
                string[] col = data.Split("|".ToCharArray());
                textbox_num.Text = col[0];
                if (b != 3)
                {
                    StreamReader sr3 = new StreamReader(usefile);
                    while (!sr3.EndOfStream)
                    {
                        string line3 = sr3.ReadLine();
                        string[] col3 = line3.Split("|".ToCharArray());
                        line3 = $"{col[0]}|{col3[1]}|{col3[2]}|{col3[3]}|{col3[4]}|{col3[5]}";
                        if (data == line3)
                        {
                            textbox_num.Text = col3[0];
                        }
                    }
                    sr3.Close();
                }
                else
                {
                    productname = col1[1];
                    StreamReader sr3 = new StreamReader(usefile);
                    while (!sr3.EndOfStream)
                    {
                        string line3 = sr3.ReadLine();
                        string[] col3 = line3.Split("|".ToCharArray());
                        line3 = $"{col[0]}|{col3[1]}|{col3[2]}|{col3[3]}";
                        if (data == line3)
                        {
                            textbox_num.Text = col3[0];
                        }
                    }
                    sr3.Close();
                }
                textbox_name.Text = col[1];
                textbox_qua.ReadOnly = true;
                ffile = col[1];
                textbox_manufacturer.Text = col[2];
                if (col[3] == "True") datastatus = true;
                else datastatus = false;

                if(b!=3)
                {
                    textbox_qua.Text = col[4];
                    textbox_other.Text = col[5];
                }

                if (datastatus)
                {
                    AddButton.Text = "Редактировать";
                    toolStripButton2.Visible = false;
                    toolStripButton1.Visible = true;
                    if (!lightstyle) toolStripButton1.Image = Properties.Resources.trashl;
                    else toolStripButton1.Image = Properties.Resources.trash;
                    toolStripButton1.Text = "Удалить данные";
                }
                else
                {

                    AddButton.Text = "Редактировать";
                    if (b != 3) toolStripLabel2.Text = toolStripLabel2 + " удаленную";
                    else toolStripLabel2.Text = toolStripLabel2 + " удаленное";
                    toolStripButton2.Visible = false;
                    toolStripButton1.Visible = true;
                    if (!lightstyle) toolStripButton1.Image = Properties.Resources.trashl;
                    else toolStripButton1.Image = Properties.Resources.trash;
                    toolStripButton1.Text = "Вернуть данные в базу";
                }
            }
        }


        private void AddForm_Load(object sender, EventArgs e)  // Событие при загрузке формы добавления
        {

        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e) // Событие при нажатии на кнопку Добавить
        {
            if (filescheck(usefile))
            {
                if (editmode)
                {
                    if (emptytextboxcheck() && nmcoincidencecheck(usefile, false))
                    {
                        string newdata = "";
                        string o = textbox_name.Text.TrimStart(' ');
                        o = o.TrimEnd(' ');
                        if (b == 3)
                        {
                            newdata = o + "|" + textbox_manufacturer.Text + "|" + datastatus;
                            productfolder(ffile, textbox_name.Text);
                            productnamereplace(productname, textbox_name.Text);
                        }
                        else
                        {
                            newdata = o + "|" + textbox_manufacturer.Text + "|" + datastatus + "|" + textbox_qua.Text + "|" + textbox_other.Text;
                        }
                        string text = File.ReadAllText(usefile);
                        text = text.Replace(editdata, newdata);
                        File.WriteAllText(usefile, text);


                        Properties.Settings.Default.refresh = true;
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                }
                else
                {
                    if (emptytextboxcheck() && nmcoincidencecheck(usefile, false))
                    {
                        //StreamReader sr = new StreamReader(usefile); // Проверка на совпадение номера с ранее добавленными номерами в базу
                        //while (!sr.EndOfStream)
                        //{
                        //    string line = sr.ReadLine();
                        //    string[] col = line.Split("|".ToCharArray());
                        //    if (textbox_num.Text == col[0])
                        //    {
                        //        MessageBox.Show(
                        //        $"Номер не может совпадать. Номер {textbox_num.Text} уже используется. Последний номер был {maxcount}",
                        //        "Внимание!",
                        //        MessageBoxButtons.OK,
                        //        MessageBoxIcon.Warning,
                        //        MessageBoxDefaultButton.Button1);
                        //        //MessageBoxOptions.DefaultDesktopOnly);
                        //        sr.Close();
                        //        return;
                        //    }
                        //}
                        //sr.Close();

                        StreamWriter streamWriter = new StreamWriter(usefile, true);

                        string o = textbox_name.Text.TrimStart(' ');
                        o = o.TrimEnd(' ');
                        if (b == 3)
                        {
                            streamWriter.WriteLine(textbox_num.Text + "|" + o + "|" + textbox_manufacturer.Text + "|" + datastatus);
                        }
                        else
                        {
                            if (b == 1) textbox_num.Text = "h " + textbox_num.Text;
                            if (b == 2) textbox_num.Text = "i " + textbox_num.Text;
                            streamWriter.WriteLine(textbox_num.Text + "|" + o + "|" + textbox_manufacturer.Text + "|" + datastatus + "|" + textbox_qua.Text + "|" + textbox_other.Text + "|" + textbox_qua.Text);
                        }
                        streamWriter.Close();

                        Properties.Settings.Default.refresh = true;
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                }
            }
            else
            {
                if (filescheck(usefile) == true)
                {
                    MessageBox.Show(
                    $"Файл {usefile} создан, повторите попытку.",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                    //MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (editmode)
            {
                if (datastatus)
                {
                    DialogResult result = MessageBox.Show(
                                $"Вы пытаетесь удалить данные. Продолжить?",
                                "Внимание!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);
                    //MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.Yes)
                    {
                        string data = editdata;
                        //string[] col = data.Split("|".ToCharArray());
                        //col[3] = "false";
                        //string newdata = "";
                        //for (int n = 0; n < col.Length; n++)
                        //{
                        //    newdata = newdata + col[n];
                        //}
                        string newdata = data.Replace("True", "False");
                        string text = File.ReadAllText(usefile);
                        text = text.Replace(data, newdata);
                        File.WriteAllText(usefile, text);
                        Properties.Settings.Default.refresh = true;
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                                $"Вы пытаетесь вернуть удаленные данные. Продолжить?",
                                "Внимание!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button2);
                    //MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.Yes)
                    {
                        string data = editdata;
                        //string[] col = data.Split("|".ToCharArray());
                        //col[3] = "false";
                        //string newdata = "";
                        //for (int n = 0; n < col.Length; n++)
                        //{
                        //    newdata = newdata + col[n];
                        //}
                        string newdata = data.Replace("False", "True");
                        string text = File.ReadAllText(usefile);
                        text = text.Replace(data, newdata);
                        File.WriteAllText(usefile, text);
                        Properties.Settings.Default.refresh = true;
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                }
            }
            else
            {
                numcoincidencecheck();
            }
        }

        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            nmcoincidencecheck(usefile,true);
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

        private void Buttonroll_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ToolStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void Textbox_manufacturer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (b == 3)
            {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
            }
        }

        private void Textbox_qua_KeyPress(object sender, KeyPressEventArgs e)
        {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
        }
    }
}
