using System.Collections.Generic;
using HarmonyInTheHome.Models;

namespace HarmonyInTheHome.Interfaces
{
    public interface ICategoryService
    {
        void AddCategory(Category cat);
        void DeleteCategory(int id);
        Category GetCategory(int id);
        Category GetCategoryWithoutRests(int id);
        List<Category> ListCategories();
        void UpdateCategory(Category cat);
    }
}