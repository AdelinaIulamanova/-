using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Тестовое_задание_ООО_НПК_ПРОГРЕСС_
{
    public partial class Visitinput : UserControl
    {
        public Visitinput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = Menu.Initialize();
            string diagnosis = comboBox1.Text + numericUpDown1.Value.ToString() + numericUpDown2.Value.ToString();
            menu.Addvisit(textBox1.Text, dateTimePicker1.Value, diagnosis, textBox2.Text);
        }
    }
}
