using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Configuration;

namespace SimpleRestApi.Configuration
{
    public class NameCommandSettings : INameCommandSettings
    {
        public string Name { get; set; }
    }
}
