using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SimpleRestApi.Configuration.Providers;

namespace SimpleRestApi.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly ICommandSettingsProvider _settingsProvider;

        public ApiController(ICommandSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        [HttpPost]
        public string Handle([FromBody] JObject message)
        {
            if (message == null)
            {
                return "Message was empty!";
            }

            var contextToken = message.SelectToken("context");
            var commandNameToken = message.SelectToken("command");
            
            if(contextToken != null && commandNameToken != null)
            {
                var contextName = contextToken.Value<string>();
                var messageHandler = _settingsProvider.GetHandlerByContext(contextName);

                return messageHandler == null ? 
                    $"Context with name '{contextName}' doesn't exist" :
                    messageHandler.Handle(commandNameToken.Value<string>());
            }
            
            return "Context or command property doesn't exist!";
        }

        [HttpGet]
        public string Ping()
        {
            return "Server is online!";
        }
    }
}