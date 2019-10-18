using System.Diagnostics;
using System;
using Renci.SshNet;
using OyaHost.BLL.Core;
using Renci.SshNet.Common;
using System.Net.Sockets;

namespace OyaHost.BLL.Universal
{
    public static class BashController
    {

        /// <summary>
        /// Wywołuje polecenie przez SSH i zwraca obiekt klasy CommandResponse.
        /// </summary>
        /// <param name="command">Polecenie</param>
        /// <param name="args">Argumenty polecenia</param>
        /// <returns></returns>
        public static CommandResponse ExecCommand(string command)
        {
            using (var sshclient = new SshClient(SSHClient.Instance.ConnectionInfo))
            {
                SshCommand sshCmd = null;
                try
                {
                    sshclient.Connect();
                    sshCmd = sshclient.CreateCommand(command);
                    sshCmd.Execute();
                    return new CommandResponse(CommandResponseStatusCode.Success, sshCmd.Result, sshCmd.Error);
                }
                catch (Exception ex)
                {
                    if (sshCmd != null)
                    {
                        return new CommandResponse(CommandResponseStatusCode.Exception, sshCmd.Result ?? string.Empty, sshCmd.Error ?? string.Empty, ex.Message + ex.StackTrace);
                    }
                    else
                    {
                        return new CommandResponse(CommandResponseStatusCode.Exception, string.Empty, string.Empty, ex.Message + ex.StackTrace);
                    }
                }
            }
        }
    }
}