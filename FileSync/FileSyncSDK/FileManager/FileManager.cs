using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace FileSyncDemo
{
    public class FileManager
    {
        FileSync m_fsConnect = null;

        public FileManager(FileSync fsConnect)
        {
            m_fsConnect = fsConnect;
        }

        /// <summary>
        /// 查看文件
        /// </summary>
        /// <param name="dest_folder"></param>
        /// <param name="dest_path"></param>
        /// <param name="callback"></param>
        public void View(string dest_folder, string dest_path, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            //string url = string.Format("http://192.168.1.85:8080/cgi-bin/filemanager/utilRequest.cgi/baidu.png?sid={0}&func=get_viewer&source_path=/BaiduYun/test&source_file=baidu.PNG", Setting.SessionID);

            //Dictionary<string, object> dict = new Dictionary<string, object>();
            //dict.Add("func", "createdir");
            //dict.Add("dest_folder", dest_folder);
            //dict.Add("dest_path", dest_path);

            //m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, callback);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dest_folder"></param>
        /// <param name="dest_path"></param>
        /// <param name="callback"></param>
        public void CreateDir(string dest_folder, string dest_path, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "createdir");
            dict.Add("dest_folder", dest_folder);
            dict.Add("dest_path", dest_path);

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, callback);
        }

        /// <summary>
        /// 删除文件或者文件夹
        /// </summary>
        /// <param name="path">Folder path.</param>
        /// <param name="file_total">Total number of folder/file(s).</param>
        /// <param name="file_name">Folder/file name.</param>
        /// <param name="callback"></param>
        public void Delete(string path, int file_total, string file_name, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "delete");
            dict.Add("path", path);
            dict.Add("file_total", file_total.ToString());
            dict.Add("file_name", file_name);

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, callback);
        }

        /// <summary>
        /// Rename a folder or file in the specified path.
        /// </summary>
        /// <param name="path">Path of the folder/ file</param>
        /// <param name="source_name">Current folder/ file name to be changed</param>
        /// <param name="dest_name">New folder/ file name</param>
        /// <param name="callback"></param>
        public void Rename(string path, string source_name, string dest_name, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "rename");
            dict.Add("path", path);
            dict.Add("source_name", source_name);
            dict.Add("dest_name", dest_name);

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, callback);
        }

        /// <summary>
        /// Copy a file/folder from the source to the destination.
        /// </summary>
        /// <param name="source_file">Name of the copied file/folder</param>
        /// <param name="source_total">Total number of copied files/folders</param>
        /// <param name="source_path">Source path of the copied file/folder</param>
        /// <param name="dest_path">Destination of the copied file/folder</param>
        /// <param name="mode">1: skip, 0: overwrite</param>
        /// <param name="duplicationName">The duplication file name when copying the same destination with source files/folders.</param>
        /// <param name="callback"></param>
        public void Copy(string source_file, int source_total, string source_path, string dest_path, int mode, string duplicationName, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            //if (string.IsNullOrEmpty(duplicationName))
            //{
            //    duplicationName = Path.GetFileNameWithoutExtension(source_file) + DateTime.Now.Ticks.ToString() + Path.GetExtension(source_file);
            //}

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "copy");
            dict.Add("source_file", source_file);
            dict.Add("source_total", source_total.ToString());
            dict.Add("source_path", source_path);
            dict.Add("dest_path", dest_path);
            dict.Add("mode", mode.ToString());

            //optional
            if (!string.IsNullOrEmpty(duplicationName))
            {
                dict.Add("dup", duplicationName);
            }

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, callback);
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="source_file">Name of the copied file/folder</param>
        /// <param name="source_total">Total number of copied files/folders</param>
        /// <param name="source_path">Source path of the copied file/folder</param>
        /// <param name="dest_path">Destination of the copied file/folder</param>
        /// <param name="mode">1: skip, 0: overwrite</param>
        /// <param name="callback"></param>
        public void Move(string source_file, int source_total, string source_path, string dest_path, int mode, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "move");
            dict.Add("source_file", source_file);
            dict.Add("source_total", source_total.ToString());
            dict.Add("source_path", source_path);
            dict.Add("dest_path", dest_path);
            dict.Add("mode", mode.ToString());

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, callback);
        }

        public void GetList(string path, bool isiso, int start, int limit, string sortfield, SortDirection dir, FileHidden hidden, FileType ft, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "get_list");
            dict.Add("is_iso", isiso ? "1" : "0");
            dict.Add("list_mode", "all");
            dict.Add("path", path);
            dict.Add("dir", dir == SortDirection.Asc ? "ASC" : "DESC");
            dict.Add("limit", limit.ToString());
            dict.Add("sort", sortfield);
            dict.Add("start", start.ToString());
            dict.Add("hidden_file", hidden == FileHidden.Hidden ? "1" : "0");
            if (ft != FileType.All)
            {
                dict.Add("type", (uint)ft);
            }
            //dict.Add("mp4_360", "0");
            //dict.Add("mp4_720", "0");
            //dict.Add("flv_720", "0");
            //dict.Add("filename", "");

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, callback);
        }

        public void GetTree(bool isiso, string node, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "get_tree");
            dict.Add("is_iso", isiso ? "1" : "0");
            dict.Add("node", node);

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, callback);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="destpath"></param>
        /// <param name="isoverwrite"></param>
        /// <param name="filePath"></param>
        /// <param name="aliasname"></param>
        /// <param name="callback"></param>
        public void Upload(string destpath, bool isoverwrite, string filePath, string aliasname, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "upload");
            dict.Add("type", "standard");
            dict.Add("dest_path", destpath);
            dict.Add("overwrite", isoverwrite ? "1" : "0");
            dict.Add("progress", aliasname.Replace("/", "-"));
            //dict.Add(Path.GetFileName(filePath), new FileInfo(filePath));
            dict.Add(filePath, new FileInfo(filePath));

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "POST", dict, callback);
        }

        /// <summary>
        /// 获取IP列表
        /// </summary>
        /// <param name="callback"></param>
        public void GetDomainIPList(FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "get_domain_ip_list");

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, callback);
        }


        /// <summary>
        /// 获取文件/文件夹状态
        /// </summary>
        /// <param name="path"></param>
        /// <param name="totalFile"></param>
        /// <param name="fileName"></param>
        /// <param name="callback"></param>
        public void GetStatus(string path, int totalFile, string fileName, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "stat");
            dict.Add("path", path);
            dict.Add("file_total", totalFile);
            dict.Add("file_name", fileName);

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, callback);
        }
    }

    public enum SortDirection
    {
        Asc,
        Desc
    }

    public class SortField
    {
        public const string FileName = "filename";
        public const string FileSize = "filesize";
        public const string FileType = "filetype";
        public const string Mt = "mt";
        public const string Privilege = "privilege";
        public const string Owner = "owner";
        public const string Group = "group";
    }

    public enum FileHidden
    {
        Hidden,
        Display
    }

    public enum FileType : uint
    {
        All = 0,
        Music = 1,
        Video = 2,
        Photo = 3
    }
}
