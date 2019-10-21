using Libvirt;
using System;

namespace OyaHost.BLL.Universal
{
    public static class VmController
    {
        public static void GetAllVmNames(){
            //var response = BashController.ExecCommand("sudo virsh list --all | awk '{ print $2 }' | tail -n +3");
            try
            {
                string[] names = new string[999];
                Connect.ListDefinedDomains(IntPtr.Zero, ref names, 999);
                foreach (var item in names)
                {
                    Console.WriteLine(item);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }
    }
}