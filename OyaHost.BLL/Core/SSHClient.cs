using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace OyaHost.BLL.Core
{
    public sealed class SSHClient
    {
        #region singleton
        private static SSHClient instance = null;
        private static readonly object padlock = new object();

        private SSHClient()
        { }

        public static SSHClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if(instance == null)
                    {
                        instance = new SSHClient();
                    } 
                    return instance;
                }
            }
        }
        #endregion
        public ConnectionInfo ConnectionInfo;

        public void Configure()
        {
            ConnectionInfo = new ConnectionInfo("localhost", 22, Config.DefaultTestUser,
                new AuthenticationMethod[]
                {
                    new PasswordAuthenticationMethod(Config.DefaultTestUser,Config.DefaultTestPassword)
                });
        }
    }
}
