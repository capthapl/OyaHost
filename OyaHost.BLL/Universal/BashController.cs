using System.Diagnostics;
using System;
using Renci.SshNet;
using OyaHost.BLL.Core;

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
        public static void ExecCommand(string command, string args)
        {
            using (var sshclient = new SshClient(SSHClient.Instance.ConnectionInfo))
            {
                sshclient.Connect();

                Console.WriteLine(sshclient.CreateCommand("cd /tmp && ls -lah").Execute());
                Console.WriteLine(sshclient.CreateCommand("pwd").Execute());
                Console.WriteLine(sshclient.CreateCommand("cd /tmp/uploadtest && ls -lah").Execute());
                sshclient.Disconnect();
            }

           /* if (string.IsNullOrEmpty(error))
            {
                return new CommandResponse(CommandResponseStatusCode.Success,output);
            }else{
                return new CommandResponse(CommandResponseStatusCode.Error,output,error);
            }*/
        }
    }
}