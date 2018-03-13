using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.CodeBuilder.Template
{
    [Serializable]
    public class ListItem
    {
		//名称
        public string Name { get; set; }
		//类型
        public string DbType { get; set; }
		//长度
        public string DbLength { get; set; }
		//字段注释
		public string Note { get; set; }
    }
}
