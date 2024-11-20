using System;
using System.Data;
using System.Data.OleDb;
class Program
{
    static void Main()
    {
        string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "C:\\Users\\233511\\Downloads\\Northwind.mdb;User Id=admin;Password=;";
        string queryString = "SELECT ProductID, UnitPrice, ProductName from products " + "WHERE UnitPrice > ? " + "ORDER BY UnitPrice DESC;";
        int paramValue = 5;
        OleDbConnection connection = new OleDbConnection(connectionString);
        OleDbCommand command = new OleDbCommand(queryString, connection);
        command.Parameters.AddWithValue("@pricePoint", paramValue);
        try
        {
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read()) { Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]); }
            reader.Close();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        Console.ReadLine();
    }
}
