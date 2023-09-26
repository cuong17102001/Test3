using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test
{
    public class ProductQuery : DbAccess
    {
        public ProductQuery(string connectionString) : base(connectionString) { }

        public DataSet FindProduct(string productName)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products WHERE ProductName = @ProductName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", productName);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);
            }

            return dataSet;
        }
    }
}
