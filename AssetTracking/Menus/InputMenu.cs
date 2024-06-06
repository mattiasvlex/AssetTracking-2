using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Menus
{
    internal abstract class InputMenu(ProgramController controller)
    {
        protected ProgramController Controller { get; set; } = controller;
        protected string Prompt { get; set; } = string.Empty;
        protected string[] InputItems { get; set; } = [];

        public abstract void Run();

        public abstract void SendRequest();
    }
}
