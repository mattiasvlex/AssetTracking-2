using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    internal class Office
    {
        [Key]
        public string? Location { get; set; }
        public string? Currency { get; set; }
        public double ToUSD { get; set; }
        public ICollection<Asset>? Assets { get; set; }
    }
}
