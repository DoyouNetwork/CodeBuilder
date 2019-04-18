using System;
using System.Collections.Generic;
using System.Linq;

namespace Rocket.CodeBuilder.Model
{
    public class DBTable
    {
        public DBTable()
        {
            Language = new List<DBDataType>();
        }
        public List<DBColumn> ColumnList { get; set; }
        public string Name { get; set; }
        public string NameLower
        {
            get => Name.ToLower();
            set => NameLower = value;
        }

        /// <summary>
        /// 获取主键类型
        /// </summary>
        public string GetKeyType()
        {
            foreach (DBColumn dBColumn in ColumnList)
            {
                if (dBColumn.IsKey)
                {
                    return dBColumn.GetType();
                }
            }
            return "";
        }

        public string ControllerName { get; set; }

        public string GetListUrl { get; set; }
        public string GetDataUrl { get; set; }
        public string AddDataUrl { get; set; }
        public string UpdateData { get; set; }
        public string DeleteDataUrl { get; set; }

        public List<DBDataType> Language { get; }

        public void AddLanguage(List<DBDataType> list)
        {
            Language.AddRange(list);

            foreach (DBColumn column in ColumnList)
            {
                column.Language = Language;
            }
        }

        public string GetDBType(DBColumn column, LanguageType language = LanguageType.CSharp)
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

        public string GetDBType(DBColumn column)
        {
            if (column == null)
            {
                return "值为空";
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
