using System;
using OyaHost.BLL.Universal;
using OyaHost.BLL.Core;

namespace OyaHost.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SSHClient.Instance.Configure();
            VmController.GetAllVmNames();
            //VmController.GetAllVmNames();
        }
    }
}
