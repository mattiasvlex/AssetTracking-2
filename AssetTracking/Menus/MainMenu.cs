using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Models;

namespace AssetTracking.Menus
{
    internal class MainMenu : ToggledMenu
    {
        public MainMenu(ProgramController controller) : base(controller)
        {
            Prompt = @"
 ▄▄▄        ██████   ██████ ▓█████▄▄▄█████▓   ▄▄▄█████▓ ██▀███   ▄▄▄       ▄████▄   ██ ▄█▀▓█████  ██▀███  
▒████▄    ▒██    ▒ ▒██    ▒ ▓█   ▀▓  ██▒ ▓▒   ▓  ██▒ ▓▒▓██ ▒ ██▒▒████▄    ▒██▀ ▀█   ██▄█▒ ▓█   ▀ ▓██ ▒ ██▒
▒██  ▀█▄  ░ ▓██▄   ░ ▓██▄   ▒███  ▒ ▓██░ ▒░   ▒ ▓██░ ▒░▓██ ░▄█ ▒▒██  ▀█▄  ▒▓█    ▄ ▓███▄░ ▒███   ▓██ ░▄█ ▒
░██▄▄▄▄██   ▒   ██▒  ▒   ██▒▒▓█  ▄░ ▓██▓ ░    ░ ▓██▓ ░ ▒██▀▀█▄  ░██▄▄▄▄██ ▒▓▓▄ ▄██▒▓██ █▄ ▒▓█  ▄ ▒██▀▀█▄  
 ▓█   ▓██▒▒██████▒▒▒██████▒▒░▒████▒ ▒██▒ ░      ▒██▒ ░ ░██▓ ▒██▒ ▓█   ▓██▒▒ ▓███▀ ░▒██▒ █▄░▒████▒░██▓ ▒██▒
 ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░░░ ▒░ ░ ▒ ░░        ▒ ░░   ░ ▒▓ ░▒▓░ ▒▒   ▓▒█░░ ░▒ ▒  ░▒ ▒▒ ▓▒░░ ▒░ ░░ ▒▓ ░▒▓░
  ▒   ▒▒ ░░ ░▒  ░ ░░ ░▒  ░ ░ ░ ░  ░   ░           ░      ░▒ ░ ▒░  ▒   ▒▒ ░  ░  ▒   ░ ░▒ ▒░ ░ ░  ░  ░▒ ░ ▒░
  ░   ▒   ░  ░  ░  ░  ░  ░     ░    ░           ░        ░░   ░   ░   ▒   ░        ░ ░░ ░    ░     ░░   ░ 
      ░  ░      ░        ░     ░  ░                       ░           ░  ░░ ░      ░  ░      ░  ░   ░     
                                                                          ░                               
";

            Options = [ "List all assets", 
                        "Edit an asset", 
                        "Add a new asset", 
                        "Remove an asset" ];
            TopRowPos = 12;  //Prompt is 10 rows, start menu from a bit further down
            LeftColumnPos = 40;
            SetMenuWidth();
        }

        protected override void NavigateOptions()
        {
            Console.Clear();
            switch (CurrentSelection)
            {
                case 0:   //List all assets
                    ListMenu listMenu = new ListMenu(Controller);
                    listMenu.Run();
                    break;
                case 1:   //Open edit menu
                    UpdateMenu updateMenu = new UpdateMenu(Controller);
                    updateMenu.Run();
                    break;
                case 2:   //Open add menu
                    AddMenu addMenu = new AddMenu(Controller);
                    addMenu.Run();
                    break;
                case 3:   //Open remove menu
                    RemoveMenu removeMenu = new RemoveMenu(Controller);
                    removeMenu.Run();
                    break;
            }
        }
    }
}
