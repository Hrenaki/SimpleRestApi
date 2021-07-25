using Core.Commands;
using Core.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestApi.Commands
{
    public class NameCommand : ICommand
    {
        public string Name => "NameCommand";
        private readonly INameCommandSettings _settings;

        public NameCommand(INameCommandSettings settings)
        {
            _settings = settings;
        }

        public string Execute()
        {
            return _settings.Name;
        }
    }
}
