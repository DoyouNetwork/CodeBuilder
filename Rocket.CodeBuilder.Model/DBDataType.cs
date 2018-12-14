using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.CodeBuilder
{
    public class DBDataType
    {
        public DBDataType()
        {
            DBType = new Dictionary<string, string>();
        }
        public LanguageType Language { get; set; }

        public Dictionary<String, String> DBType { get; set; }
    }



    public enum LanguageType
    {
        CSharp = 1,
        Javarscript = 2
    }
}
