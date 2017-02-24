using System.Collections.Generic;
using HarmonyInTheHome.Models;

namespace HarmonyInTheHome.Interfaces
{
    public interface IRestaurantService
    {
        void AddRestaurant(Restaurant rest);
        void DeleteRestaurant(int id);
        Restaurant GetRestaurant(int id);
        List<Restaurant> ListRestaurants();
        object ListRestIds();
        void UpdateRestaurant(Restaurant rest);
    }
}