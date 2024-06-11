using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Models;
using System.Diagnostics.Metrics;

namespace AssetTracking.Menus
{
    internal class AddMenu : ToggledMenu
    {

        protected Asset assetToAdd { get; set; }

        public AddMenu(ProgramController controller) : base(controller)
        {
            Prompt = "      ADD A NEW ASSET";
            Options = ["Enter type", "Enter brand", "Enter model", "Enter date", "Enter price", "Enter office location", "Cancel (main menu)"];
            TopRowPos = 3;
            LeftColumnPos = 2;
            SetMenuWidth();
            assetToAdd = new Asset();
        }

        private void ReRun()
        {
            TopRowPos = 3;
            LeftColumnPos = 2;
            SetMenuWidth();
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

        private string[] ParseDate(string date)
        {
            return new string[3];
        }

        private int ParsePrice(string price)
        {
            return 0;
        }

        private string ContainsOffice(string office)
        {
            return "";
        }

        protected override void NavigateOptions()
        {
            switch (CurrentSelection)
            {
                case 0:   //Enter type
                    LeftColumnPos += MenuWidth + 12 + 5;
                    Console.CursorLeft = LeftColumnPos;
                    Console.CursorTop = TopRowPos;
                    Console.Write("Name of Type: ");
                    string? type = Console.ReadLine();
                    assetToAdd.Type = type;
                    Console.CursorLeft = LeftColumnPos;
                    Console.CursorTop = TopRowPos;
                    Console.Write("              " + " ".PadRight(type.Length));
                    Console.CursorLeft += 5;
                    Console.Write("Type to add: " + assetToAdd.Type);
                    ReRun();
                    break;
                case 1:   //Enter brand
                    LeftColumnPos += MenuWidth + 12 + 5;
                    Console.CursorLeft = LeftColumnPos;
                    Console.CursorTop = TopRowPos + 1;
                    Console.Write("Name of Brand: ");
                    string? brand = Console.ReadLine();
                    assetToAdd.Brand = brand;
                    Console.CursorLeft = LeftColumnPos;
                    Console.CursorTop = TopRowPos + 1;
                    Console.Write("               " + " ".PadRight(brand.Length));
                    Console.CursorLeft += 11;
                    Console.Write("Brand to add: " + assetToAdd.Brand);
                    ReRun();
                    break;
                case 2:   //Enter model
                    LeftColumnPos += MenuWidth + 12 + 5;
                    Console.CursorLeft = LeftColumnPos;
                    Console.CursorTop = TopRowPos + 2;
                    Console.Write("Name of Model: ");
                    string? model = Console.ReadLine();
                    assetToAdd.Model = model;
                    Console.CursorLeft = LeftColumnPos;
                    Console.CursorTop = TopRowPos + 2;
                    Console.Write("               " + " ".PadRight(model.Length));
                    Console.CursorLeft += 10;
                    Console.Write("Model to add: " + assetToAdd.Model);
                    ReRun();
                    break;
                case 3:   //Enter date
                    LeftColumnPos += MenuWidth + 12 + 5;
                    Console.CursorLeft = LeftColumnPos;
                    Console.CursorTop = TopRowPos + 3;
                    Console.Write("Date (YYYY-MM-DD): ");
                    string? date = Console.ReadLine();
                    ParseDate(date);
                    Console.CursorLeft = LeftColumnPos;
                    Console.CursorTop = TopRowPos + 3;
                    Console.Write("                   " + " ".PadRight(date.Length));
                    Console.CursorLeft += 6;
                    Console.Write("Model to add: " + assetToAdd.Model);
                    ReRun();
                    break;
                case 4:   //Enter price

                    this.Run();
                    break;
                case 5:   //Enter office

                    this.Run();
                    break;
                case 6:   //Cancel and go to main menu
                    Console.Clear();
                    Controller.RunMainMenu();
                    break;
            }
        }
    }
}
