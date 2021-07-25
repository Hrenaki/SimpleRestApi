using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Configuration;

namespace SimpleRestApi.Configuration
{
    public class StringsCommandSettings : IStringsCommandSettings
    {
        public string[] Strings { get; set; }
    }
}
