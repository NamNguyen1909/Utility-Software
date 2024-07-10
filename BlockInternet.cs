using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace Utility_Apps
{
    internal class BlockInternet
    {
        public static class NetworkAdaptersUtility
        {
            // Phương thức thực thi lệnh và đợi quá trình kết thúc
            private static void ExecuteWaitProcess(string cmd, string args)
            {
                ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
                Process p = new Process();
                p.StartInfo = psi;
                p.Start();
                p.WaitForExit();
            }

            // Phương thức bật adapter mạng bất đồng bộ
            public static Task<bool> EnableAdapterAsync(string interfaceName, int timeOut = 2000)
            {
                bool enabled = false;
                int timeElapsed = 0; //biến lưu thời gian trôi qua
                int timeWait = 100;
                var locker = new object();

                return Task.Run(() =>
                {
                    ExecuteWaitProcess("netsh", "interface set interface \"" + interfaceName + "\" enable");

                    do
                    {
                        lock (locker) enabled = IsAdapterEnabled(interfaceName);//gọi để kiểm tra xem adapter mạng có được bật không
                        Thread.Sleep(timeWait);
                        lock (locker) timeElapsed += timeWait;

                    } while (!enabled && timeElapsed < timeOut); //Vòng lặp này sẽ tiếp tục chạy cho đến khi adapter mạng được bật 
                    return enabled;
                });
            }

            // Phương thức tắt adapter mạng bất đồng bộ
            public static Task<bool> DisableAdapterAsync(string interfaceName, int timeOut = 2000)
            {
                bool disabled = false;
                int timeElapsed = 0;
                int timeWait = 100;
                var locker = new object();

                return Task.Run(() =>
                {
                    ExecuteWaitProcess("netsh", "interface set interface \"" + interfaceName + "\" disable");

                    do
                    {
                        lock (locker) disabled = IsAdapterDisabled(interfaceName);
                        Thread.Sleep(timeWait);
                        lock (locker) timeElapsed += timeWait;

                    } while (!disabled && timeElapsed < timeOut);
                    return disabled;
                });
            }

            /// https://stackoverflow.com/a/314322/19305596
            // Kiểm tra xem adapter mạng có được bật không
            public static bool IsAdapterEnabled(string interfaceName)
            {
                var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                NetworkInterface selectedInterface = networkInterfaces
                                                        .FirstOrDefault(n => n.Name == interfaceName);
                if (selectedInterface == null)
                {
                    return false;
                }
                return selectedInterface.OperationalStatus == OperationalStatus.Up;
            }

            // Kiểm tra xem adapter mạng có được tắt không
            public static bool IsAdapterDisabled(string interfaceName)
            {
                var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                NetworkInterface selectedInterface = networkInterfaces
                                                        .FirstOrDefault(n => n.Name == interfaceName);
                if (selectedInterface == null)
                {
                    // Nếu giao diện mạng không tồn tại, nó không thể được vô hiệu hóa
                    return false;
                }
                // Trả về true nếu giao diện mạng đã bị vô hiệu hóa
                return selectedInterface.OperationalStatus != OperationalStatus.Up;
            }
        }
    }
}
