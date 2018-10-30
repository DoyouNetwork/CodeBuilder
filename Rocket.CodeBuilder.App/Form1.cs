using Newtonsoft.Json;
using RazorEngine;
using RazorEngine.Templating;
using Rocket.CodeBuilder.DataBusiness;
using Rocket.CodeBuilder.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Rocket.CodeBuilder.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetConfigValue(string key)
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

        private IDataBusiness business = null;
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

            List<string> templateFileList = new List<string>();
            string[] files = Directory.GetFiles(txt_TemplateFilePath.Text, "*.Template");


            DBTable dt = business.GetTable(cmb_TableList.SelectedValue.ToString());


            if (!string.IsNullOrEmpty(text_LanguageFilePath.Text))
            {
                try
                {
                    dt.Language = JsonConvert.DeserializeObject<List<DBDataType>>(File.ReadAllText(text_LanguageFilePath.Text));
                }
                catch (Exception)
                {
                }
            }

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

            foreach (string file in files)
            {
                string[] fileTempArray = file.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                string fileName = fileTempArray[fileTempArray.Length - 1];
                fileName = fileName.Replace("Entity", txt_ControllerName.Text);
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
                    File.WriteAllText(fileOutPath + fileName, ex.Message);
                }

                txt_log.Text = result;
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
            try
            {
                if (radioButton1.Checked)
                {
                    business = new MySqlBLL(txt_DatabaseAddress.Text, txt_DatabaseUserName.Text, txt_DatabasePassword.Text);
                }
                else
                {
                    business = new SqlServerBLL(txt_DatabaseAddress.Text, txt_DatabaseUserName.Text, txt_DatabasePassword.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


            string[] arr = new string[] { "information_schema", "mysql", "performance_schema", "test" };
            cmb_DataBaseList.DataSource = business.GetDatabase().Where(c => !arr.Contains(c)).ToArray();
            cmb_DataBaseList.SelectedIndex = 0;

            string[] tableList = business.GetDataTableNameList(cmb_DataBaseList.SelectedItem.ToString());
            Array.Sort(tableList);
            cmb_TableList.DataSource = tableList;
        }

        private void txt_ControllerName_TextChanged(object sender, EventArgs e)
        {
            txt_GetListUrlName.Text = string.Format("/{0}/GetList", txt_ControllerName.Text);
            txt_DeleteDataUrlName.Text = string.Format("/{0}/DeleteData", txt_ControllerName.Text);
            txt_AddDataUrl.Text = string.Format("/{0}/AddData", txt_ControllerName.Text);
            txt_GetDataUrl.Text = string.Format("/{0}/GetData", txt_ControllerName.Text);
            txt_UpdateDataUrl.Text = string.Format("/{0}/UpdateData", txt_ControllerName.Text);
        }

        private void cmb_TableList_SelectedValueChanged(object sender, EventArgs e)
        {
            string tableName = cmb_TableList.SelectedValue.ToString();

            char[] tableNameArray = tableName.ToCharArray();

            tableNameArray[0] = tableNameArray[0].ToString().ToUpper().ToCharArray()[0];

            txt_ControllerName.Text = string.Join("", tableNameArray);
            txt_ControllerName_TextChanged(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_TemplateFilePath.Text = GetConfigValue("TemplatePath");

            txt_FileOutPath.Text = GetConfigValue("FileOutPath");

            text_LanguageFilePath.Text = GetConfigValue("LanguageFilePath");
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
            string[] tableList = business.GetDataTableNameList(cmb_DataBaseList.SelectedItem.ToString());
            Array.Sort(tableList);
            cmb_TableList.DataSource = tableList;
            cmb_TableList_SelectedValueChanged(sender, e);
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("varchar", "String");

            //JsonConvert
        }

        private void btn_SelectLanguageFile_Click(object sender, EventArgs e)
        {
            string filePath = GetConfigValue("LanguageFilePath");

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Files (*.json)|*.json"//如果需要筛选txt文件（"Files (*.txt)|*.txt"）
            };
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                text_LanguageFilePath.Text = filePath;
                SaveConfigValue("LanguageFilePath", filePath);
            }
        }
    }
}
