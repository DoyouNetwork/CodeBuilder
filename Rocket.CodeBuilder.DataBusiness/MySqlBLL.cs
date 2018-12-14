using Rocket.CodeBuilder.Model;
using Rocket.SqlHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Rocket.CodeBuilder.DataBusiness
{
    public class MySqlBLL : IDataBusiness
    {
        private ISqlHelper mySql;
        public MySqlBLL(string source, string user, string password, string database = "")
        {
            mySql = new Rocket.SqlHelper.MySql(source, user, password, database);
        }

        public ColumnDesc[] GetColumnDesc(string tableName)
        {
            List<ColumnDesc> td = new List<ColumnDesc>();
            DataTable tableDesc = mySql.ExecuteDataTable($"show full fields from {tableName}");

            foreach (DataRow item in tableDesc.Rows)
            {
                ColumnDesc columnDesc = new ColumnDesc()
                {
                    Comment = item["Comment"].ToString(),
                    Field = item["Field"].ToString(),
                    Key = item["Key"].ToString().ToLower() == "pri",
                    Null = item["Null"].ToString().ToLower() == "yes"
                };
                columnDesc.SetType(item["Type"].ToString());

                td.Add(columnDesc);
            }

            return td.ToArray();
        }

        public DataColumn[] GetColums(string tableName)
        {
            DataTable dt = GetDataTableByName(tableName);
            if (dt != null && dt.Columns.Count >= 1)
            {
                List<DataColumn> dcList = new List<DataColumn>();
                foreach (DataColumn item in dt.Columns)
                {
                    dcList.Add(item);
                }

                return dcList.ToArray();
            }
            return null;
        }

        /// <summary>
        /// 取得所有的数据库
        /// </summary>
        public string[] GetDatabase()
        {
            DataTable dt = mySql.ExecuteDataTable("show databases;");

            if (dt == null || dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                string[] strArray = new string[dt.Rows.Count];
                for (int i = 0; i < strArray.Length; i++)
                {
                    strArray[i] = dt.Rows[i].ItemArray[0].ToString();
                }
                return strArray;
            }
        }


        /// <summary>
        /// 执行SQL语句,查询数据表
        /// </summary>
        public DataTable GetDataTable(string cmd)
        {
            return mySql.ExecuteDataTable(cmd);
        }

        /// <summary>
        /// 取得数据库的所有表
        /// </summary>
        public string[] GetDataTableNameList(string dataBase)
        {
            DataTable dt = mySql.ExecuteDataTable(string.Format("use {0}; show TABLES;", dataBase));

            if (dt == null || dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                string[] strArray = new string[dt.Rows.Count];
                for (int i = 0; i < strArray.Length; i++)
                {
                    strArray[i] = dt.Rows[i].ItemArray[0].ToString();
                }
                return strArray;
            }
        }

        /// <summary>
        /// 获取空的数据表
        /// </summary>
        /// <param name="tableName">表名</param>
        public DataTable GetDataTableByName(string tableName)
        {
            DataTable dt = GetDataTable(string.Format("select * from `{0}` limit 0", tableName));
            dt.TableName = tableName;
            return dt;
        }

        /// <summary>
        /// 取得指定表的所有列
        /// </summary>
        public DBColumn GetColumn(string columnName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取数据库表对象实体
        /// </summary>
        public DBTable GetTable(string tableName)
        {
            DBTable dt = new DBTable() { Name = tableName };

            DataColumn[] dcArray = GetColums(tableName);
            ColumnDesc[] tableDesc = GetColumnDesc(tableName);
            dt.ColumnList = new List<DBColumn>();
            foreach (DataColumn dc in dcArray)
            {
                ColumnDesc cd = tableDesc.FirstOrDefault(c => c.Field == dc.Caption);
                if (cd != null)
                {
                    dt.ColumnList.Add(new DBColumn(cd));
                }
                else
                {
                    dt.ColumnList.Add(new DBColumn(dc));
                }
            }

            return dt;
        }
    }
}
