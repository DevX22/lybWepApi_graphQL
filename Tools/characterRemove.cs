using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class character
    {
        public static string remove(string str)
        {
            str = str.Trim();
            str = string.Join("", str.Split("'"));
            return str;
        }
    }
}
