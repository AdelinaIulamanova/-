using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Тестовое_задание_ООО_НПК_ПРОГРЕСС_
{
    public partial class Patientinput : UserControl
    {
        public Patientinput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = Menu.Initialize();
            menu.Addpatient(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Value, textBox5.Text);
        }
    }
}
