using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonyInTheHome.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Cuisine {get; set;}
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
