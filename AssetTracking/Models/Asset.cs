using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    internal class Asset
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public DateOnly Date { get; set; }

        private int _price;

        public int Price
        {
            get => _price;

            set
            {
                if (value < 0)
                {
                    _price = 0;
                }
                else
                {
                    _price = value;
                }
            }
        }
        public Office? Office { get; set; }
        public string? OfficeLocation { get; set; }
    }
}