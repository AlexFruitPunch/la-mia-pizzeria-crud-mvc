using MammaMiaPizzaria.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace MammaMiaPizzaria.Models
{
    public class Pizza
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Il nome della Pizza è obbligatorio")]
        [StringLength(30, ErrorMessage = "il Nome della Pizza non può avere più di 30 caratteri")]
        public string? Nome { get; set; }

        [Required(ErrorMessage="Gli ingredienti della pizza sono obbligatori")]
        [PiuDiUnaParolaAttributoValidazione]
        public string? Ingredienti { get; set; }
        public string? immagine { get; set; }
        public double Prezzo { get; set; }

        public Pizza() 
        {
            
        }

        public Pizza(int id, string Nome, string Ingredienti,string immagine, double Prezzo)
        {
            this.id = id;
            this.Nome = Nome;
            this.Ingredienti = Ingredienti;
            this.immagine = immagine;
            this.Prezzo = Prezzo;
        }
    }
}
