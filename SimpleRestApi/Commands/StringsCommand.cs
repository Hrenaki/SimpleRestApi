using Core.Commands;
using Core.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestApi.Commands
{
    public class StringsCommand : ICommand
    {
        public string Name => "StringsCommand";
        private readonly IStringsCommandSettings _settings;

        public StringsCommand(IStringsCommandSettings settings)
        {
            _settings = settings;
        }

        public string Execute()
        {
            return new JProperty("Values", _settings.Strings).ToString();
        }
    }
}
