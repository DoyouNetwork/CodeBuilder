using Rocket.CodeBuilder.Model;
using Rocket.SqlHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Rocket.CodeBuilder.DataBusiness
{
    public class SqlServerBLL : IDataBusiness
    {
        private ISqlHelper sqlServer;
        public SqlServerBLL(string source, string user, string password, string database = "")
        {
            sqlServer = new Rocket.SqlHelper.SqlServer(source, user, password, database);
        }

        public ColumnDesc[] GetColumnDesc(string tableName)
        {
            List<ColumnDesc> td = new List<ColumnDesc>();
            DataTable tableDesc = sqlServer.ExecuteDataTable($@"
                SELECT
                	syscolumns.name AS Field,
                	syscolumns.id,
                	syscolumns.isnullable AS 'Null',
                	systypes.name AS Type,
                	syscolumns.[length] AS Lenth,
                	ISNULL(
                		sys.extended_properties.
                		VALUE
                			,
                			''
                	) AS Comment,
                	CASE keyColumn.Column_name
                WHEN syscolumns.name THEN
                	'1'
                ELSE
                	'0'
                END AS 'Key'
                FROM
                	sysobjects
                JOIN syscolumns ON sysobjects.id = syscolumns.id
                JOIN systypes ON syscolumns.xusertype = systypes.xusertype
                LEFT JOIN sys.identity_columns ON sys.identity_columns.object_id = syscolumns.id
                AND sys.identity_columns.column_id = syscolumns.colid
                LEFT JOIN sys.extended_properties ON sys.extended_properties.major_id = syscolumns.id
                AND sys.extended_properties.minor_id = syscolumns.colid,
                 INFORMATION_SCHEMA.KEY_COLUMN_USAGE keyColumn
                WHERE
                	sysobjects.name = '{tableName}'
                AND keyColumn.TABLE_NAME = sysobjects.name");

            foreach (DataRow item in tableDesc.Rows)
            {
                ColumnDesc columnDesc = new ColumnDesc()
                {
                    Comment = item["Comment"].ToString(),
                    Field = item["Field"].ToString(),
                    Key = item["Key"].ToString().ToLower() == "1",
                    Null = item["Null"].ToString().ToLower() == "1"
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

        public string[] GetDatabase()
        {
            DataTable dt = sqlServer.ExecuteDataTable("select * from sysdatabases;");

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
            return sqlServer.ExecuteDataTable(cmd);
        }

        public string[] GetDataTableNameList(string dataBase)
        {
            DataTable dt = sqlServer.ExecuteDataTable(string.Format(" use {0}; select * from sysobjects where xtype = 'U';", dataBase));

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
