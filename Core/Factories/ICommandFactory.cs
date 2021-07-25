using Core.Commands;
using Core.Configuration;

namespace Core.Factories
{
    public interface ICommandFactory
    {
        ICommand TryCreateCommand(ICommandSettings settings);
        IAsyncCommand TryCreateAsyncCommand(IAsyncCommandSettings settings);
    }
}
