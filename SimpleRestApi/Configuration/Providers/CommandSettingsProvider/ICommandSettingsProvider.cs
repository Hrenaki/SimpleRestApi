using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestApi.Configuration.Providers
{
    public interface ICommandSettingsProvider
    {
        IMessageHandler GetHandlerByContext(string contextName);
    }
}