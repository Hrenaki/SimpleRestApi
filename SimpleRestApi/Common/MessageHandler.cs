using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Commands;

namespace SimpleRestApi.Common
{
    public class MessageHandler : IMessageHandler
    {
        private readonly IEnumerable<ICommand> _commands;
        private readonly IEnumerable<IAsyncCommand> _asyncCommands;

        public MessageHandler(IEnumerable<ICommand> commands, IEnumerable<IAsyncCommand> asyncCommands)
        {
            _commands = commands;
            _asyncCommands = asyncCommands;
        }

        public string Handle(string message)
        {
            foreach (var asyncCommand in _asyncCommands)
            {
                if (asyncCommand.Name == message)
                {
                    var task = asyncCommand.ExecuteAsync();
                    Task.WaitAll(task);
                    return task.Result;
                }
            }

            foreach (var command in _commands)
            {
                if(command.Name == message)
                {
                    return command.Execute();
                }
            }

            return $"Can't find command with name '{message}'";
        }
    }
}