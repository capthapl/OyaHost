using System.Diagnostics;
using System;

namespace OyaHost.BLL.Universal
{
    public static class BashController
    {

        /// <summary>
        /// Wywołuje polecenie bashowe i zwraca obiekt klasy CommandResponse.
        /// </summary>
        /// <param name="command">Polecenie</param>
        /// <param name="args">Argumenty polecenia</param>
        /// <returns></returns>
        public static CommandResponse ExecCommand(string command, string args)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (string.IsNullOrEmpty(error))
            {
                return new CommandResponse(CommandResponseStatusCode.Success,output);
            }else{
                return new CommandResponse(CommandResponseStatusCode.Error,output,error);
            }
        }
    }
}