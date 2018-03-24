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
        IDataBusiness business = null;
        private void btn_CodeBuilder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_TemplateFilePath.Text))
            {
                MessageBox.Show("请选择模板");
                return;
            }

            if (business == null)
            {
                MessageBox.Show("请链接数据库");
                return;
            }

            if (string.IsNullOrEmpty(cmb_TableList.SelectedValue.ToString()))
            {
                MessageBox.Show("请选择表");
                return;
            }


            string content = File.ReadAllText(txt_TemplateFilePath.Text);

            DBTable dt = business.GetTable(cmb_TableList.SelectedValue.ToString());

            dt.ControllerName = txt_ControllerName.Text;
            dt.GetListUrl = txt_GetListUrlName.Text;
            dt.AddDataUrl = txt_AddDataUrl.Text;
            dt.GetDataUrl = txt_GetDataUrl.Text;
            dt.UpdateData = txt_UpdateDataUrl.Text;
            dt.DeleteDataUrl = txt_DeleteDataUrlName.Text;


            string result = "";
            try
            {
                result = Engine.Razor.RunCompile(content, Guid.NewGuid().ToString(), null, dt);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            txt_log.Text = result;
        }


        private void btn_SelectFileTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";

            //            fileDialog.Filter = "模板文件(*.Template) | *.Template | 所有文件(*.*) | *.*"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;//返回文件的完整路径
                txt_TemplateFilePath.Text = file;
            }
        }

        private void btn_ConnectionDB_Click(object sender, EventArgs e)
        {
            business = new MySqlBLL("121.42.171.176", "root", "root", "pos");
            string[] tableList = business.GetDataTableNameList("Pos");
            cmb_TableList.DataSource = tableList;
        }

        private void txt_ControllerName_TextChanged(object sender, EventArgs e)
        {
            txt_GetListUrlName.Text = String.Format("/{0}/GetList", txt_ControllerName.Text);
            txt_DeleteDataUrlName.Text = String.Format("/{0}/DeleteData", txt_ControllerName.Text);
            txt_AddDataUrl.Text = String.Format("/{0}/AddData", txt_ControllerName.Text);
            txt_GetDataUrl.Text = String.Format("/{0}/GetData", txt_ControllerName.Text);
            txt_UpdateDataUrl.Text = String.Format("/{0}/UpdateData", txt_ControllerName.Text);
        }

        private void cmb_TableList_SelectedValueChanged(object sender, EventArgs e)
        {
            string tableName = cmb_TableList.SelectedValue.ToString();

            char[] tableNameArray = tableName.ToCharArray();

            tableNameArray[0] = tableNameArray[0].ToString().ToUpper().ToCharArray()[0];

            txt_ControllerName.Text = String.Join("", tableNameArray);
            txt_ControllerName_TextChanged(sender, e);
        }
    }
}
