using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Commands;
using Core.Configuration;
using Newtonsoft.Json.Linq;

namespace SimpleRestApi.Commands
{
    public class ValuesCommand : IAsyncCommand
    {
        public string Name => "ValuesCommand";
        private readonly IValuesCommandSettings _settings;

        public ValuesCommand(IValuesCommandSettings settings)
        {
            _settings = settings;
        }

        public async Task<string> ExecuteAsync()
        {
            return await Task.Run(() => new JProperty("Values", _settings.Values).ToString());
        }
    }
}