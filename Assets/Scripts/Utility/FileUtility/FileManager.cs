using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileUtility
{
    public class FileManager
    {
        private static string[] TextureExtension = new string[] { ".jpg", ".png", ".bmp" };  //
        private static string[] MediaExtension = new string[] { ".mp4", ".rmvb", ".mkv" };  //

        public static string TextureFilter = "图片文件|*.bmp;*.jpg;*.jpeg;*.png";
        public static string MediaFilter = "视频文件|*.rmvb;*.mp4;*.mkv";

        /// <summary>
        /// 创建路径文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static bool CreateDirectory(string dirPath)
        {
            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                Log.Info(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 检测是否存在文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool CheckFileExist(string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                Log.Info(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 检查是否存在文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static bool CheckDirExist(string dirPath)
        {
            try
            {
                if (Directory.Exists(dirPath))
                {
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                Log.Info(ex.Message);
            }
            return false;
        }
        

        /// <summary>
        /// 删除没用的文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static bool DeleteNouseDirectory(string dirPath)
        {
            try
            {
                int fileLength = Directory.GetFiles(dirPath).Length;
                if (fileLength == 0)
                {
                    Directory.Delete(dirPath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Info(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 获取一重父文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static string Get1RootPath(string dirPath)
        {
            try
            {
                string root1 = Path.GetDirectoryName(dirPath);
                return root1;
            }
            catch (Exception ex)
            {
                Log.Info(ex.Message);
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取二重父文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static string Get2RootPath(string dirPath)
        {
            try
            {
                string root1 = Path.GetDirectoryName(dirPath);
                string root2 = Path.GetDirectoryName(root1);
                return root2;
            }
            catch (Exception ex)
            {
                Log.Info(ex.Message);
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取文本文件内容
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetFileContent(string filepath)
        {
            string errorStr = "";
            try
            {
                FileInfo fileInfo = new FileInfo(filepath);
                if(!fileInfo.Exists)
                {
                    return "The File not exists";
                }
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    string ret = System.Text.Encoding.UTF8.GetString(bytes);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                errorStr = ex.Message;
                Log.Info(ex.Message);
            }
            return errorStr;
        }

        /// <summary>
        /// 创建一个文本文件
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <param name="content"></param>
        public static bool CreateContentFile(string fileFullName,string content)
        {
            try
            {
                DeleteFile(fileFullName);
                using (FileStream fs = new FileStream(fileFullName, FileMode.Create))
                {
                    byte[] ctbytes = System.Text.Encoding.UTF8.GetBytes(content);
                    fs.Write(ctbytes, 0, ctbytes.Length);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                Log.Info(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 创建一个文本文件
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool CreateContentFile(string dirPath, string fileName, string content)
        {
            string filepath = Path.Combine(dirPath, fileName);
            return CreateContentFile(filepath, content);
        }
        
        /// <summary>
        /// 获取地址磁盘的空间
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="maxsize"></param>
        /// <param name="freesize"></param>
        public static void GetDirEmptySpace(string dirPath, out string driveName,out long maxsize, out long freesize)
        {
            try
            {
                if (dirPath.Contains(":\\"))
                {
                    string hardDisk = dirPath.Remove(dirPath.IndexOf(":\\"));
                    DriveInfo[] dirves = DriveInfo.GetDrives();
                    for (int i = 0; i < dirves.Length; i++)
                    {
                        if (dirves[i].Name.Contains(hardDisk))
                        {
                            driveName = hardDisk;
                            maxsize = dirves[i].TotalSize;
                            freesize = dirves[i].TotalFreeSpace;
                            return;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Info(ex.Message);
            }
            driveName = string.Empty;
            maxsize = 0;
            freesize = 0;
        }

        /// <summary>
        /// 获取文件夹下文件数量
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static int GetFileCount(string dirPath)
        {
            try
            {
                if (!Directory.Exists(dirPath))
                {
                    return 0;
                }
                return new DirectoryInfo(dirPath).GetFiles().Length;
            }
            catch (System.Exception ex)
            {
                Log.Info(ex.Message);
            }
            return 0;
        }

        /// <summary>
        /// 获取文件byte流
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static byte[] GetFileBytes(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return null;
                }
                byte[] buffer = null;
                using (FileStream fs = File.OpenRead(filePath))
                {
                    fs.Seek(0, SeekOrigin.End);
                    buffer = new byte[fs.Position];
                    fs.Seek(0, SeekOrigin.Begin);
                    fs.Read(buffer, 0, buffer.Length);
                }
                return buffer;
            }
            catch (System.Exception ex)
            {
                Log.Info(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// 讲文件名称转换成文件时间名称
        /// </summary>
        /// <param name="srcName"></param>
        /// <returns></returns>
        public static string GetFileTimeName(string srcName)
        {
            try
            {
                string name = Path.GetFileNameWithoutExtension(srcName);
                string ext = Path.GetExtension(srcName);
                name = name + System.DateTime.Now.ToString("yyyymmddhhmmssss") + ext;
                return name;
            }
            catch (Exception ex)
            {
                Log.Info(ex.Message);
            }
            return srcName;
        }

        /// <summary>
        /// 移动文件，修改名称
        /// </summary>
        /// <returns></returns>
        public static bool MoveFileByName(string dirPath, string srcName, string destName)
        {
            try
            {
                string srcFilePath = Path.Combine(dirPath, srcName);
                string destFilePath = Path.Combine(dirPath, destName);
                if (!File.Exists(srcFilePath))
                {
                    return false;
                }
                DeleteFile(destFilePath);
                File.Move(srcFilePath, destFilePath);
                return true;
            }
            catch (System.Exception ex)
            {
                Log.Info(ex.Message);
            }
            return false;
        }
        
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static bool DeleteFile(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                return true;
            }
            catch (System.Exception ex)
            {
                Log.Info(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 获取路径下所有文件夹列表
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static string[] GetDirectorys(string dirPath)
        {
            string[] dirs = Directory.GetDirectories(dirPath);
            return dirs;
        }

        /// <summary>
        /// 根据后缀获取文件路径列表
        /// </summary>
        /// <param name="exts"></param>
        /// <returns></returns>
        public static List<string> GetExtensionFile(string dirPath, string[] exts)
        {
            List<string> list = new List<string>();
            string[] totalFiles = Directory.GetFiles(dirPath);
            for (int i = 0; i < totalFiles.Length; i++)
            {
                for (int k = 0; k < exts.Length; k++)
                {
                    if (Path.GetExtension(totalFiles[i]) == exts[k])
                    {
                        list.Add(totalFiles[i]);
                        break;
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 根据后缀删除文件列表
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="exts"></param>
        public static void ClearExtensionFile(string dirPath, string[] exts)
        {
            string[] totalFiles = Directory.GetFiles(dirPath);
            for (int i = 0; i < totalFiles.Length; i++)
            {
                for (int k = 0; k < exts.Length; k++)
                {
                    if (Path.GetExtension(totalFiles[i]) == exts[k])
                    {
                        File.Delete(totalFiles[i]);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 清理texture后缀文件
        /// </summary>
        public static void ClearTextureExtensionFiles(string dirName)
        {
            ClearExtensionFile(dirName, TextureExtension);
        }

        /// <summary>
        /// 获取texture后缀文件
        /// </summary>
        /// <param name="dirName"></param>
        public static List<string> GetTextureExtensionFiles(string dirName)
        {
            return GetExtensionFile(dirName, TextureExtension);
        }

        /// <summary>
        /// 获取media后缀文件
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static List<string> GetMediaExtensionFiles(string dirPath)
        {
            return GetExtensionFile(dirPath, MediaExtension);
        }
        
        /// <summary>
        /// 打开路劲文件夹
        /// </summary>
        /// <returns></returns>
        public static void OpenPathFolder(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
        
        /// <summary>
        /// 写入文本到文件
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="path"></param>
        public static void WriteToTxt(string txt,string path)
        {
            try
            {
                //DeleteFile(path);
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(txt);
                sw.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                Log.Info(ex.Message);
            }
        }

        /// <summary>
        /// 获取电脑磁盘ID
        /// </summary>
        /// <returns></returns>
        public static string[] GetComputerDrives()
        {
            string[] allDrivers = Directory.GetLogicalDrives();
            return allDrivers;
        }

        /// <summary>
        /// 根据后缀获取文件名
        /// </summary>
        /// <param name="exts"></param>
        /// <returns></returns>
        public static List<string> GetExtensionFileName(string dirPath, string[] exts)
        {
            List<string> list = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
            foreach (FileInfo item in directoryInfo.GetFiles())
            {
                for (int k = 0; k < exts.Length; k++)
                {
                    if (Path.GetExtension(item.FullName) == exts[k])
                    {
                        list.Add(item.Name);
                        break;
                    }
                }
            }
            return list;
        }



    }
}
