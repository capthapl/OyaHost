using System;
using OyaHost.BLL.Universal;

namespace OyaHost.BLL.Universal
{
    /// <summary>
    /// Klasa pełniąca funkcję kontenera na wynik polecenia bashowego wraz ze statusem błędu, wynikiem polecenia i błędem.
    /// </summary>
    public class CommandResponse{
        public CommandResponseStatusCode CommandResponseStatusCode { get; private set; }
        public string Response { get; private set; }
        public string Error { get; private set; }
        public string ExceptionMessage { get; private set; }
        
        public CommandResponse( CommandResponseStatusCode commandResponseStatusCode, string response, string error = "", string exceptionMessage = "")
        {
            this.CommandResponseStatusCode = commandResponseStatusCode;
            this.Response = response;
            this.Error = error;
            this.ExceptionMessage = exceptionMessage;
        }
    }
}