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
            this.SuspendLayout();
            // 
            // btn_CodeBuilder
            // 
            this.btn_CodeBuilder.Location = new System.Drawing.Point(13, 13);
            this.btn_CodeBuilder.Name = "btn_CodeBuilder";
            this.btn_CodeBuilder.Size = new System.Drawing.Size(75, 23);
            this.btn_CodeBuilder.TabIndex = 0;
            this.btn_CodeBuilder.Text = "button1";
            this.btn_CodeBuilder.UseVisualStyleBackColor = true;
            this.btn_CodeBuilder.Click += new System.EventHandler(this.btn_CodeBuilder_Click);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(12, 59);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(601, 492);
            this.txt_log.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 563);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.btn_CodeBuilder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CodeBuilder;
        private System.Windows.Forms.TextBox txt_log;
    }
}

