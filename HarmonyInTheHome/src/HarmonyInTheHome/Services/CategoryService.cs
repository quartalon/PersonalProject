using HarmonyInTheHome.Interfaces;
using HarmonyInTheHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonyInTheHome.Services
{
    public class CategoryService :ICategoryService
    {
        private IGenericRepository _repo;

        public List<Category> ListCategories()
        {
            List<Category> cats = (from c in _repo.Query<Category>()
                                   select new Category
                                   {
                                       Id = c.Id,
                                       Cuisine = c.Cuisine,
                                       Restaurants = c.Restaurants
                                   }).ToList();
            return cats;
        }
        public Category GetCategory(int id)
        {
            Category cat = (from c in _repo.Query<Category>()
                            where c.Id == id
                            select new Category
                            {
                                Id = c.Id,
                                Cuisine = c.Cuisine,
                                Restaurants = c.Restaurants
                            }).FirstOrDefault();
            return cat;
        }
        public Category GetCategoryWithoutRests(int id)
        {
            Category cat = (from c in _repo.Query<Category>() where c.Id == id select c).FirstOrDefault();

            return cat;
        }

        public void AddCategory(Category cat)
        {
            _repo.Add(cat);
        }
        public void UpdateCategory(Category cat)
        {
            _repo.Update(cat);
        }
        public void DeleteCategory(int id)
        {
            Category catToDelete = GetCategory(id);
            _repo.Delete(catToDelete);
        }
        public CategoryService(IGenericRepository repo)
        {
            _repo = repo;
        }
    }
}
