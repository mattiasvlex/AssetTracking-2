using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Models;

namespace AssetTracking.Menus
{
    internal class RemoveMenu : ToggledMenu
    {
        private readonly List<Asset> Assets;

        public RemoveMenu(ProgramController controller) : base(controller) 
        {
            Prompt = "                             CHOOSE AN ASSET TO REMOVE (and press Enter)";
            Assets = Controller.GetAll();
            Options = new string[Assets.Count + 1];
            for (int i = 0; i < Options.Length - 1; i++)
            {
                Options[i] = Assets[i].ToString();
            }
            Options[Options.Length - 1] = "Go back to main menu"; 
            TopRowPos = 3;
            LeftColumnPos = 6;
            SetMenuWidth();
        }

        protected override void NavigateOptions()
        {
            if (CurrentSelection == Options.Length - 1)  //Go to main menu
            {        
                Console.Clear();
                Controller.RunMainMenu();
            } 
            else
            {
                Controller.Remove(Assets[CurrentSelection]);
                Console.WriteLine("The asset has been removed! \n\nPress any key to go back to main menu");
                Console.ReadKey();
                Console.Clear();
                Controller.RunMainMenu();
            }
        }
    }
}
