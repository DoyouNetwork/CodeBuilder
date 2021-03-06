﻿namespace Rocket.CodeBuilder.App
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_CodeBuilder = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.txt_ControllerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_GetListUrlName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DeleteDataUrlName = new System.Windows.Forms.TextBox();
            this.btn_SelectFileTemplate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_TemplateFilePath = new System.Windows.Forms.TextBox();
            this.btn_ConnectionDB = new System.Windows.Forms.Button();
            this.cmb_TableList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_AddDataUrl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_GetDataUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_UpdateDataUrl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_FileOutPath = new System.Windows.Forms.TextBox();
            this.btn_FileSavePath = new System.Windows.Forms.Button();
            this.cmb_DataBaseList = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_DatabaseAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_DatabaseUserName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_DatabasePassword = new System.Windows.Forms.TextBox();
            this.rbtn_DBType_MySql = new System.Windows.Forms.RadioButton();
            this.rbtn_DBType_SqlServer = new System.Windows.Forms.RadioButton();
            this.btn_Test = new System.Windows.Forms.Button();
            this.btn_SelectLanguageFile = new System.Windows.Forms.Button();
            this.text_LanguageFilePath = new System.Windows.Forms.TextBox();
            this.btn_WriteSettings = new System.Windows.Forms.Button();
            this.dgv_Columns = new System.Windows.Forms.DataGridView();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Node = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DbType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WriteTypeBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Columns)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CodeBuilder
            // 
            this.btn_CodeBuilder.Location = new System.Drawing.Point(720, 248);
            this.btn_CodeBuilder.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CodeBuilder.Name = "btn_CodeBuilder";
            this.btn_CodeBuilder.Size = new System.Drawing.Size(208, 82);
            this.btn_CodeBuilder.TabIndex = 0;
            this.btn_CodeBuilder.Text = "生成代码";
            this.btn_CodeBuilder.UseVisualStyleBackColor = true;
            this.btn_CodeBuilder.Click += new System.EventHandler(this.btn_CodeBuilder_Click);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(18, 352);
            this.txt_log.Margin = new System.Windows.Forms.Padding(4);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(904, 472);
            this.txt_log.TabIndex = 1;
            // 
            // txt_ControllerName
            // 
            this.txt_ControllerName.Location = new System.Drawing.Point(136, 236);
            this.txt_ControllerName.Name = "txt_ControllerName";
            this.txt_ControllerName.Size = new System.Drawing.Size(180, 28);
            this.txt_ControllerName.TabIndex = 3;
            this.txt_ControllerName.TextChanged += new System.EventHandler(this.txt_ControllerName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "控制器名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "获取数据接口";
            // 
            // txt_GetListUrlName
            // 
            this.txt_GetListUrlName.Location = new System.Drawing.Point(136, 272);
            this.txt_GetListUrlName.Name = "txt_GetListUrlName";
            this.txt_GetListUrlName.Size = new System.Drawing.Size(180, 28);
            this.txt_GetListUrlName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "删除数据接口";
            // 
            // txt_DeleteDataUrlName
            // 
            this.txt_DeleteDataUrlName.Location = new System.Drawing.Point(447, 314);
            this.txt_DeleteDataUrlName.Name = "txt_DeleteDataUrlName";
            this.txt_DeleteDataUrlName.Size = new System.Drawing.Size(180, 28);
            this.txt_DeleteDataUrlName.TabIndex = 7;
            // 
            // btn_SelectFileTemplate
            // 
            this.btn_SelectFileTemplate.Location = new System.Drawing.Point(368, 154);
            this.btn_SelectFileTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SelectFileTemplate.Name = "btn_SelectFileTemplate";
            this.btn_SelectFileTemplate.Size = new System.Drawing.Size(178, 34);
            this.btn_SelectFileTemplate.TabIndex = 9;
            this.btn_SelectFileTemplate.Text = "选择文件模板";
            this.btn_SelectFileTemplate.UseVisualStyleBackColor = true;
            this.btn_SelectFileTemplate.Click += new System.EventHandler(this.btn_SelectFileTemplate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "模板路径";
            // 
            // txt_TemplateFilePath
            // 
            this.txt_TemplateFilePath.Location = new System.Drawing.Point(105, 154);
            this.txt_TemplateFilePath.Name = "txt_TemplateFilePath";
            this.txt_TemplateFilePath.Size = new System.Drawing.Size(242, 28);
            this.txt_TemplateFilePath.TabIndex = 10;
            // 
            // btn_ConnectionDB
            // 
            this.btn_ConnectionDB.Location = new System.Drawing.Point(21, 112);
            this.btn_ConnectionDB.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ConnectionDB.Name = "btn_ConnectionDB";
            this.btn_ConnectionDB.Size = new System.Drawing.Size(112, 34);
            this.btn_ConnectionDB.TabIndex = 12;
            this.btn_ConnectionDB.Text = "连接数据库";
            this.btn_ConnectionDB.UseVisualStyleBackColor = true;
            this.btn_ConnectionDB.Click += new System.EventHandler(this.btn_ConnectionDB_Click);
            // 
            // cmb_TableList
            // 
            this.cmb_TableList.FormattingEnabled = true;
            this.cmb_TableList.Location = new System.Drawing.Point(468, 117);
            this.cmb_TableList.Name = "cmb_TableList";
            this.cmb_TableList.Size = new System.Drawing.Size(286, 26);
            this.cmb_TableList.TabIndex = 13;
            this.cmb_TableList.SelectedValueChanged += new System.EventHandler(this.cmb_TableList_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "添加数据接口";
            // 
            // txt_AddDataUrl
            // 
            this.txt_AddDataUrl.Location = new System.Drawing.Point(136, 309);
            this.txt_AddDataUrl.Name = "txt_AddDataUrl";
            this.txt_AddDataUrl.Size = new System.Drawing.Size(180, 28);
            this.txt_AddDataUrl.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 17;
            this.label6.Text = "获取数据接口";
            // 
            // txt_GetDataUrl
            // 
            this.txt_GetDataUrl.Location = new System.Drawing.Point(447, 238);
            this.txt_GetDataUrl.Name = "txt_GetDataUrl";
            this.txt_GetDataUrl.Size = new System.Drawing.Size(180, 28);
            this.txt_GetDataUrl.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "更新数据接口";
            // 
            // txt_UpdateDataUrl
            // 
            this.txt_UpdateDataUrl.Location = new System.Drawing.Point(447, 276);
            this.txt_UpdateDataUrl.Name = "txt_UpdateDataUrl";
            this.txt_UpdateDataUrl.Size = new System.Drawing.Size(180, 28);
            this.txt_UpdateDataUrl.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "文件输出路径";
            // 
            // txt_FileOutPath
            // 
            this.txt_FileOutPath.Location = new System.Drawing.Point(141, 198);
            this.txt_FileOutPath.Name = "txt_FileOutPath";
            this.txt_FileOutPath.Size = new System.Drawing.Size(206, 28);
            this.txt_FileOutPath.TabIndex = 21;
            // 
            // btn_FileSavePath
            // 
            this.btn_FileSavePath.Location = new System.Drawing.Point(368, 198);
            this.btn_FileSavePath.Margin = new System.Windows.Forms.Padding(4);
            this.btn_FileSavePath.Name = "btn_FileSavePath";
            this.btn_FileSavePath.Size = new System.Drawing.Size(178, 34);
            this.btn_FileSavePath.TabIndex = 20;
            this.btn_FileSavePath.Text = "选择文件保存路径";
            this.btn_FileSavePath.UseVisualStyleBackColor = true;
            this.btn_FileSavePath.Click += new System.EventHandler(this.btn_FileSavePath_Click);
            // 
            // cmb_DataBaseList
            // 
            this.cmb_DataBaseList.FormattingEnabled = true;
            this.cmb_DataBaseList.Location = new System.Drawing.Point(141, 117);
            this.cmb_DataBaseList.Name = "cmb_DataBaseList";
            this.cmb_DataBaseList.Size = new System.Drawing.Size(319, 26);
            this.cmb_DataBaseList.TabIndex = 24;
            this.cmb_DataBaseList.SelectedValueChanged += new System.EventHandler(this.cmb_DataBaseList_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 18);
            this.label9.TabIndex = 26;
            this.label9.Text = "数据库地址:";
            // 
            // txt_DatabaseAddress
            // 
            this.txt_DatabaseAddress.Location = new System.Drawing.Point(132, 16);
            this.txt_DatabaseAddress.Name = "txt_DatabaseAddress";
            this.txt_DatabaseAddress.Size = new System.Drawing.Size(242, 28);
            this.txt_DatabaseAddress.TabIndex = 25;
            this.txt_DatabaseAddress.Text = ".";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(381, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 18);
            this.label10.TabIndex = 28;
            this.label10.Text = "用户名:";
            // 
            // txt_DatabaseUserName
            // 
            this.txt_DatabaseUserName.Location = new System.Drawing.Point(458, 16);
            this.txt_DatabaseUserName.Name = "txt_DatabaseUserName";
            this.txt_DatabaseUserName.Size = new System.Drawing.Size(158, 28);
            this.txt_DatabaseUserName.TabIndex = 27;
            this.txt_DatabaseUserName.Text = "sa";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(624, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 18);
            this.label11.TabIndex = 30;
            this.label11.Text = "密码:";
            // 
            // txt_DatabasePassword
            // 
            this.txt_DatabasePassword.Location = new System.Drawing.Point(682, 16);
            this.txt_DatabasePassword.Name = "txt_DatabasePassword";
            this.txt_DatabasePassword.Size = new System.Drawing.Size(236, 28);
            this.txt_DatabasePassword.TabIndex = 29;
            this.txt_DatabasePassword.Text = "111111";
            // 
            // rbtn_DBType_MySql
            // 
            this.rbtn_DBType_MySql.AutoSize = true;
            this.rbtn_DBType_MySql.Location = new System.Drawing.Point(24, 60);
            this.rbtn_DBType_MySql.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn_DBType_MySql.Name = "rbtn_DBType_MySql";
            this.rbtn_DBType_MySql.Size = new System.Drawing.Size(78, 22);
            this.rbtn_DBType_MySql.TabIndex = 31;
            this.rbtn_DBType_MySql.Text = "Mysql";
            this.rbtn_DBType_MySql.UseVisualStyleBackColor = true;
            // 
            // rbtn_DBType_SqlServer
            // 
            this.rbtn_DBType_SqlServer.AutoSize = true;
            this.rbtn_DBType_SqlServer.Checked = true;
            this.rbtn_DBType_SqlServer.Location = new System.Drawing.Point(112, 60);
            this.rbtn_DBType_SqlServer.Margin = new System.Windows.Forms.Padding(4);
            this.rbtn_DBType_SqlServer.Name = "rbtn_DBType_SqlServer";
            this.rbtn_DBType_SqlServer.Size = new System.Drawing.Size(114, 22);
            this.rbtn_DBType_SqlServer.TabIndex = 32;
            this.rbtn_DBType_SqlServer.TabStop = true;
            this.rbtn_DBType_SqlServer.Text = "SQLServer";
            this.rbtn_DBType_SqlServer.UseVisualStyleBackColor = true;
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(810, 156);
            this.btn_Test.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(118, 82);
            this.btn_Test.TabIndex = 33;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // btn_SelectLanguageFile
            // 
            this.btn_SelectLanguageFile.Location = new System.Drawing.Point(555, 154);
            this.btn_SelectLanguageFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SelectLanguageFile.Name = "btn_SelectLanguageFile";
            this.btn_SelectLanguageFile.Size = new System.Drawing.Size(246, 34);
            this.btn_SelectLanguageFile.TabIndex = 34;
            this.btn_SelectLanguageFile.Text = "语言配置文件";
            this.btn_SelectLanguageFile.UseVisualStyleBackColor = true;
            this.btn_SelectLanguageFile.Click += new System.EventHandler(this.btn_SelectLanguageFile_Click);
            // 
            // text_LanguageFilePath
            // 
            this.text_LanguageFilePath.Location = new System.Drawing.Point(555, 198);
            this.text_LanguageFilePath.Name = "text_LanguageFilePath";
            this.text_LanguageFilePath.Size = new System.Drawing.Size(246, 28);
            this.text_LanguageFilePath.TabIndex = 35;
            // 
            // btn_WriteSettings
            // 
            this.btn_WriteSettings.Location = new System.Drawing.Point(764, 112);
            this.btn_WriteSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btn_WriteSettings.Name = "btn_WriteSettings";
            this.btn_WriteSettings.Size = new System.Drawing.Size(160, 34);
            this.btn_WriteSettings.TabIndex = 36;
            this.btn_WriteSettings.Text = "输出设置";
            this.btn_WriteSettings.UseVisualStyleBackColor = true;
            // 
            // dgv_Columns
            // 
            this.dgv_Columns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Columns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DisplayName,
            this.Node,
            this.DbType,
            this.WriteTypeBox});
            this.dgv_Columns.Location = new System.Drawing.Point(938, 16);
            this.dgv_Columns.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Columns.Name = "dgv_Columns";
            this.dgv_Columns.RowHeadersWidth = 62;
            this.dgv_Columns.RowTemplate.Height = 23;
            this.dgv_Columns.Size = new System.Drawing.Size(1108, 810);
            this.dgv_Columns.TabIndex = 37;
            this.dgv_Columns.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Columns_CellValueChanged);
            // 
            // DisplayName
            // 
            this.DisplayName.DataPropertyName = "Name";
            this.DisplayName.HeaderText = "名称";
            this.DisplayName.MinimumWidth = 8;
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Width = 150;
            // 
            // Node
            // 
            this.Node.DataPropertyName = "Node";
            this.Node.HeaderText = "中文名称";
            this.Node.MinimumWidth = 8;
            this.Node.Name = "Node";
            this.Node.Width = 150;
            // 
            // DbType
            // 
            this.DbType.DataPropertyName = "DbType";
            this.DbType.HeaderText = "数据库类型";
            this.DbType.MinimumWidth = 8;
            this.DbType.Name = "DbType";
            this.DbType.Width = 150;
            // 
            // WriteTypeBox
            // 
            this.WriteTypeBox.HeaderText = "输出类型";
            this.WriteTypeBox.MinimumWidth = 8;
            this.WriteTypeBox.Name = "WriteTypeBox";
            this.WriteTypeBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WriteTypeBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.WriteTypeBox.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2059, 841);
            this.Controls.Add(this.dgv_Columns);
            this.Controls.Add(this.btn_WriteSettings);
            this.Controls.Add(this.text_LanguageFilePath);
            this.Controls.Add(this.btn_SelectLanguageFile);
            this.Controls.Add(this.btn_Test);
            this.Controls.Add(this.rbtn_DBType_SqlServer);
            this.Controls.Add(this.rbtn_DBType_MySql);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_DatabasePassword);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_DatabaseUserName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_DatabaseAddress);
            this.Controls.Add(this.cmb_DataBaseList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_FileOutPath);
            this.Controls.Add(this.btn_FileSavePath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_UpdateDataUrl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_GetDataUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_AddDataUrl);
            this.Controls.Add(this.cmb_TableList);
            this.Controls.Add(this.btn_ConnectionDB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_TemplateFilePath);
            this.Controls.Add(this.btn_SelectFileTemplate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_DeleteDataUrlName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_GetListUrlName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ControllerName);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.btn_CodeBuilder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "火箭代码生成器";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Columns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CodeBuilder;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.TextBox txt_ControllerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_GetListUrlName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_DeleteDataUrlName;
        private System.Windows.Forms.Button btn_SelectFileTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_TemplateFilePath;
        private System.Windows.Forms.Button btn_ConnectionDB;
        private System.Windows.Forms.ComboBox cmb_TableList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_AddDataUrl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_GetDataUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_UpdateDataUrl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_FileOutPath;
        private System.Windows.Forms.Button btn_FileSavePath;
        private System.Windows.Forms.ComboBox cmb_DataBaseList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_DatabaseAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_DatabaseUserName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_DatabasePassword;
        private System.Windows.Forms.RadioButton rbtn_DBType_MySql;
        private System.Windows.Forms.RadioButton rbtn_DBType_SqlServer;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Button btn_SelectLanguageFile;
        private System.Windows.Forms.TextBox text_LanguageFilePath;
        private System.Windows.Forms.Button btn_WriteSettings;
        private System.Windows.Forms.DataGridView dgv_Columns;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Node;
        private System.Windows.Forms.DataGridViewTextBoxColumn DbType;
        private System.Windows.Forms.DataGridViewComboBoxColumn WriteTypeBox;
    }
}

