using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
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
        public void BooooooM()
        {
            this.txt_log.Text = "开始轰炸>>>>>\r\n";

            this.btn_Start.Enabled = false;
            this.btn_stop.Enabled = true;
            //手机号
            var phone = this.txt_phone.Text;

            this.txt_log.Text += "轰炸目标>>>"+phone+"\r\n";

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
            this.txt_log.Text += selectapi.Count+"位飞行员已就位>>>>>\r\n";
            var t = typeof(SMSAPI);
            var cotr = t.GetTypeInfo().GetConstructor(new[] { typeof(string) });
            var cotrParams = new Object[] { phone };
            dynamic some = cotr.Invoke(cotrParams);//调用构造函数//

            System.Reflection.MethodInfo[] methods = t.GetMethods();
            //所有被选中的API
            var apis = methods.Where(a => a.IsDefined(typeof(IsAPIAttribute), false))
                .Where(a => selectapi.IndexOf(((SMSBoooooM.IsAPIAttribute)((System.Attribute[])a.GetCustomAttributes())[0]).ApiName) > -1).ToList();


            //轮流使用所选api
            for (int i = 0; i < count; i++)
            {
                if (!this.btn_stop.Enabled)break;

                var j = i % apis.Count;
                var api = apis[j];
                MethodInfo method = t.GetMethod(api.Name);
                var s = method.Invoke(some, new object[] { });
                this.txt_log.Text += "第";
                this.txt_log.Text += i + 1;
                this.txt_log.Text += "次轰炸>>>";
                this.txt_log.Text += ((SMSBoooooM.IsAPIAttribute)((System.Attribute[])api.GetCustomAttributes())[0]).ApiName;
                this.txt_log.Text += ":";
                this.txt_log.Text += s;
                this.txt_log.Text += "\r\n";
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

            //获取并绑定API列表
            var t = typeof(SMSAPI);
            System.Reflection.MethodInfo[] methods = t.GetMethods();
            var apis = methods.Where(a => a.IsDefined(typeof(IsAPIAttribute), false)).ToList();
            foreach (var api in apis)
            {
                this.checklist.Items.Add(((SMSBoooooM.IsAPIAttribute)((System.Attribute[])api.GetCustomAttributes())[0]).ApiName,false);
            }
            this.txt_apicount.Text = apis.Count.ToString();
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
