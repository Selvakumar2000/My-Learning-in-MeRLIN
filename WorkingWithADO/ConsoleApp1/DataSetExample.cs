using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp1
{
    class DataSetExample
    {
        public static void DataSetFeature()
        {
            try
            {
                // Craeting Customer table
                DataTable Customer = new DataTable("Customer");
                //Creating column and schema
                DataColumn CustomerId = new DataColumn("ID", typeof(Int32));
                Customer.Columns.Add(CustomerId);
                DataColumn CustomerName = new DataColumn("Name", typeof(string));
                Customer.Columns.Add(CustomerName);
                DataColumn CustomerMobile = new DataColumn("Mobile", typeof(string));
                Customer.Columns.Add(CustomerMobile);
                //Adding Data Rows into Customer table
                Customer.Rows.Add(101, "Anurag", "2233445566");
                Customer.Rows.Add(202, "Manoj", "1234567890");

                // Craeting Orders table
                DataTable Orders = new DataTable("Orders");
                //Creating column and schema
                DataColumn OrderId = new DataColumn("ID", typeof(Int32));
                Orders.Columns.Add(OrderId);
                DataColumn CustId = new DataColumn("CustomerId", typeof(Int32));
                Orders.Columns.Add(CustId);
                DataColumn OrderAmount = new DataColumn("Amount", typeof(Int32));
                Orders.Columns.Add(OrderAmount);

                //Adding Data Rows into Orders table
                Orders.Rows.Add(10001, 101, 20000);
                Orders.Rows.Add(10002, 102, 30000);

                //Creating DataSet object
                DataSet dataSet = new DataSet();
                //Adding DataTables into DataSet
                dataSet.Tables.Add(Customer);
                dataSet.Tables.Add(Orders);
                //Customer Table
                Console.WriteLine("Customer Table Data: ");
                //Fetching DataTable from dataset using the Index position
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Console.WriteLine(row["ID"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                    
                }
                Console.WriteLine();
                //Orders Table
                Console.WriteLine("Orders Table Data: ");
                //Fetching DataTable from the DataSet using the datatable name
                foreach (DataRow row in dataSet.Tables["Orders"].Rows)
                {
                    Console.WriteLine(row["ID"] + ",  " + row["CustomerId"] + ",  " + row["Amount"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }
        
        //fetching data from datasource
        public static void FetchDataFromDataSource()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = RCHNLPT112; Initial Catalog = ADODB; Integrated Security = True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from customers";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //By default, the dataset assigns a name to the table as Table, Table1, Table2 and so on.
                //Or we can access it using index line 0,1,2 and so on.
                foreach (DataRow row in ds.Tables["Table"].Rows)
                {
                    Console.WriteLine(row["Id"]+" "+row["Name"]+" "+row["Mobile"]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something wrong..."+ex.Message);
            }
        }
        //Fetch multiple tables
        public static void FetchMultipleTables()
        {
            string ConnectionString = "Data Source = RCHNLPT112; Initial Catalog = ADODB; Integrated Security = True";
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from customers;select * from orders;";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ds.Tables[0].TableName = "Customers";
                ds.Tables[1].TableName = "Orders";
                //instead of using Table,Table1,Table2.....we can use the names which we set
                Console.WriteLine("Customer Table Data");
                foreach(DataRow row in ds.Tables[0].Rows)  //Tables[0] = Tables["Table"] = Tables["Customers"]
                {
                    Console.WriteLine(row["Id"] + " " + row["Name"] + " " + row["Mobile"]);
                }

                Console.WriteLine("\nOrder Table Data");
                foreach (DataRow row in ds.Tables[1].Rows)  //Tables[1] = Tables["Table1"] = Tables["Orders"]
                {
                    Console.WriteLine(row["Id"] + " " + row["customerId"] + " " + row["Amount"]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong...."+ex.Message);
            }
        }
    }
}
