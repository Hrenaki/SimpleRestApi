using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    public interface IAsyncCommand
    {
        string Name { get; }
        Task<string> ExecuteAsync();
    }
}
