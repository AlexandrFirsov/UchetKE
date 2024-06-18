using System;
using System.Data.SqlClient;

namespace UchetCT.models
{
    class DB
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Подключение закрыто");
            }
        }

        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
