using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSync.Library
{
    public class FileManager
    {
        public FileManagerResponse GetTree(string sid, bool isiso, string node)
        {
            string url = Util.BuildUrl(string.Format("filemanager/utilRequest.cgi?func=get_tree&sid={0}&is_iso={1}&node={2}", sid, isiso ? "1" : "0", node));
            string json = HttpHelper.Get(url);
            return MappingResponse2(json);
        }

        public FileManagerResponse Upload(string sid, string destpath, bool isoverwrite, string filename, string aliasname)
        {
            string url = Util.BuildUrl(string.Format("filemanager/utilRequest.cgi?func=upload&type=standard&sid={0}&dest_path={1}&overwrite={2}&progress=-{3}", sid, destpath, isoverwrite ? "1" : "0", aliasname));
            string json = HttpHelper.PostFile(url, filename, aliasname);
            return MappingResponse(json);
        }

        private FileManagerResponse MappingResponse(string json)
        {
            FileManagerResponse response = new FileManagerResponse();

            try
            {
                response = JsonHelper.DeserializeObject<FileManagerResponse>(json);

                response.RawResponse = json;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        private FileManagerResponse MappingResponse2(string json)
        {
            FileManagerResponse response = new FileManagerResponse();
            response.RawResponse = json;

            try
            {
                response.FolderList = new List<Folder>();

                response.FolderList = JsonHelper.DeserializeObject<List<Folder>>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}
