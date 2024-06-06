using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Menus;
using Microsoft.EntityFrameworkCore.Update.Internal;
using AssetTracking.Data;

namespace AssetTracking
{
    internal class ProgramController
    {
        private MainMenu Main;
        private ApplicationDBContext dbContext;

        public ProgramController()
        {
            dbContext = new ApplicationDBContext();
            Main = new MainMenu(this);
        }

        public void Start()
        {
            Main.Run();
        }

        public void Update(int id, string column) 
        {
            //Update field id in table with column column

        }

    }

}
