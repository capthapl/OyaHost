using System.Diagnostics;
using System;
using Renci.SshNet;
using OyaHost.BLL.Core;
using Renci.SshNet.Common;
using System.Net.Sockets;
using System.IO;

namespace OyaHost.BLL.Universal
{
    public static class BashController
    {

        /// <summary>
        /// Wywołuje polecenie przez SSH i zwraca obiekt klasy CommandResponse.
        /// </summary>clear
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
                    sshCmd = sshclient.RunCommand("echo | "+Config.DefaultTestPassword+"sudo su - root -c '"+command+"'");
                    Console.Write(sshCmd.CommandText);
                    string commandOutput = string.Empty;
                    var reader = new StreamReader(sshCmd.ExtendedOutputStream);
                    commandOutput = reader.ReadToEnd();

                    return new CommandResponse(CommandResponseStatusCode.Success, commandOutput, sshCmd.Error);
                }
                catch (Exception ex)
                {
                    return new CommandResponse(CommandResponseStatusCode.Exception,string.Empty, string.Empty, ex.Message + ex.StackTrace);

                }
            }
        }
    }
}