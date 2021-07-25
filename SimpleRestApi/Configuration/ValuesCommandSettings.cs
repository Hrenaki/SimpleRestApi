using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Configuration;

namespace SimpleRestApi.Configuration
{
    public class ValuesCommandSettings : IValuesCommandSettings
    {
        public int[] Values { get; set; }
    }
}
