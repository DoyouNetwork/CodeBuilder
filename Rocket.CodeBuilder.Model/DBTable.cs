using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.CodeBuilder.Model
{
    public class DBTable
    {
        public List<DBColumn> ColumnList { get; set; }
        public string Name { get; set; }
    }
}
