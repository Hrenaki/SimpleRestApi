using Core.Commands;
using Core.Configuration;
using Core.Factories;
using SimpleRestApi.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SimpleRestApi.Factories
{
    public class StupidCommandFactory : ICommandFactory
    {
        private IEnumerable<ICommandBuilder> _commandBuilders;
        private IEnumerable<IAsyncCommandBuilder> _asyncCommandBuilders;

        public StupidCommandFactory()
        {
            var executingAssemblyTypes = Assembly.GetExecutingAssembly().GetTypes();

            _commandBuilders = executingAssemblyTypes
                .Where(type => type.GetInterfaces().Contains(typeof(ICommandBuilder)))
                .Select(type => (ICommandBuilder)Activator.CreateInstance(type));

            _asyncCommandBuilders = executingAssemblyTypes
                .Where(type => type.GetInterfaces().Contains(typeof(IAsyncCommandBuilder)))
                .Select(type => (IAsyncCommandBuilder)Activator.CreateInstance(type));
        }


        public ICommand TryCreateCommand(ICommandSettings settings)
        {
            foreach (var builder in _commandBuilders)
            {
                var command = builder.Build(settings);
                if (command != null)
                {
                    return command;
                }
            }
            return null;
        }
        public IAsyncCommand TryCreateAsyncCommand(IAsyncCommandSettings settings)
        {
            foreach (var builder in _asyncCommandBuilders)
            {
                var command = builder.Build(settings);
                if (command != null)
                {
                    return command;
                }
            }
            return null;
        }
    }
}