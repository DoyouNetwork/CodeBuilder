using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.CodeBuilder.Model
{
    public class DBColumn
    {
        public DBColumn(DataColumn dataColumn)
        {
            this.Name = dataColumn.ColumnName;

            DbType = dataColumn.DataType.Name;
        }



        public String Name { get; set; }
        public bool IsKey { get; set; }

        public String Node { get; set; }

        public String DbType { get; set; }

        public int DbLenght { get; set; }



        public String GetType(string languageType)
        {
            return "";
        }
    }


}
