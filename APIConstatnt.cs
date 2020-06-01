using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServiceConsumeApplication
{
    public class APIConstatnt
    {
        private static string _api;

        public static string Api
        {
            get
            {
                if (_api == null)
                    _api = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetSection("EndPoint")["ServerUrl"].ToString();
                return _api;
            }
        }
    }
}
