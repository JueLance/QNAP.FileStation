using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileSyncSDK
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
            dict.Add("path",path );
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
