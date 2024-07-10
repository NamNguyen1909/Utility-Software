using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility_Apps
{
    internal class capture
    {
        #region Capture
        static string imagePath = "../../Temp/xoa/Image_";
        static string imageExtendtion = ".png";

        static int imageCount = 0;
        static int captureTime = 1000;

        /// <summary>
        /// Capture al screen then save into ImagePath
        /// </summary>
        static void CaptureScreen()
        {
            ////Create a new bitmap.
            //var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
            //                               Screen.PrimaryScreen.Bounds.Height,
            //                               PixelFormat.Format32bppArgb);

            //// Create a graphics object from the bitmap.
            //var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            //// Take the screenshot from the upper left corner to the right bottom corner.
            //gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
            //                            Screen.PrimaryScreen.Bounds.Y,
            //                            0,
            //                            0,
            //                            Screen.PrimaryScreen.Bounds.Size,
            //                            CopyPixelOperation.SourceCopy);

            //string directoryImage = imagePath + DateTime.Now.ToLongDateString();

            //if (!Directory.Exists(directoryImage))
            //{
            //    Directory.CreateDirectory(directoryImage);
            //}
            //// Save the screenshot to the specified path that the user has chosen.
            //string imageName = string.Format("{0}\\{1}{2}", directoryImage, DateTime.Now.ToLongDateString() + imageCount, imageExtendtion);

            //try
            //{
            //    bmpScreenshot.Save(imageName, ImageFormat.Png);
            //}
            //catch
            //{

            //}
            //imageCount++;

            try
            {
                using (var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                               Screen.PrimaryScreen.Bounds.Height,
                                               PixelFormat.Format32bppArgb))
                {
                    using (var gfxScreenshot = Graphics.FromImage(bmpScreenshot))
                    {
                        gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                                    Screen.PrimaryScreen.Bounds.Y,
                                                    0,
                                                    0,
                                                    Screen.PrimaryScreen.Bounds.Size,
                                                    CopyPixelOperation.SourceCopy);
                    }

                    string directoryImage = imagePath + DateTime.Now.ToString("yyyy-MM-dd");

                    if (!Directory.Exists(directoryImage))
                    {
                        Directory.CreateDirectory(directoryImage);
                    }

                    string imageName = string.Format("{0}\\{1}_{2}{3}", directoryImage, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"), imageCount, imageExtendtion);
                    bmpScreenshot.Save(imageName, ImageFormat.Png);
                    imageCount++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while capturing screen: " + ex.Message);
            }
        }

        #endregion

        #region Timer
        static int interval = 1;
        static bool isRunning = true;
        public static void StartTimmer()
        {
            //Thread thread = new Thread(() => {
            //    while (isRunning)
            //    {
            //        //nhieu luong, xu li chinh xac chenh lech thoi gian
            //        Thread.Sleep(1);

            //        if (interval % captureTime == 0)
            //            CaptureScreen();

            //        interval++;

            //        if (interval >= 1000000)
            //            interval = 0;
            //    }
            //});
            //thread.IsBackground = true;
            //thread.Start();

            Thread thread = new Thread(() => {
                while (isRunning)
                {
                    Thread.Sleep(captureTime);

                    CaptureScreen();
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }

        public static void StopTimmer()
        {
            isRunning=false;
        }
        #endregion
    }
}
