namespace SMSBoooooM
{
    partial class MainForm
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
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_span = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_count = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.checklist = new System.Windows.Forms.CheckedListBox();
            this.cb_selectAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_apicount = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "手机号码:";
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(77, 21);
            this.txt_phone.MaxLength = 11;
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(185, 21);
            this.txt_phone.TabIndex = 1;
            this.txt_phone.Tag = "18186051998是诈骗电话";
            this.txt_phone.Text = "18186051998";
            // 
            // txt_span
            // 
            this.txt_span.Location = new System.Drawing.Point(206, 56);
            this.txt_span.Name = "txt_span";
            this.txt_span.Size = new System.Drawing.Size(56, 21);
            this.txt_span.TabIndex = 3;
            this.txt_span.Text = "300";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "间隔(ms):";
            // 
            // txt_count
            // 
            this.txt_count.Location = new System.Drawing.Point(77, 56);
            this.txt_count.Name = "txt_count";
            this.txt_count.Size = new System.Drawing.Size(48, 21);
            this.txt_count.TabIndex = 5;
            this.txt_count.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "发送次数:";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(206, 278);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(80, 28);
            this.btn_Start.TabIndex = 6;
            this.btn_Start.Text = "开始轰炸";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txt_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_log.Location = new System.Drawing.Point(3, 11);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(280, 191);
            this.txt_log.TabIndex = 7;
            this.txt_log.WordWrap = false;
            // 
            // checklist
            // 
            this.checklist.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checklist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checklist.CheckOnClick = true;
            this.checklist.FormattingEnabled = true;
            this.checklist.Location = new System.Drawing.Point(3, 16);
            this.checklist.MultiColumn = true;
            this.checklist.Name = "checklist";
            this.checklist.Size = new System.Drawing.Size(280, 128);
            this.checklist.Sorted = true;
            this.checklist.TabIndex = 8;
            // 
            // cb_selectAll
            // 
            this.cb_selectAll.AutoSize = true;
            this.cb_selectAll.Location = new System.Drawing.Point(6, 111);
            this.cb_selectAll.Name = "cb_selectAll";
            this.cb_selectAll.Size = new System.Drawing.Size(48, 16);
            this.cb_selectAll.TabIndex = 11;
            this.cb_selectAll.Text = "全选";
            this.cb_selectAll.UseVisualStyleBackColor = true;
            this.cb_selectAll.CheckedChanged += new System.EventHandler(this.Cb_selectAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checklist);
            this.groupBox1.Location = new System.Drawing.Point(3, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 153);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 100);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(124, 278);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(76, 28);
            this.btn_stop.TabIndex = 14;
            this.btn_stop.Text = "停止轰炸";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.Btn_stop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 311);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(294, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.RightToLeftAutoMirrorImage = true;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "By_cc";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.ToolStripStatusLabel1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_log);
            this.groupBox3.Location = new System.Drawing.Point(3, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(289, 211);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "接口共计：";
            // 
            // txt_apicount
            // 
            this.txt_apicount.AutoSize = true;
            this.txt_apicount.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_apicount.ForeColor = System.Drawing.Color.Red;
            this.txt_apicount.Location = new System.Drawing.Point(69, 282);
            this.txt_apicount.Name = "txt_apicount";
            this.txt_apicount.Size = new System.Drawing.Size(18, 19);
            this.txt_apicount.TabIndex = 18;
            this.txt_apicount.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 333);
            this.Controls.Add(this.txt_apicount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.cb_selectAll);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.txt_count);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_span);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "SMSBooooom";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.TextBox txt_span;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_count;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.CheckedListBox checklist;
        private System.Windows.Forms.CheckBox cb_selectAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txt_apicount;
    }
}

