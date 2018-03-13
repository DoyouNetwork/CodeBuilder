using Microsoft.VisualStudio.TextTemplating;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Rocket.CodeBuilder.Template
{
    public class BuilderCode
    {
        public BuilderCode(DataTable DataTable, string TableName = "")
        {
            this.DataTable = DataTable;
            if (!string.IsNullOrEmpty(TableName))
            {
                this.TableName = TableName;
            }
            else
            {
                this.TableName = DataTable.TableName;
            }

            NameTable nt = new NameTable();
            this.TableName = nt.NameToNewName(this.TableName);


            CodeItem ci = new CodeItem();
            ci.Namespace = TableName;
            if (DataTable != null)
            {
                ci.Name = nt.NameToNewName(DataTable.TableName);
                List<DataColumn> list = new List<DataColumn>();

                foreach (DataColumn item in DataTable.Columns)
                {
                    list.Add(item);
                }

                if (list.Count >= 1)
                {
                    List<ListItem> liList = new List<ListItem>();
                    foreach (var item in list)
                    {
                        liList.Add(new ListItem() { Name = item.ColumnName, DbType = item.DataType.Name });
                    }
                    ci.Items = liList.ToArray();
                }
                CodeItem = ci;
            }
        }

        public BuilderCode(CodeItem CodeItem)
        {
            this.TableName = CodeItem.Name;
            this.CodeItem = CodeItem;
            NameTable nt = new NameTable();
            this.TableName = nt.NameToNewName(this.TableName);

        }

        public string TableName { get; set; }
        public string NameSpace { get; set; }
        public DataTable DataTable { get; set; }
        public CodeItem CodeItem { get; set; }
        public string TemplateFilePath { get; set; }
        public string OutFilePath { get; set; }
        public string OutFileName { get; set; }

        public string TempContent { get; set; }
        public string OutContent { get; set; }

        public void CreateTemplate()
        {

            TempContent = File.ReadAllText(TemplateFilePath);
            Parameter param;
            if (CodeItem != null)
            {
                param = new Parameter()
                {
                    CodeItem = CodeItem
                };
            }
            else
            {
                param = new Parameter()
                {
                    TableName = TableName,
                    Table = DataTable,
                    NameSpace = NameSpace
                };
            }

            //Templating host = new Templating();
            //host.Session = host.CreateSession();
            //host.Session.Add("Param", param);

            //Engine engine = new Engine();
            //OutContent = engine.ProcessTemplate(TempContent, host);

            Templating host = new Templating();
            Engine engine = new Engine();
            host.TemplateFileValue = TemplateFilePath;

            string output = engine.ProcessTemplate(TempContent, host);


            StringBuilder sbLog = new StringBuilder();
            bool error = false;
            foreach (var e in host.Errors)
            {
                sbLog.AppendLine(e.ToString());
                error = true;
            }

            if (error)
            {
                OutContent = sbLog.ToString();
            }

            //StringBuilder sbLog = new StringBuilder();
            //bool error = false;
            //foreach (var item in host.Errors)
            //{
            //    sbLog.AppendLine(item.ToString());
            //    error = true;
            //};
            //if (error)
            //{
            //    OutContent = sbLog.ToString();


            //}



        }
    }
}
