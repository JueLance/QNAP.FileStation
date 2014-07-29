using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace FileSync.Library
{
    public class FileManagerResponse : IResponse
    {
        public string RawResponse { get; set; }

        [DataMember(Order = 1, Name = "version")]
        public string Version { get; set; }

        [DataMember(Order = 2, Name = "build")]
        public string Build { get; set; }

        [DataMember(Order = 3, Name = "status")]
        public string Status { get; set; }

        [DataMember(Order = 4, Name = "success")]
        public bool Success { get; set; }

        [DataMember(Order = 5, Name = "FolderList")]
        public List<Folder> FolderList { get; set; }
    }

    [Serializable]
    [DataContract]
    public class Folder
    {
        [DataMember(Order = 1, Name = "text")]
        public string Text { get; set; }

        [DataMember(Order = 2, Name = "id")]
        public string ID { get; set; }

        [DataMember(Order = 3, Name = "cls")]
        public string Cls { get; set; }

        [DataMember(Order = 4, Name = "draggable")]
        public string Draggable { get; set; }

        [DataMember(Order = 5, Name = "iconCls")]
        public string IconCls { get; set; }

        //[DataMember(Order = 6, Name = "noSupportACL")]
        //public int NoSupportACL { get; set; }
    }
}
