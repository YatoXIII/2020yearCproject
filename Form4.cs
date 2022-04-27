using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace WindowsFormsApp5
{
    public partial class Form4 : Form
    {
        int maxcount = 0;
        int count = 0;
        double cor;

        string folderpathmain = @"Storage";
        string folderpathglobaldata = @"\GlobalData";

        bool editmode = false;
        bool datastatus = true;
        bool smode = false;
        bool ff = false;

        string editdata = "";

        DateTime dddate;

        string productnamefile = "product.txt";
        string reportfile = "report.txt";
        string holderfile = "holder.txt";
        string storagefile = "storage.txt";
        string cuttinginsertfile = "cuttinginsert.txt";
        string nda = "";
        int dc = 0;

        string[] ra = new string[3];

        Color color1 = ColorTranslator.FromHtml("#7CAA2D");
        Color colorf = Color.Black;
        Color color2;
        Color colorf1;
        bool lightstyle = false;

        string ffile;

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

        private string idfinder(bool mode, string filename, string name, string manu)
        {
            if (mode)
            {
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    if (col[1] == name && col[2] == manu)
                    {
                        sr.Close();
                        return col[0];
                    }
                }
                sr.Close();
                return "";
            }
            else
            {
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    if (col[0] == name)
                    {
                        sr.Close();
                        return col[1] + "|" + col[2];
                    }
                }
                sr.Close();
                return "";
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

        private void maxcountcheck(string filename) // Процедура проверки максимального числа в строке Номер
        {
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                int colnum = Convert.ToInt32(col[0]);
                if (colnum > maxcount) maxcount = colnum;
            }
            sr.Close();
        }


        //private void tbatimevalue(string filename)
        //{
        //    StreamReader sr = new StreamReader(filename);
        //    while (!sr.EndOfStream)
        //    {
        //        string line1 = sr.ReadLine();
        //        string[] col1 = line1.Split("|".ToCharArray());
        //        string[] CBPName = CB_PName.Text.Split("|".ToCharArray());
        //        if (CBPName[0] == col1[1])
        //        {
        //            cor = Convert.ToInt32(col1[4]);
        //            if (TB_Mtime.Text != "")
        //            {
        //                TB_ATime.Text = Convert.ToString(cor + Convert.ToDouble(TB_Mtime.Text));
        //            }
        //            else
        //            {
        //                TB_ATime.Text = Convert.ToString(cor);
        //            }
        //        }
        //    }
        //    sr.Close();
        //}

        private int datecount(string filename, int cd)
        {
            int l = 0;
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                string[] dated = col[cd].Split("^".ToCharArray());
                if (dated[0] == dateTimePicker1.Value.ToString("dd MMMM yyyy"))
                {
                    l++;
                }
            }
            sr.Close();
            return l;
        }

        private void coutvalue(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                string line1 = sr.ReadLine();
                string[] col1 = line1.Split("|".ToCharArray());
                string[] CBPName = CB_PName.Text.Split("|".ToCharArray());
                if (CBPName[0] == col1[1])
                {
                    cor = Convert.ToDouble(col1[6]);
                    //sr.Close();

                    //sr = new StreamReader(storagefile);
                    //while (!sr.EndOfStream)
                    //{
                    //    string line2 = sr.ReadLine();
                    //    string[] col2 = line2.Split("|".ToCharArray());
                    //    col2[1] = idfinder(false, filename, col2[1], "");
                    //    string[] dated1 = col2[4].Split("^".ToCharArray());
                    //    if (col2[1] == CB_PName.Text && Convert.ToDateTime(dated1[0]) <= dateTimePicker1.Value)
                    //    {
                    //        cor = cor + Convert.ToInt32(col2[2]);
                    //    }
                    //}


                    if (TB_Mtime.Text != "" && TB_Mtime.Text != "-" && TB_Mtime.Text.Substring(TB_Mtime.Text.Length - 1) != ",")
                    {
                        TB_ATime.Text = Convert.ToString(cor + Convert.ToDouble(TB_Mtime.Text));
                    }
                    else
                    {
                        TB_ATime.Text = Convert.ToString(cor);
                    }
                    break;
                }
            }
            sr.Close();
        }

        private void refresh_combobox()
        {
            if (smode)
            {
                int i = 2; //6
                int i1 = 0;
                int i2 = 0;
                StreamReader sr = new StreamReader(holderfile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    if (col[3] == "True")
                    {
                        i++;
                        i1++;
                    }
                }
                sr.Close();
                sr = new StreamReader(cuttinginsertfile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    if (col[3] == "True")
                    {
                        i++;
                        i2++;
                    }
                }
                sr.Close();
                CB_PName.Items.Clear();
                string[] str = new string[i];
                string[] str1 = new string[i1];
                string[] str2 = new string[i2];

                ra[0] = "          ";
                ra[1] = $"                    [{i2}]ПЛАСТИНЫ: ";
                ra[2] = $"                    [{i1}]ДЕРЖАВКИ: ";

                i = 0;
                //str[0] = "";
                //str[i] = ra[0]; i++;
                str[i] = ra[2]; i++;
                //str[i] = ra[0]; i++;
                i1 = 0;
                sr = new StreamReader(holderfile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    if (col[3] == "True")
                    {
                        str1[i1] = col[1] + "|" + col[2];
                        i1++;
                    }
                }
                sr.Close();
                IEnumerable<string> query = from word in str1
                                            orderby word.Substring(0, 1) ascending
                                            select word;
                foreach (string st in query)
                {
                    str[i] = st;
                    i++;
                }
                //str[i] = ra[0]; i++;
                str[i] = ra[1]; i++;
                //str[i] = ra[0]; i++;
                i2 = 0;
                count = i;
                sr = new StreamReader(cuttinginsertfile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    if (col[3] == "True")
                    {
                        str2[i2] = col[1] + "|" + col[2];
                        i2++;
                    }
                }
                IEnumerable<string> query1 = from word in str2
                                             orderby word.Substring(0, 1) ascending
                                             select word;
                foreach (string st in query1)
                {
                    str[i] = st;
                    i++;
                }
                foreach (string st in str)
                    CB_PName.Items.Add(st);
                sr.Close();
            }
            else
            {
                int i = 0;
                StreamReader sr = new StreamReader(productnamefile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    if (col[3] == "True")
                    {
                        i++;
                    }
                }
                sr.Close();
                CB_PName.Items.Clear();
                string[] str = new string[i];
                str[0] = "";
                i = 0;
                sr = new StreamReader(productnamefile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    if (col[3] == "True")
                    {
                        str[i] = col[1];
                        i++;
                    }
                }
                IEnumerable<string> query = from word in str
                                            orderby word.Substring(0, 1) ascending
                                            select word;
                foreach (string st in query)
                    CB_PName.Items.Add(st);
                sr.Close();
            }
        }

        private string refresh_combobox_value(string filename, string comboCell) // Функция обновления содержимого базы изделия Производитель 
        {
            string a = "";
            if (!smode)
            {
                StreamReader sr1 = new StreamReader(filename);
                while (!sr1.EndOfStream)
                {
                    string line1 = sr1.ReadLine();
                    string[] col1 = line1.Split("|".ToCharArray());
                    if (col1[1] == comboCell)
                    {
                        a = col1[1];
                        break;
                    }
                }
                sr1.Close();
            }
            else
            {
                StreamReader sr1 = new StreamReader(holderfile);
                while (!sr1.EndOfStream)
                {
                    string line1 = sr1.ReadLine();
                    string[] col1 = line1.Split("|".ToCharArray());
                    if (col1[1] + "|" + col1[2] == comboCell)
                    {
                        a = col1[1] + "|" + col1[2];
                        break;
                    }
                }
                sr1.Close();
                sr1 = new StreamReader(cuttinginsertfile);
                while (!sr1.EndOfStream)
                {
                    string line1 = sr1.ReadLine();
                    string[] col1 = line1.Split("|".ToCharArray());
                    if (col1[1] + "|" + col1[2] == comboCell)
                    {
                        a = col1[1] + "|" + col1[2];
                        break;
                    }
                }
                sr1.Close();
            }
            return a;
        }

        private double mtime_value(string filename, string pname)
        {
            double a = 0;
            StreamReader sr1 = new StreamReader(filename);
            while (!sr1.EndOfStream)
            {
                string line1 = sr1.ReadLine();
                string[] col1 = line1.Split("|".ToCharArray());
                if (col1[1] == pname)
                {
                    a = Convert.ToDouble(col1[2]);
                    break;
                }
            }
            sr1.Close();
            return a;
        }

        private bool emptytb_check()
        {
            if (smode)
            {
                if (editmode)
                {
                    if (TB_ATime.Text == "" || TB_Mtime.Text == "" || TB_Mtime.Text == "-" || TB_PName.Text == "")
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
                    if (TB_ATime.Text == "" || TB_Mtime.Text == "" || TB_Mtime.Text == "-" || CB_PName.Text == "")
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
            else
            {
                if (TB_ATime.Text == "" || TB_Mtime.Text == "" || TB_Quan.Text == "" || CB_PName.Text == "")
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

        private bool coincidencecheck(string data)
        {

            if (editdata != data)
            {
                StreamReader sr = new StreamReader(productnamefile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == data)
                    {
                        MessageBox.Show(
                             "Эти данные уже есть в базе!",
                             "Ошибка",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error,
                             MessageBoxDefaultButton.Button1);
                        sr.Close();
                        return false;
                    }
                }
                sr.Close();
            }
            return true;
        }

        // ---------------------------------------------------------------------------------------------------------------------------------------------------------



        public Form4(byte mode, string toolStripName1, string toolStripName2, string data, bool lightcolor, Color tcolor, Color fcolor, Color tcolor1, Color fcolor2)
        {
            InitializeComponent();

            //toolStrip1.BackColor = Color.White;
            color1 = tcolor;
            colorf = fcolor;
            color2 = tcolor1;
            colorf1 = fcolor2;
            lightstyle = lightcolor;

            if (mode == 1)
            {
                this.Size = new Size(749, 294);

                AddButton.Location = new Point(614, 259);

                TB_Other.Width = 633;

                label5.Location = new Point(62, 127);
                dateTimePicker1.Location = new Point(104, 124);
                dateTimePicker1.Width = 150;
                dateTimePicker1.Height = 23;

                label2.Location = new Point(493, 90);
                label2.Text = "Машинное время";
                label4.Location = new Point(514, 127);
                label4.Text = "Общее время";
                label1.Location = new Point(12, 90);
                label1.Text = "Наименование изделия";

                TB_Mtime.Location = new Point(613, 87);
                TB_ATime.Location = new Point(613, 124);

                TB_Quan.Visible = true;
                label3.Visible = true;
            }
            else if (mode == 2)
            {
                if (data == "") TB_Mtime.BackColor = Color.White;
                //TB_ATime.BackColor = Color.White;
                TB_Mtime.ReadOnly = false;
                //TB_ATime.ReadOnly = false;
                smode = true;
            }

            productnamefile = folderpathmain + folderpathglobaldata + @"\" + productnamefile;
            reportfile = folderpathmain + folderpathglobaldata + @"\" + reportfile;
            holderfile = folderpathmain + folderpathglobaldata + @"\" + holderfile;
            cuttinginsertfile = folderpathmain + folderpathglobaldata + @"\" + cuttinginsertfile;
            storagefile = folderpathmain + folderpathglobaldata + @"\" + storagefile;

            colorstyle();
            refresh_combobox();

            CB_PName.BackColor = Color.White;
            CB_PName.ForeColor = Color.Black;

            toolStripLabel2.Text = toolStripName1;
            this.Text = toolStripName1;
            toolStripLabel1.Text = toolStripName2;
            toolStripButton1.Visible = false;

            string FNA;
            if (smode) FNA = storagefile;
            else FNA = reportfile;
            if (filescheck(FNA))
            {
                maxcountcheck(FNA);
                if (data == "") TB_Num.Text = Convert.ToString(maxcount + 1);
            }

            if (data != "")
            {
                editmode = true;
                string[] col = data.Split("|".ToCharArray());
                if (smode)
                {
                    string[] dcd1 = col[4].Split(" ".ToCharArray());
                    string[] dcd = { dcd1[0] + " " + dcd1[1] + " " + dcd1[2], dcd1[3].Trim("[]".ToCharArray()) };
                    data = data.Replace(col[4], dcd[0] + "^" + Convert.ToString(Convert.ToInt32(dcd[1])-1));
                    data = data.Replace(col[5] + "|" + col[6] + "|" + col[7], col[5] + "|" + col[6]);
                    data = data.Replace(col[0] + "|" + col[1], col[1]);
                    nda = col[3];
                    TB_Num.Text = col[0];
                    CB_PName.Visible = false;
                    TB_PName.Visible = true;
                    TB_PName.Text = idfinder(false, cuttinginsertfile, col[1], "");
                    if(TB_PName.Text == "") TB_PName.Text = idfinder(false, holderfile, col[1], "");
                    TB_Mtime.Text = col[2];
                    TB_Mtime.ReadOnly = true;
                    TB_ATime.Text = col[7];
                    TB_ATime.ReadOnly = true;
                    //dateTimePicker1.Value = Convert.ToDateTime(col[5]);
                    dateTimePicker1.Visible = false;
                    TB_Date.Visible = true;
                    TB_Date.Text = dcd[0];
                    dc = Convert.ToInt32(dcd[1])-1;
                    TB_Other.Text = col[5];
                    if (col[6] == "True") datastatus = true;
                    else datastatus = false;
                }
                else
                {
                    TB_Num.Text = col[0];
                    CB_PName.Text = refresh_combobox_value(productnamefile, col[1]);
                    TB_Mtime.Text = Convert.ToString(mtime_value(productnamefile, col[1]));
                    TB_Quan.Text = col[3];
                    //TB_ATime.Text = Convert.ToString(Convert.ToDouble(TB_Mtime.Text) * Convert.ToDouble(TB_Quan.Text));
                    TB_ATime.Text = col[4];
                    string[] dcd1 = col[5].Split(" ".ToCharArray());
                    string[] dcd = { dcd1[0] + " " + dcd1[1] + " " + dcd1[2], dcd1[3].Trim("[]".ToCharArray()) };
                    data = data.Replace(col[5], dcd[0] + "^" + Convert.ToString(Convert.ToInt32(dcd[1])));
                    data = data.Replace(col[0] + "|" + col[1], col[1]);
                    dateTimePicker1.Value = Convert.ToDateTime(dcd[0]); dddate = Convert.ToDateTime(dcd[0]);
                    dc = Convert.ToInt32(dcd[1]);
                    TB_Other.Text = col[6];
                    if (col[7] == "True") datastatus = true;
                    else datastatus = false;
                }
                if (datastatus)
                {
                    AddButton.Text = "Редактировать";
                    toolStripButton1.Visible = true;
                    if (!lightstyle) toolStripButton1.Image = Properties.Resources.trashl;
                    else toolStripButton1.Image = Properties.Resources.trash;
                    toolStripButton1.Text = "Удалить данные";
                }
                else
                {

                    AddButton.Text = "Редактировать";
                    toolStripLabel2.Text = "Редактирвоать";
                    toolStripLabel1.Text = "удаленные данные";
                    toolStripButton1.Visible = true;
                    if (!lightstyle) toolStripButton1.Image = Properties.Resources.trashl;
                    else toolStripButton1.Image = Properties.Resources.trash;
                    toolStripButton1.Text = "Вернуть данные в базу";
                }

                editdata = data;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (smode)
            {
                if (editmode)
                {
                    string[] c = TB_PName.Text.Split("|".ToCharArray());
                    c[0] = c[0].TrimEnd(' ');
                    c[1] = c[1].TrimStart(' ');
                    string id = idfinder(true, cuttinginsertfile, c[0], c[1]);
                    if (id == "") id = idfinder(true, holderfile, c[0], c[1]);
                    string newdata = $"{id}|{TB_Mtime.Text}|{nda}|{TB_Date.Text}^{dc}|{TB_Other.Text}|{datastatus}";

                    string text = File.ReadAllText(storagefile);
                    text = text.Replace(editdata, newdata);
                    File.WriteAllText(storagefile, text);

                    Properties.Settings.Default.refresh = true;
                    Properties.Settings.Default.Save();
                    this.Close();

                }
                else
                {
                    if (emptytb_check())
                    {
                        string[] c = CB_PName.Text.Split("|".ToCharArray());
                        c[0] = c[0].TrimEnd(' ');
                        c[1] = c[1].TrimStart(' ');
                        string id = idfinder(true, cuttinginsertfile, c[0], c[1]);
                        if (id == "") id = idfinder(true, holderfile, c[0], c[1]);
                        string newdata = $"{TB_Num.Text}|{id}|{TB_Mtime.Text}|{TB_ATime.Text}|{dateTimePicker1.Value.ToString("dd MMMM yyyy")}^{datecount(storagefile, 4)}|{TB_Other.Text}|{datastatus}";

                        if (coincidencecheck(newdata))
                        {
                            StreamWriter streamWriter = new StreamWriter(storagefile, true);
                            streamWriter.WriteLine(newdata);
                            streamWriter.Close();

                            Properties.Settings.Default.refresh = true;
                            Properties.Settings.Default.countwork = true;
                            Properties.Settings.Default.Save();
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                if (editmode)
                {
                    if (emptytb_check())
                    {
                        if (dateTimePicker1.Value != dddate) dc = datecount(reportfile, 5);
                        string newdata = $"{CB_PName.Text}|{TB_Mtime.Text}|{TB_Quan.Text}|{TB_ATime.Text}|{dateTimePicker1.Value.ToString("dd MMMM yyyy")}^{dc}|{TB_Other.Text}|{datastatus}";
                        if (coincidencecheck(newdata))
                        {
                            string text = File.ReadAllText(reportfile);
                            text = text.Replace(editdata, newdata);
                            File.WriteAllText(reportfile, text);

                            Properties.Settings.Default.refresh_r = true;
                            Properties.Settings.Default.countwork = true;
                            Properties.Settings.Default.Save();
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (emptytb_check())
                    {

                        string newdata = $"{TB_Num.Text}|{CB_PName.Text}|{TB_Mtime.Text}|{TB_Quan.Text}|{TB_ATime.Text}|{dateTimePicker1.Value.ToString("dd MMMM yyyy")}^{datecount(reportfile, 5)}|{TB_Other.Text}|{datastatus}";

                        if (coincidencecheck(newdata))
                        {
                            StreamWriter streamWriter = new StreamWriter(reportfile, true);
                            streamWriter.WriteLine(newdata);
                            streamWriter.Close();

                            Properties.Settings.Default.refresh_r = true;
                            Properties.Settings.Default.countwork = true;
                            Properties.Settings.Default.Save();
                            this.Close();
                        }
                    }
                }
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

        private void CB_PName_TextChanged(object sender, EventArgs e)
        {
            if (!smode)
            {
                TB_Mtime.Text = Convert.ToString(mtime_value(productnamefile, CB_PName.Text));
                if (TB_Quan.Text != "" && TB_Mtime.Text != "" && TB_Mtime.Text != "-" && TB_Mtime.Text.Substring(TB_Mtime.Text.Length - 1) != ",") TB_ATime.Text = Convert.ToString(Convert.ToDouble(TB_Mtime.Text) * Convert.ToDouble(TB_Quan.Text));
            }
            else
            {
                bool cancel = false;
                for (int k = 0; k < ra.Length; k++)
                {
                    if (CB_PName.Text == ra[k])
                    {
                        CB_PName.Text = null;
                        TB_ATime.Text = null;
                        cancel = true;
                        break;
                    }
                }
                if (!cancel)
                {
                    //MainForm mf = new MainForm();
                    //string fna;
                    if (CB_PName.SelectedIndex < count)
                    {
                        //    fna = holderfile;
                        coutvalue(holderfile);
                    }
                    else
                    {
                        //    fna = cuttinginsertfile;
                        coutvalue(cuttinginsertfile);
                    }


                    //StreamReader sr = new StreamReader(fna);
                    //while(!sr.EndOfStream);
                    //{
                    //    string line = sr.ReadLine();
                    //    string[] col = line.Split('|');
                    //    if (col[0] == idfinder(true, fna, b[0], b[1]);
                    //}

                    //string[] b = CB_PName.Text.Split('|');
                    //string v = idfinder(true, fna, b[0], b[1]);
                    //TB_ATime.Text = Convert.ToString(mf.squallvolue(mf.countfound(v, fna), CB_PName.Text, dateTimePicker1.Value, 25000));
                }
            }
        }

        private void TB_Quan_TextChanged(object sender, EventArgs e)
        {
                if (TB_Mtime.Text != "" && TB_Quan.Text != "" && TB_Mtime.Text != "-" && TB_Mtime.Text.Substring(TB_Mtime.Text.Length - 1) != ",") TB_ATime.Text = Convert.ToString(Convert.ToDouble(TB_Mtime.Text) * Convert.ToDouble(TB_Quan.Text));
        }

        private void TB_Quan_KeyPress(object sender, KeyPressEventArgs e)
        {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if (smode)
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
                        string newdata = "";
                        string[] dt = editdata.Split("|".ToCharArray());
                        newdata = data.Replace("True", "False");
                        //string[] col = data.Split("|".ToCharArray());
                        //col[3] = "false";
                        //string newdata = "";
                        //for (int n = 0; n < col.Length; n++)
                        //{
                        //    newdata = newdata + col[n];
                        //}
                        string text = File.ReadAllText(storagefile);
                        text = text.Replace(data, newdata);
                        File.WriteAllText(storagefile, text);
                        Properties.Settings.Default.refresh = true;
                        Properties.Settings.Default.countwork = true;
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
                        //string[] col = data.Split("|".ToCharArray());
                        //col[3] = "false";
                        //string newdata = "";
                        //for (int n = 0; n < col.Length; n++)
                        //{
                        //    newdata = newdata + col[n];
                        //}
                        string data = editdata;
                        string newdata = "";
                        string[] dt = editdata.Split("|".ToCharArray());
                        newdata = data.Replace("False", "True");
                        string text = File.ReadAllText(storagefile);
                        text = text.Replace(data, newdata);
                        File.WriteAllText(storagefile, text);
                        Properties.Settings.Default.refresh = true;
                        Properties.Settings.Default.countwork = true;
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                }
            }
            else
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
                        string text = File.ReadAllText(reportfile);
                        text = text.Replace(data, newdata);
                        File.WriteAllText(reportfile, text);
                        Properties.Settings.Default.refresh = true;
                        Properties.Settings.Default.countwork = true;
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
                        string text = File.ReadAllText(reportfile);
                        text = text.Replace(data, newdata);
                        File.WriteAllText(reportfile, text);
                        Properties.Settings.Default.refresh = true;
                        Properties.Settings.Default.countwork = true;
                        Properties.Settings.Default.Save();
                        this.Close();
                    }
                }
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void CB_PName_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void TB_Mtime_TextChanged(object sender, EventArgs e)
        {
            if (TB_Mtime.Text != "" && TB_Mtime.Text != "-" && TB_Mtime.Text.Substring(TB_Mtime.Text.Length - 1) != "," && cor + Convert.ToDouble(TB_Mtime.Text) > 2147483647) TB_Mtime.Text = "";
            if (TB_ATime.Text != "")
            {
                double l = 0;
                if (TB_Mtime.Text != "" && TB_Mtime.Text != "-" && TB_Mtime.Text.Substring(TB_Mtime.Text.Length - 1) != ",")
                {
                    l = Convert.ToDouble(TB_Mtime.Text);
                }
                TB_ATime.Text = Convert.ToString(cor + l);
            }
        }

        private void TB_Mtime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (smode)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                {
                    e.Handled = true;
                }
                var tb = (TextBox)sender;
                //Разбираемся с минусом
                if (e.KeyChar.ToString().Equals("-"))
                {
                    e.Handled = tb.SelectionStart != 0 || tb.Text.IndexOf("-") != -1;
                    if (!e.Handled)
                    {
                        return;
                    }
                }
                //Десятичный разделитель в системе
                var decSep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
                //Разбираемся с десятичным разделителем.
                if (e.KeyChar.ToString().Equals(decSep))
                {
                    e.Handled = tb.Text.Length == 0 || tb.Text.IndexOf(decSep) != -1;
                    if (!e.Handled)
                    {
                        return;
                    }
                }
                //Разбираемся с цифрами
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            }
            else
            {
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
            }
            
        }

        private void CB_PName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(CB_PName.Text != "")
            {
                if (CB_PName.SelectedIndex <= count)
                {
                    coutvalue(holderfile);
                }
                else
                {
                    coutvalue(cuttinginsertfile);
                }
            }
        }
    }
}
