using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Тестовое_задание_ООО_НПК_ПРОГРЕСС_
{
    class Menu
    {
        private static Menu menu = null;
        private SQLiteConnection database { get; set; } = new SQLiteConnection("Data Source=database.db; Version=3");//соединение с бд 
        
        protected Menu()
        {

        }
        public static Menu Initialize()//создание экземпляра класса 
        {
            if (menu == null) menu = new Menu();
            return menu;
        }
        private bool CheckID(string patientid)
        {
            SQLiteCommand cmd = database.CreateCommand();
            cmd.CommandText = "select Patient_ID from patient where Patient_ID like @patientid";
            cmd.Parameters.Add("@patientid", System.Data.DbType.String).Value = patientid;
            SQLiteDataReader sql = cmd.ExecuteReader();
            if (sql.HasRows) { sql.Close(); return true; }
            else
            {
                sql.Close(); return false;
            }
        }
        public void Addpatient(string patientid,string surname,string name,string patronymic, DateTime datebirth, string telephone)//прием сообщений от сервера 
        {
            database.Open();
            if (CheckID(patientid)==false)
            {
                SQLiteCommand cmd = database.CreateCommand();
                cmd.CommandText = "insert into patient(Patient_ID,Surname,Name,Patronymic,Date_of_Birth, Telephone) values ( @patientid , @surname, @name,@patronymic,@datebirth,@telephone)";
                cmd.Parameters.Add("@patientid", System.Data.DbType.String).Value = patientid;
                cmd.Parameters.Add("@surname", System.Data.DbType.String).Value = surname;
                cmd.Parameters.Add("@name", System.Data.DbType.String).Value = name;
                cmd.Parameters.Add("@patronymic", System.Data.DbType.String).Value = patronymic;
                cmd.Parameters.Add("@datebirth", System.Data.DbType.DateTime).Value = datebirth.Date;
                cmd.Parameters.Add("@telephone", System.Data.DbType.String).Value = telephone;
                cmd.ExecuteNonQuery();
            }
            else MessageBox.Show("Пациент с данным ид уже существует!");
            database.Close();
        }
        private bool CheckvisitID(string visitid)
        {
            SQLiteCommand cmd = database.CreateCommand();
            cmd.CommandText = "select Visit_ID from visits where Visit_ID like @visitid";
            cmd.Parameters.Add("@visitid", System.Data.DbType.String).Value = visitid;
            SQLiteDataReader sql = cmd.ExecuteReader();
            if (sql.HasRows) { sql.Close(); return true; }
            else
            {
                sql.Close(); return false;
            }
        }
        public void Addvisit(string visitid, DateTime datevisit, string diagnosis, string patientid)//прием сообщений от сервера 
        {
            database.Open();
            if (CheckID(patientid))
            {
                if (CheckvisitID(visitid) ==false)
                {
                    SQLiteCommand cmd = database.CreateCommand();
                    cmd.CommandText = "insert into visits(Visit_ID,Date_of_visit,Diagnosis,Patient_ID) values ( @visitid, @datevisit,  @diagnosis, @patientid)";
                    cmd.Parameters.Add("@patientid", System.Data.DbType.String).Value = patientid;
                    cmd.Parameters.Add("@visitid", System.Data.DbType.String).Value = visitid;
                    cmd.Parameters.Add("@datevisit", System.Data.DbType.DateTime).Value = datevisit.Date;
                    cmd.Parameters.Add("@diagnosis", System.Data.DbType.String).Value = diagnosis;
                    cmd.ExecuteNonQuery();
                }
                else MessageBox.Show("Посещение с данным ид уже существует!");
            }
            else MessageBox.Show("Пациента с данным ид не существует!");
            database.Close();
        }
        public List<List<string>> Visitviewing(string patientid)
        {
            database.Open();
            if (CheckID(patientid))
            {
                List<List<string>> visitviewing = new List<List<string>>();
                SQLiteCommand cmd = database.CreateCommand();
                cmd.CommandText = "select Visit_ID,Date_of_visit,Diagnosis from visits where Patient_ID like @patientid";
                cmd.Parameters.Add("@patientid", System.Data.DbType.String).Value = patientid;
                SQLiteDataReader sql = cmd.ExecuteReader();
                while (sql.Read())
                {
                    List<string> vv = new List<string>();
                    visitviewing.Add(vv);
                    visitviewing[visitviewing.Count - 1].Add(sql.GetValue(0).ToString());
                    visitviewing[visitviewing.Count - 1].Add(sql.GetValue(1).ToString().Substring(0, 10));
                    visitviewing[visitviewing.Count - 1].Add(sql.GetValue(2).ToString());
                }
                sql.Close();
                database.Close();
                return visitviewing;
            }
            else
            {
                MessageBox.Show("Пациента с данным ид не существует!");
                database.Close();
                return null;
            }
        }
        public List<string> Patientviewing(string patientid)
        {
            database.Open();
            if (CheckID(patientid))
            {
                List<string> patientviewing = new List<string>();
                SQLiteCommand cmd = database.CreateCommand();
                cmd.CommandText = "select Surname,Name,Patronymic,Date_of_Birth, Telephone from patient where Patient_ID like @patientid";
                cmd.Parameters.Add("@patientid", System.Data.DbType.String).Value = patientid;
                SQLiteDataReader sql = cmd.ExecuteReader();
                while (sql.Read())
                {
                    patientviewing.Add(patientid);
                    patientviewing.Add(sql.GetValue(0).ToString());
                    patientviewing.Add(sql.GetValue(1).ToString());
                    patientviewing.Add(sql.GetValue(2).ToString());
                    patientviewing.Add(sql.GetValue(3).ToString().Substring(0,10));
                    patientviewing.Add(sql.GetValue(4).ToString());
                }
                sql.Close();
                database.Close();
                return patientviewing;
            }
            else
            {
                MessageBox.Show("Пациента с данным ид не существует!");
                database.Close();
                return null;
            }
        }
        public List<List<string>> Patientviewing1()
        {
            database.Open();
            List<List<string>> patientviewing = new List<List<string>>();
            SQLiteCommand cmd = database.CreateCommand();
            cmd.CommandText = "select  Patient_ID,Surname,Name,Patronymic,Date_of_Birth, Telephone from patient";
            SQLiteDataReader sql = cmd.ExecuteReader();
            while (sql.Read())
            {
                List<string> pv = new List<string>();
                patientviewing.Add(pv);
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(0).ToString());
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(1).ToString());
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(2).ToString());
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(3).ToString());
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(4).ToString().Substring(0,10));
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(5).ToString());
            }
            sql.Close();
            database.Close();
            return patientviewing;
        }
        public List<List<string>> Patientviewing2(string surname, string name, int from, int befor)
        {
            database.Open();
            List<List<string>> patientviewing = new List<List<string>>();
            SQLiteCommand cmd = database.CreateCommand();
            cmd.CommandText = $"select Patient_ID,Surname,Name,Patronymic,Date_of_Birth, Telephone from patient where Surname like @surname and Name like @name and date(Date_of_Birth) >= '{from-1}%' and date(Date_of_Birth) <= '{befor+1}%' ";
            cmd.Parameters.Add("@surname", System.Data.DbType.String).Value = surname;
            cmd.Parameters.Add("@name", System.Data.DbType.String).Value = name;
            SQLiteDataReader sql = cmd.ExecuteReader();
            while (sql.Read())
            {
                List<string> pv = new List<string>();
                patientviewing.Add(pv);
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(0).ToString());
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(1).ToString());
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(2).ToString());
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(3).ToString());
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(4).ToString().Substring(0, 10));
                patientviewing[patientviewing.Count - 1].Add(sql.GetValue(5).ToString());
            }
            sql.Close();
            database.Close();
            return patientviewing;
        }
    }
}
