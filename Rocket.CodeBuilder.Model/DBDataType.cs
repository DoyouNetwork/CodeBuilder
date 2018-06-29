using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.CodeBuilder.Model
{
    public class DBDataType
    {
        public DBDataType()
        {
            
        }
        public LanguageType Language { get; set; }
    }

    public enum LanguageType
    {
        CSharp = 1,
        Javarscript = 2
    }
}
