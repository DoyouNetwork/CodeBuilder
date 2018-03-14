using Rocket.CodeBuilder.DataBusiness;
using Rocket.CodeBuilder.Template;
using System;
using System.Data;
using System.Windows.Forms;

using RazorEngine;
using RazorEngine.Templating;
using System.IO;
using Rocket.CodeBuilder.Model;

namespace Rocket.CodeBuilder.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_CodeBuilder_Click(object sender, EventArgs e)
        {
            //server=123.207.96.103;user id=root; password=root_1234; database=jinggongqiangjiang"
            IDataBusiness business = new MySqlBLL("127.0.0.1", "root", "root", "jinggongqiangjiang");


            DataTable dt = business.GetDataTableByName("ERP_Account");

            BuilderCode bc = new BuilderCode(dt)
            {
                NameSpace = "Incloud"
            };

            bc.CodeItem.Namespace = bc.NameSpace;

            //生成实体模型代码
            bc.TemplateFilePath = "D:\\Projects\\Template\\Index.tt";
            bc.OutFileName = string.Format("Index.cshtml");
            bc.OutFilePath = string.Format(@"D:\\Projects\\Code\\");
            bc.CreateTemplate();

            txt_log.Text = bc.OutContent;

            Console.WriteLine("生成完毕");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDataBusiness business = new MySqlBLL("127.0.0.1", "root", "root", "jinggongqiangjiang");
            #region 备份
            string name = "Account";
            string content = File.ReadAllText("D:\\Projects\\Template\\" + name + "\\Index.template");

            DBTable dt = business.GetTable("erp_account");
            DataColumn[] dataColumnList = business.GetColums("erp_account");

            string result = "";
            try
            {
                result = Engine.Razor.RunCompile(content, Guid.NewGuid().ToString(), null, dt);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }


            //var result = Engine.Razor.RunCompile(template, "templateKey1", null, new { Name = "World" });



            //foreach (DataColumn item in dataColumnList)
            //{
            //    dataListCode.AppendFormat("{{ field: '{0}', title: '{0}' }},", item.ColumnName).AppendLine();
            //}

            //content = content.Replace("@(ControllerName)", name);
            //content = content.Replace("@(DataListCode)", dataListCode.ToString());
            if (!Directory.Exists("D:\\Projects\\Template\\" + name + "\\"))
            {
                Directory.CreateDirectory("D:\\Projects\\Template\\" + name + "\\");
            }
            File.WriteAllText("D:\\Projects\\Template\\" + name + "\\Index.cshtml", result);
            #endregion

        }
    }
}
