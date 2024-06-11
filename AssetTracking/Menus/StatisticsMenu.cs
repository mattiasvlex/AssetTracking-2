using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Menus
{
    internal class StatisticsMenu : ToggledMenu
    {
        public StatisticsMenu(ProgramController controller) : base(controller) 
        {
            Prompt = "No statistics to show yet!";
            Options = [ "Go back to main menu" ];
            TopRowPos = 3;
            LeftColumnPos = 40;
            SetMenuWidth();
        }

        protected override void NavigateOptions()
        {
            switch (CurrentSelection)
            {
                case 0:    //Go to main menu
                    Console.Clear();
                    Controller.RunMainMenu();
                    break;
            }
        }
    }
}
