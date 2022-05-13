using MammaMiaPizzaria.Models;
using MammaMiaPizzaria.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MammaMiaPizzaria.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]                                                           //dichiariamo che questo metodo vuole fare una GET                                   
        public IActionResult ListinoPizze()
        {
            List<Pizza> Pizze = PizzaData.GetPizze();
            return View("ListinoPizze", Pizze);
        }

        [HttpGet]
        public IActionResult DettaglioPizza(int id)
        {
            Pizza pizzaTrovata = null;

            foreach (Pizza Pizza in PizzaData.GetPizze())
            {
                if (Pizza.id == id)
                {
                    pizzaTrovata = Pizza;
                    break;
                }
            }

            if (pizzaTrovata != null)
            {
                return View("DettaglioPizza", pizzaTrovata);
            }
            else
            {
                return NotFound("il post con id" + id + "non è stato trovato");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("FormPizza");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza nuovaPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPizza", nuovaPizza);
            }

            Pizza nuovaPizzaConId = new Pizza(PizzaData.GetPizze().Count, nuovaPizza.Nome, nuovaPizza.Ingredienti, nuovaPizza.immagine, nuovaPizza.Prezzo);

            PizzaData.GetPizze().Add(nuovaPizzaConId);

            return RedirectToAction("ListinoPizze");
        }
    }
}
