using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility_Apps
{
    public partial class SetShutdownTime : Form
    {
        public SetShutdownTime()
        {
            InitializeComponent();
            loadStatusBar();
        }

        StatusBarPanel downTimePanel = new StatusBarPanel();
        StatusBarPanel barPanel = new StatusBarPanel();

        decimal downTime = 0;

        void loadStatusBar()
        {
            StatusBar bar = new StatusBar();
            bar.ShowPanels = true;
            bar.Panels.Add(barPanel);
            bar.Panels.Add(downTimePanel);

            downTimePanel.Text = "";
            barPanel.Text = "Waiting...";

            this.Controls.Add(bar);
        }
        private void numericUpDownSecond_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown box = sender as NumericUpDown;

            if (box.Value >= 60)
            {
                numericUpDownMinute.Value++;
                box.Value = 0;
            }
        }
        private void numericUpDownMinute_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown box = sender as NumericUpDown;

            if (box.Value >= 60)
            {
                numericUpDownHour.Value++;
                box.Value = 0;
            }

        }
        /// <summary>
        /// shutdown theo command
        /// </summary>
        /// <param name="command"></param>
        void Shutdown(string command)
        {
            System.Diagnostics.Process.Start("shutdown", command);
        }

        void caculateDownTime()
        {
            downTime = numericUpDownSecond.Value + numericUpDownMinute.Value * 60 + numericUpDownHour.Value * 60 * 60;
        }

        private void btShutdown_Click(object sender, EventArgs e)
        {
            caculateDownTime();
            //-s là tắt máy
            Shutdown("-s -t " + downTime);
            barPanel.Text = "Shutting down...";
            timer1.Start();


        }

        private void btRestart_Click(object sender, EventArgs e)
        {
            caculateDownTime();
            //-r là khởi động lại
            Shutdown("-r -t " + downTime);
            barPanel.Text = "Restarting...";
            timer1.Start();

        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            //hủy lệnh là -a
            Shutdown("-a");
            barPanel.Text = "Waiting...";
            downTimePanel.Text = "";
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            downTime--;
            downTimePanel.Text = downTime.ToString();
        }
    }
 }

    

