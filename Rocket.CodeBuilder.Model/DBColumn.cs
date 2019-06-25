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

            InitializeWriteType();
        }

        public DBColumn(ColumnDesc columnDesc)
        {
            IsKey = columnDesc.Key;

            Name = columnDesc.Field;

            DbType = columnDesc.Type;

            Node = columnDesc.Comment;

            InitializeWriteType();
        }


        public string Name { get; set; }
        /// <summary>
        /// 小驼峰命名法
        /// </summary>
        public string NameCamel
        {
            get
            {
                return $"{Name[0].ToString().ToLower()}{ Name.Substring(1, Name.Length - 1)}";
            }
        }

        public bool IsKey { get; set; }

        public string Node { get; set; }

        public string DbType { get; set; }

        public int DbLenght { get; set; }

        public WriteType WriteType { get; set; }
        public void InitializeWriteType()
        {
            string columnType = GetType();
            switch (columnType)
            {
                case "int":
                case "decimal":
                    WriteType = WriteType.Default;
                    break;

                case "DateTime":
                    WriteType = WriteType.Default;
                    break;

                case "bool":
                    WriteType = WriteType.Checkbox;
                    break;

                default:
                    WriteType = WriteType.Default;
                    break;
            }
        }

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

    public enum WriteType
    {
        Default = 0,
        Redio = 1,//枚举选择
        Checkbox = 2,//布尔
        Select = 3,//多项单圈
        FileUpload = 4
    }

}
