using Core.Commands;
using Core.Configuration;
using SimpleRestApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestApi.Builders
{
    public class NameCommandBuilder : ICommandBuilder
    {
        public ICommand Build(ICommandSettings settings)
        {
            if (settings is INameCommandSettings)
            {
                return new NameCommand(settings as INameCommandSettings);
            }
            return null;
        }
    }
}