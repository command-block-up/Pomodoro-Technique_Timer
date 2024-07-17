namespace Pomodoro_Technique
{
    partial class PomodoroForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.start_button = new System.Windows.Forms.Button();
            this.read_list = new System.Windows.Forms.Button();
            this.TaskList = new System.Windows.Forms.ListBox();
            this.task_add = new System.Windows.Forms.Button();
            this.task_view = new System.Windows.Forms.Button();
            this.task_delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.show_task_info = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("字体圈欣意冠黑体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(274, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 84);
            this.label1.TabIndex = 0;
            this.label1.Text = "25:00";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(62, 96);
            this.progressBar.Maximum = 1500;
            this.progressBar.Name = "progressBar";
            this.progressBar.RightToLeftLayout = true;
            this.progressBar.Size = new System.Drawing.Size(693, 23);
            this.progressBar.TabIndex = 1;
            // 
            // start_button
            // 
            this.start_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start_button.Location = new System.Drawing.Point(334, 368);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(132, 70);
            this.start_button.TabIndex = 2;
            this.start_button.Text = "开始";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // read_list
            // 
            this.read_list.Location = new System.Drawing.Point(677, 415);
            this.read_list.Name = "read_list";
            this.read_list.Size = new System.Drawing.Size(111, 23);
            this.read_list.TabIndex = 3;
            this.read_list.Text = "ReadList";
            this.read_list.UseVisualStyleBackColor = true;
            this.read_list.Click += new System.EventHandler(this.read_list_Click);
            // 
            // TaskList
            // 
            this.TaskList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TaskList.FormattingEnabled = true;
            this.TaskList.ItemHeight = 15;
            this.TaskList.Location = new System.Drawing.Point(12, 19);
            this.TaskList.Name = "TaskList";
            this.TaskList.Size = new System.Drawing.Size(289, 169);
            this.TaskList.TabIndex = 4;
            // 
            // task_add
            // 
            this.task_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.task_add.Location = new System.Drawing.Point(307, 19);
            this.task_add.Name = "task_add";
            this.task_add.Size = new System.Drawing.Size(134, 53);
            this.task_add.TabIndex = 5;
            this.task_add.Text = "添加";
            this.task_add.UseVisualStyleBackColor = true;
            this.task_add.Click += new System.EventHandler(this.task_add_Click);
            // 
            // task_view
            // 
            this.task_view.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.task_view.Location = new System.Drawing.Point(307, 78);
            this.task_view.Name = "task_view";
            this.task_view.Size = new System.Drawing.Size(134, 53);
            this.task_view.TabIndex = 5;
            this.task_view.Text = "查看";
            this.task_view.UseVisualStyleBackColor = true;
            this.task_view.Click += new System.EventHandler(this.task_view_Click);
            // 
            // task_delete
            // 
            this.task_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.task_delete.Location = new System.Drawing.Point(307, 137);
            this.task_delete.Name = "task_delete";
            this.task_delete.Size = new System.Drawing.Size(134, 53);
            this.task_delete.TabIndex = 5;
            this.task_delete.Text = "删除";
            this.task_delete.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.Controls.Add(this.TaskList);
            this.panel1.Controls.Add(this.task_delete);
            this.panel1.Controls.Add(this.task_view);
            this.panel1.Controls.Add(this.task_add);
            this.panel1.Location = new System.Drawing.Point(62, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 213);
            this.panel1.TabIndex = 6;
            // 
            // show_task_info
            // 
            this.show_task_info.Location = new System.Drawing.Point(669, 386);
            this.show_task_info.Name = "show_task_info";
            this.show_task_info.Size = new System.Drawing.Size(119, 23);
            this.show_task_info.TabIndex = 7;
            this.show_task_info.Text = "ShowTaskInfo";
            this.show_task_info.UseVisualStyleBackColor = true;
            // 
            // PomodoroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.show_task_info);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.read_list);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Name = "PomodoroForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button read_list;
        private System.Windows.Forms.ListBox TaskList;
        private System.Windows.Forms.Button task_add;
        private System.Windows.Forms.Button task_view;
        private System.Windows.Forms.Button task_delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button show_task_info;
    }
}

