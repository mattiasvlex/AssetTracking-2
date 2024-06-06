using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Menus
{
    internal class AddMenu : InputMenu
    {
        public AddMenu(ProgramController controller) : base(controller)
        {
            Prompt = "ADD NEW ASSET\n";
            
        }

        public override void Run()
        {
            
        }
        public override void SendRequest()
        {
            
        }
    }
}
