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
    public partial class AJob : UserControl
    {
        private PlanItem job;
        public PlanItem Job { get => job; set => job = value; }

        private event EventHandler edited;

        public  event EventHandler Edited
        {
            add => edited += value;
            remove => edited -= value;
        }

        private event EventHandler deleted;

        public event EventHandler Deleted
        {
            add => deleted += value;
            remove => deleted -= value;
        }


        public AJob(PlanItem job)
        {
            InitializeComponent();
            cbStatus.DataSource = PlanItem.ListStatus;

            this.Job = job;

            ShowInfo();
        }

        void ShowInfo()
        {
            txbJob.Text = Job.Job;
            nmFromHours.Value = Job.FromTime.X;
            nmFromMinutes.Value = Job.FromTime.Y;

            nmToHours.Value = Job.ToTime.X;
            nmToMinutes.Value = Job.ToTime.Y;

            cbStatus.SelectedIndex = PlanItem.ListStatus.IndexOf(Job.Status);
            ckbDone.Checked = PlanItem.ListStatus.IndexOf(Job.Status) == (int)EPlanItem.DONE ? true : false;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Job.Job= txbJob.Text;
            Job.FromTime = new Point((int)nmFromHours.Value, (int)nmFromMinutes.Value);
            Job.ToTime = new Point((int)nmToHours.Value, (int)nmToMinutes.Value);
            Job.Status= PlanItem.ListStatus[cbStatus.SelectedIndex];

            if (edited!=null)
                edited(this, new EventArgs());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(deleted!=null)
                deleted(this, new EventArgs());
        }

        private void ckbDone_CheckedChanged(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex=ckbDone.Checked ? (int)EPlanItem.DONE : (int)EPlanItem.DOING;
        }
    }
}
