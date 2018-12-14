using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Rocket.CodeBuilder
{
    public class DBColumn
    {
        public DBColumn(DataColumn dataColumn, string node = "")
        {
            Name = dataColumn.ColumnName;

            DbType = dataColumn.DataType.Name;

            Node = node;
        }

        public DBColumn(ColumnDesc columnDesc)
        {
            IsKey = columnDesc.Key;

            Name = columnDesc.Field;

            DbType = columnDesc.Type;

            Node = columnDesc.Comment;
        }


        public string Name { get; set; }
        public bool IsKey { get; set; }

        public string Node { get; set; }

        public string DbType { get; set; }

        public int DbLenght { get; set; }

        public List<DBDataType> Language { get; set; }


        public string GetType()
        {
            DBColumn column = this;
            if (column == null)
            {
                return "值为空";
            }
            if (Language == null)
            {
                return "语言表为空";
            }
            string typeString = column.DbType;
            DBDataType type = Language.FirstOrDefault(c => c.Language == LanguageType.CSharp);
            try
            {
                if (type != null && type.DBType.Keys.Contains(column.DbType))
                {
                    typeString = type.DBType[column.DbType];
                }
            }
            catch (Exception ex)
            {
                typeString = ex.Message;
            }

            return typeString;
        }
    }


}
