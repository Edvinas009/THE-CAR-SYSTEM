
namespace Assignment3___Car_SystemForCsharp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnNormalMode = new System.Windows.Forms.Button();
            this.tbTemp = new System.Windows.Forms.TextBox();
            this.tbHeadLight = new System.Windows.Forms.TextBox();
            this.lbTemp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.lbLogs = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // btnNormalMode
            // 
            this.btnNormalMode.BackColor = System.Drawing.Color.DarkRed;
            this.btnNormalMode.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnNormalMode.Location = new System.Drawing.Point(153, 92);
            this.btnNormalMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNormalMode.Name = "btnNormalMode";
            this.btnNormalMode.Size = new System.Drawing.Size(132, 28);
            this.btnNormalMode.TabIndex = 1;
            this.btnNormalMode.Text = "Alarm";
            this.btnNormalMode.UseVisualStyleBackColor = false;
            this.btnNormalMode.Click += new System.EventHandler(this.btnReadSerial_Click);
            // 
            // tbTemp
            // 
            this.tbTemp.Location = new System.Drawing.Point(152, 149);
            this.tbTemp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTemp.Name = "tbTemp";
            this.tbTemp.Size = new System.Drawing.Size(132, 22);
            this.tbTemp.TabIndex = 2;
            this.tbTemp.TextChanged += new System.EventHandler(this.tbTemp_TextChanged);
            // 
            // tbHeadLight
            // 
            this.tbHeadLight.Location = new System.Drawing.Point(152, 181);
            this.tbHeadLight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbHeadLight.Name = "tbHeadLight";
            this.tbHeadLight.Size = new System.Drawing.Size(132, 22);
            this.tbHeadLight.TabIndex = 3;
            this.tbHeadLight.TextChanged += new System.EventHandler(this.tbHeadLight_TextChanged);
            // 
            // lbTemp
            // 
            this.lbTemp.AutoSize = true;
            this.lbTemp.Location = new System.Drawing.Point(55, 149);
            this.lbTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTemp.Name = "lbTemp";
            this.lbTemp.Size = new System.Drawing.Size(90, 17);
            this.lbTemp.TabIndex = 4;
            this.lbTemp.Text = "Temperature";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "HeadLight";
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 16;
            this.lbLog.Location = new System.Drawing.Point(335, 92);
            this.lbLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(159, 116);
            this.lbLog.TabIndex = 6;
            this.lbLog.SelectedIndexChanged += new System.EventHandler(this.lbLog_SelectedIndexChanged);
            // 
            // lbLogs
            // 
            this.lbLogs.AutoSize = true;
            this.lbLogs.Location = new System.Drawing.Point(335, 48);
            this.lbLogs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.Size = new System.Drawing.Size(32, 17);
            this.lbLogs.TabIndex = 7;
            this.lbLogs.Text = "Log";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lbLogs);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTemp);
            this.Controls.Add(this.tbHeadLight);
            this.Controls.Add(this.tbTemp);
            this.Controls.Add(this.btnNormalMode);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnNormalMode;
        private System.Windows.Forms.TextBox tbTemp;
        private System.Windows.Forms.TextBox tbHeadLight;
        private System.Windows.Forms.Label lbTemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Label lbLogs;
        private System.Windows.Forms.Timer timer2;
    }
}

