using MySql.Data.MySqlClient;
using System.Data;

namespace Rocket.SqlHelper
{
    public class MySql : ISqlHelper
    {
        private string connectionString { get; set; }
        private MySqlConnection conn { get; set; }
        private MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(connectionString);
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            return conn;
        }

        public MySql(string source, string user, string password, string database = "")
        {
            if (string.IsNullOrEmpty(database))
            {
                connectionString = string.Format("server={0};user id={1}; password={2};", source, user, password);
            }
            else
            {
                connectionString = string.Format("server={0};user id={1}; password={2}; database={3}", source, user, password, database);
            }

            GetConnection();
        }



        /// <summary>
        /// 查询数据集
        /// </summary>
        /// <param name="cmd">SQL语句</param>
        public DataSet ExecuteDataSet(string cmd)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, GetConnection());
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
