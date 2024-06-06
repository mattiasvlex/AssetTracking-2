using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Menus
{
    internal abstract class InputMenu
    {
        protected ProgramController Controller { get; set; }
        protected string Prompt { get; set; } = string.Empty;
        protected string[] InputItems { get; set; }

        public InputMenu(ProgramController controller)
        {
            Controller = controller;
        }

        public abstract void Run();

        public abstract void SendRequest();
    }
}
