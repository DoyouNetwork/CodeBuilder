using Newtonsoft.Json;
using RazorEngine;
using RazorEngine.Templating;
using Rocket.CodeBuilder.DataBusiness;
using Rocket.CodeBuilder.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            dgv_Columns.AutoGenerateColumns = false;
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
        DBTable dt = null;

        /// <summary>
        /// 生成代码
        /// </summary>
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


            if (!string.IsNullOrEmpty(text_LanguageFilePath.Text))
            {
                try
                {
                    dt.AddLanguage(JsonConvert.DeserializeObject<List<DBDataType>>(File.ReadAllText(text_LanguageFilePath.Text)));
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

                switch (fileName)
                {
                    case "EntityService.Template":
                    case "IEntityService.Template":
                    case "EntityController.Template":
                    case "Entity.Template":
                        fileName = fileName.Replace("Template", "cs");
                        break;

                    case "Index.Template":
                        fileName = fileName.Replace("Template", "cshtml");
                        break;
                }

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


        /// <summary>
        /// 设置模板文件路径
        /// </summary>
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


        /// <summary>
        /// Db Connection
        /// </summary>
        private void btn_ConnectionDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtn_DBType_MySql.Checked)
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

            string[] tableArr = new string[] { "__EFMigrationsHistory" };
            string[] tableList = business.GetDataTableNameList(cmb_DataBaseList.SelectedItem.ToString()).Where(c => !tableArr.Contains(c)).ToArray();

            Array.Sort(tableList);
            cmb_TableList.DataSource = tableList;
        }

        /// <summary>
        /// 修改控制器名称
        /// </summary>
        private void txt_ControllerName_TextChanged(object sender, EventArgs e)
        {
            txt_GetListUrlName.Text = string.Format("/{0}/GetList", txt_ControllerName.Text);
            txt_DeleteDataUrlName.Text = string.Format("/{0}/DeleteData", txt_ControllerName.Text);
            txt_AddDataUrl.Text = string.Format("/{0}/AddData", txt_ControllerName.Text);
            txt_GetDataUrl.Text = string.Format("/{0}/GetData", txt_ControllerName.Text);
            txt_UpdateDataUrl.Text = string.Format("/{0}/UpdateData", txt_ControllerName.Text);
        }

        /// <summary>
        /// 改变表选择
        /// </summary>
        private void cmb_TableList_SelectedValueChanged(object sender, EventArgs e)
        {
            string tableName = cmb_TableList.SelectedValue.ToString();

            char[] tableNameArray = tableName.ToCharArray();

            tableNameArray[0] = tableNameArray[0].ToString().ToUpper().ToCharArray()[0];

            txt_ControllerName.Text = string.Join("", tableNameArray);
            txt_ControllerName_TextChanged(sender, e);

            dt = business.GetTable(cmb_TableList.SelectedValue.ToString());

            dgv_Columns.DataSource = dt.ColumnList;

            for (int i = 0; i < dgv_Columns.Rows.Count; i++)
            {
                DataGridViewComboBoxCell rowColumn = (DataGridViewComboBoxCell)dgv_Columns.Rows[i].Cells["WriteTypeBox"];
                if (rowColumn != null)
                {
                    rowColumn.Value = WriteType.Default.ToString();
                }
            }

        }

        /// <summary>
        /// 窗体载入
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_TemplateFilePath.Text = GetConfigValue("TemplatePath");

            txt_FileOutPath.Text = GetConfigValue("FileOutPath");

            text_LanguageFilePath.Text = GetConfigValue("LanguageFilePath");

            foreach (WriteType wt in Enum.GetValues(typeof(WriteType)))
            {
                WriteTypeBox.Items.Add(wt.ToString());
            }
        }

        /// <summary>
        /// 设置代码文件输出路径
        /// </summary>
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

        /// <summary>
        /// 选择数据库改变,查出所有表
        /// </summary>
        private void cmb_DataBaseList_SelectedValueChanged(object sender, EventArgs e)
        {
            string[] tableArr = new string[] { "__EFMigrationsHistory" };
            string[] tableList = business.GetDataTableNameList(cmb_DataBaseList.SelectedItem.ToString()).Where(c => !tableArr.Contains(c)).ToArray();
            Array.Sort(tableList);
            cmb_TableList.DataSource = tableList;
            cmb_TableList_SelectedValueChanged(sender, e);
        }

        /// <summary>
        /// 测试按钮
        /// </summary>
        private void btn_Test_Click(object sender, EventArgs e)
        {
            DBDataType dBDataType = new DBDataType
            {
                Language = LanguageType.CSharp
            };
            dBDataType.DBType.Add("varchar", "String");
            dBDataType.DBType.Add("int", "int");


            List<DBDataType> dataList = new List<DBDataType>
            {
                dBDataType
            };
            string json = JsonConvert.SerializeObject(dataList);

        }

        /// <summary>
        /// 查询配置文件
        /// </summary>
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

        private void Dgv_Columns_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Columns.Columns[e.ColumnIndex].Name == "WriteTypeBox")
            {
                DBColumn column = dgv_Columns.Rows[e.RowIndex].DataBoundItem as DBColumn;
                DataGridViewComboBoxCell comboxCell = (DataGridViewComboBoxCell)dgv_Columns.Rows[e.RowIndex].Cells["WriteTypeBox"];
                foreach (WriteType wt in Enum.GetValues(typeof(WriteType)))
                {
                    if (wt.ToString() == comboxCell.Value.ToString())
                    {
                        column.WriteType = wt;
                    }
                }
            }
        }
    }
}
