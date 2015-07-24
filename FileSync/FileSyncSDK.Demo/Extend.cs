using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileSyncDemo
{
    public static class Extend
    {
        public static string Join(this List<string> list, string split)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("{0}{1}", item, split);
            }

            return sb.ToString();
        }
    }
}
