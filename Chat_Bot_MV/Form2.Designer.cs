namespace Chat_Bot_MV
{
    partial class Form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_report = new System.Windows.Forms.TextBox();
            this.textBox_request = new System.Windows.Forms.TextBox();
            this.button_enter = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_report
            // 
            this.textBox_report.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_report.Location = new System.Drawing.Point(12, 21);
            this.textBox_report.Multiline = true;
            this.textBox_report.Name = "textBox_report";
            this.textBox_report.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_report.Size = new System.Drawing.Size(665, 349);
            this.textBox_report.TabIndex = 0;
            this.textBox_report.TabStop = false;
            this.textBox_report.TextChanged += new System.EventHandler(this.textBox_report_TextChanged_1);
            // 
            // textBox_request
            // 
            this.textBox_request.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox_request.Location = new System.Drawing.Point(12, 395);
            this.textBox_request.Multiline = true;
            this.textBox_request.Name = "textBox_request";
            this.textBox_request.Size = new System.Drawing.Size(665, 22);
            this.textBox_request.TabIndex = 1;
            // 
            // button_enter
            // 
            this.button_enter.Location = new System.Drawing.Point(704, 395);
            this.button_enter.Name = "button_enter";
            this.button_enter.Size = new System.Drawing.Size(94, 23);
            this.button_enter.TabIndex = 2;
            this.button_enter.Text = "Отправить";
            this.button_enter.UseVisualStyleBackColor = true;
            this.button_enter.Click += new System.EventHandler(this.button_enter_Click_1);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(704, 357);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(94, 23);
            this.button_clear.TabIndex = 3;
            this.button_clear.Text = "Удалить";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click_1);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::Chat_Bot_MV.Properties.Resources.Зернистый_фон_градиент;
            this.ClientSize = new System.Drawing.Size(822, 453);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_enter);
            this.Controls.Add(this.textBox_request);
            this.Controls.Add(this.textBox_report);
            this.KeyPreview = true;
            this.Name = "Form_main";
            this.Text = "Чат-Бот";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_main_KeyDown_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_report;
        private System.Windows.Forms.TextBox textBox_request;
        private System.Windows.Forms.Button button_enter;
        private System.Windows.Forms.Button button_clear;
    }
}