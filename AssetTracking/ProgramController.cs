using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracking.Menus;
using Microsoft.EntityFrameworkCore.Update.Internal;
using AssetTracking.Data;
using Microsoft.EntityFrameworkCore;
using AssetTracking.Models;

namespace AssetTracking
{
    internal class ProgramController
    {
        private readonly MainMenu Main;
        private readonly ApplicationDBContext dbContext;

        public ProgramController()
        {
            dbContext = new ApplicationDBContext();
            Main = new MainMenu(this);
        }

        public void Start()
        {
            dbContext.Assets.Find(1);  //First query is slow, so make it before the main menu is launched
            RunMainMenu();
        }

        public void RunMainMenu()
        {
            Main.Run();
        }

        public List<Asset> GetAll()
        {
            return dbContext.Assets
                .Include(a => a.Office)
                .OrderBy(a => a.OfficeLocation)
                .ThenBy(a => a.Date)
                .AsNoTracking()
                .ToList();
        }

        public void Add(Asset asset)
        {
            dbContext.Assets.Add(asset);
            dbContext.SaveChanges();
        }

        public void Update(int id, string column)
        {
            //Update field id in table with column column

        }

        public void Remove(Asset asset)
        {
            dbContext.Assets.Remove(asset);
            dbContext.SaveChanges();
        }

    }
}
