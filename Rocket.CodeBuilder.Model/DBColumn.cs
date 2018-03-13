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
            //dataColumn.DataType.Name
        }

        public string Name { get; set; }

        public string Node { get; set; }

        public DbType DbType { get; set; }

        public int DbLenght { get; set; }
    }

    public enum DbType
    {

    }
}
