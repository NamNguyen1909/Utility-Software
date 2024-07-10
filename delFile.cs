using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility_Apps
{
    public class delFile
    {
        public static void DeleteAllFilesInDirectory(string directoryPath)
        {
            try
            {
                // Kiểm tra xem thư mục tồn tại không
                if (Directory.Exists(directoryPath))
                {
                    // Lấy danh sách tất cả các tệp trong thư mục
                    string[] files = Directory.GetFiles(directoryPath);
                    foreach (string file in files)
                    {
                        File.Delete(file);
                        Console.WriteLine($"Deleted file: {file}");
                    }

                    // Lấy danh sách tất cả các thư mục con
                    string[] subDirectories = Directory.GetDirectories(directoryPath);
                    foreach (string subDirectory in subDirectories)
                    {
                        // Gọi đệ quy để xóa các tệp trong thư mục con
                        DeleteAllFilesInDirectory(subDirectory);
                    }

                    // Sau khi xóa tất cả các tệp trong thư mục con, xóa thư mục cha
                    Directory.Delete(directoryPath);
                    Console.WriteLine($"Deleted directory: {directoryPath}");
                }
                else
                {
                    Console.WriteLine($"Directory does not exist: {directoryPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting files: {ex.Message}");
            }
        }
    }
}
