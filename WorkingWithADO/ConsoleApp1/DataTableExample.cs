using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1
{
    class DataTableExample
    {
        //feature of data table
        public static void DataTableFeature()
        {
            try
            {
                //create datatable
                DataTable dt = new DataTable("Employee");

                //Add the DataColumn with properties
                DataColumn Id = new DataColumn("Id");
                Id.DataType = typeof(int);
                Id.Unique = true;
                Id.AutoIncrement = true;
                Id.AutoIncrementSeed = 100;
                Id.AutoIncrementStep = 1;
                Id.Caption = "Student Id";
                Id.AllowDBNull = false;
                dt.Columns.Add(Id);

                //Add the DataColumn with few Properties
                DataColumn Name = new DataColumn("Name");
                Name.MaxLength = 50;
                Name.AllowDBNull = false;
                dt.Columns.Add(Name);

                //Add the DataColumn with default properties
                DataColumn Email = new DataColumn("Email");
                dt.Columns.Add(Email);

                //Setting Primary Key
                dt.PrimaryKey = new DataColumn[] { Id };

                //Add values in each row
                DataRow row1 = dt.NewRow();
                //row1["Id"] = 100;  no need to assign,because it is autoincremental
                row1["Name"] = "Selvakumar";
                row1["Email"] = "skselva@gmail.com";
                dt.Rows.Add(row1);

                //Adding new DataRow by simply adding the values
                dt.Rows.Add(null, "Wasim", "wasim@gmail.com");  //pass null for autoincremented property
                dt.Rows.Add(null, "Surya", "surya@gmail.com");

                //printing
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["Id"] + " " + row["Name"] + " " + row["Email"]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something wrong..."+ex.Message);
            }
        }

        //copy table
        public static void CopyDataTableFeature()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = RCHNLPT112; Initial Catalog = ADODB; Integrated Security = True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from teacher;";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable originaldt = new DataTable();
                da.Fill(originaldt);
                Console.WriteLine("Printing Original Data of Teacher table\n");
                foreach (DataRow row in originaldt.Rows)
                {
                    Console.WriteLine(row["Id"] + " " + row["Name"] + " " + row["Email"]+" "+row["Mobile"]);
                }

                //delete a data
                foreach (DataRow row in originaldt.Rows)
                {
                    if (Convert.ToInt32(row["Id"]) == 102)
                    {
                        row.Delete();
                        Console.WriteLine("\nRow with Id 102 Deleted");
                    }
                }
                originaldt.AcceptChanges();
                Console.WriteLine();
                Console.WriteLine("After Deletion");
                foreach (DataRow row in originaldt.Rows)
                {
                    Console.WriteLine(row["Id"] + " " + row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                }

                //copying original data table into another data table using Copy() method
                Console.WriteLine("\nPrinting Original Data from Copy table\n");
                DataTable copydt = originaldt.Copy();
                if (copydt != null)
                {
                    foreach (DataRow row in copydt.Rows)
                    {
                        Console.WriteLine(row["Id"] + " " +row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something wrong.."+ex.Message);
            }
        }

        //clone a table
        //schema is a collection of database objects such tables, views, stored procedures, functions, indexes, triggers.
        public static void CloneDataTableFeature()
        {
            SqlConnection con = new SqlConnection("Data Source = RCHNLPT112; Initial Catalog = ADODB; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from teacher;";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable originaldt = new DataTable();
            da.Fill(originaldt);
            Console.WriteLine("Printing Original Data of Teacher table\n");
            foreach (DataRow row in originaldt.Rows)
            {
                Console.WriteLine(row["Id"] + " " + row["Name"] + " " + row["Email"] + " " + row["Mobile"]);
            }
            //copying original data table into another data table using Copy() method
            Console.WriteLine("\nPrinting Original Data from Clone table\n");
            DataTable clonedt = originaldt.Clone();
            if (clonedt.Rows.Count > 0)
            {
                foreach (DataRow row in clonedt.Rows)
                {
                    Console.WriteLine(row["Id"] + " " + row["Name"] + " " + row["Email"] + " " + row["Mobile"]);
                }
            }
            else
            {
                Console.WriteLine("cloneDataTable is Empty");
                Console.WriteLine("Adding Data to cloneDataTable");
                clonedt.Rows.Add(101, "Test1", "Test1@gmail.com", "1234567890");
                clonedt.Rows.Add(101, "Test2", "Test1@gmail.com", "1234567890");
                foreach (DataRow row in clonedt.Rows)
                {
                    Console.WriteLine(row["Id"] + " " + row["Name"] + " " + row["Email"] + " " + row["Mobile"]);
                }
            }
        }
    }
}
