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

            //m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(callback));

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

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(callback));
        }

        /// <summary>
        /// 获取指定目录下面的文件列表
        /// </summary>
        /// <param name="isiso"></param>
        /// <param name="node"></param>
        /// <param name="callback"></param>
        public void GetTree(bool isiso, string node, FileSyncAPIRequest.FileSyncRequestCompletedHandler callback)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("func", "get_tree");
            dict.Add("is_iso", isiso ? "1" : "0");
            dict.Add("node", node);

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "GET", dict, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(callback));
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
            dict.Add(Path.GetFileName(filePath), new FileInfo(filePath));

            m_fsConnect.SendRequest("filemanager/utilRequest.cgi", "POST", dict, new FileSyncAPIRequest.FileSyncRequestCompletedHandler(callback));
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

    }
}
