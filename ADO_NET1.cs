using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADO_NET1
{
    public class Program
    {
        static void Main()
        {
            // 1.1 Manual
            // string sqlconnectStr = "Server=TUONG\\SQLEXPRESS;Database=xtlab;Trusted_Connection=True;";

            // 1.2 SqlConnectionStringBuilder
            var sqlStringBuilder = new SqlConnectionStringBuilder();
            sqlStringBuilder["Server"] = "TUONG\\SQLEXPRESS";
            sqlStringBuilder["Database"] = "xtlab";
            sqlStringBuilder["Trusted_Connection"] = true;
            string sqlconnectStr = sqlStringBuilder.ToString();

            // 2. Connection
            using var connection = new SqlConnection(sqlconnectStr);

            connection.Open();

            // 3. Command (Query)
            using DbCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT TOP (5) * FROM Sanpham";

            // 4. Data Reader
            var dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                System.Console.WriteLine($"{dataReader["TenSanpham"]}, {dataReader["Gia"],25}");
            }

            connection.Close();
        }
    }
}