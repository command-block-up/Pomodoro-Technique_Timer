using System;
using System.Windows.Forms;

namespace Pomodoro_Technique
{
    public partial class PomodoroForm : Form
    {
        // 倒计时定时器，负责递减剩余时间
        private System.Windows.Forms.Timer countdownTimer;

        // 当前任务的剩余秒数，根据会话类型动态调整
        private int remainingSeconds;

        // 进度条更新定时器，与倒计时同步更新UI上的进度条
        private System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.Timer restProgressTimer;

        // 标识当前是否正处于计时期间
        private bool isRunning;

        // 番茄钟的标准时长（分钟）
        private const int PomodoroDurationMinutes = 25;

        // 短休息时长（分钟）
        private const int ShortBreakDurationMinutes = 10;

        // 长休息时长（分钟）
        private const int LongBreakDurationMinutes = 30;

        // 记录已经完成的番茄钟数量，用于决定何时进行长休息
        private int completedPomodoros;

        // 枚举定义了三种会话类型，简化逻辑判断
        private enum SessionType { Pomodoro, ShortBreak, LongBreak }

        // 当前正在进行的会话类型
        private SessionType currentSession;

        public PomodoroForm()
        {
            InitializeComponent();
            InitializeRestProgressTimer();
            InitializeTimers(); // 初始化所有需要的计时器组件
            progressBar.Maximum = PomodoroDurationMinutes * 60; // 设置进度条最大值为一个番茄钟的总秒数
        }

        // 初始化休息期间的进度条更新定时器
        private void InitializeRestProgressTimer()
        {
            restProgressTimer = new System.Windows.Forms.Timer { Interval = 3000 }; // 每隔三秒更新一次
            restProgressTimer.Tick += RestProgressTimer_Tick;
        }

        // 休息期间的进度条更新逻辑
        private void RestProgressTimer_Tick(object sender, EventArgs e)
        {
            // 根据当前会话类型调整进度条的更新逻辑
            switch (currentSession)
            {
                case SessionType.ShortBreak:
                    progressBar.Value = (int)Math.Floor((double)progressBar.Maximum * (remainingSeconds - ShortBreakDurationMinutes * 60) / (double)progressBar.Maximum);
                    break;
                case SessionType.LongBreak:
                    progressBar.Value = (int)Math.Floor((double)progressBar.Maximum * (remainingSeconds - LongBreakDurationMinutes * 60) / (double)progressBar.Maximum);
                    break;
            }

            // 达到最大值后停止计时器
            if (progressBar.Value >= progressBar.Maximum)
            {
                restProgressTimer.Stop();
            }
        }



        // 初始化倒计时和进度条更新的定时器实例及事件处理
        private void InitializeTimers()
        {
            countdownTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            countdownTimer.Tick += CountdownTimer_Tick; // 每秒触发一次计时器回调

            progressTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            progressTimer.Tick += ProgressTimer_Tick; // 同步更新进度条
        }

        // 倒计时定时器的Tick事件处理器
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            // 减少剩余秒数，模拟时间流逝
            remainingSeconds--;

            // 更新UI显示的时间
            UpdateUI();

            // 检查是否到达会话结束
            if (remainingSeconds <= 0)
            {
                // 根据当前会话类型决定下一步动作
                switch (currentSession)
                {
                    case SessionType.Pomodoro:
                        // 完成一个番茄钟，增加完成计数并检查是否开始长休息
                        completedPomodoros++;
                        if (completedPomodoros % 4 == 0)
                        {
                            StartLongBreak(); // 完成四个番茄钟后进入长休息
                        }
                        else
                        {
                            StartShortBreak(); // 否则进入短休息
                        }
                        break;
                    case SessionType.ShortBreak:
                    case SessionType.LongBreak:
                        // 休息结束，开始新的番茄钟
                        StartPomodoro();
                        break;
                }
            }
        }

        // 进度条更新的Tick事件处理器
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            // 根据当前会话类型调整进度条的更新逻辑
            switch (currentSession)
            {
                case SessionType.Pomodoro:
                    // 番茄钟情况下，每秒增加一次
                    progressBar.Value++;
                    break;
                case SessionType.ShortBreak:
                    // 短休息情况下，每秒增加的步长需根据短休息的总秒数调整，以确保进度条在休息结束时刚好填满
                    int shortBreakSteps = (int)(ShortBreakDurationMinutes * 60 / progressBar.Maximum);
                    progressBar.Value = (progressBar.Value + shortBreakSteps) % progressBar.Maximum;
                    break;
                case SessionType.LongBreak:
                    // 长休息同理，调整增加的步长
                    int longBreakSteps = (int)(LongBreakDurationMinutes * 60 / progressBar.Maximum);
                    progressBar.Value = (progressBar.Value + longBreakSteps) % progressBar.Maximum;
                    break;
            }
            if (progressBar.Value >= progressBar.Maximum)
            {
                // 进度条满后停止更新
                progressTimer.Stop();
            }
        }

        // 更新用户界面显示的时间或休息信息
        private void UpdateUI()
        {
            // 将剩余秒数转换为分钟和秒，并格式化输出
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;
            label1.Text = $"{minutes:D2}:{seconds:D2}";
        }

        // 开始一个新的番茄钟会话
        private void StartPomodoro()
        {
            // 重置剩余秒数为一个番茄钟的时长
            remainingSeconds = PomodoroDurationMinutes * 60;
            // 设置当前会话为番茄钟
            currentSession = SessionType.Pomodoro;
            // 更新UI
            UpdateUI();
            // 启动倒计时和进度条更新定时器
            countdownTimer.Start();
            progressTimer.Start();
            // 改变按钮文本为“停止”
            start_button.Text = "停止";
        }

        // 开始短休息会话
        private void StartShortBreak()
        {
            // 重置进度条值为0
            progressBar.Value = 0;

            // 设置休息时长
            remainingSeconds = ShortBreakDurationMinutes * 60;
            // 更新会话类型
            currentSession = SessionType.ShortBreak;
            // 提醒用户休息，并更新UI
            UpdateUI();
            ShowNotification("番茄工作法", "开始短休息");
            // 启动倒计时和进度条更新
            countdownTimer.Start();
            // 启动休息期间的进度条更新定时器
            restProgressTimer.Start();
        }

        // 开始长休息会话
        private void StartLongBreak()
        {
            // 重置进度条值为0
            progressBar.Value = 0;

            // 设置长休息时长
            remainingSeconds = LongBreakDurationMinutes * 60;
            // 更新会话类型
            currentSession = SessionType.LongBreak;
            // 提醒用户休息，并更新UI
            UpdateUI();
            ShowNotification("番茄工作法", "开始长休息");
            // 启动倒计时和进度条更新
            countdownTimer.Start();
            // 启动休息期间的进度条更新定时器
            restProgressTimer.Start();
        }

        // 休息结束后重置状态，准备开始新的番茄钟
        private void ResetAfterBreak()
        {
            // 重置剩余秒数为新的番茄钟时长
            remainingSeconds = PomodoroDurationMinutes * 60;
            // 重置进度条
            progressBar.Value = 0;
            // 更新UI
            UpdateUI();
            // 改变按钮文本为“开始”
            start_button.Text = "开始";
            // 重置运行状态
            isRunning = false;
        }

        private void ShowNotification(string title, string message)
        {
            // 创建BalloonTipIcon枚举的实例，这里使用Info作为例子
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = message;
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.ShowBalloonTip(5000); // 参数为显示时间，单位为毫秒
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }

        // 主要控制按钮的点击事件处理
        private void start_button_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                // 如果当前没有运行，开始相应的会话
                isRunning = true;
                switch (currentSession)
                {
                    case SessionType.Pomodoro:
                        StartPomodoro();
                        break;
                    case SessionType.ShortBreak:
                        StartShortBreak();
                        break;
                    case SessionType.LongBreak:
                        StartLongBreak();
                        break;
                }
            }
            else
            {
                // 如果当前正在运行，停止计时
                isRunning = false;
                countdownTimer.Stop();
                progressTimer.Stop();

                // 无论当前是哪种会话，都重置UI显示
                if (currentSession == SessionType.Pomodoro)
                {
                    // 特别地，如果是番茄钟进行中，保留完成的番茄钟计数，但重置显示
                    remainingSeconds = PomodoroDurationMinutes * 60;
                    progressBar.Value = 0;
                    UpdateUI();
                }
                else
                {
                    // 对于休息，直接准备开始新的番茄钟
                    ResetAfterBreak();
                }

                start_button.Text = "开始";
            }
        }
    }
}