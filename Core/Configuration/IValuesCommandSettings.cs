using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    public interface IValuesCommandSettings : IAsyncCommandSettings
    {
        int[] Values { get; }
    }
}
