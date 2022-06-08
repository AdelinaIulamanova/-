using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Тестовое_задание_ООО_НПК_ПРОГРЕСС_
{
    public partial class Patientviewing : UserControl
    {
        public Patientviewing()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("", "Ид Пациента");
            dataGridView1.Columns.Add("", "Фамилия");
            dataGridView1.Columns.Add("", "Имя");
            dataGridView1.Columns.Add("", "Отчество");
            dataGridView1.Columns.Add("", "Дата рождения");
            dataGridView1.Columns.Add("", "Телефон");

        }
        public void Active()
        {
            dataGridView1.Rows.Clear();
            Menu menu = Menu.Initialize();
            List<List<string>> patientviewing = menu.Patientviewing1();
            if (patientviewing != null)
                for (int i = 0; i < patientviewing.Count; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    for (int j = 0; j < 6; j++)
                        row.Cells[j].Value = patientviewing[i][j];
                    dataGridView1.Rows.Add(row);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Menu menu = Menu.Initialize();
            List<List<string>> patientviewing = menu.Patientviewing2(textBox1.Text,textBox2.Text,Convert.ToInt32( numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
            if (patientviewing != null)
                for (int i = 0; i < patientviewing.Count; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    for (int j = 0; j < 6; j++)
                        row.Cells[j].Value = patientviewing[i][j];
                    dataGridView1.Rows.Add(row);
                }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string patientid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            var visitviewing = new Visitviewing();
            visitviewing.Patientid(patientid);
            visitviewing.Active();
            this.Controls.Clear();
            this.Controls.Add(visitviewing);
        }
    }
}
