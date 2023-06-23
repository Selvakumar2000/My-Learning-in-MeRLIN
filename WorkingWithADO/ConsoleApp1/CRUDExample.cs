using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1
{
    class CRUDExample
    {
        //Create Table
        public static void CreateTable()
        {
            //To connect to the database server is recommended to use Windows Authentication, commonly known as integrated security
            //When true, the current Windows account credentials are used for authentication.
            try
            { 
                SqlConnection con = new SqlConnection("Data Source = RCHNLPT112; Initial Catalog = ADODB; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("create table student(Id int not null, Name varchar(50),Email varchar(30),Department varchar(30));",con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully");
                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something wrong, "+ex.Message);
            }
        }

        //Insert Data into a Table       C => Create
        public static void InsertData()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=RCHNLPT112;Initial Catalog=ADODB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into student values(104,'Bharath','bharath@gmail.com','ECE')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Data Inserted Successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something Wrong..."+ex.Message);
            }
        }

        //Read Data                      R => Read
        public static void ReadData()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=RCHNLPT112;Initial Catalog=ADODB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select * from student", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader(); //connected architecture
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["Id"] + " " + sdr["Name"] + " " + sdr["Email"] + " " + sdr["Department"]);
                }
                con.Close();
                Console.WriteLine("\nData Readed Succesfully....");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something wrong...." + ex.Message);
            }
        }

        //Read Based on ID
        public static void ReadDataById()
        {
            try
            {
                //we don't need to explicitly close the connection
                using SqlConnection con = new SqlConnection("Data Source=RCHNLPT112;Initial Catalog=ADODB;Integrated Security=True");
                //SqlCommand cmd = new SqlCommand("select * from student where Id=100;", con); (CommandText,Connection)
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from student where Id=100;";
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["Id"] + " " + sdr["Name"] + " " + sdr["Email"] + " " + sdr["Department"]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something wrong...."+ex.Message);
            }
        }

        //Count Number Of Students in the database
        //ExecuteScalar() method => return a single value.
        public static void StudentCount()
        {
            try
            {
                using SqlConnection con = new SqlConnection("Data Source=RCHNLPT112;Initial Catalog=ADODB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText="select count(Id) from student;";
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                Console.WriteLine("Total Count Of Student in the Student Database : {0}",count);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something wrong..."+ex.Message);
            }
        }

        //Read Data using SqlDataAdapter
        public static void ReadDataUsingAdapter()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=RCHNLPT112;Initial Catalog=ADODB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from student;";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine("Printing the Data using DataTable");
                foreach(DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["Id"]+" "+row["Name"]+" "+row["Email"]+" "+row["Department"]);
                }
                Console.WriteLine("\nPrinting the Data using DataSet");
                DataSet ds = new DataSet();
                da.Fill(ds, "student");
                foreach(DataRow row in ds.Tables["student"].Rows)
                {
                    Console.WriteLine(row["Id"] + " " + row["Name"] + " " + row["Email"] + " " + row["Department"]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something wrong..."+ex.Message);
            }
        }

        //Update Data                   C => Update
        public static void UpdateData()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=RCHNLPT112;Initial Catalog=ADODB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Update student set Name='Mohammed Wasim',Email='mwasim@gmail.com' where Id=101;", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Data Updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Wrong..." + ex.Message);
            }
        }

        //Delete data                D => Delete
        public static void DeleteData()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=RCHNLPT112;Initial Catalog=ADODB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("Delete from student where Id=104", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Data Deleted Successfully");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something Wrong..."+ex.Message);
            }
        }
    }
}
