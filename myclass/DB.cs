using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Diagnostics;

namespace crud.myclass
{
    internal class DB
    {
        public MySqlConnection con;

        public DB()
        {
            string host = "localhost";
            string database = "studentdb";
            string username = "root";
            string password = "";
            string port = "3306";

            string constring = "datasource =" + host + ";database=" + database + "; port=" + port + "; username =" + username + ";" + "password=" + password + "; SslMode =none;";
            
            con = new MySqlConnection(constring);
        }
    }
    class CRUD : DB
    {
        //PROPERTIES
        public string name { set; get; }

        public string age { set; get; } 

        public string gender { set; get; }

        //FOR ID
        public string id { set; get; }

        //READING DATA
        public DataTable dt = new DataTable();

        public DataSet ds = new DataSet();


        //CREATE FUNCTION
        public void Create_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO student(`name`,`age`,`gender`) VALUES(@name, @age, @gender) ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@age", MySqlDbType.VarString).Value = age;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;

                cmd.ExecuteNonQuery();
                con.Close();

            }
        }


        //UPDATE FUNCTION
        public void Update_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE student SET name=@name, age=@age, gender=@gender WHERE id=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@age", MySqlDbType.VarString).Value = age;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //DELETE FUNCTION

        public void Delete_data()
        {
            con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM student WHERE id=@id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

               
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //READ FUNCTION
        
        public void Read_data()
        {
            dt.Clear();
            string query = "SELECT * FROM student";
            MySqlDataAdapter MDA = new MySqlDataAdapter(query,con);
            MDA.Fill(ds);
            dt = ds.Tables[0];
        }

    }
}
