using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.CodeBuilder.Template
{
    [Serializable]
    public class Parameter
    {
        public string NameSpace { get; set; }
        public string TableName { get; set; }
        public CodeItem CodeItem { get; set; }

        public DataTable Table { get; set; }

        /// <summary>
        /// 获得列名字符串数组
        /// </summary>
        public string[] GetColumnStr()
        {
            List<string> strArray = new List<string>();
            //sb.AppendLine(string.Format("public string Test {{ get; set; }}"));
            foreach (var item in CodeItem.Items)
            {
                strArray.Add(item.Name);
            }
            return strArray.ToArray();
        }

        //获得命名空间
        public string GetNameSpace()
        {
            if (string.IsNullOrEmpty(NameSpace))
            {
                return "";
            }
            else
            {
                return "." + NameSpace;
            }
        }

        //生成列对应属性代码
        public string GetColumnStrs()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine(string.Format("public string Test {{ get; set; }}"));
            foreach (var item in CodeItem.Items)
            {
                if (item.Name == "AddTime")
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(item.Note))
                {
                    sb.AppendLine(string.Format("//{0}", item.Note));
                }
                string typeStr = GetParse(item.DbType);
                switch (typeStr)
                {
                    case "DateTime":
                        //sb.AppendLine(string.Format("private {0} _{1};", typeStr, column.ColumnName));
                        //sb.AppendLine(string.Format("public {0} {1} {{  get{{return _{1} == null ? DateTime.MinValue : _{1};}}set{{_{1} = value;}}}}", typeStr, column.ColumnName));
                        sb.AppendLine(string.Format("public {0}? {1} {{ get; set; }}", typeStr, item.Name));
                        break;

                    default:
                        sb.AppendLine(string.Format("public {0} {1} {{ get; set; }}", typeStr, item.Name));
                        break;
                }
            }
            return sb.ToString();
        }

        //获得类型转换代码
        public string GetParse(string typename)
        {
            string parse = "string";
            switch (typename)
            {
                case "Int32":
                    parse = "int";
                    break;

                case "DateTime":
                    parse = "DateTime";
                    break;

                case "Boolean":
                    parse = "bool";
                    break;
            }
            return parse;
        }

        //获得类型转换代码
        public string GetParse(DataColumn columb)
        {
            string parse = "string";
            switch (columb.DataType.Name)
            {
                case "Int32":
                    parse = "int";
                    break;

                case "DateTime":
                    parse = "DateTime";
                    break;

                case "Boolean":
                    parse = "bool";
                    break;
            }
            return parse;
        }

    }
}
