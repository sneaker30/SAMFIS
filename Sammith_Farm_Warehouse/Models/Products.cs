using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Sammith_Farm_Warehouse.Controllers;

namespace Sammith_Farm_Warehouse.Models
{
    public class Products
    {
        public int pro_id { get; set; }
        public string pro_name { get; set; }
        public string pro_unit { get; set; }
        public int pro_unit_price { get; set; }
        public string pro_img { get; set; }
        public string pro_details { get; set; }

        internal AppDB Db { get; set; }

        public Products() { }

        internal Products(AppDB db)
        {
            Db = db;
        }

        public List<Products> GetProdctsAsync(string pro_id, string limit)
        {
            var _products = new List<Products>();
            DbDataReader dr;
            using var com = Db.Connection.CreateCommand();
            if (com.Connection.State != ConnectionState.Open)
            {
                com.Connection.Close();
                com.Connection.Open();
            }
            var sql = "SELECT * FROM productions_tb ";
            if ((pro_id != "all") && (!string.IsNullOrEmpty(pro_id)))
            {
                sql += "WHERE pro_id = @pro_id ";
            }
            sql += "LIMIT " + limit + ";";
            com.CommandText = sql;
            if ((pro_id != "all") && (!string.IsNullOrEmpty(pro_id)))
            {
                com.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@pro_id",
                    DbType = DbType.Int16,
                    Value = pro_id
                });
            }
            dr = com.ExecuteReader();
            _products.Clear();
            using (dr)
            {
                while (dr.Read())
                {
                    var _product = new Products(Db)
                    {
                        pro_id = dr.GetInt16(0),
                        pro_name = dr.GetString(1),
                        pro_unit = dr.GetString(2),
                        pro_unit_price = dr.GetInt16(3),
                        pro_img = dr.GetString(4),
                        pro_details = dr.GetString(5)
                    };
                    _products.Add(_product);
                }
            }

            return _products;
        }
    }
}