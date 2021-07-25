using Core.Commands;
using Core.Configuration;
using SimpleRestApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestApi.Builders
{
    public class StringsCommandBuilder : ICommandBuilder
    {
        public ICommand Build(ICommandSettings settings)
        {
            if (settings is IStringsCommandSettings)
            {
                return new StringsCommand(settings as IStringsCommandSettings);
            }
            return null;
        }
    }
}