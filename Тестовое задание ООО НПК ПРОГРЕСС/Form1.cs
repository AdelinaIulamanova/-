using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Тестовое_задание_ООО_НПК_ПРОГРЕСС_
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var patientinput = new Patientinput();
            panel1.Controls.Add(patientinput);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var visitinput = new Visitinput();
            panel1.Controls.Add(visitinput);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var patientviewing = new Patientviewing();
            patientviewing.Active();
            panel1.Controls.Add(patientviewing);
        }
    }
}
