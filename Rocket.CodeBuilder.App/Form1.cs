using Rocket.CodeBuilder.DataBusiness;
using Rocket.CodeBuilder.Template;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using RazorEngine;
using RazorEngine.Templating;
using System.IO;
using Rocket.CodeBuilder.Model;
using System.Configuration;
using System.Collections.Generic;

namespace Rocket.CodeBuilder.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public String GetConfigValue(string key)
        {
            string v = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(v))
            {
                return "";
            }
            else
            {
                return v;
            }
        }

        public void SaveConfigValue(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (!config.AppSettings.Settings.AllKeys.Contains(key))
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        IDataBusiness business = null;
        private void btn_CodeBuilder_Click(object sender, EventArgs e)
        {
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

            if (string.IsNullOrEmpty(txt_TemplateFilePath.Text))
            {
                MessageBox.Show("请选择模板");
                return;
            }

            List<String> templateFileList = new List<string>();
            string[] files = Directory.GetFiles(txt_TemplateFilePath.Text, "*.Template");


            DBTable dt = business.GetTable(cmb_TableList.SelectedValue.ToString());

            dt.ControllerName = txt_ControllerName.Text;
            dt.GetListUrl = txt_GetListUrlName.Text;
            dt.AddDataUrl = txt_AddDataUrl.Text;
            dt.GetDataUrl = txt_GetDataUrl.Text;
            dt.UpdateData = txt_UpdateDataUrl.Text;
            dt.DeleteDataUrl = txt_DeleteDataUrlName.Text;

            string fileOutPath = string.Format("{0}\\{1}\\", txt_FileOutPath.Text, dt.Name);
            if (!Directory.Exists(fileOutPath))
            {
                Directory.CreateDirectory(fileOutPath);
            }

            foreach (var file in files)
            {
                string[] fileTempArray = file.Split(new String[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                string fileName = fileTempArray[fileTempArray.Length - 1];
                switch (fileName)
                {
                    case "Controller.Template":
                        fileName = $"{txt_ControllerName.Text}Controller.cs";
                        break;
                    case "Model.Template":
                        fileName = $"{txt_ControllerName.Text}.cs";
                        break;
                    case "Edit.Template":
                        fileName = $"Edit.cshtml";
                        break;
                    case "List.Template":
                        fileName = $"List.cshtml";
                        break;
                }
                string content = File.ReadAllText(file);
                string result = "";
                try
                {
                    result = Engine.Razor.RunCompile(content, Guid.NewGuid().ToString(), null, dt);

                    File.WriteAllText(fileOutPath + fileName, result);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

                txt_log.Text += result + "\r\n";
            }


        }


        private void btn_SelectFileTemplate_Click(object sender, EventArgs e)
        {
            string path = GetConfigValue("TemplatePath");

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (!string.IsNullOrEmpty(path))
            {
                dialog.SelectedPath = path;
            }
            dialog.Description = "请选择模板文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                txt_TemplateFilePath.Text = foldPath;
                SaveConfigValue("TemplatePath", foldPath);
            }
        }

        private void btn_ConnectionDB_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                business = new MySqlBLL(txt_DatabaseAddress.Text, txt_DatabaseUserName.Text, txt_DatabasePassword.Text);
            }
            else
            {
                //business = new ("111.230.185.209", "root", "root");
            }


            cmb_DataBaseList.DataSource = business.GetDatabase();
            cmb_DataBaseList.SelectedIndex = 0;

            string[] tableList = business.GetDataTableNameList(cmb_DataBaseList.SelectedItem.ToString());
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

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_TemplateFilePath.Text = GetConfigValue("TemplatePath");

            txt_FileOutPath.Text = GetConfigValue("FileOutPath");
        }

        private void btn_FileSavePath_Click(object sender, EventArgs e)
        {
            string path = GetConfigValue("FileOutPath");

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (!string.IsNullOrEmpty(path))
            {
                dialog.SelectedPath = path;
            }
            dialog.Description = "请选择文件输出路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                txt_FileOutPath.Text = foldPath;
                SaveConfigValue("FileOutPath", foldPath);
            }
        }

        private void cmb_DataBaseList_SelectedValueChanged(object sender, EventArgs e)
        {
            cmb_TableList.DataSource = business.GetDataTableNameList(cmb_DataBaseList.SelectedItem.ToString());
            cmb_TableList_SelectedValueChanged(sender, e);
        }
    }
}
