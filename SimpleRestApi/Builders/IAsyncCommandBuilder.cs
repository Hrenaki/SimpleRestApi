using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Commands;
using Core.Configuration;

namespace SimpleRestApi.Builders
{
    public interface IAsyncCommandBuilder
    {
        IAsyncCommand Build(IAsyncCommandSettings settings);
    }
}