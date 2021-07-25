using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Core.Commands;
using Core.Configuration;
using SimpleRestApi.Builders;
using SimpleRestApi.Common;
using Core.Common;
using Core.Factories;

namespace SimpleRestApi.Configuration.Providers
{
    public class CommandSettingsProvider : ICommandSettingsProvider
    {
        private Dictionary<string, MessageHandler> _contextDictionary;

        public CommandSettingsProvider(ICommandFactory commandFactory)
        {
            var root = JObject.Parse(File.ReadAllText("appsettings.json"));

            var contextsToken = root.SelectToken("Contexts");
            if(contextsToken == null)
            {
                throw new Exception("Token 'Contexts' doesn't present in " + "appsettings.json");
            }

            var contexts = contextsToken.ToObject<Context[]>();

            var executingAssemblyTypes = Assembly.GetExecutingAssembly().GetTypes();
            var commandSettingsTypes = executingAssemblyTypes.Where(type => type.Name.EndsWith("CommandSettings") && !type.IsInterface);

            _contextDictionary = new Dictionary<string, MessageHandler>();

            foreach(var context in contexts)
            {
                var commandList = new List<ICommand>();
                var asyncCommandList = new List<IAsyncCommand>();

                foreach(var commandSetting in context.CommandSettings)
                {
                    var settings = commandSetting.Settings.ToObject(commandSettingsTypes.Single(type => type.Name == commandSetting.Type));

                    if(settings is ICommandSettings)
                    {
                        var command = commandFactory.TryCreateCommand(settings as ICommandSettings);
                        if(command != null)
                        {
                            commandList.Add(command);
                        }
                    }
                    else if(settings is IAsyncCommandSettings)
                    {
                        var asyncCommand = commandFactory.TryCreateAsyncCommand(settings as IAsyncCommandSettings);
                        if (asyncCommand != null)
                        {
                            asyncCommandList.Add(asyncCommand);
                        }
                    }
                }

                _contextDictionary.Add(context.Name, new MessageHandler(commandList, asyncCommandList));
            }
        }

        public IMessageHandler GetHandlerByContext(string contextName)
        {
            if(_contextDictionary.ContainsKey(contextName))
            {
                return _contextDictionary[contextName];
            }

            return null;
        }
    }
}
