
using System.Data;
using System.Data.SqlClient;

namespace Rocket.SqlHelper
{
    public class SqlServer : ISqlHelper
    {
        private string connectionString { get; set; }
        private SqlConnection conn { get; set; }
        private SqlConnection GetConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(connectionString);
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            return conn;
        }

        public SqlServer(string source, string user, string password, string database = "")
        {
            if (string.IsNullOrEmpty(database))
            {
                connectionString = string.Format("Data Source={0}; User ID={1}; Password={2};", source, user, password);
            }
            else
            {
                connectionString = string.Format("Data Source={0}; User ID={1}; Password={2}; Initial Catalog={3}", source, user, password, database);
            }
        }



        /// <summary>
        /// 查询数据集
        /// </summary>
        /// <param name="cmd">SQL语句</param>
        public DataSet ExecuteDataSet(string cmd)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, GetConnection());
            adapter.Fill(ds);
            return ds;
        }

        /// <summary>
        /// 查询数据表
        /// </summary>
        /// <param name="cmd">SQL语句</param>
        public DataTable ExecuteDataTable(string cmd)
        {
            return ExecuteDataSet(cmd).Tables[0];
        }
    }
}
