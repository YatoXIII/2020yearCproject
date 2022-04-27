using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Text.RegularExpressions;
using DGVPrinterHelper;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApp5
{

    public partial class MainForm : Form
    {


        long hflength = 0;
        long ciflength = 0;
        long pflength = 0;
        string folderpathmain = @"Storage";
        string folderpathglobaldata = @"\GlobalData";
        string folderpathproductdata = @"\ProductData";
        string folderallreport = @"\Reports";
        string fileway = "";
        string usefile;
        string holderfile = "holder.txt";
        string cuttinginsertfile = "cuttinginsert.txt";
        string productnamefile = "product.txt";
        string reportfile = "report.txt";
        //string areportfile = "areports.txt";
        string storagefile = "storage.txt";
        string productname = "";
        string usefileproduct = "";
        bool DGV_Product_save = true;
        bool sortchangepn = false;
        bool sortchangeh = false;
        bool sortchanges = false;
        bool sortchangeci = false;
        bool colorstyle = true;
        bool deletedisplay;

        int nm = 0;
        int na = 0;
        int nq = 0;

        string[] r = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "-", "*", "/", ".", ",", ";", ":", " ", "?", "\"", "'", "/", @"\", ">", "<", ";", ":", "{", "}", "[", "]" };


        Color color1;
        Color colorf;
        Color color2;
        Color colorf1;

        Color color3 = Color.FromArgb(255, 235, 235, 235);
        Color color4 = Color.LightGray;

        Color deletecolor = Color.FromArgb(255, 255, 204, 204);




        public MainForm()
        {
            InitializeComponent();
        }

        private void Open_AddForm(byte a, string FormName, string toolStripName, string data) // Процедура открытия окна Добавления данных
        {
            AddForm AddForm1 = new AddForm(a, FormName, toolStripName, data, colorstyle, color1, colorf, color2, colorf1);
            AddForm1.ShowDialog();
        }






        //<-------------------------------------------------------------------------------------------------------------->
        //                                           Функции и процедуры
        //                                                Функционал
        //<-------------------------------------------------------------------------------------------------------------->


        protected override void WndProc(ref Message m) // Требуется для изменения границ формы при FormBorderStyle == none
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
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
                else
                {
                    this.Close();
                    filescheck(filename);
                }
                return false;
            }
        }

        private void search()
        {
            if (toolStripTextBox1.Text != "")
            {
                refresh();
                Regex regex = new Regex(toolStripTextBox1.Text, RegexOptions.IgnoreCase);
                if (tabControl1.SelectedTab == tabPage1)
                {
                    int k = 0;
                    //DGV_Product_Name;
                    for (int i = 0; i < DGV_Product_Name.Rows.Count; i++)
                    {
                        for (int n = 0; n < DGV_Product_Name.Columns.Count; n++)
                        {
                            if (regex.IsMatch(Convert.ToString(DGV_Product_Name[n, i].Value)))
                            {
                                DGV_Product_Name[n, i].Style.BackColor = Color.Yellow;
                                k++;
                            }
                        }
                    }
                    DGV_P_Label2.Visible = true;
                    DGV_P_Label2.Text = $"Найдено: {Convert.ToString(k)}";
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    int k = 0;
                    //DGV_Holder;
                    for (int i = 0; i < DGV_Holder.Rows.Count; i++)
                    {
                        for (int n = 0; n < DGV_Holder.Columns.Count; n++)
                        {
                            if (regex.IsMatch(Convert.ToString(DGV_Holder[n, i].Value)))
                            {
                                DGV_Holder[n, i].Style.BackColor = Color.Yellow;
                                k++;
                            }
                        }
                    }
                    DGV_H_Label2.Visible = true;
                    DGV_H_Label2.Text = $"Найдено: {Convert.ToString(k)}";
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    int k = 0;
                    //DGV_CuttingInsert;
                    for (int i = 0; i < DGV_CuttingInsert.Rows.Count; i++)
                    {
                        for (int n = 0; n < DGV_CuttingInsert.Columns.Count; n++)
                        {
                            if (regex.IsMatch(Convert.ToString(DGV_CuttingInsert[n, i].Value)))
                            {
                                DGV_CuttingInsert[n, i].Style.BackColor = Color.Yellow;
                                k++;
                            }
                        }
                    }
                    DGV_CI_Label2.Visible = true;
                    DGV_CI_Label2.Text = $"Найдено: {Convert.ToString(k)}";
                }
                else if (tabControl1.SelectedTab == tabPage4)
                {
                    int k = 0;
                    //DGV_Product;
                    for (int i = 0; i < DGV_Product.Rows.Count; i++)
                    {
                        for (int n = 0; n < DGV_Product.Columns.Count; n++)
                        {
                            if (regex.IsMatch(Convert.ToString(DGV_Product[n, i].Value)))
                            {
                                DGV_Product[n, i].Style.BackColor = Color.Yellow;
                                k++;
                            }
                            else
                            {
                                DGV_Product[n, i].Style.BackColor = Color.White;
                            }
                        }
                    }
                    DGV_P_Label2.Visible = true;
                    DGV_P_Label2.Text = $"Найдено: {Convert.ToString(k)}";
                }
                else if (tabControl1.SelectedTab == tabPage5)
                {
                    int k = 0;
                    //DGV_Product_Name;
                    for (int i = 0; i < DGV_Report.Rows.Count; i++)
                    {
                        for (int n = 0; n < DGV_Report.Columns.Count; n++)
                        {
                            if (regex.IsMatch(Convert.ToString(DGV_Report[n, i].Value)))
                            {
                                DGV_Report[n, i].Style.BackColor = Color.Yellow;
                                k++;
                            }
                        }
                    }
                    DGV_R_Label2.Visible = true;
                    DGV_R_Label2.Text = $"Найдено: {Convert.ToString(k)}";
                }
                else if (tabControl1.SelectedTab == tabPage6)
                {
                    int k = 0;
                    //DGV_Product_Name;
                    for (int i = 0; i < DGV_Storage.Rows.Count; i++)
                    {
                        for (int n = 0; n < DGV_Storage.Columns.Count; n++)
                        {
                            if (regex.IsMatch(Convert.ToString(DGV_Storage[n, i].Value)))
                            {
                                DGV_Storage[n, i].Style.BackColor = Color.Yellow;
                                k++;
                            }
                        }
                    }
                    DGV_S_Label2.Visible = true;
                    DGV_S_Label2.Text = $"Найдено: {Convert.ToString(k)}";
                }
                else if (tabControl1.SelectedTab == tabPage7)
                {
                    if (DGV_AR.Visible)
                    {
                        refresh_dgv_ar();
                        int k = 0;
                        //DGV_Product_Name;
                        for (int i = 0; i < DGV_AR.Rows.Count; i++)
                        {
                            for (int n = 0; n < DGV_AR.Columns.Count; n++)
                            {
                                if (regex.IsMatch(Convert.ToString(DGV_AR[n, i].Value)))
                                {
                                    DGV_AR[n, i].Style.BackColor = Color.Yellow;
                                    k++;
                                }
                            }
                        }
                        L2_AR.Visible = true;
                        L2_AR.Text = $"Найдено: {Convert.ToString(k)}";
                    }
                    else if (DGV_ARR.Visible /*&& !arr_editmode*/)
                    {
                        refresh_dgv_arr(tabPage7.Text);
                        int k = 0;
                        //DGV_Product_Name;
                        for (int i = 0; i < DGV_ARR.Rows.Count; i++)
                        {
                            for (int n = 0; n < DGV_ARR.Columns.Count; n++)
                            {
                                if (regex.IsMatch(Convert.ToString(DGV_ARR[n, i].Value)))
                                {
                                    DGV_ARR[n, i].Style.BackColor = Color.Yellow;
                                    k++;
                                }
                            }
                        }
                        L2_AR.Visible = true;
                        L2_AR.Text = $"Найдено: {Convert.ToString(k)}";
                    }
                }
            }
            else
            {
                DGV_P_Label2.Visible = false;
                DGV_PN_Label2.Visible = false;
                DGV_H_Label2.Visible = false;
                DGV_CI_Label2.Visible = false;
                DGV_R_Label2.Visible = false;
                DGV_S_Label2.Visible = false;
                L2_AR.Visible = false;
                refresh();
                if (DGV_ARR.Visible && tabControl1.SelectedTab == tabPage7 /*&& !arr_editmode*/)
                    refresh_dgv_arr(tabPage7.Text);
                if (DGV_AR.Visible && tabControl1.SelectedTab == tabPage7)
                    refresh_dgv_ar();
            }
        }

        private long filelength(string filename) // Функция возвращает вес файла
        {
            FileInfo fileInf = new FileInfo(filename);
            return fileInf.Length;
        }

        private bool filechange(string filename, long blength) // Проверка веса файла и если вес отличается то возвращает значение иситины
        {
            if (filescheck(filename))
            {
                if (filelength(filename) != blength)
                {
                    return true;
                }
            }
            return false;
        }

        private int countstorage(string name, string manu, int coun)
        {
            //int b = 0;
            StreamReader sr = new StreamReader(storagefile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                string sti;
                sti = idfinder(false, cuttinginsertfile, col[1], "");
                if (sti == "") sti = idfinder(false, holderfile, col[1], "");
                string[] stri = sti.Split("|".ToCharArray());
                if (name == stri[0] && manu == stri[1])
                {
                    if (Convert.ToBoolean(col[7]))
                    {
                        if (Convert.ToBoolean(col[6]))
                        {
                            coun = coun + Convert.ToInt32(col[2]);
                        }
                        else
                        {
                            coun = coun - Convert.ToInt32(col[2]);
                        }
                        sr.Close();
                        return coun;
                    }
                }
            }
            sr.Close();
            return 0;
        }
        //private int countreport(string name, string manu, int coun, int ccc)
        //{
        //    //int b = 0;
        //    StreamReader sr = new StreamReader(reportfile);
        //    while (!sr.EndOfStream)
        //    {
        //        int cc = 0;
        //        bool c = false;
        //        string line = sr.ReadLine();
        //        string[] col = line.Split("|".ToCharArray());
        //        for (int g = 0; g < DGV_Product_Name.Rows.Count; g++)
        //        {
        //            DataGridViewCell cell = (DataGridViewCell)DGV_Product_Name.Rows[g].Cells["Product_Name"];
        //            if (Convert.ToString(cell.Value) == col[1])
        //            {
        //                productname = Convert.ToString(cell.Value);
        //                for (int l = 0; l < r.Length; l++)
        //                {
        //                    if (productname.Substring(productname.Length - 1) == r[l])
        //                    {
        //                        productname = productname + "0";
        //                        break;
        //                    }
        //                }

        //                if (productname != "")
        //                {
        //                    string us = usefileproduct;
        //                    productfolder(productname);
        //                    StreamReader sr1 = new StreamReader(usefileproduct);
        //                    while (!sr1.EndOfStream)
        //                    {
        //                        string line1 = sr1.ReadLine();
        //                        string[] col1 = line1.Split("|".ToCharArray());
        //                        if ($"{name}|{manu}" == idfinder(false, cuttinginsertfile, col1[3], ""))
        //                        {
        //                            if (cc != ccc)
        //                            {
        //                                cc++;
        //                            }
        //                            else
        //                            {
        //                                double xqua10 = Convert.ToDouble(col1[4]);
        //                                double xqua = Convert.ToDouble(col[3]);
        //                                coun = coun - Convert.ToInt32(((xqua10 / 10) * xqua));

        //                                sr1.Close();
        //                                sr.Close();

        //                                c = true;
        //                                ccc++;
        //                                coun = countreport(name, manu, coun, ccc);
        //                                break;
        //                            }
        //                        }
        //                    }
        //                    sr1.Close();
        //                    usefileproduct = us;
        //                }
        //                break;
        //            }
        //        }
        //        if (c) break;
        //    }
        //    sr.Close();
        //    return coun;
        //}
        int y = 0;
        private void refresh_dgv_holder() // Процедура обновления данных в датагриде державок
        {
            usefile = holderfile;
            filescheck(usefile);

            int i = 0;
            if (Properties.Settings.Default.countwork)
            {
                StreamReader sr1 = new StreamReader(usefile);
                while (!sr1.EndOfStream)
                {
                    string line = sr1.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    double h = counthi(col[1] + "|" + col[2], Convert.ToDouble(col[4]));
                    if (col[3] != "False" || отображатьУдаленныеToolStripMenuItem.Checked == true)
                    {
                        if (i == y)
                        {
                            sr1.Close();
                            dataswitchhi(usefile, Convert.ToString(h), line);
                            y++;
                            refresh_dgv_holder();
                            return;
                        }
                        i++;
                    }
                }
                sr1.Close();
                y = 0;
            }

            hflength = filelength(usefile);
            DGV_Holder.Rows.Clear();
            StreamReader sr = new StreamReader(usefile);
            i = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                if (col[3] != "False" || отображатьУдаленныеToolStripMenuItem.Checked == true)
                {
                    int id = Convert.ToInt32(col[0].TrimStart("h ".ToCharArray()));
                    double h = counthi(col[1] + "|" + col[2], Convert.ToDouble(col[4]));
                    DGV_Holder.Rows.Add(id, col[1], col[2], h, col[5], col[4]);
                    if (col[3] == "False") DGV_Holder.Rows[i].DefaultCellStyle.BackColor = deletecolor;

                    i++;
                }
            }
            sr.Close();

            sortchangeh = true;

            DGV_H_Label1.Text = $"Отображено строк: {i}";
            refresh_dgv_product_combobox_holder();
        }

        private double counthi(string name, double cn)
        {
            for (int i = 0; i < DGV_Storage.RowCount - 1; i++)
            {
                if (DGV_Storage["sname", i].Value.ToString() == name && DGV_Storage.Rows[i].DefaultCellStyle.BackColor != deletecolor)
                {
                    cn = cn + Convert.ToDouble(DGV_Storage["squaadd", i].Value);
                }
            }

            return cn;
        }
        private double counthir(string name, double cn, DateTime date, /*int dateid,*/ string qua, int quan)
        {
            bool j = true;
            for (int i = 0; i < DGV_Storage.RowCount - 1; i++)
            {
                if (DGV_Storage.Rows[i].DefaultCellStyle.BackColor != deletecolor)
                {
                    bool cancel = false;
                    string[] datei = DGV_Storage["sdate", i].Value.ToString().Split(" ".ToCharArray());
                    string[] datet = { datei[0] + " " + datei[1] + " " + datei[2], datei[3] };

                    if (/*!j &&*/ quan <= 0 && DGV_Storage["sname", i].Value.ToString() == name && Convert.ToDateTime(datet[0]) == date && DGV_Storage["snote", i].Value.ToString() == "Отчет")
                    {
                        cancel = true;
                    }
                    if (j && datet[0] == date.ToString() && "-" + qua == DGV_Storage["squaadd", i].Value.ToString() && DGV_Storage["sname", i].Value.ToString() == name)
                    {
                        cancel = true;
                        j = false;
                    }
                    if (!cancel)
                    {
                        if (DGV_Storage["sname", i].Value.ToString() == name && Convert.ToDateTime(datet[0]) <= date /*&& dateid < Convert.ToInt32(datet[1].TrimEnd(']').TrimStart('['))*/)
                        {
                            quan = quan - 1;
                            cn = cn + Convert.ToDouble(DGV_Storage["squaadd", i].Value);
                        }
                    }
                }
            }

            return cn;
        }

        public int countfound(string id, string filename)
        {
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                if (col[0] == id)
                {
                    sr.Close();
                    return Convert.ToInt32(col[4]);
                }
            }
            sr.Close();
            return 0;
        }

        private void dataswitchhi(string filename, string newdatad, string line)
        {
            string[] col = line.Split('|');
            string text = File.ReadAllText(filename);
            text = text.Replace(line, $"{col[0]}|{col[1]}|{col[2]}|{col[3]}|{col[4]}|{col[5]}|{newdatad}");
            File.WriteAllText(filename, text);
        }

        private void refresh_dgv_cuttinginsert() // Процедура обновления данных в датагриде режущих пластин
        {
            usefile = cuttinginsertfile;
            filescheck(usefile);

            int i = 0;
            if (Properties.Settings.Default.countwork)
            {
                StreamReader sr1 = new StreamReader(usefile);
                while (!sr1.EndOfStream)
                {
                    string line = sr1.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    double h = counthi(col[1] + "|" + col[2], Convert.ToInt32(col[4]));
                    if (col[3] != "False" || отображатьУдаленныеToolStripMenuItem.Checked == true)
                    {
                        if (i == y)
                        {
                            sr1.Close();
                            dataswitchhi(usefile, Convert.ToString(h), line);
                            y++;
                            refresh_dgv_cuttinginsert();
                            return;
                        }
                        i++;
                    }
                }
                sr1.Close();
                y = 0;
            }

            ciflength = filelength(usefile);
            DGV_CuttingInsert.Rows.Clear();
            StreamReader sr = new StreamReader(usefile);
            i = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                double h = counthi(col[1] + "|" + col[2], Convert.ToInt32(col[4]));
                if (col[3] != "False" || отображатьУдаленныеToolStripMenuItem.Checked == true)
                {
                    int id = Convert.ToInt32(col[0].TrimStart("i ".ToCharArray()));
                    DGV_CuttingInsert.Rows.Add(id, col[1], col[2], counthi(col[1] + "|" + col[2], Convert.ToInt32(col[4])), col[5], col[4]);
                    if (col[3] == "False") DGV_CuttingInsert.Rows[i].DefaultCellStyle.BackColor = deletecolor;

                    i++;
                }
            }
            sr.Close();

            sortchangeci = true;

            DGV_CI_Label1.Text = $"Отображено строк: {i}";
            refresh_dgv_product_combobox_cuttinginsert();
        }

        private int pnamequan(string name)
        {
            int i=0;
            StreamReader sr = new StreamReader(reportfile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                if (col[1] == name && col[7] != "False")
                {
                    i = i + Convert.ToInt32(col[3]);
                }
            }
            sr.Close();
            return i;
        }

        private void refresh_dgv_product_name() // Процедура обновления данных в датагриде изделий
        {
            usefile = productnamefile;
            filescheck(usefile);
            pflength = filelength(usefile);
            DGV_Product_Name.Rows.Clear();
            StreamReader sr = new StreamReader(usefile);
            int i = 0;
            while (!sr.EndOfStream)
            {

                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());

                if (col[3] != "False" || отображатьУдаленныеToolStripMenuItem.Checked == true)
                {
                    DGV_Product_Name.Rows.Add(null, col[1], col[2], pnamequan(col[1]));
                    if (col[3] == "False")
                    {
                        DGV_Product_Name.Rows[i].DefaultCellStyle.BackColor = deletecolor;
                    }
                    i++;
                }
            }
            sr.Close();
            NumerateCells_Product_Name();
            sortchangepn = true;

            DGV_P_Label1.Text = $"Отображено строк: {i}";
            productfolderwork();
        }

        private void refresh_dgv_product(string filename) // Процедура обновления данных в датагриде изделий
        {
            usefile = filename;
            filescheck(usefile);
            pflength = filelength(usefile);
            DGV_Product.Rows.Clear();
            StreamReader sr = new StreamReader(usefile);
            int i = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());

                DGV_Product.Rows.Add();

                DataGridViewComboBoxCell comboCellH = (DataGridViewComboBoxCell)DGV_Product["Holder", i];
                DataGridViewComboBoxCell comboCellC = (DataGridViewComboBoxCell)DGV_Product["CuttingInsert", i];

                refresh_dgv_product_combobox_cuttinginsert();


                int id = Convert.ToInt32(col[0]);
                DGV_Product["ProductID", i].Value = id;
                DGV_Product["ProductProgramm", i].Value = col[1];
                refresh_dgv_product_combobox_holder();
                for (int k = 0; k < comboCellH.Items.Count; k++)
                {
                    if (Convert.ToString(comboCellH.Items[k]) == idfinder(false, holderfile, col[2], ""))
                    {
                        comboCellH.Value = comboCellH.Items[k];
                    }
                }
                for (int k = 0; k < comboCellC.Items.Count; k++)
                {
                    if (Convert.ToString(comboCellC.Items[k]) == idfinder(false, cuttinginsertfile, col[3], ""))
                    {
                        comboCellC.Value = comboCellC.Items[k];
                    }
                }
                DGV_Product["pqua", i].Value = col[4];
                DGV_Product["Note", i].Value = col[5];



                //DGV_Product["MHolder", i].Value = refresh_combobox_value(holderfile, Convert.ToString(comboCellH.Value));
                //DGV_Product["MCuttingInsert", i].Value = refresh_combobox_value(cuttinginsertfile, Convert.ToString(comboCellC.Value));

                i++;

            }
            sr.Close();
            DGV_Product_save = true;

            DGV_PN_Label1.Text = $"Отображено строк: {i}";

        }


        private DateTime mindate(string filenamem, int cd, DateTime d1, DateTime d2, DateTime d3)
        {
            DateTime ddd = dateTimePicker2.Value;
            StreamReader sr = new StreamReader(filenamem);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                string[] datetd = col[5].Split("^".ToCharArray());
                if (Convert.ToDateTime(datetd[0]) >= d1 && Convert.ToDateTime(datetd[0]) <= d2 && Convert.ToDateTime(datetd[0]) > d3)
                {
                    if (ddd >= Convert.ToDateTime(datetd[0]))
                    {
                        ddd = Convert.ToDateTime(datetd[0]);
                    }
                }
            }
            sr.Close();


            return ddd;
        }


        private int cdate(string date)
        {
            int cn = 0;
            for (int i = 0; i < DGV_Storage.RowCount - 1; i++)
            {
                string[] datei = DGV_Storage["sdate", i].Value.ToString().Split(" ".ToCharArray());
                string[] datea = { datei[0] + " " + datei[1] + " " + datei[2], datei[3] };
                if (datea[0] == date)
                {
                    cn++;
                }
            }

            return cn;
        }

        DateTime mdate;
        private void refresh_dgv_report()
        {
            int colIndex = 1;

            filescheck(reportfile);
            DGV_Report.Rows.Clear();


            StreamReader sr = new StreamReader(reportfile);
            int i = 0, n = 0;
            na = 0;
            nq = 0;
            nm = 0;


            if (radioButton1.Checked)
            {
                sr = new StreamReader(reportfile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    string[] datetd = col[5].Split("^".ToCharArray());
                    if (Convert.ToDateTime(datetd[0]) >= dateTimePicker1.Value && Convert.ToDateTime(datetd[0]) <= dateTimePicker2.Value)
                    {
                        if (col[7] != "False" || отображатьУдаленныеToolStripMenuItem.Checked == true)
                        {
                            n++;
                        }
                    }
                }
                sr.Close();
                mdate = dateTimePicker1.MinDate;
                mdate = mindate(reportfile, 5, dateTimePicker1.Value, dateTimePicker2.Value, mdate);
            }
            else n = 1;
            sr.Close();
            for (int k = 0; k < n; k++)
            {
                string datee = "";
                int h = 0;
                int p = 0;
                sr = new StreamReader(reportfile);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    {
                        //if (Properties.Settings.Default.countwork && Convert.ToBoolean(col[8]))
                        //{
                        //    for (int o = 0; o < DGV_CuttingInsert.Rows.Count; o++)
                        //    {
                        //        string col16 = "";
                        //        string fname = cuttinginsertfile;
                        //        int j = 0;
                        //        StreamReader sr2 = new StreamReader(fname);
                        //        while (!sr2.EndOfStream)
                        //        {
                        //            string line2 = sr2.ReadLine();
                        //            string[] col2 = line2.Split("|".ToCharArray());
                        //            if (Convert.ToBoolean(col2[3]))
                        //            {
                        //                j = countreport(col2[1], col2[2], Convert.ToInt32(col2[6]),0);
                        //                if (j != 0)
                        //                {
                        //                    col16 = line2;
                        //                    break;
                        //                }
                        //            }
                        //        }
                        //        sr2.Close();
                        //        if (j != 0 /*&& Properties.Settings.Default.countwork*/)
                        //        {

                        //            sr.Close();
                        //            string[] istr = col16.Split("|".ToCharArray());
                        //            istr[6] = Convert.ToString(j);
                        //            string text = File.ReadAllText(fname);
                        //            text = text.Replace(col16, $"{istr[0]}|{istr[1]}|{istr[2]}|{istr[3]}|{istr[4]}|{istr[5]}|{istr[6]}");
                        //            File.WriteAllText(fname, text);

                        //            text = File.ReadAllText(reportfile);
                        //            text = text.Replace(line, $"{col[0]}|{col[1]}|{col[2]}|{col[3]}|{col[4]}|{col[5]}|{col[6]}|{col[7]}|{false}");
                        //            File.WriteAllText(reportfile, text);
                        //            refresh_dgv_report();
                        //            return;
                        //        }
                        //    }
                        //}
                    }
                    string[] datetd = col[5].Split("^".ToCharArray());
                    if (radioButton2.Checked || Convert.ToDateTime(datetd[0]) == mdate)
                    {
                        if (col[7] != "False" || отображатьУдаленныеToolStripMenuItem.Checked == true)
                        {
                            DGV_Report.Rows.Add();
                            //DGV_Report["rid", i].Value = col[0];
                            DGV_Report["rid", i].Value = colIndex; colIndex++;
                            DGV_Report["rpname", i].Value = col[1];
                            DGV_Report["rmtime", i].Value = col[2];
                            DGV_Report["rquantity", i].Value = col[3];
                            DGV_Report["ratime", i].Value = col[4];
                            DGV_Report["rdate", i].Value = datetd[0] + $" [{h}]"; h++;
                            DGV_Report["sdates", i].Value = $"{ Convert.ToInt32(datetd[1])}";
                            DGV_Report["rother", i].Value = col[6];
                            if (col[7] == "False") DGV_Report.Rows[i].DefaultCellStyle.BackColor = deletecolor;
                            else DGV_Report.Rows[i].DefaultCellStyle.BackColor = color4;


                            i++;
                            na = na + Convert.ToInt32(col[4]);
                            nq = nq + Convert.ToInt32(col[3]);
                            nm = nm + Convert.ToInt32(col[2]);


                            DGV_Report.Rows.Add();
                            DGV_Report["rpname", i].Value = "Наименование пластины";
                            DGV_Report["rmtime", i].Value = "Производитель";
                            DGV_Report["rquantity", i].Value = "Расход";
                            DGV_Report["ratime", i].Value = "Остаток";
                            if (col[7] == "False") DGV_Report.Rows[i].DefaultCellStyle.BackColor = deletecolor;
                            else DGV_Report.Rows[i].DefaultCellStyle.BackColor = color3;
                            i++;

                            //--------------------------------------------------------------------------------------

                            bool y = true;
                            for (int g = 0; g < DGV_Product_Name.Rows.Count; g++)
                            {
                                DataGridViewCell cell = (DataGridViewCell)DGV_Product_Name.Rows[g].Cells["Product_Name"];
                                if (Convert.ToString(cell.Value) == col[1])
                                {
                                    productname = Convert.ToString(cell.Value);
                                    for (int l = 0; l < r.Length; l++)
                                    {
                                        if (productname.Substring(productname.Length - 1) == r[l])
                                        {
                                            productname = productname + "0";
                                            break;
                                        }
                                    }

                                    if (productname != "")
                                    {
                                        string us = usefileproduct;
                                        productfolder(productname);
                                        if (datee != datetd[0])
                                        {
                                            //p = cdate(datetd[0]);
                                            p = 0;
                                            datee = datetd[0];
                                        }
                                        StreamReader sr1 = new StreamReader(usefileproduct);
                                        while (!sr1.EndOfStream)
                                        {
                                            y = false;
                                            string line1 = sr1.ReadLine();
                                            string[] col1 = line1.Split("|".ToCharArray());

                                            double xqua10 = Convert.ToDouble(col1[4]);
                                            double xqua = Convert.ToDouble(col[3]);

                                            DGV_Report.Rows.Add();
                                            string[] sty = idfinder(false, cuttinginsertfile, col1[3], "").Split("|".ToCharArray());
                                            DGV_Report["rpname", i].Value = sty[0];
                                            DGV_Report["rmtime", i].Value = sty[1];
                                            //DGV_Report["rquantity", i].Value = Convert.ToString((xqua10 / 10) * xqua);
                                            DGV_Report["rquantity", i].Value = Convert.ToString(xqua10 );

                                            //DGV_Report["ratime", i].Value = counthir(sty[0] + "|" + sty[1], countfound(col1[3], cuttinginsertfile), Convert.ToDateTime(datetd[0]), /*p,*/ Convert.ToString((xqua10 / 10) * xqua), p) - Convert.ToInt32((xqua10 / 10) * xqua);
                                            //DGV_Report["ratime", i].Value = counthir(sty[0] + "|" + sty[1], countfound(col1[3], cuttinginsertfile), Convert.ToDateTime(datetd[0]), /*p,*/ Convert.ToString(xqua10), p) /*- Convert.ToDouble(xqua10)*/;
                                            DGV_Report["ratime", i].Value = countrepor(sty[0] + "|" + sty[1], countfound(col1[3], cuttinginsertfile), Convert.ToDateTime(datetd[0]), /*p,*/ Convert.ToString(xqua10), p) /*- Convert.ToDouble(xqua10)*/;
                                            if (xqua10 == 0) DGV_Report["rquantity", i].Value = 0;
                                            if (col[7] == "False") DGV_Report.Rows[i].DefaultCellStyle.BackColor = deletecolor;
                                            i++;
                                            p++;
                                        }
                                        sr1.Close();
                                        usefileproduct = us;
                                    }
                                    break;
                                }
                            }
                            if (y)
                            {
                                DGV_Report.Rows.Add();
                                DGV_Report["rpname", i].Value = "Нет данных";
                                if (col[7] == "False") DGV_Report.Rows[i].DefaultCellStyle.BackColor = deletecolor;
                                i++;
                            }

                            //--------------------------------------------------------------------------------------

                            //--------------------------------------------------------------------------------------
                        }
                    }
                }
                mdate = mindate(reportfile, 5, dateTimePicker1.Value, dateTimePicker2.Value, mdate);
                sr.Close();
            }
            sr.Close();
            //NumerateCells_Report();
            refresh_dgv_storage();
            atimelabel.Text = Convert.ToString(na);
            DGV_R_Label1.Text = $"Отображено строк: {i}";
        }

        private double countrepor(string name, double cn, DateTime date, /*int dateid,*/ string qua, int quan)
        {
            bool j = true;
            quan++;
            for (int i = 0; i < DGV_Storage.RowCount - 1; i++)
            {
                if (DGV_Storage.Rows[i].DefaultCellStyle.BackColor != deletecolor)
                {
                    bool cancel = false;
                    string[] datei = DGV_Storage["sdate", i].Value.ToString().Split(" ".ToCharArray());
                    string[] datet = { datei[0] + " " + datei[1] + " " + datei[2], datei[3] };

                    //if (/*!j &&*/ quan <= 0 && DGV_Storage["sname", i].Value.ToString() == name && Convert.ToDateTime(datet[0]) == date && DGV_Storage["snote", i].Value.ToString() == "Отчет")
                    //{
                    //    cancel = true;
                    //}
                    if (j && datet[0] == date.ToString() && "-" + qua == DGV_Storage["squaadd", i].Value.ToString() && DGV_Storage["sname", i].Value.ToString() == name)
                    {
                        cancel = true;
                        j = false;
                    }
                    if (!cancel)
                    {
                        if (DGV_Storage["snote", i].Value.ToString() == "Отчет"&& DGV_Storage["sname", i].Value.ToString() == name && Convert.ToDateTime(datet[0]) == date /*&& dateid < Convert.ToInt32(datet[1].TrimEnd(']').TrimStart('['))*/)
                        {
                            if(DGV_Storage["squaadd", i].Style.BackColor != Color.Green)
                            {
                                DGV_Storage["squaadd", i].Style.BackColor = Color.Green;
                                return Convert.ToDouble(DGV_Storage["squaall", i].Value);
                            }
                        }
                    }
                }
            }

            return cn;
        }

        private double coutvalue(string namema, string filename, string datet)
        {
            double cor;
            string[] dated = datet.Split("^".ToCharArray());
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                string line1 = sr.ReadLine();
                string[] col1 = line1.Split("|".ToCharArray());
                string[] namemau = namema.Split("|".ToCharArray());
                if (namemau[0] == col1[1])
                {
                    cor = Convert.ToInt32(col1[4]);
                    sr.Close();

                    sr = new StreamReader(storagefile);
                    while (!sr.EndOfStream)
                    {
                        string line2 = sr.ReadLine();
                        string[] col2 = line2.Split("|".ToCharArray());
                        string[] dated2 = col2[4].Split("^".ToCharArray());
                        col2[1] = idfinder(false, filename, col2[1], "");
                        if (col2[1] == namema && Convert.ToDateTime(dated2[0]) <= Convert.ToDateTime(dated[0]))
                        {
                            bool cancel = false;
                            if (Convert.ToDateTime(dated2[0]) == Convert.ToDateTime(dated[0]))
                            {
                                if (Convert.ToInt64(dated2[1]) > Convert.ToInt64(dated[1])) cancel = true;
                            }

                            if (!cancel) cor = cor + Convert.ToDouble(col2[2]);
                        }
                    }

                    sr.Close();
                    return cor;
                }
            }
            sr.Close();
            return 0;
        }

        int ik = 0;
        bool iki = true;
        private void storagecountrefresh()
        {
            if (iki)
            {
                ik = 0;
                iki = false;
            }
            int i = 0;
            StreamReader sr = new StreamReader(storagefile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (i != ik)
                {
                    i++;
                }
                else
                {
                    ik++;
                    string[] col = line.Split("|".ToCharArray());
                    sr.Close();
                    if (idfinder(false, cuttinginsertfile, col[1], "") != "") col[3] = Convert.ToString(coutvalue(idfinder(false, cuttinginsertfile, col[1], ""), cuttinginsertfile, col[4]));
                    else col[3] = Convert.ToString(coutvalue(idfinder(false, holderfile, col[1], ""), holderfile, col[4]));

                    string text = File.ReadAllText(storagefile);
                    text = text.Replace(line, $"{col[0]}|{col[1]}|{col[2]}|{col[3]}|{col[4]}|{col[5]}|{col[6]}");
                    File.WriteAllText(storagefile, text);

                    storagecountrefresh();
                    return;
                }
            }
            sr.Close();
            iki = true;
        }

        private int coutvalue2(string namema, string datet)
        {
            int cor = 1;
            string[] dated = datet.Split("^".ToCharArray());

            for (int i = 0; i < DGV_Storage.Rows.Count - 1; i++)
            {
                string[] dated2 = DGV_Storage["sdate", i].Value.ToString().Split(" ".ToCharArray());
                if (DGV_Storage["sname", i].Value.ToString() == namema && dated2[0] + " " + dated2[1] + " " + dated2[2] == dated[0])
                {
                    cor++;
                }
            }

            return cor;
        }
        private int srqua(string name, int qua, string date, string dateid)
        {
            for (int i = 0; i < DGV_Storage.Rows.Count - 1; i++)
            {
                string[] dated2 = DGV_Storage["sdate", i].Value.ToString().Split(" ".ToCharArray());
                if (DGV_Storage["sname", i].Value.ToString() == name && Convert.ToDateTime(dated2[0] + " " + dated2[1] + " " + dated2[2]) <= Convert.ToDateTime(date) && Convert.ToInt32(dated2[3].TrimEnd(']').TrimStart('[')) < Convert.ToInt32(dateid))
                {
                    qua = qua + Convert.ToInt32(DGV_Storage["squaadd", i].Value);
                }
            }
            return qua;
        }

        private void refresh_dgv_storage()
        {
            usefile = storagefile;
            storagecountrefresh();
            filescheck(usefile);
            DGV_Storage.Rows.Clear();


            int i = 0;
            StreamReader sr = new StreamReader(usefile);
            while (!sr.EndOfStream)
            {
                //string col16 = "";
                //if (Convert.ToBoolean(col[7]))
                //{
                //    string fname = cuttinginsertfile;
                //    int j = 0;
                //    StreamReader sr1 = new StreamReader(fname);
                //    while (!sr1.EndOfStream)
                //    {
                //        string line1 = sr1.ReadLine();
                //        string[] col1 = line1.Split("|".ToCharArray());
                //        if (Convert.ToBoolean(col1[3]))
                //        {
                //            j = countstorage(col1[1], col1[2], Convert.ToInt32(col1[6]));
                //            if (j != 0)
                //            {
                //                col16 = line1;
                //                break;
                //            }
                //        }
                //    }
                //    sr1.Close();
                //    if (j == 0)
                //    {
                //        fname = holderfile;
                //        sr1 = new StreamReader(fname);
                //        while (!sr1.EndOfStream)
                //        {
                //            string line1 = sr1.ReadLine();
                //            string[] col1 = line1.Split("|".ToCharArray());
                //            if (Convert.ToBoolean(col1[3]))
                //            {
                //                j = countstorage(col1[1], col1[2], Convert.ToInt32(col1[6]));
                //                if (j != 0)
                //                {
                //                    col16 = line1;
                //                    break;
                //                }
                //            }
                //        }
                //        sr1.Close();
                //    }
                //    if (j != 0 && Properties.Settings.Default.countwork)
                //    {
                //        string[] istr = col16.Split("|".ToCharArray());
                //        istr[6] = Convert.ToString(j);
                //        string text = File.ReadAllText(fname);
                //        text = text.Replace(col16, $"{istr[0]}|{istr[1]}|{istr[2]}|{istr[3]}|{istr[4]}|{istr[5]}|{istr[6]}");
                //        File.WriteAllText(fname, text);

                //        string tx = $"{col[0]}|{col[1]}|{col[2]}|{col[3]}|{col[4]}|{col[5]}|{col[6]}|{col[7]}";
                //        string tx1 = $"{col[0]}|{col[1]}|{col[2]}|{col[3]}|{col[4]}|{col[5]}|{col[6]}|False";
                //        sr.Close();

                //        text = File.ReadAllText(storagefile);
                //        text = text.Replace(tx, tx1);
                //        File.WriteAllText(storagefile, text);

                //        refresh_dgv_storage();
                //        return;
                //    }
                //}

                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                if (col[6] != "False" || отображатьУдаленныеToolStripMenuItem.Checked == true)
                {
                    string b = idfinder(false, cuttinginsertfile, col[1], "");
                    if (b == "") b = idfinder(false, holderfile, col[1], "");
                    string[] datee = col[4].Split("^".ToCharArray());
                    DGV_Storage.Rows.Add(col[0], b, col[2], col[3], $"{datee[0]} [159951]", col[5], col[3]);
                    if (col[6] == "False")
                    {
                        DGV_Storage.Rows[i].DefaultCellStyle.BackColor = deletecolor;
                    }
                    i++;
                }

            }
            sr.Close();

            sr = new StreamReader(reportfile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                for (int g = 0; g < DGV_Product_Name.Rows.Count; g++)
                {
                    DataGridViewCell cell = (DataGridViewCell)DGV_Product_Name.Rows[g].Cells["Product_Name"];
                    if (Convert.ToString(cell.Value) == col[1])
                    {
                        productname = Convert.ToString(cell.Value);
                        for (int l = 0; l < r.Length; l++)
                        {
                            if (productname.Substring(productname.Length - 1) == r[l])
                            {
                                productname = productname + "0";
                                break;
                            }
                        }

                        if (productname != "")
                        {
                            string us = usefileproduct;
                            productfolder(productname);
                            StreamReader sr1 = new StreamReader(usefileproduct);
                            while (!sr1.EndOfStream)
                            {
                                string line1 = sr1.ReadLine();
                                string[] col1 = line1.Split("|".ToCharArray());

                                double xqua10 = Convert.ToDouble(col1[4]);
                                double xqua = Convert.ToDouble(col[3]);
                                string b = idfinder(false, cuttinginsertfile, col1[3], "");
                                string[] datee = col[5].Split("^".ToCharArray());
                                //DGV_Storage.Rows.Add(i + 1, b, "-" + Convert.ToString(xqua10 / 10) * xqua), 0, $"{datee[0]} [159951]", "Отчет");
                                DGV_Storage.Rows.Add(i + 1, b, "-" + Convert.ToString(xqua10 ), 0, $"{datee[0]} [159951]", "Отчет");

                if (col[7] == "False") DGV_Storage.Rows[i].DefaultCellStyle.BackColor = deletecolor;
                                i++;
                            }
                            sr1.Close();
                            usefileproduct = us;
                        }
                        break;
                    }
                }
            }
            sr.Close();


            for (int y = 0; y < DGV_Storage.RowCount - 1; y++)
            {
                string[] datee = DGV_Storage["sdate", y].Value.ToString().Split(" ".ToCharArray());
                string[] datet = { $"{datee[0]} {datee[1]} {datee[2]}", datee[3].TrimEnd(']').TrimStart('[') };
                if (datet[1] == "159951")
                {
                    datet[1] = sdatework(datet[0]);
                    DGV_Storage["sdate", y].Value = DGV_Storage["sdate", y].Value.ToString().Replace(datee[3], $"[{datet[1]}]");
                }
            }

            for (int y = 0; y < DGV_Storage.RowCount - 1; y++)
            {
                string[] datee = DGV_Storage["sdate", y].Value.ToString().Split(" ".ToCharArray());
                string[] datet = { $"{datee[0]} {datee[1]} {datee[2]}", datee[3].TrimEnd(']').TrimStart('[') };
                string[] b = DGV_Storage["sname", y].Value.ToString().Split('|');
                string fna = cuttinginsertfile;
                string v = idfinder(true, fna, b[0], b[1]);
                if (v == "")
                {
                    fna = holderfile;
                    v = idfinder(true, fna, b[0], b[1]);
                }
                if (DGV_Storage.Rows[y].DefaultCellStyle.BackColor != deletecolor) DGV_Storage["squaall", y].Value = squallvolue(countfound(v, fna), DGV_Storage["sname", y].Value.ToString(), Convert.ToDateTime(datet[0]), Convert.ToInt32(datet[1]));
                else DGV_Storage["squaall", y].Value = "-";
            }

            sortchanges = true;
            NumerateCells_Storage();
            DGV_S_Label1.Text = $"Отображено строк: {i}";
        }

        private string sdatework(string date)
        {
            int i = 1;
            for (int y = 0; y < DGV_Storage.RowCount - 1; y++)
            {
                string[] datee = DGV_Storage["sdate", y].Value.ToString().Split(" ".ToCharArray());
                string[] datet = { $"{datee[0]} {datee[1]} {datee[2]}", datee[3].TrimEnd(']').TrimStart('[') };
                if (datet[0] == date && datet[1] != "159951") i++;
            }

            return Convert.ToString(i);
        }

        public double squallvolue(double qua,string name, DateTime date, int dateid)
        {
            for (int i = 0; i < DGV_Storage.RowCount - 1; i++)
            {
                string[] datee = DGV_Storage["sdate", i].Value.ToString().Split(" ".ToCharArray());
                string[] datet = { $"{datee[0]} {datee[1]} {datee[2]}", datee[3].TrimEnd(']').TrimStart('[') };
                if (DGV_Storage["sname", i].Value.ToString() == name && Convert.ToDateTime(datet[0]) <= date && DGV_Storage.Rows[i].DefaultCellStyle.BackColor != deletecolor)
                {
                    if (Convert.ToDateTime(datet[0]) == date)
                    {
                        if (Convert.ToInt32(datet[1]) <= dateid)
                        {
                            qua = qua + Convert.ToDouble(DGV_Storage["squaadd", i].Value);
                        }
                    }
                    else
                    {
                        qua = qua + Convert.ToDouble(DGV_Storage["squaadd", i].Value);
                    }
                }
            }

            return qua;
        }

        private void refresh_dgv_ar()
        {
            DGV_AR.Rows.Clear();
            DirectoryInfo dir = new DirectoryInfo(folderpathmain + folderallreport);
            int i = 1;
            foreach (var item in dir.GetFiles())
            {
                DGV_AR.Rows.Add(i, item.Name.TrimEnd(".txt".ToCharArray()));
                i++;
            }
            L1_AR.Text = "Отображено строк: " + i;
        }
        private void dgvarrvisible(bool a)
        {
            DGV_ARR.Visible = a;
            //AR_edit.Visible = a;
            AR_print.Visible = a;
            //AR_save.Visible = a;
            AR_delete.Visible = a;

            if (a)
            {
                DGV_AR.Visible = false;
                AR_path.Visible = false;
            }
            else
            {
                DGV_AR.Visible = true;
                AR_path.Visible = true;
            }
        }
        private void refresh_dgv_arr(string reportdate)
        {
            //arr_editmode = false;
            tabPage7.Text = reportdate;

            DGV_ARR.Rows.Clear();

            reportdate = folderpathmain + folderallreport + @"\" + reportdate;

            StreamReader sr = new StreamReader(reportdate);
            int i = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split('|');
                Color col0 = Color.FromArgb(Convert.ToInt32(col[0]));
                if (col[0] == "0") col0 = Color.White;
                DGV_ARR.Rows.Add(col[1], col[2], col[3], col[4], col[5]);
                DGV_ARR.Rows[i].DefaultCellStyle.BackColor = col0;
                i++;
            }
            sr.Close();

            L1_AR.Text = "Отображено строк: " + i;
        }

        private bool save_dgv_product(string filename) // Сохранение данных по каждому изделию
        {
            bool cancel = false;
            for (int h = 0; h < DGV_Product.Rows.Count; h++)
            {
                for (int j = 0; j < DGV_Product.Columns.Count; j++)
                {
                    if (Convert.ToString(DGV_Product[j, h].Value) == "" && j != DGV_Product.Columns["Note"].Index && h != DGV_Product.Rows.Count - 1 && DGV_Product.Columns["MCuttingInsert"].Index != j && DGV_Product.Columns["MHolder"].Index != j && j != DGV_Product.Columns["ProductProgramm"].Index)
                    {
                        tabControl1.SelectedTab = tabPage4;

                        MessageBox.Show(
                            "Все поля должны быть заполнены!",
                            "Внимание!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                        cancel = true;
                        break;
                    }
                }
                if (cancel == true) break;
            }
            if(!cancel)
            {
                StreamWriter sw = new StreamWriter(filename);
                for (int i = 0; i < DGV_Product.RowCount-1; i++)
                {
                    string[] co1 = Convert.ToString(DGV_Product["Holder", i].Value).Split("|".ToCharArray());
                    co1[0] = co1[0].TrimEnd(' ');
                    co1[1] = co1[1].TrimStart(' ');
                    string[] co2 = Convert.ToString(DGV_Product["CuttingInsert", i].Value).Split("|".ToCharArray());
                    co2[0] = co2[0].TrimEnd(' ');
                    co2[1] = co2[1].TrimStart(' ');
                    string hid = idfinder(true, holderfile, co1[0], co1[1]);
                    string cid = idfinder(true, cuttinginsertfile, co2[0], co2[1]);
                    if (Convert.ToString(DGV_Product["ProductID", i].Value) == "" && Convert.ToString(DGV_Product["ProductProgramm", i].Value) == "" && Convert.ToString(DGV_Product["Holder", i].Value) == "" && Convert.ToString(DGV_Product["CuttingInsert", i].Value) == "" && Convert.ToString(DGV_Product["pqua", i].Value) == "")
                    {
                    }
                    else
                    {
                        sw.WriteLine(DGV_Product["ProductID", i].Value + "|" + DGV_Product["ProductProgramm", i].Value + "|" + hid + "|" + cid + "|" + DGV_Product["pqua", i].Value + "|" + DGV_Product["Note", i].Value);
                    }
                }

                sw.Close();
                DGV_Product_save = true;

                Properties.Settings.Default.countwork = true;
                Properties.Settings.Default.Save();

                return true;
            }
            return false;
        }

        public void refresh() // Процедура полного обновления данных
        {
            refresh_dgv_product_name();
            refresh_dgv_storage();
            refresh_dgv_report();
            refresh_dgv_holder();
            refresh_dgv_cuttinginsert();
        }

        private void folderwork() // Процедура работы с файлами
        {
            Directory.CreateDirectory(folderpathmain);
            Directory.CreateDirectory(folderpathmain + folderpathglobaldata);
            Directory.CreateDirectory(folderpathmain + folderpathproductdata);
            Directory.CreateDirectory(folderpathmain + folderallreport);

            holderfile = folderpathmain + folderpathglobaldata + @"\" + holderfile;
            cuttinginsertfile = folderpathmain + folderpathglobaldata + @"\" + cuttinginsertfile;
            productnamefile = folderpathmain + folderpathglobaldata + @"\" + productnamefile;
            reportfile = folderpathmain + folderpathglobaldata + @"\" + reportfile;
            storagefile = folderpathmain + folderpathglobaldata + @"\" + storagefile;
        }

        private void productfolder(string prodname) // Процедура создания папки для каждого изделия
        {
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
            string file = folderpathmain + folderpathproductdata + @"\" + prodname;
            Directory.CreateDirectory(file);
            string filename = file + @"\Data.txt";
            FileInfo fileInf = new FileInfo(filename);
            if (fileInf.Exists == false)
            {
                FileStream fs = fileInf.Create();
                fs.Close();
            }
            Directory.CreateDirectory(file + @"\File");
            filesfix(filename, 4);
            usefileproduct = filename;

            fileslabel.Text = "Прикреплено файлов: " + new DirectoryInfo(file + @"\File").GetFiles().Length.ToString();
        }

        private string productfolder2(string prodname) // Процедура создания папки для каждого изделия
        {
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

            return prodname;
        }

        private bool empty_combobox(string combobox)
        {
            if (combobox == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void refresh_dgv_product_combobox_holder() // процедура обновления комбобокса державок датагрида изделия
        {
            int m = 0;
            StreamReader sr = new StreamReader(holderfile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                if (col[3] == "True")
                {
                    m++;
                }
            }
            sr.Close();
            string[] str = new string[m];

            m = 0;
            sr = new StreamReader(holderfile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                if (col[3] == "True")
                {
                    str[m] = col[1] + "|" + col[2];
                    m++;
                }
            }

            IEnumerable<string> query = from word in str
                                        orderby word.Substring(0, 1) ascending
                                        select word;
            m = 0;
            foreach (string st in query)
            {
                str[m] = st;
                m++;
            }

            sr.Close();

            for (int i = 0; i < DGV_Product.RowCount; i++)
            {
                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)DGV_Product["Holder", i];

                if (empty_combobox(Convert.ToString(comboCell.Value)))
                {
                    comboCell.Items.Clear();
                    comboCell.Items.AddRange(str);
                }
                else
                {
                    string value = comboCell.Value.ToString();
                    comboCell.Value = null;
                    comboCell.Items.Clear();
                    comboCell.Items.AddRange(str);
                    comboCell.Value = value;
                }
            }
        }

        private void refresh_dgv_product_combobox_cuttinginsert() // процедура обновления комбобокса пластин датагрида изделия
        {
            int m = 0;
            StreamReader sr = new StreamReader(cuttinginsertfile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                if (col[3] == "True")
                {
                    m++;
                }
            }

            sr.Close();
            string[] str = new string[m];

            m = 0;
            sr = new StreamReader(cuttinginsertfile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                if (col[3] == "True")
                {
                    str[m] = col[1] + "|" + col[2];
                    m++;
                }
            }

            IEnumerable<string> query = from word in str
                                        orderby word.Substring(0, 1) ascending
                                        select word;
            m = 0;
            foreach (string st in query)
            {
                str[m] = st;
                m++;
            }

            sr.Close();

            for (int i = 0; i < DGV_Product.RowCount; i++)
            {
                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)DGV_Product["CuttingInsert", i];

                if (empty_combobox(Convert.ToString(comboCell.Value)))
                {
                    comboCell.Items.Clear();
                    comboCell.Items.AddRange(str);
                }
                else
                {
                    string value = comboCell.Value.ToString();
                    comboCell.Value = null;
                    comboCell.Items.Clear();
                    comboCell.Items.AddRange(str);
                    comboCell.Value = value;
                }
            }
        }

        //private void refresh_dgv_product_combobox_holder() // процедура обновления комбобокса державок датагрида изделия
        //{
        //    for (int i = 0; i < DGV_Product.RowCount; i++)
        //    {
        //        DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)DGV_Product["Holder", i];

        //        if (empty_combobox(Convert.ToString(comboCell.Value)))
        //        {
        //            comboCell.Items.Clear();
        //            StreamReader sr = new StreamReader(holderfile);
        //            while (!sr.EndOfStream)
        //            {
        //                string line = sr.ReadLine();
        //                string[] col = line.Split("|".ToCharArray());
        //                if (col[3] == "True") comboCell.Items.AddRange(col[1]);
        //            }
        //            sr.Close();
        //        }
        //    }
        //}

        //private void refresh_dgv_product_combobox_cuttinginsert() // процедура обновления комбобокса пластин датагрида изделия
        //{
        //    for (int i = 0; i < DGV_Product.RowCount; i++)
        //    {
        //        DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)DGV_Product["CuttingInsert", i];

        //        if (empty_combobox(Convert.ToString(comboCell.Value)))
        //        {
        //            comboCell.Items.Clear();
        //            StreamReader sr = new StreamReader(cuttinginsertfile);
        //            while (!sr.EndOfStream)
        //            {
        //                string line = sr.ReadLine();
        //                string[] col = line.Split("|".ToCharArray());
        //                if (col[3] == "True") comboCell.Items.AddRange(col[1]);
        //            }
        //            sr.Close();
        //        }
        //    }
        //}

        private string refresh_combobox_value(string filename, string comboCell) // Функция обновления содержимого базы изделия Производитель 
        {
            string a = "";
            StreamReader sr1 = new StreamReader(filename);
            while (!sr1.EndOfStream)
            {
                string line1 = sr1.ReadLine();
                string[] col1 = line1.Split("|".ToCharArray());
                if (col1[1] == comboCell)
                {
                    a = col1[2];
                    break;
                }
            }
            sr1.Close();
            return a;
        }

        public void NumerateCells() // Процедура номерации датагрида изделий
        {
            int colIndex = 0;
            for (int i = 0; i < DGV_Product.RowCount - 1; i++)
                DGV_Product.Rows[i].Cells[colIndex].Value = i + 1;
        }

        public void NumerateCells_Product_Name() 
        {
            int colIndex = 0;
            for (int i = 0; i < DGV_Product_Name.RowCount - 1; i++)
                DGV_Product_Name.Rows[i].Cells[colIndex].Value = i + 1;
        }

        public void NumerateCells_Report()
        {
            int colIndex = 0;
            for (int i = 0; i < DGV_Report.RowCount - 1; i++)
                DGV_Report.Rows[i].Cells[colIndex].Value = i + 1;
        }
        public void NumerateCells_Storage()
        {
            int colIndex = 0;
            for (int i = 0; i < DGV_Storage.RowCount - 1; i++)
                DGV_Storage.Rows[i].Cells[colIndex].Value = i + 1;
        }

        private void filesfix(string filename, int mode) // Починка файлов для обновления.
        {
            bool g = false;
            StreamReader sr2 = new StreamReader(filename);
            while (!sr2.EndOfStream)
            {
                g = true;
                break;
            }
            sr2.Close();


            if (g)
            {
                if (mode == 0 || mode == 1)
                {
                    if (filename == productnamefile)
                    {
                        StreamReader sr = new StreamReader(filename);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] col = line.Split("|".ToCharArray());
                            if (col.Length < 3)
                            {
                                sr.Close();
                                string newdata = line + "|0|True";
                                string text = File.ReadAllText(filename);
                                text = text.Replace(line, newdata);
                                File.WriteAllText(filename, text);
                                filesfix(filename, mode);

                                string text1 = File.ReadAllText(filename);
                                text1 = text1.Replace("true", "True");
                                File.WriteAllText(filename, text1);

                                text1 = File.ReadAllText(filename);
                                text1 = text1.Replace("false", "False");
                                File.WriteAllText(filename, text1);

                                break;
                            }
                        }
                        sr.Close();
                    }
                }
                if (mode == 0 || mode == 2)
                {
                    StreamReader sr = new StreamReader(filename);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] col = line.Split("|".ToCharArray());
                        if (col.Length < 4)
                        {
                            sr.Close();
                            string newdata = line + $"|True";
                            string text = File.ReadAllText(filename);
                            text = text.Replace(line, newdata);
                            File.WriteAllText(filename, text);
                            filesfix(filename, mode);

                            string text1 = File.ReadAllText(filename);
                            text1 = text1.Replace("true", "True");
                            File.WriteAllText(filename, text1);

                            text1 = File.ReadAllText(filename);
                            text1 = text1.Replace("false", "False");
                            File.WriteAllText(filename, text1);

                            break;
                        }
                    }
                    sr.Close();
                }
                if (mode == 0 || mode == 3)
                {
                    StreamReader sr = new StreamReader(filename);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] col = line.Split("|".ToCharArray());
                        if (col.Length >= 4 && col.Length < 6)
                        {
                            sr.Close();
                            string newdata = line + $"|0|";
                            string text = File.ReadAllText(filename);
                            text = text.Replace(line, newdata);
                            File.WriteAllText(filename, text);
                            filesfix(filename, mode);
                            string text1 = File.ReadAllText(filename);
                            text1 = text1.Replace("true", "True");
                            File.WriteAllText(filename, text1);

                            text1 = File.ReadAllText(filename);
                            text1 = text1.Replace("false", "False");
                            File.WriteAllText(filename, text1);
                            break;
                        }
                    }
                    sr.Close();
                }

                if (mode == 0 || mode == 4)
                {
                    StreamReader sr = new StreamReader(filename);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] col = line.Split("|".ToCharArray());
                        if (col.Length == 5)
                        {
                            sr.Close();
                            string newdata = col[0] + "|" + col[1] + "|" + col[2] + "|" + col[3] + "|" + "0" + "|" + col[4];
                            string text = File.ReadAllText(filename);
                            text = text.Replace(line, newdata);
                            File.WriteAllText(filename, text);
                            filesfix(filename, mode);
                            break;
                        }
                    }
                    sr.Close();
                }
                if (mode == 0 || mode == 5)
                {
                    //StreamReader sr = new StreamReader(filename);
                    //while (!sr.EndOfStream)
                    //{
                    //    string line = sr.ReadLine();
                    //    string[] col = line.Split("|".ToCharArray());
                    //    if (col.Length == 6)
                    //    {

                    //        sr.Close();
                    //        string newdata = col[0] + "|" + col[1] + "|" + col[2] + "|" + refresh_combobox_value(holderfile, col[2]) + "|" + col[3] + "|" + refresh_combobox_value(cuttinginsertfile, col[3]) + "|" + col[4] + "|" + col[5];
                    //        string text = File.ReadAllText(filename);
                    //        text = text.Replace(line, newdata);
                    //        File.WriteAllText(filename, text);
                    //        filesfix(filename, mode);
                    //        break;
                    //    }
                    //}
                    //sr.Close();
                }
            }
            if (mode == 0 || mode == 6)
            {
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    if (col.Length <= 6)
                    {
                        sr.Close();
                        string newdata = line + $"|{col[4]}";
                        string text = File.ReadAllText(filename);
                        text = text.Replace(line, newdata);
                        File.WriteAllText(filename, text);
                        filesfix(filename, mode);

                        string text1 = File.ReadAllText(filename);
                        text1 = text1.Replace("true", "True");
                        File.WriteAllText(filename, text1);

                        text1 = File.ReadAllText(filename);
                        text1 = text1.Replace("false", "False");
                        File.WriteAllText(filename, text1);

                        break;
                    }
                }
                sr.Close();
            }
            if (mode == 0 || mode == 7)
            {
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    string[] cl = col[0].Split(" ".ToCharArray());
                    if (cl.Length == 1)
                    {
                        sr.Close();
                        col[0] = "h " + col[0];

                        string newdata = $"{col[0]}|{col[1]}|{col[2]}|{col[3]}|{col[4]}|{col[5]}|{col[6]}";
                        string text = File.ReadAllText(filename);
                        text = text.Replace(line, newdata);
                        File.WriteAllText(filename, text);



                        filesfix(filename, mode);
                        break;
                    }
                }
                sr.Close();
            }
            if (mode == 0 || mode == 8)
            {
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    string[] cl = col[0].Split(" ".ToCharArray());
                    if (cl.Length == 1)
                    {
                        col[0] = "i " + col[0];
                        sr.Close();

                        string newdata = $"{col[0]}|{col[1]}|{col[2]}|{col[3]}|{col[4]}|{col[5]}|{col[6]}";
                        string text = File.ReadAllText(filename);
                        text = text.Replace(line, newdata);
                        File.WriteAllText(filename, text);

                        filesfix(filename, mode);
                        break;
                    }
                }
                sr.Close();
            }
            if (mode == 0 || mode == 9)
            {
                StreamReader sr = new StreamReader(filename);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] col = line.Split("|".ToCharArray());
                    string[] cl = col[5].Split("^".ToCharArray());
                    if (cl.Length == 1)
                    {
                        sr.Close();
                        if (dttd == col[5])
                        {
                            string newdata = $"{col[0]}|{col[1]}|{col[2]}|{col[3]}|{col[4]}|{col[5]}^{dt}|{col[6]}|{col[7]}";
                            string text = File.ReadAllText(filename);
                            text = text.Replace(line, newdata);
                            File.WriteAllText(filename, text);
                            dt++;
                        }
                        else
                        {
                            dttd = col[5];
                            dt = 0;
                        }
                        filesfix(filename, mode);
                        break;
                    }
                }
                sr.Close();
            }
            //if (mode == 0 || mode == 10)
            //{
            //    StreamReader sr = new StreamReader(filename);
            //    while (!sr.EndOfStream)
            //    {
            //        string line = sr.ReadLine();
            //        string[] col = line.Split("|".ToCharArray());
            //        if (col.Length == 6)
            //        {
            //            sr.Close();
            //            string newdata = line + "|True";
            //            string text = File.ReadAllText(filename);
            //            text = text.Replace(line, newdata);
            //            File.WriteAllText(filename, text);
            //            filesfix(filename, mode);
            //            break;
            //        }
            //    }
            //    sr.Close();
            //}
            }
        string dttd;
        int dt = 0;
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
                        return col[1]+"|"+col[2];
                    }
                }
                sr.Close();
                return "";
            }
        }

        private bool productclose()
        {
            if(DGV_Product_save)
            {
            }
            else
            {
                DialogResult dr = MessageBox.Show(
                        $"Сохранить данные изделия {tabPage4.Text.Replace("Изделие: ", null)}?",
                        "Внимание!",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button3);
                if (dr == DialogResult.Yes)
                {
                    if (save_dgv_product(usefileproduct)) return true;
                    else return false;
                }
                if (dr == DialogResult.Cancel)
                {
                    return false;
                }
            }

            DGV_Product_save = true;
            return true;
        }

        private void datastats()
        {
            double pi = 0, pk = 0;
            StreamReader sr = new StreamReader(productnamefile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                pi++;
                if (col[3] == "False") pk++;
            }
            sr.Close();

            double hi = 0, hk = 0;
            sr = new StreamReader(holderfile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                hi++;
                if (col[3] == "False") hk++;
            }
            sr.Close();

            double ci = 0, ck = 0;
            sr = new StreamReader(cuttinginsertfile);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] col = line.Split("|".ToCharArray());
                ci++;
                if (col[3] == "False") ck++;
            }
            sr.Close();

            double ai = pi + hi + ci;

            alldatalabel.Text = $"{ai} (100%)";
            if (ai != 0) alldatadeletedlabel.Text = $"{pk + hk + ck} ({Convert.ToInt32(((pk + hk + ck) / ai) * 100)}%)";

            if (ai != 0) productdatalabel.Text = $"{pi} ({Convert.ToInt32((pi / ai) * 100)}%)";
            if (pi != 0) productdatadeletedlabel.Text = $"{pk} ({Convert.ToInt32((pk / pi) * 100)}%)";

            if (ai != 0)  holderdatalabel.Text = $"{hi} ({Convert.ToInt32((hi / ai) * 100)}%)";
            if (hi != 0) holderdatadeletedlabel.Text = $"{hk} ({Convert.ToInt32((hk / hi) * 100)}%)";

            if (ai != 0) cuttinginsertdatalabel.Text = $"{ci} ({Convert.ToInt32((ci / ai) * 100)}%)";
            if (ci != 0) cuttinginsertdatadeletedlabel.Text = $"{ck} ({Convert.ToInt32((ck / ci) * 100)}%)";
            refresh_dgv_report(); 

            //usereportfile = folderpathmain + reportpath + @"\" + dateTimePicker1.Value.ToString("MM.yyyy") + ".txt";
            //FileInfo fi = new FileInfo(usereportfile);
            //if (fi.Exists)
            //{
            //    label7.Visible = false;
            //    button4.Visible = false;
            //    DGV_Report2.Visible = true;
            //}
            //else
            //{
            //    label7.Visible = true;
            //    button4.Visible = true;
            //    DGV_Report2.Visible = false;
            //}
        }

        private void productfolderwork()
        {
            string us = usefileproduct;
            if (DGV_Product_Name.Rows.Count != 0)
            {
                for (int n = 0; n < DGV_Product_Name.Rows.Count-1; n++)
                {
                    DataGridViewCell cell = (DataGridViewCell)DGV_Product_Name.Rows[n].Cells["Product_Name"];

                    productname = Convert.ToString(cell.Value);
                    for (int i = 0; i < r.Length; i++)
                    {
                        if (productname.Substring(productname.Length - 1) == r[i])
                        {
                            productname = productname + "0";
                            break;
                        }
                    }

                    if (productname != "")
                    {
                        productfolder(productname);
                        filesfix(usefileproduct, 5);
                    }
                }
            }
            usefileproduct = us;
        }


        // <-------------------------------------------------------------------------------------------------------------->
        //                                    Функции / Процедуры / События
        //                                              Дизайн
        // <-------------------------------------------------------------------------------------------------------------->

        private void colorswitch() // Процедура подключение стилей цвета
        {
            color1 = ColorTranslator.FromHtml("#7CAA2D");
            colorf = Color.Black;
            color2 = Color.FromArgb(255, 40, 43, 48);
            colorf1 = Color.White;

            if (!colorstyle)
            {
                buttonfullscreen.BackgroundImage = Properties.Resources.expandl;
                buttonroll.BackgroundImage = Properties.Resources.minusi;
                homebutton.BackgroundImage = Properties.Resources.pagei;

                menuStrip1.BackColor = color1;

                buttonfullscreen.BackColor = menuStrip1.BackColor;
                buttonroll.BackColor = menuStrip1.BackColor;
                buttonclose.BackColor = menuStrip1.BackColor;
                homebutton.BackColor = menuStrip1.BackColor;

                for (int i = 0; i < menuStrip1.Items.Count; i++)
                {
                    menuStrip1.Items[i].ForeColor = colorf;
                }
            }
            else
            {
                buttonfullscreen.BackgroundImage = Properties.Resources.expand;
                buttonroll.BackgroundImage = Properties.Resources.minus;
                homebutton.BackgroundImage = Properties.Resources.page;

                menuStrip1.BackColor = color2;

                buttonfullscreen.BackColor = menuStrip1.BackColor;
                buttonroll.BackColor = menuStrip1.BackColor;
                buttonclose.BackColor = menuStrip1.BackColor;
                homebutton.BackColor = menuStrip1.BackColor;

                for (int i = 0; i < menuStrip1.Items.Count; i++)
                {
                    menuStrip1.Items[i].ForeColor = colorf1;
                }
            }
            toolStripTextBox1.ForeColor = Color.Black;

        }



        // <-------------------------------------------------------------------------------------------------------------->
        //                                                События
        // <-------------------------------------------------------------------------------------------------------------->






        private void MainForm_Load(object sender, EventArgs e)  // Событие запуска основной формы
        {

            this.Opacity = 0;
            Form3 f = new Form3();
            f.Show();
            timer1.Start();
            deletedisplay = Properties.Settings.Default.deleteddisplay;
            if (deletedisplay) отображатьУдаленныеToolStripMenuItem.Checked = true;

            folderwork();
            FileInfo fin1 = new FileInfo(productnamefile);
            FileInfo fin2 = new FileInfo(holderfile);
            FileInfo fin3 = new FileInfo(cuttinginsertfile);
            FileInfo fin4 = new FileInfo(reportfile);
            FileInfo fin5 = new FileInfo(storagefile);

            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            if (!fin1.Exists)
            {
                FileStream fs = fin1.Create();
                fs.Close();
            }
            if (!fin2.Exists)
            {
                FileStream fs = fin2.Create();
                fs.Close();
            }
            if (!fin3.Exists)
            {
                FileStream fs = fin3.Create();
                fs.Close();
            }
            if (!fin4.Exists)
            {
                FileStream fs = fin4.Create();
                fs.Close();
            }
            if (!fin5.Exists)
            {
                FileStream fs = fin5.Create();
                fs.Close();
            }
            Properties.Settings.Default.firststart = false;
            Properties.Settings.Default.Save();
        
            DGV_H_Label2.Visible = false;
            DGV_P_Label2.Visible = false;
            DGV_PN_Label2.Visible = false;
            DGV_CI_Label2.Visible = false;
            DGV_R_Label2.Visible = false;


            dateTimePicker1.MaxDate = dateTimePicker2.Value;
            dateTimePicker2.MinDate = dateTimePicker1.Value;

            сохранитьToolStripMenuItem.Visible = false; // Невидимый пункт меню
            закрытьToolStripMenuItem.Visible = false;

            filesfix(holderfile, 2);
            filesfix(cuttinginsertfile, 2);
            filesfix(holderfile, 3);
            filesfix(holderfile, 6);
            filesfix(cuttinginsertfile, 3);
            filesfix(cuttinginsertfile, 6);
            filesfix(productnamefile, 1);
            filesfix(holderfile, 7);
            filesfix(cuttinginsertfile, 8);
            filesfix(reportfile, 9);

            refresh();
            refresh_dgv_product_combobox_holder();
            refresh_dgv_product_combobox_cuttinginsert();
            productfolderwork();
            filechangetimer.Enabled = true;

            this.DGV_Product.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Автоперенос слов по выстое в датагриде изделия

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)DGV_Product_Name.Columns["buttondelete"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.BackColor = Color.White;
            c.DefaultCellStyle.SelectionBackColor = Color.LightGray;


            //menuStrip1.BackColor = Color.White;
            buttonclose.BackgroundImage = Properties.Resources.cancelred;
            colorstyle = Properties.Settings.Default.lightstyle;
            colorswitch();

            DGV_Holder.Sort(DGV_Holder.Columns[Properties.Settings.Default.DGV_Holder], Properties.Settings.Default.DGV_Holder_SortDirection);
            DGV_CuttingInsert.Sort(DGV_CuttingInsert.Columns[Properties.Settings.Default.DGV_CuttingInsert], Properties.Settings.Default.DGV_CuttingInsert_SortDirection);
            DGV_Product.Sort(DGV_Product.Columns[Properties.Settings.Default.DGV_Product], Properties.Settings.Default.DGV_Product_SortDirection);
            DGV_Product_Name.Sort(DGV_Product_Name.Columns[Properties.Settings.Default.DGV_Product_Name], Properties.Settings.Default.DGV_Product_Name_SortDirection);
            DGV_Storage.Sort(DGV_Storage.Columns[Properties.Settings.Default.DGV_Storage], Properties.Settings.Default.DGV_Storage_SortDirection);
            if (Properties.Settings.Default.rb_type)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true; 
            }

            toolStripTextBox1.ForeColor = Color.Black;


            if (Properties.Settings.Default.countwork)
            {
                Properties.Settings.Default.countwork = false;
                Properties.Settings.Default.Save();
                refresh_dgv_holder();
                refresh_dgv_cuttinginsert();
            }

            if (tabControl1.TabPages.Contains(tabPage4)) tabControl1.TabPages.Remove(tabPage4);
            if (tabControl1.TabPages.Contains(tabPage7)) tabControl1.TabPages.Remove(tabPage7);
        } 

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) // Событие закрытия окна программы 
        {
            Properties.Settings.Default.deleteddisplay = deletedisplay;

            Properties.Settings.Default.lightstyle = colorstyle;

            Properties.Settings.Default.DGV_Holder = DGV_Holder.SortedColumn.Index;
            if (DGV_Holder.SortOrder == SortOrder.Ascending)
            {
                Properties.Settings.Default.DGV_Holder_SortDirection = System.ComponentModel.ListSortDirection.Ascending;
            }
            else
            {
                Properties.Settings.Default.DGV_Holder_SortDirection = System.ComponentModel.ListSortDirection.Descending;
            }

            Properties.Settings.Default.DGV_CuttingInsert = DGV_CuttingInsert.SortedColumn.Index;
            if (DGV_CuttingInsert.SortOrder == SortOrder.Ascending)
            {
                Properties.Settings.Default.DGV_CuttingInsert_SortDirection = System.ComponentModel.ListSortDirection.Ascending;
            }
            else
            {
                Properties.Settings.Default.DGV_CuttingInsert_SortDirection = System.ComponentModel.ListSortDirection.Descending;
            }

            Properties.Settings.Default.DGV_Product = DGV_Product.SortedColumn.Index;
            if (DGV_Product.SortOrder == SortOrder.Ascending)
            {
                Properties.Settings.Default.DGV_Product_SortDirection = System.ComponentModel.ListSortDirection.Ascending;
            }
            else
            {
                Properties.Settings.Default.DGV_Product_SortDirection = System.ComponentModel.ListSortDirection.Descending;
            }

            Properties.Settings.Default.DGV_Product_Name = DGV_Product_Name.SortedColumn.Index;
            if (DGV_Product_Name.SortOrder == SortOrder.Ascending)
            {
                Properties.Settings.Default.DGV_Product_Name_SortDirection = System.ComponentModel.ListSortDirection.Ascending;
            }
            else
            {
                Properties.Settings.Default.DGV_Product_Name_SortDirection = System.ComponentModel.ListSortDirection.Descending;
            }

            Properties.Settings.Default.DGV_Storage = DGV_Storage.SortedColumn.Index;
            if (DGV_Storage.SortOrder == SortOrder.Ascending)
            {
                Properties.Settings.Default.DGV_Storage_SortDirection = System.ComponentModel.ListSortDirection.Ascending;
            }
            else
            {
                Properties.Settings.Default.DGV_Storage_SortDirection = System.ComponentModel.ListSortDirection.Descending;
            }

            if(radioButton1.Checked )Properties.Settings.Default.rb_type = true;
            else Properties.Settings.Default.rb_type = false;

            Properties.Settings.Default.Save();

            if (DGV_Product_save)
            {
                DialogResult result = MessageBox.Show( // Вывод сообщения о закрытии с возможностью отмены
                "Приложение будет закрыто",
                "Внимание!",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
                //MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Cancel) // Если нажата кнопка "НЕТ" закрытие отменяется
                {
                    e.Cancel = true;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show( // Вывод сообщения о закрытии окна без сохранения с возможностью отмены или выхода с сохранением данных в базе изделий
                "Вы не сохранили изменения данных изделия. Закрыть приложение с сохранением данных?",
                "Внимание!",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                //MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Cancel) // Если нажата кнопка "НЕТ" закрытие отменяется
                {
                    e.Cancel = true;
                }
                if (result == DialogResult.Yes) // Если нажата кнопка "Да" сохраняются данные
                {
                    if (!save_dgv_product(usefileproduct)) e.Cancel = true;
                }
            }

        }

        private void ОбновитьToolStripMenuItem_Click(object sender, EventArgs e) // Событие кнопки обновить в меню
        {
            refresh();

            if (DGV_Product_save)
            {
                if(сохранитьToolStripMenuItem.Visible == true) refresh_dgv_product(usefileproduct);
            }
            else
            {
                DialogResult result = MessageBox.Show(
                "Вы не сохранили изменения данных изделия. Несохраненные данные будут потеряны. Сохранить данные и продолжить?",
                "Внимание!",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                //MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes) // Если нажата кнопка "Да" сохраняются данные
                {
                    refresh_dgv_product(usefileproduct);
                }
                if(result == DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        private void Filechangetimer_Tick(object sender, EventArgs e) // Тик таймера 
        {
            if(Properties.Settings.Default.fileadd)
            {
                fileslabel.Text = "Прикреплено файлов: " + new DirectoryInfo(fileway).GetFiles().Length.ToString();
                Properties.Settings.Default.fileadd = false;
                Properties.Settings.Default.Save();
            }

            if(Properties.Settings.Default.refresh)
            {
                Properties.Settings.Default.refresh = false;
                Properties.Settings.Default.Save();
                refresh();
            }

            if(Properties.Settings.Default.refresh_r)
            {
                refresh_dgv_report();
                Properties.Settings.Default.refresh_r = false;
                Properties.Settings.Default.Save();
            }

            if (filechange(holderfile, hflength))
            {
                refresh_dgv_holder();
                refresh_dgv_product_combobox_holder();
            }
            if (filechange(cuttinginsertfile, ciflength))
            {
                refresh_dgv_cuttinginsert();
                refresh_dgv_product_combobox_cuttinginsert();
            }
            if (filechange(productnamefile, pflength))
            {
                refresh_dgv_product_name();
            }
            if (sortchanges)
            {
                if (DGV_Storage.SortOrder == SortOrder.Ascending)
                {
                    DGV_Storage.Sort(DGV_Storage.SortedColumn, System.ComponentModel.ListSortDirection.Ascending);
                }
                else if (DGV_Storage.SortOrder == SortOrder.Descending)
                {
                    DGV_Storage.Sort(DGV_Storage.SortedColumn, System.ComponentModel.ListSortDirection.Descending);
                }
                sortchanges = false;
            }
            if (sortchangepn)
            {
                if (DGV_Product_Name.SortOrder == SortOrder.Ascending)
                {
                    DGV_Product_Name.Sort(DGV_Product_Name.SortedColumn, System.ComponentModel.ListSortDirection.Ascending);
                }
                else if (DGV_Product_Name.SortOrder == SortOrder.Descending)
                {
                    DGV_Product_Name.Sort(DGV_Product_Name.SortedColumn, System.ComponentModel.ListSortDirection.Descending);
                }
                sortchangepn = false;
            }
            if (sortchangeh)
            {
                if (DGV_Holder.SortOrder == SortOrder.Ascending)
                {
                    DGV_Holder.Sort(DGV_Holder.SortedColumn, System.ComponentModel.ListSortDirection.Ascending);
                }
                else if (DGV_Holder.SortOrder == SortOrder.Descending)
                {
                    DGV_Holder.Sort(DGV_Holder.SortedColumn, System.ComponentModel.ListSortDirection.Descending);
                }
                sortchangeh = false;
            }
            if (sortchangeci)
            {
                if (DGV_CuttingInsert.SortOrder == SortOrder.Ascending)
                {
                    DGV_CuttingInsert.Sort(DGV_CuttingInsert.SortedColumn, System.ComponentModel.ListSortDirection.Ascending);
                }
                else if (DGV_CuttingInsert.SortOrder == SortOrder.Descending)
                {
                    DGV_CuttingInsert.Sort(DGV_CuttingInsert.SortedColumn, System.ComponentModel.ListSortDirection.Descending);
                }
                sortchangeci = false;
            }
        }


        private void DGV_Product_Name_CellDoubleClick(object sender, DataGridViewCellEventArgs e) // Событие двойного клика делает видимой 4 вкладку датагрида и выводит туда данные соотвутствующие названию изделия
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1 && e.RowIndex < DGV_Product_Name.Rows.Count - 1)
            {
                bool cancel = true;
                if (DGV_Product_save)
                {
                    cancel = false;
                }
                else
                {
                    DialogResult result = MessageBox.Show( // Вывод сообщения о закрытии окна без сохранения с возможностью отмены или выхода с сохранением данных в базе изделий
                    "Вы не сохранили изменения данных прошлого Изделия. Сохранить данные и открыть следующе изделие?",
                    "Внимание!",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                    //MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.No) // Если нажата кнопка "НЕТ" проходит открытие без сохранения
                    {
                        cancel = false;
                    }
                    if (result == DialogResult.Yes) // Если нажата кнопка "Да" сохраняются данные и открывается след. изделие
                    {
                        if (save_dgv_product(usefileproduct)) cancel = false;
                        else cancel = true;
                    }
                }

                if (cancel == false)
                {
                    if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && e.ColumnIndex != 2)
                    {
                        DataGridViewCell cell = (DataGridViewCell)DGV_Product_Name.Rows[e.RowIndex].Cells["Product_Name"];
                        tabPage4.Text = $"Изделие: {cell.Value}";
                        сохранитьToolStripMenuItem.Text = $"Сохранить данные {cell.Value}";
                        сохранитьToolStripMenuItem.Visible = true;
                        закрытьToolStripMenuItem.Text = $"Закрыть данные {cell.Value}";
                        закрытьToolStripMenuItem.Visible = true;


                        productname = Convert.ToString(cell.Value);
                        for (int i = 0; i < r.Length; i++)
                        {
                            if (productname.Substring(productname.Length-1) == r[i])
                            {
                                productname = productname + "0";
                                break;
                            }
                        }

                        if (productname != "")
                        {
                            productfolder(productname);
                        }

                        refresh_dgv_product(usefileproduct);
                        refresh_dgv_product_combobox_holder();
                        refresh_dgv_product_combobox_cuttinginsert();
                        fileway = folderpathmain + folderpathproductdata + @"\" + productfolder2(Convert.ToString(cell.Value)) + @"\File";

                        sortchangepn = true;

                        if (!tabControl1.TabPages.Contains(tabPage4)) tabControl1.TabPages.Add(tabPage4);
                        tabControl1.SelectedTab = tabPage4;
                    }
                }

            }
            else
            {
                if(productclose())
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < DGV_Product_Name.Rows.Count - 1)
                    {
                        refresh_dgv_product_name();
                        if (DGV_Product_Name.SortOrder == SortOrder.Ascending)
                        {
                            DGV_Product_Name.Sort(DGV_Product_Name.SortedColumn, System.ComponentModel.ListSortDirection.Ascending);
                        }
                        else
                        {
                            DGV_Product_Name.Sort(DGV_Product_Name.SortedColumn, System.ComponentModel.ListSortDirection.Descending);
                        }
                        DataGridViewCell cell1 = (DataGridViewCell)DGV_Product_Name.Rows[e.RowIndex].Cells[0];
                        DataGridViewCell cell2 = (DataGridViewCell)DGV_Product_Name.Rows[e.RowIndex].Cells[1];
                        DataGridViewCell cell3 = (DataGridViewCell)DGV_Product_Name.Rows[e.RowIndex].Cells[2];

                        string datastatus = "True";
                        if (DGV_Product_Name.Rows[e.RowIndex].DefaultCellStyle.BackColor == deletecolor) datastatus = "False";

                        string data = $"{Convert.ToString(cell1.Value)}|{Convert.ToString(cell2.Value)}|{Convert.ToString(cell3.Value)}|{datastatus}";

                        sortchangeh = true;

                        if (tabControl1.TabPages.Contains(tabPage4)) tabControl1.TabPages.Remove(tabPage4);
                        Open_AddForm(3, "Редактировать", изделиеToolStripMenuItem.Text, data);
                    }
                }
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex == DGV_Product_Name.Rows.Count - 1)
                {
                    refresh_dgv_product_name();
                    if (tabControl1.TabPages.Contains(tabPage4)) tabControl1.TabPages.Remove(tabPage4);
                    Open_AddForm(3, добавитьToolStripMenuItem.Text, изделиеToolStripMenuItem.Text, "");
                }

            }
        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e) // Событие нажатия ФайЛ > сохранить 
        {
            if (save_dgv_product(usefileproduct))
                MessageBox.Show(
                    $"Данные изделия {tabPage4.Text.Replace("Изделие: ", "")} сохранены",
                    "Внимание!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                //MessageBoxOptions.DefaultDesktopOnly);
        }

        private void DGV_Product_CellEndEdit(object sender, DataGridViewCellEventArgs e) // Событие изменение содержимого ячейки датагрида изделий
        {
            DGV_PN_Label1.Text =  $"Отображено строк: {Convert.ToString(DGV_Product.Rows.Count - 1)}";

            refresh_dgv_product_combobox_holder();
            refresh_dgv_product_combobox_cuttinginsert();
            NumerateCells();

            //if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            //{
            //    DataGridViewCell cell1 = (DataGridViewCell)DGV_Product.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    DGV_Product["MHolder", e.RowIndex].Value = refresh_combobox_value(holderfile, Convert.ToString(cell1.Value));
            //}

            //if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            //{
            //    DataGridViewCell cell2 = (DataGridViewCell)DGV_Product.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    DGV_Product["MCuttingInsert", e.RowIndex].Value = refresh_combobox_value(cuttinginsertfile, Convert.ToString(cell2.Value));
            //}

            DGV_Product_save = false;
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void DGV_Product_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DGV_Product.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DGV_Holder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < DGV_Holder.RowCount - 1)
            {
                refresh_dgv_holder();
                if (DGV_Holder.SortOrder == SortOrder.Ascending)
                {
                    DGV_Holder.Sort(DGV_Holder.SortedColumn, System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    DGV_Holder.Sort(DGV_Holder.SortedColumn, System.ComponentModel.ListSortDirection.Descending);
                }
                DataGridViewCell cell1 = (DataGridViewCell)DGV_Holder.Rows[e.RowIndex].Cells[0];
                DataGridViewCell cell2 = (DataGridViewCell)DGV_Holder.Rows[e.RowIndex].Cells[1];
                DataGridViewCell cell3 = (DataGridViewCell)DGV_Holder.Rows[e.RowIndex].Cells[2];
                DataGridViewCell cell4 = (DataGridViewCell)DGV_Holder.Rows[e.RowIndex].Cells[3];
                DataGridViewCell cell5 = (DataGridViewCell)DGV_Holder.Rows[e.RowIndex].Cells[4];
                DataGridViewCell cell6 = (DataGridViewCell)DGV_Holder.Rows[e.RowIndex].Cells[5];

                string datastatus = "True";
                if (DGV_Holder.Rows[e.RowIndex].DefaultCellStyle.BackColor == deletecolor) datastatus = "False";

                string data = $"{Convert.ToString(cell1.Value)}|{Convert.ToString(cell2.Value)}|{Convert.ToString(cell3.Value)}|{datastatus}|{Convert.ToString(cell6.Value)}|{Convert.ToString(cell5.Value)}|{Convert.ToString(cell4.Value)}";

                sortchangeh = true;

                Open_AddForm(1, "Редактировать", державкуToolStripMenuItem.Text, data);
            }
            if(e.RowIndex == DGV_Holder.Rows.Count-1)
            {
                refresh_dgv_holder();
                Open_AddForm(1, добавитьToolStripMenuItem.Text, державкуToolStripMenuItem.Text, "");
            }
        }

        private void DGV_CuttingInsert_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < DGV_CuttingInsert.RowCount - 1)
            {
                refresh_dgv_cuttinginsert();
                if (DGV_CuttingInsert.SortOrder == SortOrder.Ascending)
                {
                    DGV_CuttingInsert.Sort(DGV_CuttingInsert.SortedColumn, System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    DGV_CuttingInsert.Sort(DGV_CuttingInsert.SortedColumn, System.ComponentModel.ListSortDirection.Descending);
                }
                DataGridViewCell cell1 = (DataGridViewCell)DGV_CuttingInsert.Rows[e.RowIndex].Cells[0];
                DataGridViewCell cell2 = (DataGridViewCell)DGV_CuttingInsert.Rows[e.RowIndex].Cells[1];
                DataGridViewCell cell3 = (DataGridViewCell)DGV_CuttingInsert.Rows[e.RowIndex].Cells[2];
                DataGridViewCell cell4 = (DataGridViewCell)DGV_CuttingInsert.Rows[e.RowIndex].Cells[3];
                DataGridViewCell cell5 = (DataGridViewCell)DGV_CuttingInsert.Rows[e.RowIndex].Cells[4];
                DataGridViewCell cell6 = (DataGridViewCell)DGV_CuttingInsert.Rows[e.RowIndex].Cells[5];

                string datastatus = "True";
                if (DGV_CuttingInsert.Rows[e.RowIndex].DefaultCellStyle.BackColor == deletecolor) datastatus = "False";

                string data = $"{Convert.ToString(cell1.Value)}|{Convert.ToString(cell2.Value)}|{Convert.ToString(cell3.Value)}|{datastatus}|{Convert.ToString(cell6.Value)}|{Convert.ToString(cell5.Value)}|{Convert.ToString(cell4.Value)}";

                sortchangeci = true;

                Open_AddForm(2, "Редактировать", режущуюПластинуToolStripMenuItem.Text, data);
            }
            if (e.RowIndex == DGV_CuttingInsert.Rows.Count-1)
            {
                refresh_dgv_cuttinginsert();
                Open_AddForm(2, добавитьToolStripMenuItem.Text, режущуюПластинуToolStripMenuItem.Text, "");
            }
        }

        private void DGV_Product_Name_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Код для кнопки Удалиить

            //if (e.ColumnIndex == 2 && e.RowIndex != DGV_Product_Name.Rows.Count-1)
            //{
            //    DataGridViewButtonColumn c = (DataGridViewButtonColumn)DGV_Product_Name.Columns["buttondelete"];
            //    DataGridViewCellStyle ce = (DataGridViewCellStyle)DGV_Product_Name.Rows[e.RowIndex].DefaultCellStyle;
            //    ce.BackColor = Color.Red;
            //    c.FlatStyle = FlatStyle.Standard;

            //    bool cancel = false;
            //    DialogResult result = MessageBox.Show( // Вывод сообщения о закрытии окна без сохранения с возможностью отмены или выхода с сохранением данных в базе изделий
            //    $"Вы пытаеть удалить данные изделия {Convert.ToString(DGV_Product_Name["Product_Name", e.RowIndex].Value)}! Продолжить удаление?",
            //    "Внимание!",
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Exclamation,
            //    MessageBoxDefaultButton.Button2);
            //    //MessageBoxOptions.DefaultDesktopOnly);
            //    if (result == DialogResult.No)
            //    {
            //        cancel = true;
            //    }
            //    if (result == DialogResult.Yes) // Если нажата кнопка "Да" сохраняются данные и открывается след. изделие
            //    {
            //        cancel = false;
            //    }
            //    if (!cancel)
            //    {
            //        if (e.RowIndex == 0)
            //        {
            //            string editdata = Convert.ToString(DGV_Product_Name["ID", e.RowIndex].Value + "|" + DGV_Product_Name["Product_Name", e.RowIndex].Value) + "\r\n";
            //            string text = File.ReadAllText(productnamefile);
            //            text = text.Replace(editdata, null);
            //            File.WriteAllText(productnamefile, text);
            //        }
            //        else if (e.RowIndex > 0)
            //        {
            //            string editdata = "\r\n" + Convert.ToString(DGV_Product_Name["ID", e.RowIndex].Value + "|" + DGV_Product_Name["Product_Name", e.RowIndex].Value);
            //            string text = File.ReadAllText(productnamefile);
            //            text = text.Replace(editdata, null);
            //            File.WriteAllText(productnamefile, text);
            //        }
            //    }
            //    ce.BackColor = System.Drawing.Color.White;
            //    c.FlatStyle = FlatStyle.Popup;
            //}
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            fileloadform f = new fileloadform(fileway, colorstyle, color1, colorf, color2, colorf1);
            f.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Process PrFolder = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.FileName = "explorer";
            psi.Arguments = fileway;
            PrFolder.StartInfo = psi;
            PrFolder.Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo drstring = new DirectoryInfo(fileway);
            FileInfo[] filescount = drstring.GetFiles();
            if (filescount.Length != 0)
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    int i = 0;
                    foreach (FileInfo fi in drstring.GetFiles("."))
                    {
                        fi.CopyTo(folderBrowser.SelectedPath + @"\" + fi.Name, true);
                        i++;
                    }

                    MessageBox.Show(
                    $"{i} файлов скопировано в папку {folderBrowser.SelectedPath}",
                    "Внимание!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                    Process PrFolder = new Process();
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.CreateNoWindow = true;
                    psi.WindowStyle = ProcessWindowStyle.Normal;
                    psi.FileName = "explorer";
                    psi.Arguments = folderBrowser.SelectedPath;
                    PrFolder.StartInfo = psi;
                    PrFolder.Start();
                }
            }
            else
            {
                MessageBox.Show(
                    $"Не найдено файлов привязанных к изделию {productname}",
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
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                if(colorstyle) buttonfullscreen.BackgroundImage = Properties.Resources.expand;
                else buttonfullscreen.BackgroundImage = Properties.Resources.expandl;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                if (colorstyle) buttonfullscreen.BackgroundImage = Properties.Resources.minimize;
                else buttonfullscreen.BackgroundImage = Properties.Resources.minimizel;
            }
        }

        private void MenuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);

        }

        private void Buttonroll_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ВидToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        int ti = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(ti>=250)
            {
                this.Opacity = this.Opacity + 0.01;
            }
            if(this.Opacity == 1)
            {
                timer1.Stop();
            }
            ti++;
        }

        private void ИзделиеToolStripMenuItem_Click_1(object sender, EventArgs e) // Нажатие на вкладку менюстрип Добавить >> Изделие
        {
            refresh_dgv_product_name();
            Open_AddForm(3, добавитьToolStripMenuItem.Text, изделиеToolStripMenuItem.Text, "");
        }

        private void РежущуюПластинуToolStripMenuItem_Click_1(object sender, EventArgs e) // Нажатие на вкладку менюстрип Добавить >> Режущую Пластину
        {
            refresh_dgv_cuttinginsert();
            Open_AddForm(2, добавитьToolStripMenuItem.Text, режущуюПластинуToolStripMenuItem.Text, "");
        }

        private void ДержавкуToolStripMenuItem_Click_1(object sender, EventArgs e) // Нажатие на вкладку менюстрип Добавить >> Державку
        {
            refresh_dgv_holder();
            Open_AddForm(1, добавитьToolStripMenuItem.Text, державкуToolStripMenuItem.Text, "");
        }

        private void СменитьТемуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorstyle)
            {
                colorstyle = false;
                colorswitch();
            }
            else
            {
                colorstyle = true;
                colorswitch();
            }
        }

        private void ОтображатьУдаленныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (отображатьУдаленныеToolStripMenuItem.Checked)
            {
                отображатьУдаленныеToolStripMenuItem.Checked = false;
                deletedisplay = false;
            }
            else
            {
                отображатьУдаленныеToolStripMenuItem.Checked = true;
                deletedisplay = true;
            }
            refresh();
        }

        private void ПоискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search();
            t2s = false;
            timer2.Start();
        }

        bool t2s;
        private void ToolStripTextBox1_Enter(object sender, EventArgs e)
        {
            t2s = true;
            timer2.Start();
        }

        private void ToolStripTextBox1_Leave(object sender, EventArgs e)
        {
            t2s = false;
            timer3.Start();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            int i = toolStripTextBox1.Width;

            if (t2s)
            {
                i = i + 5;
                if (i <= 300)
                {
                    toolStripTextBox1.Size = new Size(i, toolStripTextBox1.Height);
                }
                else
                {
                    timer2.Stop();
                }
            }
            else
            {
                i = i-5;
                if (i >= 100)
                {
                    toolStripTextBox1.Size = new Size(i, toolStripTextBox1.Height);
                }
                else
                {
                    timer2.Stop();
                }
            }
            // if (t2s) for (int i = toolStripTextBox1.Width; i < 200; i++) toolStripTextBox1.Size = new Size(i, toolStripTextBox1.Height);
            // else for (int i = toolStripTextBox1.Width; i >= 100; i--) toolStripTextBox1.Size = new Size(i, toolStripTextBox1.Height);
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            timer2.Start();
            timer3.Stop();
        }

        private void СохранитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            save_dgv_product(usefileproduct);
        }

        private void ЗакрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(productclose())
            {
                сохранитьToolStripMenuItem.Visible = false;
                закрытьToolStripMenuItem.Visible = false;
                if (tabControl1.TabPages.Contains(tabPage4)) tabControl1.TabPages.Remove(tabPage4);
            }
        }

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(tabControl1.SelectedTab == tabPage5) datastats();
            if(tabControl1.SelectedTab == tabPage4)
            {
                сохранитьToolStripMenuItem.Visible = true;
                закрытьToolStripMenuItem.Visible = true;
            }
            else
            {
                сохранитьToolStripMenuItem.Visible = false; // Невидимый пункт меню
                закрытьToolStripMenuItem.Visible = false;
            }
            if (tabControl1.SelectedTab != tabPage7)
            {
                if (tabControl1.TabPages.Contains(tabPage7)) tabControl1.TabPages.Remove(tabPage7);
            }
            else
            {
                refresh_dgv_ar();
            }

        }

        private void DGV_Report2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < DGV_Report.RowCount - 1 )
            {
                bool cancel = false;
                if (e.ColumnIndex == DGV_Report.Columns["rpname"].Index && DGV_Report[0,e.RowIndex].Value != null && DGV_Report[0, e.RowIndex].Value != "")
                {
                    cancel = true;

                    DataGridViewCell cell = (DataGridViewCell)DGV_Report.Rows[e.RowIndex].Cells["rpname"];
                    tabPage4.Text = $"Изделие: {cell.Value}";
                    сохранитьToolStripMenuItem.Text = $"Сохранить данные {cell.Value}";
                    сохранитьToolStripMenuItem.Visible = true;
                    закрытьToolStripMenuItem.Text = $"Закрыть данные {cell.Value}";
                    закрытьToolStripMenuItem.Visible = true;


                    productname = Convert.ToString(cell.Value);
                    for (int i = 0; i < r.Length; i++)
                    {
                        if (productname.Substring(productname.Length - 1) == r[i])
                        {
                            productname = productname + "0";
                            break;
                        }
                    }

                    if (productname != "")
                    {
                        productfolder(productname);
                    }

                    refresh_dgv_product(usefileproduct);
                    refresh_dgv_product_combobox_holder();
                    refresh_dgv_product_combobox_cuttinginsert();
                    fileway = folderpathmain + folderpathproductdata + @"\" + Convert.ToString(cell.Value) + @"\File";

                    sortchangepn = true;

                    if (!tabControl1.TabPages.Contains(tabPage4)) tabControl1.TabPages.Add(tabPage4);
                    tabControl1.SelectedTab = tabPage4;
                }
                DataGridViewCell cell1 = (DataGridViewCell)DGV_Report.Rows[e.RowIndex].Cells[0];
                if (cell1.Value == null || cell1.Value == "") cancel = true;
                if (!cancel)
                {
                    DataGridViewCell cell2 = (DataGridViewCell)DGV_Report.Rows[e.RowIndex].Cells[1];
                    DataGridViewCell cell3 = (DataGridViewCell)DGV_Report.Rows[e.RowIndex].Cells[2];
                    DataGridViewCell cell4 = (DataGridViewCell)DGV_Report.Rows[e.RowIndex].Cells[3];
                    DataGridViewCell cell5 = (DataGridViewCell)DGV_Report.Rows[e.RowIndex].Cells[4];
                    DataGridViewCell cell6 = (DataGridViewCell)DGV_Report.Rows[e.RowIndex].Cells[5];
                    DataGridViewCell cell7 = (DataGridViewCell)DGV_Report.Rows[e.RowIndex].Cells[6];
                    DataGridViewCell cell8 = (DataGridViewCell)DGV_Report.Rows[e.RowIndex].Cells[7];
                    //refresh_dgv_holder();
                    if (DGV_Report.SortOrder == SortOrder.Ascending)
                    {
                        DGV_Report.Sort(DGV_Report.SortedColumn, System.ComponentModel.ListSortDirection.Ascending);
                    }
                    else if (DGV_Report.SortOrder == SortOrder.Descending)
                    {
                        DGV_Report.Sort(DGV_Report.SortedColumn, System.ComponentModel.ListSortDirection.Descending);
                    }

                    string datastatus = "True";
                    if (DGV_Report.Rows[e.RowIndex].DefaultCellStyle.BackColor == deletecolor) datastatus = "False";
                    string[] dat = cell6.Value.ToString().Split(" ".ToCharArray());
                    string[] datet = { $"{dat[0]} {dat[1]} {dat[2]}", dat[3] };
                    string data = $"{Convert.ToString(cell1.Value)}|{ Convert.ToString(cell2.Value)}|{ Convert.ToString(cell3.Value)}|{Convert.ToString(cell4.Value)}|{Convert.ToString(cell5.Value)}|{datet[0] + $" [{cell7.Value.ToString()}]"}|{Convert.ToString(cell8.Value)}|{datastatus}";

                    Form4 f4 = new Form4(1, "Редактировать", "данные", data, colorstyle, color1, colorf, color2, colorf1);
                    f4.ShowDialog();
                }
            }
            else if (e.RowIndex == DGV_Report.Rows.Count - 1 && DGV_Report[e.ColumnIndex, e.RowIndex].Style.BackColor != color3)
            {
                Form4 f4 = new Form4(1,"Добавить", "данные", "", colorstyle, color1, colorf, color2, colorf1);
                f4.ShowDialog();
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = dateTimePicker2.Value;
            dateTimePicker2.MinDate = dateTimePicker1.Value;
            refresh_dgv_report();
        }


        private void Button4_Click(object sender, EventArgs e)
        {
            DGV_Report.Columns["rother"].Visible = false;
            DGV_Report.Columns["rdate"].Visible = false;

            int i = DGV_Report.Rows.Count-1;
            DGV_Report.Rows.Add();
            DGV_Report["rpname", i].Value = "Итого: ";
            DGV_Report["rmtime", i].Value = nm;
            DGV_Report["rquantity", i].Value = nq;
            DGV_Report["ratime", i].Value = na;
            DGV_Report.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;

            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Отчет";
            printer.SubTitle = $"Дата: {dateTimePicker1.Value} - {dateTimePicker2.Value}";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "TOOLS Наладчика";
            printer.FooterSpacing = 15;
            printer.PrinterName = "Microsoft Print to PDF";
            printer.PrintDataGridView(DGV_Report);

            DGV_Report.Columns["rother"].Visible = true;
            DGV_Report.Columns["rdate"].Visible = true;
            refresh_dgv_report();
        }


        private void ToolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            search();
        }

        private void Buttonradd_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(1,"Добавить", "данные", "", colorstyle, color1, colorf, color2, colorf1);
            f4.ShowDialog();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                if (colorstyle) buttonfullscreen.BackgroundImage = Properties.Resources.minimize;
                else buttonfullscreen.BackgroundImage = Properties.Resources.minimizel;
            }
            else
            {
                if (colorstyle) buttonfullscreen.BackgroundImage = Properties.Resources.expand;
                else buttonfullscreen.BackgroundImage = Properties.Resources.expandl;
            }
        }

        private void DGV_Product_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int res;
            if (e.ColumnIndex == DGV_Product.Columns["pqua"].Index)
            {
                if (e.FormattedValue.ToString() == string.Empty)
                    return;
                else
                    if (!int.TryParse(e.FormattedValue.ToString(), out res) || e.FormattedValue.ToString().Length > 10)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void DGV_Product_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex != 0)
            {
                for (int j = 0; j < DGV_Product.Columns.Count; j++)
                {
                    if (DGV_Product.Columns["MCuttingInsert"].Index != j && DGV_Product.Columns["MHolder"].Index != j)
                    {
                        if (Convert.ToString(DGV_Product[j, e.RowIndex - 1].Value) == "" && j != DGV_Product.Columns["Note"].Index && j != DGV_Product.Columns["ProductProgramm"].Index)
                        {
                            MessageBox.Show(
                                "Все поля должны быть заполнены!",
                                "Внимание!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                            e.Cancel = true;
                            break;
                        }
                    }
                }
            }
        }

        private void DGV_Storage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < DGV_Storage.RowCount - 1 && DGV_Storage["snote",e.RowIndex].Value.ToString() != "Отчет")
            {
                refresh_dgv_storage();
                if (DGV_Storage.SortOrder == SortOrder.Ascending)
                {
                    DGV_Storage.Sort(DGV_Storage.SortedColumn, System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    DGV_Storage.Sort(DGV_Storage.SortedColumn, System.ComponentModel.ListSortDirection.Descending);
                }
                DataGridViewCell cell1 = (DataGridViewCell)DGV_Storage.Rows[e.RowIndex].Cells[0];
                DataGridViewCell cell2 = (DataGridViewCell)DGV_Storage.Rows[e.RowIndex].Cells[1];
                DataGridViewCell cell3 = (DataGridViewCell)DGV_Storage.Rows[e.RowIndex].Cells[2];
                DataGridViewCell cell4 = (DataGridViewCell)DGV_Storage.Rows[e.RowIndex].Cells[3];
                DataGridViewCell cell5 = (DataGridViewCell)DGV_Storage.Rows[e.RowIndex].Cells[4];
                DataGridViewCell cell6 = (DataGridViewCell)DGV_Storage.Rows[e.RowIndex].Cells[5];
                DataGridViewCell cell8 = (DataGridViewCell)DGV_Storage.Rows[e.RowIndex].Cells[6];


                string datastatus = "True";
                string[] stl = Convert.ToString(cell2.Value).Split("|".ToCharArray());
                stl[0] = stl[0].TrimEnd(' ');
                stl[1] = stl[1].TrimStart(' ');
                string id = idfinder(true, cuttinginsertfile, stl[0], stl[1]);
                if(id == "") id = idfinder(true, holderfile, stl[0], stl[1]);
                if (DGV_Storage.Rows[e.RowIndex].DefaultCellStyle.BackColor == deletecolor) datastatus = "False";

                string data = $"{Convert.ToString(cell1.Value)}|{id}|{Convert.ToString(cell3.Value)}|{Convert.ToString(cell8.Value)}|{Convert.ToString(cell5.Value)}|{Convert.ToString(cell6.Value)}|{datastatus}|{Convert.ToString(cell4.Value)}";

                //sortchangeh = true;

                Form4 f4 = new Form4(2, "Редактировать", "данные", data, colorstyle, color1, colorf, color2, colorf1);
                f4.ShowDialog();
            }
            if (e.RowIndex == DGV_Storage.Rows.Count - 1)
            {
                refresh_dgv_storage();
                Form4 f4 = new Form4(2, "Добавить", "данные", "", colorstyle, color1, colorf, color2, colorf1);
                f4.ShowDialog();
            }
        }

        private void ОбновитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            refresh_dgv_storage();
            Form4 f4 = new Form4(2, "Добавить", "данные", "", colorstyle, color1, colorf, color2, colorf1);
            f4.ShowDialog();
        }

        private void BT_AllReports_Click(object sender, EventArgs e)
        {
            if (!tabControl1.TabPages.Contains(tabPage7)) tabControl1.TabPages.Add(tabPage7);
            refresh_dgv_ar();
            dgvarrvisible(false);
            AR_delete.Visible = false;
            //AR_edit.Text = "Редактировать";
            tabPage7.Text = "Список отчетов";
            tabControl1.SelectedTab = tabPage7;

            L2_AR.Visible = false;
        }

        private void BT_ReportSave_Click(object sender, EventArgs e)
        {
            string rfile = $"{dateTimePicker1.Value.ToString("dd MMMM yyyy")} - {dateTimePicker2.Value.ToString("dd MMMM yyyy")}";
            rfile = folderpathmain + folderallreport + @"\" + rfile;

            bool u = true;
            bool m = true;
            bool cancel = true;
            int i = 0;
            while (u)
            {
                i++;
                string g = rfile + $" [{i}]";
                FileInfo fi = new FileInfo(g);
                if (fi.Exists)
                {
                    if (m)
                    {
                        m = false;
                        DialogResult result = MessageBox.Show(
                                    $"Отчет за {dateTimePicker1.Value.ToString("dd MMMM yyyy")} - {dateTimePicker2.Value.ToString("dd MMMM yyyy")} уже существует! Вы хотите создать еще один отчет?",
                                    "Внимание!",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.No)
                        {
                            cancel = true;
                            break;
                        }
                        if (result == DialogResult.Yes)
                        {
                            cancel = false;
                        }
                    }
                }
                else
                {
                    FileStream fs = fi.Create();
                    fs.Close();
                    rfile = g;
                    u = false;
                }
            }

            if (cancel == true && m == true) cancel = false;

            if (!cancel)
            {
                DGV_Report.Columns["rother"].Visible = false;
                DGV_Report.Columns["rdate"].Visible = false;

                i = DGV_Report.Rows.Count - 1;
                DGV_Report.Rows.Add();
                DGV_Report["rpname", i].Value = "Итого: ";
                DGV_Report["rmtime", i].Value = nm;
                DGV_Report["rquantity", i].Value = nq;
                DGV_Report["ratime", i].Value = na;
                DGV_Report.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;

                string text = "";
                for (i = 0; i < DGV_Report.Rows.Count-1; i++)
                {
                    string line = DGV_Report.Rows[i].DefaultCellStyle.BackColor.ToArgb().ToString();
                    for (int j = 0; j < DGV_Report.Columns.Count; j++)
                    {
                        if (DGV_Report.Columns[j].Visible == true)
                        {
                            string h;
                            if (DGV_Report[j, i].Value != null) h = DGV_Report[j, i].Value.ToString();
                            else h = "";
                            line = line + $"|{h}";
                        }
                    }
                    text = text + line + "\r\n";
                }

                DGV_Report.Columns["rother"].Visible = true;
                DGV_Report.Columns["rdate"].Visible = true;
                refresh_dgv_report();

                File.WriteAllText(rfile, text);
                MessageBox.Show(
                                    $"Отчет сохранен!",
                                    "Внимание!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1);


            }
        }

        private void DGV_AR_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex < DGV_AR.RowCount - 1)
            {
                dgvarrvisible(true);
                refresh_dgv_arr(DGV_AR[DGV_AR.Columns["AR_Date"].Index,e.RowIndex].Value.ToString());
            }
        }

        private void DGV_ARR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //bool arr_editmode = false;
        private void AR_edit_Click(object sender, EventArgs e)
        {
            //if(arr_editmode)
            //{
            //    //AR_edit.Text = "Редактировать";
            //    refresh_dgv_arr(tabPage7.Text);
            //    AR_delete.Visible = false;
            //   // AR_save.Visible = false;
            //}
            //else
            //{
            //    refresh_dgv_arr(tabPage7.Text);
            //    //AR_edit.Text = "Отмена";
            //    AR_delete.Visible = true;
            //    arr_editmode = true;
            //    for (int i = 0; i < DGV_ARR.Columns.Count; i++)
            //    {
            //        DGV_ARR.Columns[i].ReadOnly = false;
            //    }
            //    DGV_ARR.Rows[DGV_ARR.RowCount-1].ReadOnly = true;
            //}
        }

        private void AR_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                                    $"Отчет {tabPage7.Text} будет безвозвратно удален! Вы уверены что хотите это сделать?",
                                    "Внимание!",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);
            if(result == DialogResult.Yes)
            {
                File.Delete(folderpathmain + folderallreport + @"\" + tabPage7.Text);

                AR_delete.Visible = false;
                tabControl1.SelectedTab = tabPage5;
                //arr_editmode = false;
                if (tabControl1.TabPages.Contains(tabPage7)) tabControl1.TabPages.Remove(tabPage7);
            }
        }

        private void AR_print_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Отчет";
            printer.SubTitle = $"Дата: {tabPage7.Text.TrimEnd("[123456789]".ToCharArray())}";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "TOOLS Наладчика";
            printer.FooterSpacing = 15;
            printer.PrinterName = "Microsoft Print to PDF";
            printer.PrintDataGridView(DGV_ARR);
        }

        private void ToolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Process PrFolder = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.FileName = "explorer";
            psi.Arguments = folderpathmain + folderallreport;
            PrFolder.StartInfo = psi;
            PrFolder.Start();
        }

        private void RadioButton1_Click(object sender, EventArgs e)
        {
            refresh_dgv_report();
        }
    }
}

     
