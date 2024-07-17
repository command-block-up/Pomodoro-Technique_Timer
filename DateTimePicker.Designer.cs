namespace Pomodoro_Technique
{
    partial class DateTimePicker
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
            this.Picker = new System.Windows.Forms.DateTimePicker();
            this.cancel = new System.Windows.Forms.Button();
            this.yes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Picker
            // 
            this.Picker.Location = new System.Drawing.Point(12, 12);
            this.Picker.Name = "Picker";
            this.Picker.Size = new System.Drawing.Size(279, 25);
            this.Picker.TabIndex = 0;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(151, 96);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 33);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // yes
            // 
            this.yes.Location = new System.Drawing.Point(70, 96);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(75, 33);
            this.yes.TabIndex = 1;
            this.yes.Text = "确定";
            this.yes.UseVisualStyleBackColor = true;
            this.yes.Click += new System.EventHandler(this.ok_Click);
            // 
            // DateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 141);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.Picker);
            this.Name = "DateTimePicker";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker Picker;
        public System.Windows.Forms.Button yes;
        public System.Windows.Forms.Button cancel;
    }
}