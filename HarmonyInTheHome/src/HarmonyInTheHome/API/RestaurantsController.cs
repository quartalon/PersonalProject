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
    public class RestaurantsController : Controller
    {
        private IRestaurantService _restService;

        [HttpGet]
        public List<Restaurant> Get()
        {
            return _restService.ListRestaurants();
        }
        
        [HttpGet("rids")]
        public IActionResult GetRids()
        {
            return Ok(_restService.ListRestIds());
        }

        [HttpGet("{id}")]
        public Restaurant Get(int id)
        {
            return _restService.GetRestaurant(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Restaurant newRest)
        {
            if (newRest == null)
            {
                return BadRequest();

            }
            else if (newRest.Id == 0)
            {
                _restService.AddRestaurant(newRest);
                return Ok();
            }
            else
            {
                _restService.UpdateRestaurant(newRest);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _restService.DeleteRestaurant(id);
            return Ok();
        }

        public RestaurantsController(IRestaurantService restService)
        {
            _restService = restService;
        }
    }
}
