﻿namespace Pomodoro_Technique
{
    partial class TaskInfo
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
            this.name_label = new System.Windows.Forms.Label();
            this.created_at_label = new System.Windows.Forms.Label();
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.RichTextBox();
            this.updated_at_label = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.plan_finish_date_label = new System.Windows.Forms.Label();
            this.plan_finish_date_textbox = new System.Windows.Forms.TextBox();
            this.tomatoes_count_plan_label = new System.Windows.Forms.Label();
            this.tomatoes_count_plan_textbox = new System.Windows.Forms.TextBox();
            this.tomatoes_count_done_label = new System.Windows.Forms.Label();
            this.tomatoes_count_done_textbox = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(19, 35);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(37, 15);
            this.name_label.TabIndex = 0;
            this.name_label.Text = "名称";
            // 
            // created_at_label
            // 
            this.created_at_label.AutoSize = true;
            this.created_at_label.Location = new System.Drawing.Point(19, 200);
            this.created_at_label.Name = "created_at_label";
            this.created_at_label.Size = new System.Drawing.Size(67, 15);
            this.created_at_label.TabIndex = 0;
            this.created_at_label.Text = "创建时间";
            // 
            // name_textbox
            // 
            this.name_textbox.Location = new System.Drawing.Point(62, 32);
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(254, 25);
            this.name_textbox.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 197);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 25);
            this.textBox1.TabIndex = 1;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(22, 63);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(294, 128);
            this.description.TabIndex = 2;
            this.description.Text = "";
            // 
            // updated_at_label
            // 
            this.updated_at_label.AutoSize = true;
            this.updated_at_label.Location = new System.Drawing.Point(19, 234);
            this.updated_at_label.Name = "updated_at_label";
            this.updated_at_label.Size = new System.Drawing.Size(67, 15);
            this.updated_at_label.TabIndex = 0;
            this.updated_at_label.Text = "更新时间";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 231);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(224, 25);
            this.textBox2.TabIndex = 1;
            // 
            // plan_finish_date_label
            // 
            this.plan_finish_date_label.AutoSize = true;
            this.plan_finish_date_label.Location = new System.Drawing.Point(19, 270);
            this.plan_finish_date_label.Name = "plan_finish_date_label";
            this.plan_finish_date_label.Size = new System.Drawing.Size(97, 15);
            this.plan_finish_date_label.TabIndex = 0;
            this.plan_finish_date_label.Text = "计划完成时间";
            // 
            // plan_finish_date_textbox
            // 
            this.plan_finish_date_textbox.Location = new System.Drawing.Point(122, 267);
            this.plan_finish_date_textbox.Name = "plan_finish_date_textbox";
            this.plan_finish_date_textbox.Size = new System.Drawing.Size(194, 25);
            this.plan_finish_date_textbox.TabIndex = 1;
            // 
            // tomatoes_count_plan_label
            // 
            this.tomatoes_count_plan_label.AutoSize = true;
            this.tomatoes_count_plan_label.Location = new System.Drawing.Point(19, 307);
            this.tomatoes_count_plan_label.Name = "tomatoes_count_plan_label";
            this.tomatoes_count_plan_label.Size = new System.Drawing.Size(97, 15);
            this.tomatoes_count_plan_label.TabIndex = 0;
            this.tomatoes_count_plan_label.Text = "预估番茄数目";
            // 
            // tomatoes_count_plan_textbox
            // 
            this.tomatoes_count_plan_textbox.Location = new System.Drawing.Point(122, 304);
            this.tomatoes_count_plan_textbox.Name = "tomatoes_count_plan_textbox";
            this.tomatoes_count_plan_textbox.Size = new System.Drawing.Size(194, 25);
            this.tomatoes_count_plan_textbox.TabIndex = 1;
            // 
            // tomatoes_count_done_label
            // 
            this.tomatoes_count_done_label.AutoSize = true;
            this.tomatoes_count_done_label.Location = new System.Drawing.Point(19, 345);
            this.tomatoes_count_done_label.Name = "tomatoes_count_done_label";
            this.tomatoes_count_done_label.Size = new System.Drawing.Size(97, 15);
            this.tomatoes_count_done_label.TabIndex = 0;
            this.tomatoes_count_done_label.Text = "已用番茄数目";
            // 
            // tomatoes_count_done_textbox
            // 
            this.tomatoes_count_done_textbox.Location = new System.Drawing.Point(122, 342);
            this.tomatoes_count_done_textbox.Name = "tomatoes_count_done_textbox";
            this.tomatoes_count_done_textbox.Size = new System.Drawing.Size(194, 25);
            this.tomatoes_count_done_textbox.TabIndex = 1;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(56, 438);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(102, 41);
            this.ok.TabIndex = 3;
            this.ok.Text = "确定";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(164, 438);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(102, 41);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 491);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.description);
            this.Controls.Add(this.tomatoes_count_done_textbox);
            this.Controls.Add(this.tomatoes_count_plan_textbox);
            this.Controls.Add(this.plan_finish_date_textbox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.name_textbox);
            this.Controls.Add(this.tomatoes_count_done_label);
            this.Controls.Add(this.tomatoes_count_plan_label);
            this.Controls.Add(this.plan_finish_date_label);
            this.Controls.Add(this.updated_at_label);
            this.Controls.Add(this.created_at_label);
            this.Controls.Add(this.name_label);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label created_at_label;
        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.Label updated_at_label;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label plan_finish_date_label;
        private System.Windows.Forms.TextBox plan_finish_date_textbox;
        private System.Windows.Forms.Label tomatoes_count_plan_label;
        private System.Windows.Forms.TextBox tomatoes_count_plan_textbox;
        private System.Windows.Forms.Label tomatoes_count_done_label;
        private System.Windows.Forms.TextBox tomatoes_count_done_textbox;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
    }
}