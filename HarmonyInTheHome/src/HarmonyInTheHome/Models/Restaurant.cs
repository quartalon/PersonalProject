using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonyInTheHome.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Phone { get; set; }
        public bool DineIn { get; set; }
        public bool TakeAway { get; set; }
        public bool Delivery { get; set; }
        public string PriceRange { get; set; }
        public string Reviews { get; set; }
        public string MapUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
