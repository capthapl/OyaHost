using System;

namespace OyaHost.BLL.Universal
{
    public static class VmController
    {
        public static void GetAllVmNames(){
            BashController.ExecCommand("sudo virsh list --all | awk '{ print $2 }' | tail -n +3",string.Empty);
           
            //Console.WriteLine(response.CommandResponseStatusCode.ToString() + response.Response);
        }
    }
}