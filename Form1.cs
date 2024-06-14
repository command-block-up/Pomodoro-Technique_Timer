using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pomodoro_Technique
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timerUpdateProgress;

        public Form1()
        {
            InitializeComponent();
            // 初始化Timer
            timerUpdateProgress = new System.Windows.Forms.Timer();
            timerUpdateProgress.Interval = 60000; // 每隔60000毫秒（即60秒）触发一次Tick事件
            timerUpdateProgress.Tick += TimerUpdateProgress_Tick; // 设置Tick事件的处理方法
        }

        private void TimerUpdateProgress_Tick(object sender, EventArgs e)
        {
            // 更新进度条的值，这里以逐步增加到100为例
            if (progressBar.Value < 100)
            {
                progressBar.Value += 10; // 每次增加10，根据需要调整
            }
            else
            {
                // 当进度条达到最大值时，停止计时器
                timerUpdateProgress.Stop();
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            // 开始计时器
            timerUpdateProgress.Start();
        }
    }
}
