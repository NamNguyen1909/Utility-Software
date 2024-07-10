using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace Utility_Apps
{
    public partial class Reminder : Form
    {
        public static int DayOfWeek = 7;
        public static int DayOfColumn = 6;

        public static int dateButtonWidth=97;
        public static int dateButtonHeight = 49;

        public static int margin = 6;
        public static int notifyTime = 1;
        public static int notifyTimeOut = 10000;



        #region Properties
        private int appTime;

        public int AppTime
        {
            get { return appTime; }
            set { appTime = value; }
        }

        private string filePath = "data.xml";

        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private PlanData job;
        public PlanData Job { get => job; set => job = value; }

        

        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        #endregion

        public Reminder()
        {
            InitializeComponent();

            tmNotify.Start();
            appTime = 0;

            LoadMatrix();

            try
            {
                Job = DeserializeFromXML(filePath) as PlanData;
                if (Job == null || Job.Job == null || Job.Job.Count == 0)
                {
                    Job = new PlanData();
                    SetDefaultJob();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                SetDefaultJob();
            }
            this.FormClosing += Reminder_FormClosing; // Thêm sự kiện FormClosing vào form Reminder
            this.FormClosed += Reminder_FormClosed;
            AddNumberIntoMatrixByDate(dtpkDate.Value);
        }

        void SetDefaultJob()
        {
            Job = new PlanData();
            Job.Job = new List<PlanItem>();
            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new Point(4, 0),
                ToTime = new Point(5, 0),
                Job = "Thử nghiệm",
                Status = PlanItem.ListStatus[(int)EPlanItem.COMING]
            });
            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new Point(4, 0),
                ToTime = new Point(5, 0),
                Job = "Thử nghiệm",
                Status = PlanItem.ListStatus[(int)EPlanItem.COMING]
            });
            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new Point(4, 0),
                ToTime = new Point(5, 0),
                Job = "Thử nghiệm",
                Status = PlanItem.ListStatus[(int)EPlanItem.DONE]
            });
            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now.AddDays(-1),
                FromTime = new Point(4, 0),
                ToTime = new Point(5, 0),
                Job = "Thử nghiệm",
                Status = PlanItem.ListStatus[(int)EPlanItem.COMING]
            });
            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now.AddDays(-1),
                FromTime = new Point(4, 0),
                ToTime = new Point(5, 0),
                Job = "Thử nghiệm",
                Status = PlanItem.ListStatus[(int)EPlanItem.COMING]
            });
        }

        void LoadMatrix()
        {

            Matrix = new List<List<Button>>();
            
            Button oldBtn= new Button() { Width=0,Height=0,Location= new Point(-margin,0)};
            for (int i = 0;i< DayOfColumn;i++)
            {
                Matrix.Add(new List<Button>());
                for(int j=0;j<DayOfWeek;j++)
                {
                    Button btn= new Button() { Width=dateButtonWidth,Height=dateButtonHeight};
                    btn.Location = new Point(oldBtn.Location.X + oldBtn.Width+margin , oldBtn.Location.Y);
                    btn.Click += Btn_Click;

                    pnlMatrix.Controls.Add(btn);
                    Matrix[i].Add(btn);

                    oldBtn=btn;
                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-margin, oldBtn.Location.Y+dateButtonHeight+margin) };
            }
            SetDefaultDate();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((sender as Button).Text))
                return;
            DailyPlan daily = new DailyPlan(new DateTime(dtpkDate.Value.Year,dtpkDate.Value.Month,Convert.ToInt32((sender as Button).Text)),Job);
            daily.ShowDialog();
        }

        void ClearMatrix()
        {
            for (int i = 0;i<Matrix.Count;i++)
            {
                for(int j=0 ; j < Matrix[i].Count;j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.White;
                }
            }
        }

        int DayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    return (DateTime.IsLeapYear(date.Year)) ? 29 : 28;
                default:
                    return 30;
            }
        }

        void AddNumberIntoMatrixByDate(DateTime date )
        {
            ClearMatrix();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);
            
            int line = 0;

            for (int i = 1; i <= DayOfMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button btn= Matrix[line][column];
                btn.Text=i.ToString();

                //đổi backcolor của ngày hiện tại
                if (isEqualDate(useDate,DateTime.Now))
                {
                    btn.BackColor=Color.DodgerBlue;
                }
                //đổi backcolor của ngày được chọn
                if (isEqualDate(useDate, date))
                {
                    btn.BackColor = Color.LightSkyBlue;
                }

                if (column>=6)
                    line++;
                useDate=useDate.AddDays(1);
            }
        }

        bool isEqualDate(DateTime dateA ,DateTime dateB)
        {
            return dateA.Year==dateB.Year && dateA.Month== dateB.Month && dateA.Day==dateB.Day;
        }

        void SetDefaultDate()
        {
            dtpkDate.Value=DateTime.Now;    
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
        }



        private void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            dtpkDate.Value=dtpkDate.Value.AddMonths(-1);
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
        }

        private void SerializeToXML(object data, string filePath)
        {
            FileStream fs= new FileStream(filePath, FileMode.Create,FileAccess.Write);
            XmlSerializer sr= new XmlSerializer(typeof(PlanData));

            sr.Serialize(fs, data);

            fs.Close();
        }

        private object DeserializeFromXML(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(PlanData));

                object result = sr.Deserialize(fs);
                fs.Close();
                return result;
            }
            catch (Exception ex)
            {
                fs.Close();
                MessageBox.Show(ex.ToString());
                return null;
                //throw new NotImplementedException();
            }
            
        }

        private void Reminder_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializeToXML(Job, filePath);
        }

        private void Reminder_FormClosed(object sender, FormClosedEventArgs e)
        {
            SerializeToXML(Job, filePath);
        }

        private void tmNotify_Tick(object sender, EventArgs e)
        {
            if (!ckbNotify.Checked)
                return;

            AppTime++;

            if (AppTime <notifyTime)
                return;

            if (Job == null || Job.Job == null)
                return;

            DateTime currentDate = DateTime.Now;
            List<PlanItem> todayjobs = Job.Job.Where(p => p.Date.Year == currentDate.Year && p.Date.Month == currentDate.Month && p.Date.Day == currentDate.Day).ToList();
            Notify.ShowBalloonTip(notifyTimeOut, "Lịch công việc", string.Format("Bạn có {0} việc trong ngày hôm nay", todayjobs.Count), ToolTipIcon.Info);

            AppTime = 0;
        }

        private void nmNotify_ValueChanged(object sender, EventArgs e)
        {
            notifyTime = (int)nmNotify.Value;
        }

        private void ckbNotify_CheckedChanged(object sender, EventArgs e)
        {
            nmNotify.Enabled = ckbNotify.Checked;
        }
    }
}
