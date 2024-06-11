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

        public bool IsOlderThan(int years, int months)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            int diffMonths = today.Year * 12 + today.Month - (this.Date.Year * 12 + this.Date.Month);
            int diffDays = today.Day - this.Date.Day;
            if (diffMonths > years * 12 + months)
            {
                return true;
            }
            else if (diffMonths == years * 12 + months && diffDays >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "      " + Type.PadRight(15) + Brand.PadRight(15) + Model.PadRight(15) + 
                   Date.ToString().PadRight(15) + OfficeLocation.PadRight(15) + Price;
        }

        public string ToStringWithLocalPrice()
        {
            return "      " + Type.PadRight(15) + Brand.PadRight(15) + Model.PadRight(15) +
                   Date.ToString().PadRight(15) + OfficeLocation.PadRight(15) + 
                   Price.ToString().PadRight(15) + Math.Round(Price * Office.ToUSD, 1);
        }
    }
}