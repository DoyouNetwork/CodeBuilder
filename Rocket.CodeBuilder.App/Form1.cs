using Rocket.CodeBuilder.DataBusiness;
using Rocket.CodeBuilder.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
