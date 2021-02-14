using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    public static class AppConfigClass
    {
        public static string host { get; set; } = "smtp.web.de";
        public static int port { get; set; } = 25;
    }
}
