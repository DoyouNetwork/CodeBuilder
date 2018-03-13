using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.CodeBuilder.Template
{
    [Serializable]
    public class CodeItem
    {
        public string Name { get; set; }
        public ListItem[] Items { get; set; }

        public string Namespace { get; set; }
    }
}
