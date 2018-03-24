namespace Rocket.CodeBuilder.App
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
            this.SuspendLayout();
            // 
            // btn_CodeBuilder
            // 
            this.btn_CodeBuilder.Location = new System.Drawing.Point(635, 93);
            this.btn_CodeBuilder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_CodeBuilder.Name = "btn_CodeBuilder";
            this.btn_CodeBuilder.Size = new System.Drawing.Size(185, 69);
            this.btn_CodeBuilder.TabIndex = 0;
            this.btn_CodeBuilder.Text = "生成代码";
            this.btn_CodeBuilder.UseVisualStyleBackColor = true;
            this.btn_CodeBuilder.Click += new System.EventHandler(this.btn_CodeBuilder_Click);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(16, 179);
            this.txt_log.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(804, 509);
            this.txt_log.TabIndex = 1;
            // 
            // txt_ControllerName
            // 
            this.txt_ControllerName.Location = new System.Drawing.Point(116, 82);
            this.txt_ControllerName.Name = "txt_ControllerName";
            this.txt_ControllerName.Size = new System.Drawing.Size(160, 25);
            this.txt_ControllerName.TabIndex = 3;
            this.txt_ControllerName.TextChanged += new System.EventHandler(this.txt_ControllerName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "控制器名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "获取数据接口";
            // 
            // txt_GetListUrlName
            // 
            this.txt_GetListUrlName.Location = new System.Drawing.Point(116, 113);
            this.txt_GetListUrlName.Name = "txt_GetListUrlName";
            this.txt_GetListUrlName.Size = new System.Drawing.Size(160, 25);
            this.txt_GetListUrlName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "删除数据接口";
            // 
            // txt_DeleteDataUrlName
            // 
            this.txt_DeleteDataUrlName.Location = new System.Drawing.Point(392, 147);
            this.txt_DeleteDataUrlName.Name = "txt_DeleteDataUrlName";
            this.txt_DeleteDataUrlName.Size = new System.Drawing.Size(160, 25);
            this.txt_DeleteDataUrlName.TabIndex = 7;
            // 
            // btn_SelectFileTemplate
            // 
            this.btn_SelectFileTemplate.Location = new System.Drawing.Point(323, 43);
            this.btn_SelectFileTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SelectFileTemplate.Name = "btn_SelectFileTemplate";
            this.btn_SelectFileTemplate.Size = new System.Drawing.Size(132, 29);
            this.btn_SelectFileTemplate.TabIndex = 9;
            this.btn_SelectFileTemplate.Text = "选择文件模板";
            this.btn_SelectFileTemplate.UseVisualStyleBackColor = true;
            this.btn_SelectFileTemplate.Click += new System.EventHandler(this.btn_SelectFileTemplate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "模板路径";
            // 
            // txt_TemplateFilePath
            // 
            this.txt_TemplateFilePath.Location = new System.Drawing.Point(116, 43);
            this.txt_TemplateFilePath.Name = "txt_TemplateFilePath";
            this.txt_TemplateFilePath.Size = new System.Drawing.Size(160, 25);
            this.txt_TemplateFilePath.TabIndex = 10;
            // 
            // btn_ConnectionDB
            // 
            this.btn_ConnectionDB.Location = new System.Drawing.Point(13, 13);
            this.btn_ConnectionDB.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ConnectionDB.Name = "btn_ConnectionDB";
            this.btn_ConnectionDB.Size = new System.Drawing.Size(100, 29);
            this.btn_ConnectionDB.TabIndex = 12;
            this.btn_ConnectionDB.Text = "连接数据库";
            this.btn_ConnectionDB.UseVisualStyleBackColor = true;
            this.btn_ConnectionDB.Click += new System.EventHandler(this.btn_ConnectionDB_Click);
            // 
            // cmb_TableList
            // 
            this.cmb_TableList.FormattingEnabled = true;
            this.cmb_TableList.Location = new System.Drawing.Point(120, 12);
            this.cmb_TableList.Name = "cmb_TableList";
            this.cmb_TableList.Size = new System.Drawing.Size(185, 23);
            this.cmb_TableList.TabIndex = 13;
            this.cmb_TableList.SelectedValueChanged += new System.EventHandler(this.cmb_TableList_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "添加数据接口";
            // 
            // txt_AddDataUrl
            // 
            this.txt_AddDataUrl.Location = new System.Drawing.Point(116, 144);
            this.txt_AddDataUrl.Name = "txt_AddDataUrl";
            this.txt_AddDataUrl.Size = new System.Drawing.Size(160, 25);
            this.txt_AddDataUrl.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "获取数据接口";
            // 
            // txt_GetDataUrl
            // 
            this.txt_GetDataUrl.Location = new System.Drawing.Point(392, 85);
            this.txt_GetDataUrl.Name = "txt_GetDataUrl";
            this.txt_GetDataUrl.Size = new System.Drawing.Size(160, 25);
            this.txt_GetDataUrl.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "更新数据接口";
            // 
            // txt_UpdateDataUrl
            // 
            this.txt_UpdateDataUrl.Location = new System.Drawing.Point(392, 116);
            this.txt_UpdateDataUrl.Name = "txt_UpdateDataUrl";
            this.txt_UpdateDataUrl.Size = new System.Drawing.Size(160, 25);
            this.txt_UpdateDataUrl.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 704);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

