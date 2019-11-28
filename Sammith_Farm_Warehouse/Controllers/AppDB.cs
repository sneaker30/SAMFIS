using System;
using MySql.Data.MySqlClient;

namespace Sammith_Farm_Warehouse.Controllers
{
    public class AppDB : IDisposable
    {
        public MySqlConnection Connection { get; }

        public AppDB(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}
