using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomodoro_Technique
{
    public partial class TaskInfo : Form
    {
        public TaskInfo()
        {
            InitializeComponent();
        }
        private void ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void set_plan_finish_date_Click(object sender, EventArgs e)
        {
            using (DateTimePicker dateTimePicker = new DateTimePicker())
            {
                // 显示模式对话框，等待用户交互
                DialogResult result = dateTimePicker.ShowDialog(this);

                // 当对话框关闭时，根据返回的DialogResult执行后续操作
                if (result == DialogResult.OK)
                {
                    Global.planFinishDate = dateTimePicker.Picker.Value;
                }
                else if (result == DialogResult.Cancel)
                {
                    // 执行Cancel操作
                }
            }
        }
    }
}
