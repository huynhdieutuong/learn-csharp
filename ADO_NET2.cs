using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADO_NET2
{
    public class Program
    {
        static void ShowDataTable(DataTable table)
        {
            System.Console.WriteLine($"Table Name: {table.TableName}");
            System.Console.Write($"{"Index",20}");
            foreach (DataColumn c in table.Columns)
            {
                System.Console.Write($"{c.ColumnName,20}");
            }
            System.Console.WriteLine();

            int numberCols = table.Columns.Count;
            int index = 1;
            foreach (DataRow r in table.Rows)
            {
                System.Console.Write($"{index,20}");
                index++;
                for (int i = 0; i < numberCols; i++)
                {
                    System.Console.Write($"{r[i],20}");
                }
                System.Console.WriteLine();
            }
        }
        static void Main()
        {
            string sqlconnectStr = "Server=TUONG\\SQLEXPRESS;Database=xtlab;Trusted_Connection=True;";
            using var connection = new SqlConnection(sqlconnectStr);

            connection.Open();

            // 1. DataSet & DataTable
            var dataset = new DataSet();
            var table = new DataTable("MyTable");
            dataset.Tables.Add(table);

            table.Columns.Add("No.");
            table.Columns.Add("Name");
            table.Columns.Add("Age");

            table.Rows.Add(1, "John Doe", 25);
            table.Rows.Add(2, "John Doe 2", 30);
            table.Rows.Add(3, "John Doe 3", 20);

            // ShowDataTable(table);

            // 2. DataAdapter
            var adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "NhanVien");

            // 2.1 SelectCommand
            adapter.SelectCommand = new SqlCommand("SELECT NhanviennID, Ten, Ho FROM Nhanvien", connection);

            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            DataTable table2 = dataSet.Tables["Nhanvien"];
            ShowDataTable(table2);

            // 2.2 InsertCommand
            adapter.InsertCommand = new SqlCommand("INSERT INTO Nhanvien (Ten, Ho) VALUES (@Ten, @Ho)", connection);
            adapter.InsertCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");
            adapter.InsertCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");

            // var row = table2.Rows.Add();
            // row["Ten"] = "Abc";
            // row["Ho"] = "Xyz";

            // 2.3 DeleteCommand
            adapter.DeleteCommand = new SqlCommand("DELETE FROM Nhanvien WHERE NhanviennID = @NhanviennID", connection);
            var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@NhanviennID", SqlDbType.Int));
            pr1.SourceColumn = "NhanviennID";
            pr1.SourceVersion = DataRowVersion.Original;

            // var row10 = table2.Rows[10];
            // row10.Delete();

            // 2.4 UpdateCommand
            adapter.UpdateCommand = new SqlCommand("UPDATE Nhanvien SET Ten = @Ten, Ho = @Ho WHERE NhanviennID = @NhanviennID", connection);
            var pr2 = adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NhanviennID", SqlDbType.Int));
            pr2.SourceColumn = "NhanviennID";
            pr2.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");
            adapter.UpdateCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");

            // var row10 = table2.Rows[10];
            // row10["Ten"] = "Tuong";
            // row10["Ho"] = "Huynh";

            // Update
            adapter.Update(dataSet);

            connection.Close();
        }
    }
}