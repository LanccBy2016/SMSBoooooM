using SMSAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSBoooooM
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.btn_stop.Enabled = false;
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            this.Height = 575;
            Thread pThread = new Thread(new ThreadStart(this.BooooooM));
            pThread.Start();
        }

        Dictionary<string, SMSAPIBase> apis = new Dictionary<string, SMSAPIBase>();

        public void BooooooM()
        {
            this.txt_log.Text = "开始轰炸>>>>>\r\n";

            this.btn_Start.Enabled = false;
            this.btn_stop.Enabled = true;
            //手机号
            var phone = this.txt_phone.Text;

            this.txt_log.Text += "轰炸目标>>>" + phone + "\r\n";

            //轰炸次数
            var count = int.Parse(this.txt_count.Text);
            //间隔(毫秒)
            var span = int.Parse(this.txt_span.Text);
            //所有选中的API
            var selectapi = this.checklist.CheckedItems;
            if (selectapi.Count < 1)
            {
                this.txt_log.Text += "无可用短信接口...\r\n";
                this.btn_Start.Enabled = true;
                this.btn_stop.Enabled = false;
                return;
            }
            this.txt_log.Text += selectapi.Count + "位飞行员已就位>>>>>\r\n";


            //轮流使用所选api
            for (int i = 0; i < count; i++)
            {
                if (!this.btn_stop.Enabled) break;

                var j = i % selectapi.Count;
                var apiKey = selectapi[j].ToString();
                var api = apis[apiKey];

                var result= api.Run(this.txt_phone.Text.Trim()).Result;

                string state = result.IsSuccess ? "√" : "×";


                this.txt_log.Text += $"[{state}][{i+1}]{apiKey}返回值：{result.Message}\r\n";
                this.txt_log.Select(this.txt_log.TextLength, 0);
                this.txt_log.ScrollToCaret();
                Thread.Sleep(span);
            }
            this.txt_log.Text += "轰炸完成~";
            this.txt_log.Select(this.txt_log.TextLength, 0);
            this.txt_log.ScrollToCaret();
            this.btn_Start.Enabled = true;
            this.btn_stop.Enabled = false;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            string Path =System.IO.Directory.GetCurrentDirectory()+@"\apis";
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            else
            {
                //读取当前程序的apis目录下所有的.dll文件，并加载其中所有继承自SMSAPIBase的类。
                DirectoryInfo dir = new DirectoryInfo(Path);
                var dlls = dir.GetFileSystemInfos().ToList().Where(s=>s.Extension==".dll").ToList();
                dlls.ForEach(s =>
                {
                    Assembly assembly = Assembly.LoadFile(s.FullName);
                    var types = assembly.GetTypes().ToList();
                    types.ForEach(t =>
                    {
                        if (t.BaseType!=null&&t.BaseType.Name.Contains("SMSAPIBase"))
                        {
                            var apiKey = $"{s.Name.Replace(".dll","")}_{t.Name}";
                            var api = System.Activator.CreateInstance(t) as SMSAPIBase;
                            apis.Add(apiKey,api);
                            this.checklist.Items.Add(apiKey);
                        }
                    });
                });
                this.txt_apicount.Text = apis.Count.ToString();
            }
        }

        private void Cb_selectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool checkall = this.cb_selectAll.Checked;
            for (var i = 0; i < checklist.Items.Count; i++)
            {
                checklist.SetItemChecked(i, checkall);
            }
        }


        private void Btn_stop_Click(object sender, EventArgs e)
        {
            this.btn_stop.Enabled = false;
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/LanccBy2016");
        }
    }
}
