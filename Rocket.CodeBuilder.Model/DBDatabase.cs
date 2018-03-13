using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.CodeBuilder.Model
{
    public class DBDatabase
    {
        public DBDatabase()
        {

        }

        /// <summary>
        /// 数据库表
        /// </summary>
        public List<DBTable> TableList { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        public string Name { get; set; }
    }
}
