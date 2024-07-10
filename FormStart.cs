using System;
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
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Height=Screen.PrimaryScreen.Bounds.Height/2;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, Screen.PrimaryScreen.Bounds.Height - (this.Height+40));

            //string test = "../../temp/xoa";
            LoadImageList();
            LoadListView();
            myListView.Click += myListView_Click;
        }



        ImageList imgListLarge;
        void LoadImageList()
        {
            imgListLarge = new ImageList();
            imgListLarge.ImageSize = new Size(68, 68);
            imgListLarge.Images.Add(new Bitmap(Application.StartupPath + "\\Images\\clock.png"));
            imgListLarge.Images.Add(new Bitmap(Application.StartupPath + "\\Images\\reminder.png"));
            imgListLarge.Images.Add(new Bitmap(Application.StartupPath + "\\Images\\internet-block.png"));
            imgListLarge.Images.Add(new Bitmap(Application.StartupPath + "\\Images\\notebook.png"));
            imgListLarge.Images.Add(new Bitmap(Application.StartupPath + "\\Images\\delete-files.png"));
            imgListLarge.Images.Add(new Bitmap(Application.StartupPath + "\\Images\\screen-capture.png"));
        }

        ListView myListView;
        void LoadListView()
        {
        
            myListView = new ListView();
            myListView.Dock = DockStyle.Fill;
            myListView.View=View.LargeIcon;
            myListView.LargeImageList = imgListLarge;
            myListView.ShowItemToolTips = true;

            ListViewItem shutdown_timer = new ListViewItem();
            shutdown_timer.Text = "Hẹn giờ";
            shutdown_timer.ToolTipText = "Hẹn giờ tắt máy";
            shutdown_timer.Tag = "shutdown_timer";
            shutdown_timer.ImageIndex = 0;
            myListView.Items.Add(shutdown_timer);

            ListViewItem reminder = new ListViewItem();
            reminder.Text = "Nhắc lịch";
            reminder.ToolTipText = "Nhắc lịch làm việc";
            reminder.Tag = "reminder";
            reminder.ImageIndex = 1;
            myListView.Items.Add(reminder);

            ListViewItem internet_block = new ListViewItem();
            internet_block.Text = "Chặn mạng";
            internet_block.ToolTipText = "Cấm truy cập internet";
            internet_block.Tag = "internet_block";
            internet_block.ImageIndex = 2;
            myListView.Items.Add(internet_block);

            ListViewItem notebook = new ListViewItem();
            notebook.Text = "Note book";
            notebook.ToolTipText = "Note book";
            notebook.Tag = "notebook";
            notebook.ImageIndex = 3;
            myListView.Items.Add(notebook);

            ListViewItem del_file = new ListViewItem();
            del_file.Text = "Xóa file";
            del_file.ToolTipText = "Xóa file tạm";
            del_file.Tag = "del_file";
            del_file.ImageIndex = 4;
            myListView.Items.Add(del_file);

            ListViewItem screen_capture = new ListViewItem();
            screen_capture.Text = "Theo dõi";
            screen_capture.ToolTipText = "Theo dõi hoạt động trên màn hình";
            screen_capture.Tag = "screen_capture";
            screen_capture.ImageIndex = 5;
            myListView.Items.Add(screen_capture);

            this.Controls.Add(myListView);
        }

        private bool isCapturing = false;

        private void myListView_Click(object sender, EventArgs e)
        {
            if (myListView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = myListView.SelectedItems[0];
                string tagValue = selectedItem.Tag.ToString();

                string interfaceName = "Wi-Fi"; // Thay thế bằng tên của adapter mạng của bạn
                int timeOut = 5000; // Thời gian chờ tối đa, tùy chọn (5 giây)
                bool isAdapterEnabled = BlockInternet.NetworkAdaptersUtility.IsAdapterEnabled(interfaceName); // Cập nhật trạng thái của adapter mạng

                // Kiểm tra giá trị Tag và thực hiện các hành động tương ứng
                switch (tagValue)
                {
                    case "shutdown_timer":
                        //MessageBox.Show("Bạn vừa chọn shutdown_timer");
                        this.Hide();
                        SetShutdownTime f= new SetShutdownTime();
                        f.ShowDialog();
                        f = null;
                        this.Show();
                        break;
                    case "reminder":
                        //MessageBox.Show("Bạn vừa chọn reminder");
                        Reminder r = new Reminder();
                        r.Show();
                        r = null;
                        break;
                    case "internet_block":
                        isAdapterEnabled = BlockInternet.NetworkAdaptersUtility.IsAdapterEnabled(interfaceName); // Cập nhật lại trạng thái của adapter mạng
                        if (isAdapterEnabled)
                        {
                            // Gọi phương thức vô hiệu hóa adapter mạng                    
                            Task<bool> disableTask = BlockInternet.NetworkAdaptersUtility.DisableAdapterAsync(interfaceName, timeOut);
                            disableTask.ContinueWith(async t =>
                            {
                                bool disableResult = await t;
                                if (disableResult)
                                {
                                    isAdapterEnabled = false; // Cập nhật trạng thái của adapter mạng
                                }
                            });
                        }
                        else
                        {
                            // Gọi phương thức kích hoạt adapter mạng
                            Task<bool> enableTask = BlockInternet.NetworkAdaptersUtility.EnableAdapterAsync(interfaceName, timeOut);
                            enableTask.ContinueWith(async t =>
                            {
                                bool enableResult = await t;
                                if (enableResult)
                                {
                                    isAdapterEnabled = true; // Cập nhật trạng thái của adapter mạng
                                }
                            });
                        }
                        break;
                    case "notebook":
                        //MessageBox.Show("Bạn vừa chọn notebook");
                        this.Hide();
                        Notebook n = new Notebook();
                        n.Show();
                        n = null;
                        this.Show();
                        break;
                    case "del_file":
                        delFile.DeleteAllFilesInDirectory("../../temp/xoa");
                        //MessageBox.Show("Đã xóa file");
                        break;

                    case "screen_capture":
                        if (isCapturing)
                        {
                            capture.StopTimmer();
                            isCapturing = false;
                            //MessageBox.Show("Đã dừng chụp màn hình");
                        }
                        else
                        {
                            capture.StartTimmer();
                            isCapturing = true;
                            //MessageBox.Show("Bắt đầu chụp màn hình");
                        }
                        break;



                    default:
                        break;


                }

            }
        }
    }
}
