using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElonRich.API.Api
{
    public class ApiInitializer
    {
        public static HttpClient HttpClient { get; set; } = new();
    }
}
