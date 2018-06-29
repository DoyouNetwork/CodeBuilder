using Rocket.CodeBuilder.Model;
using Rocket.SqlHelper;
using System;
using System.Collections.Generic;
using System.Data;

namespace Rocket.CodeBuilder.DataBusiness
{
    public class SqlServerBLL : IDataBusiness
    {
        ISqlHelper mySql;
        public SqlServerBLL(string source, string user, string password, string database = "")
        {
            mySql = new Rocket.SqlHelper.SqlServer(source, user, password, database);
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

        public string[] GetDatabase()
        {
            DataTable dt = mySql.ExecuteDataTable("select * from sysdatabases;");

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

        public DataTable GetDataTable(string cmd)
        {
            return mySql.ExecuteDataTable(cmd);
        }

        public string[] GetDataTableNameList(string dataBase)
        {
            DataTable dt = mySql.ExecuteDataTable(string.Format(" use {0}; select * from sysobjects where xtype = 'U';", dataBase));

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

        public DataTable GetDataTableByName(string tableName)
        {
            DataTable dt = GetDataTable(string.Format("select top 1 * from [{0}] ", tableName));
            dt.TableName = tableName;
            return dt;
        }

        public DBColumn GetColumn(string columnName)
        {
            throw new NotImplementedException();
        }

        public DBTable GetTable(string tableName)
        {
            DBTable dt = new DBTable() { Name = tableName };

            DataColumn[] dcArray = GetColums(tableName);

            dt.ColumnList = new List<DBColumn>();
            foreach (var dc in dcArray)
            {
                dt.ColumnList.Add(new DBColumn(dc));
            }

            return dt;
        }
    }
}
