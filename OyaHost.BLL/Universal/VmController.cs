using System;

namespace OyaHost.BLL.Universal
{
    public static class VmController
    {
        public static void GetAllVmNames(){
            var response = BashController.ExecCommand("sudo virsh list --all | awk '{ print $2 }' | tail -n +3");
            Console.WriteLine(response.CommandResponseStatusCode.ToString() + response.Response + response.ExceptionMessage);
        }
    }
}