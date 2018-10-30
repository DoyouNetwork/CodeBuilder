using System;
using System.Collections.Generic;
using System.Linq;

namespace Rocket.CodeBuilder.Model
{
    public class DBTable
    {
        public List<DBColumn> ColumnList { get; set; }
        public string Name { get; set; }
        public string NameLower
        {
            get => Name.ToLower();
            set => NameLower = value;
        }

        public string ControllerName { get; set; }

        public string GetListUrl { get; set; }
        public string GetDataUrl { get; set; }
        public string AddDataUrl { get; set; }
        public string UpdateData { get; set; }
        public string DeleteDataUrl { get; set; }

        public List<DBDataType> Language { get; set; }

        public string GetDBType(DBColumn column, LanguageType language)
        {
            string typeString = column.DbType;
            DBDataType type = Language.FirstOrDefault(c => c.Language == language);
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
