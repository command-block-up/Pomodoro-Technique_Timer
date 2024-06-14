using System;
using System.Windows.Forms;

namespace Pomodoro_Technique
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Timer countdownTimer; // 倒计时定时器
        private int totalSeconds = 1500;
        private Timer timerUpdateProgress;

        public Form()
        {
            InitializeComponent();
            InitializeCountdownTimer();
            // 初始化Timer
            timerUpdateProgress = new System.Windows.Forms.Timer();
            timerUpdateProgress.Interval = 60000; // 每隔60000毫秒（即60秒）触发一次Tick事件
            timerUpdateProgress.Tick += TimerUpdateProgress_Tick; // 设置Tick事件的处理方法
        }

        private void InitializeCountdownTimer()
        {
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // 每隔1000毫秒（即1秒）触发一次Tick事件
            countdownTimer.Tick += CountdownTimer_Tick;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            totalSeconds--; // 时间递减1秒
            if (totalSeconds <= 0)
            {
                // 倒计时结束，停止定时器
                countdownTimer.Stop();
                label1.Text = "Time's up!";
            }
            else
            {
                // 计算剩余的分钟和秒，并更新Label
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds % 60;
                label1.Text = $"{minutes:D2}:{seconds:D2}"; // D2保证了即使是个位数也会显示为两位数，如01:05
            }
        }


        private void TimerUpdateProgress_Tick(object sender, EventArgs e)
        {
            // 更新进度条的值，这里以逐步增加到100为例
            if (progressBar.Value < 100)
            {
                progressBar.Value += 4; // 每次增加4，根据需要调整
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
            countdownTimer.Start();
            timerUpdateProgress.Start();
        }
    }
}
