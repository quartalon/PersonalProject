using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HarmonyInTheHome.Data;
using HarmonyInTheHome.Models;
using HarmonyInTheHome.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HarmonyInTheHome.API
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ICategoryService _catService;

        [HttpGet]

        public List<Category> Get()
        {
            return _catService.ListCategories();
        }


        [HttpGet("{id}")]

        public Category Get(int id)
        {
            return _catService.GetCategory(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Category cat)
        {
            if (cat == null)
            {
                return BadRequest();

            }
            else if (cat.Id == 0)
            {
                _catService.AddCategory(cat);
                return Ok();
            }
            else
            {
                _catService.UpdateCategory(cat);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _catService.DeleteCategory(id);
            return Ok();
        }

        public CategoriesController(ICategoryService catService)
        {
            _catService = catService;
        }
    }
}
