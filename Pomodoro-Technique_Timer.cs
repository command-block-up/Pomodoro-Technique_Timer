using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.WindowsAPICodePack.Taskbar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
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

        private int TaskbarProgressMaximumValue;

        public PomodoroForm()
        {
            InitializeComponent();
            InitializeTimers(); // 初始化所有需要的计时器组件
            progressBar.Maximum = PomodoroDurationMinutes * 60; // 设置进度条最大值为一个番茄钟的总秒数
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
            progressBar.Value++;
            UpdateTaskbarProgress(progressBar.Value);


            if (progressBar.Value >= progressBar.Maximum)
            {
                // 进度条满后停止更新
                progressTimer.Stop();
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
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
            this.Text = "番茄工作法：番茄钟";
            // 重置进度条值为0
            progressBar.Value = 0;
            // 设置任务栏进度条为可见
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            // 重置剩余秒数为一个番茄钟的时长
            remainingSeconds = PomodoroDurationMinutes * 60;
            // 设置当前会话为番茄钟
            currentSession = SessionType.Pomodoro;
            // 更新UI
            UpdateUI();
            new ToastContentBuilder()
                       .AddArgument("action", "viewConversation")
                       .AddArgument("conversationId", 9813)
                       .AddText("开始番茄钟")
                       .Show();
            progressBar.Maximum = remainingSeconds;
            TaskbarProgressMaximumValue = remainingSeconds;
            // 启动倒计时和进度条更新定时器
            countdownTimer.Start();
            progressTimer.Start();
            // 改变按钮文本为“停止”
            start_button.Text = "停止";
        }

        // 开始短休息会话
        private void StartShortBreak()
        {
            this.Text = "番茄工作法：短休息";
            // 重置进度条值为0
            progressBar.Value = 0;

            // 设置休息时长
            remainingSeconds = ShortBreakDurationMinutes * 60;
            // 更新会话类型
            currentSession = SessionType.ShortBreak;
            // 提醒用户休息，并更新UI
            UpdateUI();
            new ToastContentBuilder()
                       .AddArgument("action", "viewConversation")
                       .AddArgument("conversationId", 9813)
                       .AddText("开始短休息")
                       .Show();
            progressBar.Maximum = remainingSeconds;
            TaskbarProgressMaximumValue = remainingSeconds;
            // 启动倒计时和进度条更新
            countdownTimer.Start();
            progressTimer.Start();
            // 改变按钮文本为“停止”
            start_button.Text = "停止";
        }

        // 开始长休息会话
        private void StartLongBreak()
        {
            this.Text = "番茄工作法：长休息";
            // 重置进度条值为0
            progressBar.Value = 0;

            // 设置长休息时长
            remainingSeconds = LongBreakDurationMinutes * 60;
            // 更新会话类型
            currentSession = SessionType.LongBreak;
            // 提醒用户休息，并更新UI
            UpdateUI();
            new ToastContentBuilder()
                       .AddArgument("action", "viewConversation")
                       .AddArgument("conversationId", 9813)
                       .AddText("开始长休息")
                       .Show();
            progressBar.Maximum = remainingSeconds;
            TaskbarProgressMaximumValue = remainingSeconds;
            // 启动倒计时和进度条更新
            countdownTimer.Start();
            progressTimer.Start();
            // 改变按钮文本为“停止”
            start_button.Text = "停止";
        }

        // 休息结束后重置状态，准备开始新的番茄钟
        private void ResetAfterBreak()
        {
            // 重置剩余秒数为新的番茄钟时长
            remainingSeconds = PomodoroDurationMinutes * 60;
            // 停止休息期间的进度条更新定时器
            progressTimer.Stop();
            // 重置进度条
            progressBar.Value = 0;
            // 更新UI
            UpdateUI();
            // 改变按钮文本为“开始”
            start_button.Text = "开始";
            // 重置运行状态
            isRunning = false;
        }


        // 主要控制按钮的点击事件处理
        private void start_button_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                // 如果当前没有运行，开始相应的会话
                isRunning = true;
                StartPomodoro();
            }
            else
            {
                // 如果当前正在运行，停止计时
                isRunning = false;
                countdownTimer.Stop();
                progressTimer.Stop();
                this.Text = "番茄工作法";
                // 设置任务栏进度条为不可见
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

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
        // 用于存储任务的列表
        private List<TaskItem> tasks;

        public PomodoroForm(string filePath)
        {
            InitializeComponent();
            LoadTasksFromJson(filePath);
            tasks = new List<TaskItem>();
        }

        // 读取JSON文件的方法
        private void LoadTasksFromJson(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                tasks = JsonConvert.DeserializeObject<List<TaskItem>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tasks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SaveTasksToJsonFile(string filePath, List<TaskItem> tasks)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }
        public void UpdateTaskComboBox()
        {
            // 清空DataSource
            TaskComboBox.DataSource = null;

            // 将任务添加到ComboBox
            TaskComboBox.DataSource = tasks;
            TaskComboBox.DisplayMember = "Name"; // 如果TaskItem类中有名为Name的字段
        }

        // read_list按钮的事件处理
        private void read_list_Click(object sender, EventArgs e)
        {
            // 假设你的JSON文件路径是 "tasks.json"
            LoadTasksFromJson("tasks.json");
            UpdateTaskComboBox();
            // 定位到第一个任务
            if (tasks.Count > 0)
            {
                TaskComboBox.SelectedIndex = 0;
            }
        }

        private void task_view_Click(object sender, EventArgs e)
        {
            if (TaskComboBox.SelectedItem != null)
            {
                var selectedTask = TaskComboBox.SelectedItem as TaskItem;
                using (TaskInfo TaskInfo = new TaskInfo())
                {
                    TaskInfo.plan_finish_date_textbox.Visible = true;
                    TaskInfo.set_plan_finish_date.Visible = false;

                    // 在TaskInfo窗体中显示任务信息
                    TaskInfo.name_textbox.Text = selectedTask.Name;
                    TaskInfo.description.Text = selectedTask.Description;
                    TaskInfo.created_at_textbox.Text = selectedTask.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                    TaskInfo.updated_at_textbox.Text = selectedTask.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                    TaskInfo.plan_finish_date_textbox.Text = selectedTask.PlanFinishDate.ToString("yyyy-MM-dd HH:mm:ss");
                    TaskInfo.tomatoes_count_plan_textbox.Text = selectedTask.TomatoesCountPlan.ToString();
                    TaskInfo.tomatoes_count_done_textbox.Text = selectedTask.TomatoesCountDone.ToString();

                    DialogResult result = TaskInfo.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("OK");
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        MessageBox.Show("Cancel");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择一个任务来查看详细信息。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void task_add_Click(object sender, EventArgs e)
        {

            using (TaskInfo taskInfoForm = new TaskInfo())
            {
                // 清空窗体的值（如果需要的话）
                taskInfoForm.name_textbox.Text = "";
                taskInfoForm.description.Text = "";
                taskInfoForm.created_at_textbox.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                taskInfoForm.updated_at_textbox.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                taskInfoForm.plan_finish_date_textbox.Visible = false;
                taskInfoForm.set_plan_finish_date.Visible = true;
                taskInfoForm.tomatoes_count_plan_textbox.Text = "0";
                taskInfoForm.tomatoes_count_done_textbox.Text = "0";

                DialogResult result = taskInfoForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string name = taskInfoForm.name_textbox.Text;
                    string description = taskInfoForm.description.Text;
                    string createdAt = taskInfoForm.created_at_textbox.Text;
                    string updatedAt = taskInfoForm.updated_at_textbox.Text;
                    int tomatoesCountPlan = int.Parse(taskInfoForm.tomatoes_count_plan_textbox.Text);
                    int tomatoesCountDone = int.Parse(taskInfoForm.tomatoes_count_done_textbox.Text);

                    DateTime createdAt_datetime = DateTime.ParseExact(createdAt, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime updatedAt_datetime = DateTime.ParseExact(updatedAt, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    TaskItem newTask = new TaskItem
                    {
                        Name = name,
                        Description = description,
                        CreatedAt = createdAt_datetime,
                        UpdatedAt = updatedAt_datetime,
                        PlanFinishDate = Global.planFinishDate,
                        TomatoesCountPlan = tomatoesCountPlan,
                        TomatoesCountDone = tomatoesCountDone
                    };

                    tasks.Add(newTask);
                    SaveTasksToJsonFile("tasks.json", tasks);
                    UpdateTaskComboBox();
                    // 定位到新添加的任务
                    TaskComboBox.SelectedIndex = tasks.Count - 1;
                }
            }
        }
        private void task_delete_Click(object sender, EventArgs e)
        {
            // 检查是否有任务被选中
            if (TaskComboBox.SelectedIndex >= 0)
            {
                // 从原始的任务列表中移除对应的任务
                var selectedTask = TaskComboBox.SelectedItem as TaskItem;
                tasks.Remove(selectedTask);

                // 更新UI
                UpdateTaskComboBox();

                // 保存更新后的任务列表
                SaveTasksToJsonFile("tasks.json", tasks);
                // 设置SelectedIndex为-1，避免显示已删除的任务
                TaskComboBox.SelectedIndex = -1;

                // 定位到第一个任务
                if (tasks.Count > 0)
                {
                    TaskComboBox.SelectedIndex = 0;
                    TaskComboBox.DisplayMember = "Name"; // 如果TaskItem类中有名为Name的字段
                }
            }
            else
            {
                MessageBox.Show("请选择一个任务进行删除。");
            }
        }
        private void UpdateTaskbarProgress(int value)
        {
            if (value >= 0 && value <= TaskbarProgressMaximumValue)
            {
                TaskbarManager.Instance.SetProgressValue(value, TaskbarProgressMaximumValue);
            }
        }

        private void TopMostButton_Click(object sender, EventArgs e)
        {
            if (this.TopMost == false)
            {
                this.TopMost = true;

            }
            else
            {
                this.TopMost = false;
            }
        }
    }
    // 任务模型类
    public class TaskItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime PlanFinishDate { get; set; }
        public int TomatoesCountPlan { get; set; }
        public int TomatoesCountDone { get; set; }
    }
}