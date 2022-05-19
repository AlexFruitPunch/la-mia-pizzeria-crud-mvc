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
            Pizza pizzaTrovata = null;

            using (PizzaContext db = new PizzaContext())
            {
                try
                {

                    pizzaTrovata = db.Pizze
                          .Where(Pizza => Pizza.Id == id)
                          .First();

                    return View("DettaglioPizza", pizzaTrovata);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("il post con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
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

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaDaCreare = new Pizza(nuovaPizza.Nome, nuovaPizza.Ingredienti, nuovaPizza.Immagine, nuovaPizza.Prezzo);

                db.Pizze.Add(pizzaDaCreare);
                db.SaveChanges();
            }

                return RedirectToAction("ListinoPizze");
        }

        [HttpGet]
        public IActionResult Aggiorna(int id)
        {
            Pizza pizzaDaModificare = null;

            using (PizzaContext db = new PizzaContext())
            {

                //stesso modo di fare le query rispetto a prima ma usando le query classiche di SQL e non entity Framework
                pizzaDaModificare = (from pizza in db.Pizze
                                     where pizza.Id == id
                                     select pizza).First();
            }

            if (pizzaDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                return View("PizzaDaModificare", pizzaDaModificare);
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

            Pizza pizzaDaModificare = null;

            using (PizzaContext db = new PizzaContext())
            {
                pizzaDaModificare = db.Pizze
                      .Where(Pizza => Pizza.Id == id)
                      .First();

                if (pizzaDaModificare != null)
                {
                    //aggiorniamo i campi con i nuovi valori
                    pizzaDaModificare.Nome = modello.Nome;
                    pizzaDaModificare.Ingredienti = modello.Ingredienti;
                    pizzaDaModificare.Immagine = modello.Immagine;
                    pizzaDaModificare.Prezzo = modello.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("ListinoPizze");
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public IActionResult Cancella(int id)
        {
            Pizza? pizzaDaCancellare = null;

            using (PizzaContext db = new PizzaContext())
            {
                pizzaDaCancellare = db.Pizze
                      .Where(Pizza => Pizza.Id == id)
                      .FirstOrDefault();
                if (pizzaDaCancellare != null)
                {
                    db.Pizze.Remove(pizzaDaCancellare);
                    db.SaveChanges();

                    return RedirectToAction("ListinoPizze");
                }
                else
                {
                    return NotFound();
                }
            }
        }

        //ricordsi di fare un metodo di utilità per ricercare pizze nel database per non ripetere codice
    }
}
