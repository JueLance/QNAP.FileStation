using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace FileSyncDemo
{
    public class BaseResponse
    {
        [JsonProperty("version")]
        [DataMember(Order = 1, Name = "version")]
        public string Version { get; set; }

        [JsonProperty("build")]
        [DataMember(Order = 2, Name = "build")]
        public string Build { get; set; }

        [JsonProperty("status")]
        [DataMember(Order = 3, Name = "status")]
        public int Status { get; set; }

        [JsonProperty("success")]
        [DataMember(Order = 4, Name = "success")]
        public bool Success { get; set; }
    }

    public class FileListResponse
    {
        //"medialib": 1,
        //Total numer
        private int total { get; set; }
        //ACL permission. 7: read write, 4: read only, 0: deny
        public int acl { get; set; }
        public int is_acl_enable { get; set; }
        public int is_winacl_support { get; set; }
        public int is_winacl_enable { get; set; }
        public int rtt_support { get; set; }
        public FileMeta[] datas { get; set; }
    }


    public class FileMeta
    {
        public string filename { get; set; }
        public string isfolder { get; set; }
        public string filesize { get; set; }
        public string group { get; set; }
        public string owner { get; set; }
        public string iscommpressed { get; set; }
        public string privilege { get; set; }
        public string filetype { get; set; }
        public string mt { get; set; }

        public string FilePath { get; set; }
        public string FullPath { get; set; }
    }
}