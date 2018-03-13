using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Rocket.SqlHelper
{
    public interface ISqlHelper
    {
        /// <summary>
        /// 查询获取数据表
        /// </summary>
        /// <param name="cmd">SQL语句</param>
        DataTable ExecuteDataTable(string cmd);

        ///// <summary>
        ///// 获取数据库表结构
        ///// </summary>
        ///// <param name="tableName">数据库表名</param>
        //DataTable GetTable(string tableName);


        /// <summary>
        /// 查询数据集
        /// </summary>
        /// <param name="cmd">SQL语句</param>
        DataSet ExecuteDataSet(string cmd);
    }
}
