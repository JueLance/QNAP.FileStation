using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;

namespace FileSyncDemo
{
    public partial class TaskForm : Form
    {
        protected TaskForm()
        {
            InitializeComponent();

            fm = new FileManager(Program.fsConnect);
        }
        FileManager fm = null;
        private List<ITask> list = new List<ITask>();
        ITask currentTask = null;

        private void TaskForm_Load(object sender, EventArgs e)
        {
            LoadBackgroundTask();

            //Thread th = new Thread(new ThreadStart(DoBackgroundTask));
            //th.IsBackground = true;
            //th.Start();
        }

        private void DoBackgroundTask()
        {
            if (lbBackgroundTask.InvokeRequired)
            {
                lbBackgroundTask.Invoke((EventHandler)delegate
                {
                    if (lbBackgroundTask.Items.Count > 0)
                    {
                        BackgroundTask task = lbBackgroundTask.Items[0] as BackgroundTask;

                        currentTask = task;

                        switch (task.ActionType)
                        {
                            case ActionType.None:


                                break;
                            case ActionType.Copy:

                                UiLog.Log(string.Format("移动文件{0} =====> {1}", task.FullPath, task.DestinationPath));

                                fm.Copy(task.FileName, 1, task.FilePath, task.DestinationPath, 1, string.Empty, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(CopyFileFinish));

                                break;
                            case ActionType.Move:

                                UiLog.Log(string.Format("移动文件{0} =====> {1}", task.FullPath, task.DestinationPath));

                                fm.Move(task.FileName, 1, task.FilePath, task.DestinationPath, 1, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(MoveFileFinish));

                                break;
                            case ActionType.Paste:

                                break;
                            default:

                                break;
                        }
                    }
                });
            }
            else
            {
                if (lbBackgroundTask.Items.Count > 0)
                {
                    BackgroundTask task = lbBackgroundTask.Items[0] as BackgroundTask;

                    currentTask = task;

                    switch (task.ActionType)
                    {
                        case ActionType.None:


                            break;
                        case ActionType.Copy:

                            UiLog.Log(string.Format("移动文件{0} =====> {1}", task.FullPath, task.DestinationPath));

                            fm.Copy(task.FileName, 1, task.FilePath, task.DestinationPath, 1, string.Empty, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(CopyFileFinish));

                            break;
                        case ActionType.Move:

                            UiLog.Log(string.Format("移动文件{0} =====> {1}", task.FullPath, task.DestinationPath));

                            fm.Move(task.FileName, 1, task.FilePath, task.DestinationPath, 1, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(MoveFileFinish));

                            break;
                        case ActionType.Paste:

                            break;
                        default:

                            break;
                    }
                }
            }
        }

        private void CopyFileFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    try
                    {
                        BaseResponse response = JsonConvert.DeserializeObject<BaseResponse>(arg.Response);

                        if (response.Status == 1)
                        {
                            MainFrm main = TaskForm.Instance.Owner as MainFrm;
                            if (main != null)
                            {
                                if (main.InvokeRequired)
                                {
                                    main.Invoke((EventHandler)delegate
                                    {
                                        main.SyncFolderViewState();
                                        main.SyncFileViewState();
                                    });
                                }
                                else
                                {
                                    main.SyncFolderViewState();
                                    main.SyncFileViewState();
                                }
                            }

                            UiLog.Log("复制文件成功");
                        }
                        else
                        {
                            UiLog.Log("复制文件失败");
                        }

                        if (currentTask != null)
                        {
                            list.Remove(currentTask);
                            currentTask = null;
                            LoadBackgroundTask();
                        }
                        else
                        {
                            DoBackgroundTask();
                        }
                    }
                    catch (Exception ex)
                    {
                        UiLog.Log(ex.Message);
                    }

                    break;
                case FileSyncAPIRequestResult.Fail:
                    MessageBox.Show("调用API时发生错误， 错误消息：" + arg.Error.error_msg);
                    break;
                default:
                    break;
            }
        }


        private void MoveFileFinish(object obj, FileSyncRequestResultEventArgs arg)
        {
            switch (arg.Result)
            {
                case FileSyncAPIRequestResult.Success:

                    try
                    {
                        BaseResponse response = JsonConvert.DeserializeObject<BaseResponse>(arg.Response);

                        if (response.Status == 1)
                        {
                            MainFrm main = TaskForm.Instance.Owner as MainFrm;
                            if (main != null)
                            {
                                if (main.InvokeRequired)
                                {
                                    main.Invoke((EventHandler)delegate
                                    {
                                        main.SyncFolderViewState();
                                        main.SyncFileViewState();
                                    });
                                }
                                else
                                {
                                    main.SyncFolderViewState();
                                    main.SyncFileViewState();
                                }
                            }

                            UiLog.Log("移动文件成功");
                        }
                        else
                        {
                            UiLog.Log("移动文件失败");
                        }

                        if (currentTask != null)
                        {
                            list.Remove(currentTask);
                            currentTask = null;
                            LoadBackgroundTask();
                        }
                        else
                        {
                            DoBackgroundTask();
                        }
                    }
                    catch (Exception ex)
                    {
                        UiLog.Log(ex.Message);
                    }

                    break;
                case FileSyncAPIRequestResult.Fail:
                    MessageBox.Show("调用API时发生错误， 错误消息：" + arg.Error.error_msg);
                    break;
                default:
                    break;
            }
        }


        private void LoadBackgroundTask()
        {
            if (lbBackgroundTask.InvokeRequired)
            {
                lbBackgroundTask.Invoke((EventHandler)delegate
                {
                    lbBackgroundTask.SuspendLayout();
                    lbBackgroundTask.Items.Clear();
                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            lbBackgroundTask.Items.Add(item);
                        }
                        lbBackgroundTask.PerformLayout();
                    }
                });
            }
            else
            {
                lbBackgroundTask.SuspendLayout();
                lbBackgroundTask.Items.Clear();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        lbBackgroundTask.Items.Add(item);
                    }
                    lbBackgroundTask.PerformLayout();
                }
            }
        }

        private static TaskForm _TaskForm;

        public static TaskForm Instance
        {
            get
            {
                if (_TaskForm == null || _TaskForm.IsDisposed)
                {
                    _TaskForm = new TaskForm();
                }

                return _TaskForm;
            }
        }

        public void AddBackgroundTask(ITask task)
        {
            list.Add(task);
        }

        public void AddBackgroundTaskRange(List<ITask> tasks)
        {
            list.AddRange(tasks);
        }

        public void RemoveBackgroundTask(ITask task)
        {
            list.Remove(task);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            LoadBackgroundTask();
        }

        private void TaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            //e.Cancel = true;
        }

        private void TaskForm_Activated(object sender, EventArgs e)
        {
            LoadBackgroundTask();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DoBackgroundTask();
        }

        private void TaskForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }
    }

    public interface ITask
    {
        ActionType ActionType { get; set; }

        DateTime DateTime { get; set; }
    }

    [Serializable]
    public class BackgroundTask : ITask
    {
        //public FileMeta FileMeta { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string FullPath { get; set; }

        public string DestinationPath { get; set; }

        public ActionType ActionType { get; set; }

        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return string.Format("[{0:yyyy-MM-dd HH:mm:ss}][{1}]\t{2}-->{3}", DateTime, ActionType, FullPath, DestinationPath);
        }
    }

    [Serializable]
    public enum ActionType
    {
        None,
        Copy,
        Move,
        Paste
    }
}
