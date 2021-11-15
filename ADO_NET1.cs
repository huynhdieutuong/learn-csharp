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

            // 4. Data Reader
            // 4.1 command.ExecuteReader(); - return full rows, use for normal data
            command.CommandText = "SELECT TOP (@limit) * FROM Sanpham";
            var limit = new SqlParameter("@limit", 5);
            command.Parameters.Add(limit);

            using var dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read()) // if return false, end data
                {
                    System.Console.WriteLine($"{dataReader["TenSanpham"]}, {dataReader["Gia"],25}");
                }
            }
            else
            {
                System.Console.WriteLine("No data");
            }

            // 4.2 command.ExecuteScalar(); - return one value (first row, first column), use for count, max, min
            command.CommandText = "SELECT COUNT(SanphamId) FROM Sanpham";

            var returnValue = command.ExecuteScalar();
            System.Console.WriteLine(returnValue);

            // 4.3 command.ExecuteNonQuery(); - return number, use for Insert, Update, Delete
            command.CommandText = "INSERT INTO Shippers (Hoten, Sodienthoai) VALUES (@Hoten, @Sodienthoai)";
            var Hoten = new SqlParameter("@Hoten", "LoShip");
            var Sodienthoai = new SqlParameter("@Sodienthoai", "888888");
            command.Parameters.Add(Hoten);
            command.Parameters.Add(Sodienthoai);

            var result = command.ExecuteNonQuery();
            System.Console.WriteLine(result);

            // 5. StoredProcedure
            // 5.1 Create procedure (function) in SQL Server
            // CREATE PROCEDURE getProductInfo(@id INT)
            // AS
            // BEGIN
            // 	SELECT TenSanpham, TenDanhMuc
            // 	FROM Sanpham
            // 	INNER JOIN Danhmuc ON Danhmuc.DanhmucID = Sanpham.DanhmucID
            // 	WHERE SanphamID = @id
            // END

            // *** Use procedure (run function)
            // EXEC getProductInfo 5

            // 5.2 Call in command
            command.CommandText = "getProductInfo";
            command.CommandType = CommandType.StoredProcedure;
            var id = new SqlParameter("@id", 5);
            command.Parameters.Add(id);
            id.Value = 3;

            using var reader = command.ExecuteReader();
            dataReader.Read();
            System.Console.WriteLine($"{reader["TenSanpham"]}, {reader["TenDanhMuc"],25}");

            connection.Close();
        }
    }
}