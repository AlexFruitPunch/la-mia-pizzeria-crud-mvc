using MammaMiaPizzaria.DataBase;
using MammaMiaPizzaria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MammaMiaPizzaria.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizze = new List<Pizza>();
                return Ok(pizze);
            }
                
        }
    }
}
