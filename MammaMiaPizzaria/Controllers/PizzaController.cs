using MammaMiaPizzaria.DataBase;
using MammaMiaPizzaria.Models;
using MammaMiaPizzaria.Utils;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MammaMiaPizzaria.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]                                                                                            
        public IActionResult ListinoPizze()
        {

            List<Pizza> Pizze = new List<Pizza>();

            using (PizzaContext db = new PizzaContext())
            {
                Pizze = db.Pizze.ToList<Pizza>();
            }

            return View("ListinoPizze", Pizze);
        }

        [HttpGet]
        public IActionResult DettaglioPizza(int id)
        {
            Pizza pizzaTrovata = GetPizzaByid(id);

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
            return View("CreatePizza");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza nuovaPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatePizza", nuovaPizza);
            }

            Pizza nuovaPizzaConId = new Pizza(PizzaData.GetPizze().Count, nuovaPizza.Nome, nuovaPizza.Ingredienti, nuovaPizza.Immagine, nuovaPizza.Prezzo);

            //il mio modello è corretto
            PizzaData.GetPizze().Add(nuovaPizzaConId);

            return RedirectToAction("ListinoPizze");
        }

        [HttpGet]
        public IActionResult Aggiorna(int id)
        {
            Pizza pizzaDaModificare = GetPizzaByid(id);
            if (pizzaDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                return View("PizzaDaModificare",pizzaDaModificare);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aggiorna(int id, Pizza modello)
        {
            if (!ModelState.IsValid)
            {
                return View("Aggiorna", modello);
            }

            Pizza pizzaDaModificare = GetPizzaByid(id);

            if (pizzaDaModificare != null)
            {
                //aggiorniamo i campi con i nuovi valori
                pizzaDaModificare.Nome = modello.Nome;
                pizzaDaModificare.Ingredienti = modello.Ingredienti;
                pizzaDaModificare.Immagine = modello.Immagine;
                pizzaDaModificare.Prezzo = modello.Prezzo;

                return RedirectToAction("ListinoPizze");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Cancella(int id)
        {
            int indicePizzaDaCancellare = -1;

            List<Pizza> pizzaList = PizzaData.GetPizze();

            for (int i = 0; i < pizzaList.Count; i++)
            {
                if (pizzaList[i].Id == id)
                {
                    indicePizzaDaCancellare = i;
                }
            }

            if(indicePizzaDaCancellare >= 0)
            {
                PizzaData.GetPizze().RemoveAt(indicePizzaDaCancellare);
                return RedirectToAction("ListinoPizze");
            }
            else
            {
                return NotFound();
            }
        }

        private Pizza GetPizzaByid(int id)
        {
            Pizza pizzaTrovata = null;

            foreach (Pizza Pizza in PizzaData.GetPizze())
            {
                if (Pizza.Id == id)
                {
                    pizzaTrovata = Pizza;
                    break;
                }
            }
            return pizzaTrovata;
        }
    }
}
