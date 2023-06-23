using System;

namespace ConsoleApp1
{
    /*
     * ADO stands for Microsoft ActiveX Data Objects.
     * Used to communicate between the .NET Application and data sources.
     * Data Providers => SqlConnection , SqlCommand , SqlDataReader , SqlDataAdapter , DataSet
     * using block to close the connection automatically.
     * 
     * SqlDataReader => Connected Architecutre and forward only..fast retrival.ExecuteReader() method can be used
       =>once it read a record, it will then read the next record, there is no way to go back and read the previous record.
     * ExecuteScalar() can be used for aggregate functions
     * ExecuteNonQuery() method return the number of rows affected
     * 
     * SqlDataAdapter() => works as a bridge between a DataSet and a data source (SQL Server Database) to retrieve data.
     * used to fill the DataSet or DataTable and update the data source.
     * DataSet and DataTable are in-memory data stores, that can store tables, just like a database.
     * Fill() method =>Opening and closing of the database connections automatically for us.
     * 
     * DataTable =>We can create userdefined table with user defined attributes with properties.
     *           => Copy() --> If you want to create a full copy of a data table, then you need to use the Copy method of the
     *                         DataTable object which will copy not only the DataTable data but also its schema. 
     *           => Clone() --> if you want to copy the data table schema without data, then you need to use the 
     *                          Clone method of the data table      
     * Reference => https://dotnettutorials.net/lesson/datatable-methods/
     * 
     * DataSet => DataSet is a collection of data tables that contains the relational data in memory in tabular format.
     *         =>  distributed and disconnected architecture.it is used to fetch the data without interacting with any data source.
     
     * DataView => enables you to create different views of the data stored in a DataTable, a capability that is often used in
     *             data-binding applications. Using a DataView, you can expose the data in a table with different sort orders, and
     *             you can filter the data by row state or based on a filter expression. 
     *             
     * Stored Procedure => A Stored Procedure in SQL is a database object which contains pre-compiled SQL Statements
     *                  => block of code that is designed to perform a specific task whenever it is called
     */
    class Program
    {
        static void Main(string[] args)
        {
            //CRUDExample.CreateTable();
            //CRUDExample.InsertData();        // C
            //CRUDExample.ReadData();         //  R 
            //CRUDExample.UpdateData();      //   U
            //CRUDExample.DeleteData();     //    D

            //Reading Data

            //CRUDExample.ReadDataById();
            //CRUDExample.StudentCount();
            //CRUDExample.ReadDataUsingAdapter();

            //DataTable Feature

            //DataTableExample.DataTableFeature();
            //DataTableExample.CopyDataTableFeature();
            //DataTableExample.CloneDataTableFeature();

            //DataSet

            //DataSetExample.DataSetFeature();
            //DataSetExample.FetchDataFromDataSource();
            //DataSetExample.FetchMultipleTables();

            //stored procedure
            //StoredProcedureExample.UseStoreProcedureToGetAllValues();
            //StoredProcedureExample.UseSPtoGetValuesByID();
            StoredProcedureExample.UseSPtoInsertData();
        }
    }
}
