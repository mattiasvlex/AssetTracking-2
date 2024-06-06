using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Options = new string[] { "List assets", 
                                     "Edit assets", 
                                     "Add new asset", 
                                     "Remove asset" };
            TopRowPos = 12;  //Prompt is 10 rows, start menu from there
        }

        public override void SendRequest()
        {
            switch (CurrentSelection)
            {
                case 0:
                    //GetAll from Controller
                    break;
                case 1:
                    //Open edit menu
                    break;
                case 2:
                    //Open add menu
                    break;
                case 3:
                    //Open remove menu
                    break;
            }
        }
    }
}
