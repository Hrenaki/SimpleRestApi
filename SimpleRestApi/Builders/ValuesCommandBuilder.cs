using Core.Commands;
using Core.Configuration;
using SimpleRestApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestApi.Builders
{
    public class ValuesCommandBuilder : IAsyncCommandBuilder
    {
        public IAsyncCommand Build(IAsyncCommandSettings settings)
        {
            if (settings is IValuesCommandSettings)
            {
                return new ValuesCommand(settings as IValuesCommandSettings);
            }
            return null;
        }
    }
}