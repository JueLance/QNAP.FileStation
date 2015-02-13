using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace FileSyncSDK
{
    public class JsonHelper
    {
        public static string Serializer<T>(T obj)
        {
            string result = string.Empty;
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, obj);
                result = Encoding.UTF8.GetString(ms.ToArray());
            }
            return result;
        }

        public static T DeserializeObject<T>(string json)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                T t = (T)serializer.ReadObject(ms);
                return t;
            } 
        }

        // var stream = new MemoryStream();
        // serializer.WriteObject(stream, test);
        // byte[] dataBytes = new byte[stream.Length];
        // stream.Position = 0;
        // stream.Read(dataBytes, 0, (int)stream.Length);
        // string dataString = Encoding.UTF8.GetString(dataBytes);

        // Console.WriteLine(dataString);
        // Console.ReadKey();
    }
}

