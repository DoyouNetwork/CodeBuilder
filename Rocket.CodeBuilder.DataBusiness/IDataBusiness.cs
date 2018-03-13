using Rocket.CodeBuilder.Model;
using System.Data;

namespace Rocket.CodeBuilder.DataBusiness
{
    public interface IDataBusiness
    {
        /// <summary>
        /// 取得所有的数据库
        /// </summary>
        string[] GetDatabase();

        /// <summary>
        /// 取得数据库的所有表
        /// </summary>
        string[] GetDataTableNameList(string dataBase);

        /// <summary>
        /// 执行SQL语句,查询数据表
        /// </summary>
        DataTable GetDataTable(string cmd);

        /// <summary>
        /// 获取空的数据表
        /// </summary>
        /// <param name="tableName">表名</param>
        DataTable GetDataTableByName(string tableName);

        /// <summary>
        /// 取得指定表的所有列
        /// </summary>
        DataColumn[] GetColums(string tableName);

        /// <summary>
        /// 获取数据表列
        /// </summary>
        DBColumn GetColumn(string columnName);

        /// <summary>
        /// 获取数据库表对象实体
        /// </summary>
        DBTable GetTable(string tableName);
    }
}
