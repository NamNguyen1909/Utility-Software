﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility_Apps
{
    public partial class DailyPlan : Form
    {
        private DateTime date;
        public DateTime Date { get => date; set => date = value; }

        private PlanData job;
        public PlanData Job { get => job; set => job = value; }

        FlowLayoutPanel fPanel = new FlowLayoutPanel();
        public DailyPlan(DateTime date,PlanData job)
        {
            InitializeComponent();

            this.Date = date;
            this.Job = job;

            
            fPanel.Width = pnlJob.Width;
            fPanel.Height = pnlJob.Height;
            pnlJob.Controls.Add(fPanel);

            
            dtpkDate.Value = Date;
        }
        void ShowJobByDate(DateTime date)
        {
            fPanel.Controls.Clear();
            if (Job != null && Job.Job != null)
            {
                List<PlanItem> todayJob = GetJobByDay(date);

                for (int i = 0; i < todayJob.Count; i++)
                {
                    AddJob(todayJob[i]);
                }
            }
        }

        void AddJob(PlanItem job)
        {
            AJob aJob = new AJob(job);
            aJob.Edited += AJob_Edited;
            aJob.Deleted += AJob_Deleted;
           
            fPanel.Controls.Add(aJob);

        }

        private void AJob_Deleted(object sender, EventArgs e)
        {
           AJob uc = sender as AJob;  
           PlanItem job= uc.Job;

            fPanel.Controls.Remove(uc);
            Job.Job.Remove(job);
        }

        private void AJob_Edited(object sender, EventArgs e)
        {
            
        }

        List<PlanItem> GetJobByDay(DateTime date)
        {
            return Job.Job.Where(p=>p.Date.Year==date.Year && p.Date.Month==date.Month && p.Date.Day==date.Day).ToList();
        }
        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            ShowJobByDate((sender as DateTimePicker).Value);
        }

        private void btnPreviousDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(-1);
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(1);

        }

        private void mnsiAddJob_Click(object sender, EventArgs e)
        {
            PlanItem item = new PlanItem() 
            { 
                Date = dtpkDate.Value,
                Status = PlanItem.ListStatus[(int)EPlanItem.COMING] // Thiết lập trạng thái mặc định là "coming"
            };
            Job.Job.Add(item);
            AddJob(item);
        }

        private void mnsiToday_Click(object sender, EventArgs e)
        {
            dtpkDate.Value=DateTime.Now;
        }
    }
}
