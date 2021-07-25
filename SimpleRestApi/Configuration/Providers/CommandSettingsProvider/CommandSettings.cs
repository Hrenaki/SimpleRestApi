using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestApi.Configuration.Providers
{
    internal class CommandSetting
    {
        public string Type { get; set; }
        public JObject Settings { get; set; }
    }
}