using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestApi.Configuration.Providers
{
    internal class Context
    {
        public string Name { get; set; }
        public CommandSetting[] CommandSettings { get; set; }
    }
}