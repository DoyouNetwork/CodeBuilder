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

        public string ControllerName { get; set; }

        public string GetListUrl { get; set; }
        public string GetDataUrl { get; set; }
        public string AddDataUrl { get; set; }
        public string UpdateData { get; set; }
        public string DeleteDataUrl { get; set; }
    }
}
