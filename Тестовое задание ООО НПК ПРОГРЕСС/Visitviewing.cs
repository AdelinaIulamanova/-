using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Тестовое_задание_ООО_НПК_ПРОГРЕСС_
{
    public partial class Visitviewing : UserControl
    {
        string patientid="";
        public Visitviewing()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("", "Ид посещения");
            dataGridView1.Columns.Add("", "Дата посещения");
            dataGridView1.Columns.Add("", "Диагноз");
        }

        public void Patientid(string patid)
        {
            patientid = patid;
        }
        public void Active()
        {
            dataGridView1.Rows.Clear();
            Menu menu = Menu.Initialize();
            List<List<string>> visitviewing = menu.Visitviewing(patientid);
            if(visitviewing!=null)
            for (int i = 0; i < visitviewing.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                for (int j = 0; j < 3; j++)
                    row.Cells[j].Value = visitviewing[i][j];
                dataGridView1.Rows.Add(row);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = Menu.Initialize();
            List<List<string>> visitviewing = menu.Visitviewing(patientid);
            List<string> patientviewing = menu.Patientviewing(patientid);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"xmltest.xml");
            XmlElement xRoot = xmlDocument.DocumentElement;
            XmlElement patientElement = xmlDocument.CreateElement("patient");
            XmlAttribute patientidAttr = xmlDocument.CreateAttribute("patientid");
            XmlElement surnameElement = xmlDocument.CreateElement("surname");
            XmlElement nameElement = xmlDocument.CreateElement("name");
            XmlElement patronymicElement = xmlDocument.CreateElement("patronymic");
            XmlElement datebirthElement = xmlDocument.CreateElement("datebirth");
            XmlElement telephoneElement = xmlDocument.CreateElement("telephone");
            XmlText patientidText = xmlDocument.CreateTextNode(patientviewing[0]);
            XmlText surnameText = xmlDocument.CreateTextNode(patientviewing[1]);
            XmlText nameText = xmlDocument.CreateTextNode(patientviewing[2]);
            XmlText patronymicText = xmlDocument.CreateTextNode(patientviewing[3]);
            XmlText datebirthText = xmlDocument.CreateTextNode(patientviewing[4]);
            XmlText telephoneText = xmlDocument.CreateTextNode(patientviewing[5]);
            patientidAttr.AppendChild(patientidText);
            surnameElement.AppendChild(surnameText);
            nameElement.AppendChild(nameText);
            patronymicElement.AppendChild(patronymicText);
            datebirthElement.AppendChild(datebirthText);
            telephoneElement.AppendChild(telephoneText);
            patientElement.Attributes.Append(patientidAttr);
            patientElement.AppendChild(surnameElement);
            patientElement.AppendChild(nameElement);
            patientElement.AppendChild(patronymicElement);
            patientElement.AppendChild(datebirthElement);
            patientElement.AppendChild(telephoneElement);
            xRoot.AppendChild(patientElement);
            for(int i = 0; i < visitviewing.Count; i++)
            {
                XmlElement visitElement = xmlDocument.CreateElement("visit");
                XmlAttribute visitidAttr = xmlDocument.CreateAttribute("visitid");
                XmlElement datevisitElement = xmlDocument.CreateElement("datevisit");
                XmlElement diagnosisElement = xmlDocument.CreateElement("diagnosis");
                XmlText visitidText = xmlDocument.CreateTextNode(visitviewing[i][0]);
                XmlText datevisitText = xmlDocument.CreateTextNode(visitviewing[i][1]);
                XmlText diagnosisText = xmlDocument.CreateTextNode(visitviewing[i][2]);
                visitidAttr.AppendChild(visitidText);
                datevisitElement.AppendChild(datevisitText);
                diagnosisElement.AppendChild(diagnosisText);
                visitElement.Attributes.Append(visitidAttr);
                visitElement.AppendChild(datevisitElement);
                visitElement.AppendChild(diagnosisElement);
                xRoot.AppendChild(visitElement);

            }
            xmlDocument.Save(@"xmltest.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            var patientviewing = new Patientviewing();
            patientviewing.Active();
            this.Controls.Add(patientviewing);
        }
    }
}
