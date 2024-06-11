using AssetTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Menus
{
    internal class ListMenu : ToggledMenu
    {
        private readonly List<Asset> Assets;
        public ListMenu(ProgramController controller) : base(controller)
        {
            Assets = Controller.GetAll();
            Prompt = "      Type           Brand          Model          Date           Location       Price USD      Local Price\n";
            Prompt += "      -----          -----          ------         -----          --------       ---------      -----------";

            Options = [ "View statistics",
                        "Go back to main menu" ];

            TopRowPos = 4 + Assets.Count;  //4 is 2 below the prompt
            LeftColumnPos = 40;
            SetMenuWidth();
        }

        public override void Run()
        {
            Console.WriteLine(Prompt);
            foreach (var asset in Assets)
            {
                if (asset.IsOlderThan(2, 9))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(asset.ToStringWithLocalPrice());
                    Console.ResetColor();
                }
                else if (asset.IsOlderThan(2, 6))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(asset.ToStringWithLocalPrice());
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(asset.ToStringWithLocalPrice());
                }
            }
            DrawMenuOptions();
            bool run = true;
            while (run)
            {
                ConsoleKey keyPressed = Console.ReadKey().Key;
                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        MoveCursorUp();
                        DrawMenuOptions();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveCursorDown();
                        DrawMenuOptions();
                        break;
                    case ConsoleKey.Enter:
                        NavigateOptions();
                        run = false;
                        break;
                }
            }
        }

        protected override void NavigateOptions()
        {
            switch (CurrentSelection)
            {
                case 0:   //View statistics
                    Console.Clear();
                    StatisticsMenu statMenu = new StatisticsMenu(Controller);
                    statMenu.Run();
                    break;
                case 1:    //Go to main menu
                    Console.Clear();
                    Controller.RunMainMenu();
                    break;
            }
        }
    }
}
