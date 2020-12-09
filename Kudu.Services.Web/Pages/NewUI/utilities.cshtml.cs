using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Renci.SshNet;

namespace Kudu.Services.Web.Pages.NewUI
{
    public class utilitiesModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost(string data)
        {
            if(data == "collectNWTrace")
            {
                collectNWTrace();
            }
        }
        public void collectNWTrace()
        {
            try
            {
                using (var client = new SshClient("172.18.0.2", 2222, "root", "Docker!"))
                {
                    client.Connect();
                    //client.RunCommand("etc/init.d/networking restart");
                    client.RunCommand("mkdir testFolder");
                    client.RunCommand("cd testFolder");
                    client.RunCommand("cd testFolder");
                    client.RunCommand("timeout 10 tcpdump -i eth0 -s 65535 -w networkTrace1.cap");
                    client.Disconnect();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            // to do : return something
        }
    }
}
