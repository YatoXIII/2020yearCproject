using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        int ti = 0;

        private void Form3_Load(object sender, EventArgs e)
        {
            this.AllowTransparency = true;
            this.BackColor = Color.AliceBlue;//цвет фона  
            this.TransparencyKey = this.BackColor;

            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ti < 100)
            {
                this.Opacity = this.Opacity + 0.01;
            }
            if(ti>=200 && ti<300)
            {
                this.Opacity = this.Opacity - 0.01;
            }
            if(ti>300)
            {
                timer1.Stop();
                this.Close();
            }


           ti++;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
