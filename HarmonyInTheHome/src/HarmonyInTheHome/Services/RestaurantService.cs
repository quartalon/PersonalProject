using HarmonyInTheHome.Interfaces;
using HarmonyInTheHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonyInTheHome.Services
{
    public class RestaurantService :IRestaurantService
    {
        private IGenericRepository _repo;
        private ICategoryService _cService;

        public List<Restaurant> ListRestaurants()
        {
            List<Restaurant> rests = (from r in _repo.Query<Restaurant>()
                                      select new Restaurant
                                      {
                                          Id = r.Id,
                                          Name = r.Name,
                                          Owner = r.Owner,
                                          StreetAddress = r.StreetAddress,
                                          City = r.City,
                                          State = r.State,
                                          Zip = r.Zip,
                                          Phone = r.Phone,
                                          DineIn = r.DineIn,
                                          TakeAway = r.TakeAway,
                                          Delivery = r.Delivery,
                                          PriceRange = r.PriceRange,
                                          Reviews = r.Reviews,
                                          MapUrl = r.MapUrl,
                                          WebsiteUrl = r.WebsiteUrl,
                                          ImageUrl = r.ImageUrl,
                                          Category = r.Category
                                      }).ToList();
            return rests;
        }
        public object ListRestIds()
        {
            List<Restaurant> restIds = (from r in _repo.Query<Restaurant>()
                                        select new Restaurant
                                        {
                                            Id = r.Id,
                                            Name = r.Name,
                                            Owner = r.Owner,
                                            StreetAddress = r.StreetAddress,
                                            City = r.City,
                                            State = r.State,
                                            Zip = r.Zip,
                                            Phone = r.Phone,
                                            DineIn = r.DineIn,
                                            TakeAway = r.TakeAway,
                                            Delivery = r.Delivery,
                                            PriceRange = r.PriceRange,
                                            Reviews = r.Reviews,
                                            MapUrl = r.MapUrl,
                                            WebsiteUrl = r.WebsiteUrl,
                                            ImageUrl = r.ImageUrl,
                                            Category = r.Category
                                        }).ToList();

            var rand = new Random();
            var i = rand.Next(0, restIds.Count);
            return restIds[i];
        }

        public Restaurant GetRestaurant(int id)
        {
            Restaurant rest = (from r in _repo.Query<Restaurant>()
                               where r.Id == id
                               select new Restaurant
                               {
                                   Id = r.Id,
                                   Name = r.Name,
                                   Owner = r.Owner,
                                   StreetAddress = r.StreetAddress,
                                   City = r.City,
                                   State = r.State,
                                   Zip = r.Zip,
                                   Phone = r.Phone,
                                   DineIn = r.DineIn,
                                   TakeAway = r.TakeAway,
                                   Delivery = r.Delivery,
                                   PriceRange = r.PriceRange,
                                   Reviews = r.Reviews,
                                   MapUrl = r.MapUrl,
                                   WebsiteUrl = r.WebsiteUrl,
                                   ImageUrl = r.ImageUrl,
                                   Category = r.Category
                               }).FirstOrDefault();
            return rest;
        }
        public void AddRestaurant(Restaurant rest)
        {
            Category cat = _cService.GetCategoryWithoutRests(rest.Category.Id);
            rest.Category = cat;
            _repo.Add(rest);
        }
        public void UpdateRestaurant(Restaurant rest)
        {
            Category cat = _cService.GetCategoryWithoutRests(rest.Category.Id);
            rest.Category = cat;
            _repo.Update(rest);
        }
        public void DeleteRestaurant(int id)
        {
            Restaurant restToDelete = GetRestaurant(id);
            _repo.Delete(restToDelete);
        }
        public RestaurantService(IGenericRepository repo, ICategoryService cService)
        {
            _repo = repo;
            _cService = cService;
        }

    }
}
