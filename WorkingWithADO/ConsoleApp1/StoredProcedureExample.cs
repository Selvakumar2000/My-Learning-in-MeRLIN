using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1
{
    class StoredProcedureExample
    {
        public static void UseStoreProcedureToGetAllValues()
        {
            string ConnectionString = "Data Source = RCHNLPT112; Initial Catalog = ADODB; Integrated Security = True";
            try
            {
                using SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("spGetStudents",con);
                //cmd.Connection = con;
                //cmd.CommandText = "spGetStudents";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    Console.WriteLine(sdr["Name"] + " " + sdr["Email"]+" "+sdr["Department"]);
                }
                //con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong....."+ex.Message);
            }
        }

        public static void UseSPtoGetValuesByID()
        {
            string ConnectionString = "Data Source = RCHNLPT112; Initial Catalog = ADODB; Integrated Security = True";
            try
            {
                using SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = con,
                    CommandText= "spGetStudentsById",
                    CommandType=CommandType.StoredProcedure
                };
                //SqlCommand cmd = new SqlCommand("spGetStudentsById", con);
                //cmd.CommandType = CommandType.StoredProcedure;

                //define a parameter
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@Id",    //parameter name defined in SP
                    SqlDbType = SqlDbType.Int, //specify the datatype
                    Value = 106,  //value passes to the paramater
                    Direction=ParameterDirection.Input  //specify the parameter as input, By default the parameter direction is Input.

                };

                //add paramter into the command
                cmd.Parameters.Add(param1);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    Console.WriteLine(sdr["Id"]+" "+sdr["Name"] + " " + sdr["Email"] + " " + sdr["Department"]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong...."+ex.Message);
            }
        }

        public static void UseSPtoInsertData()
        {
            string ConnectionString = "Data Source = RCHNLPT112; Initial Catalog = ADODB; Integrated Security = True";
            try
            {
                using SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = con,
                    CommandText = "spInsertData",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@Id",    //parameter name defined in SP
                    SqlDbType = SqlDbType.Int, //specify the datatype
                    Value = 108,  //value passes to the paramater
                    Direction = ParameterDirection.Input  //specify the parameter as input, By default the parameter direction is Input.

                };

                //add paramter into the command
                cmd.Parameters.Add(param1);

                //other ways to add data  if we not mention the direction,by default it is Input direction
                cmd.Parameters.AddWithValue("@Name", "NarenKrish");
                cmd.Parameters.AddWithValue("@Email", "kk@gmail.com");
                cmd.Parameters.AddWithValue("@Department", "Finance");

                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Inserted Successfully....");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong..."+ex.Message);
            }
        }
    }
}
