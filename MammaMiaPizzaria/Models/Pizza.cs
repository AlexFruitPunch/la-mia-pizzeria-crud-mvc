using MammaMiaPizzaria.Utils.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MammaMiaPizzaria.Models
{
    [Table("pizza")]
    [Index(nameof(Id), IsUnique = true)]
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome della Pizza è obbligatorio")]
        [StringLength(50, ErrorMessage = "il Nome della Pizza non può avere più di 50 caratteri")]
        public string? Nome { get; set; }

        [Required(ErrorMessage="Gli ingredienti della pizza sono obbligatori")]
        [Column(TypeName = "text")]
        [PiuDiUnaParolaAttributoValidazione]
        public string? Ingredienti { get; set; }

        [Required(ErrorMessage = "l'url dell'immagine è obbligatoria")]
        [Url(ErrorMessage = "L'url inserito non è valido")]
        public string? Immagine { get; set; }

        [Required(ErrorMessage = "Le pizze devono avere un prezzo")]
        [Column(TypeName = "decimal(6, 2)")]
        public double Prezzo { get; set; }

        public Pizza() 
        {
            
        }

        public Pizza(int id, string Nome, string Ingredienti,string immagine, double Prezzo)
        {
            this.Id = id;
            this.Nome = Nome;
            this.Ingredienti = Ingredienti;
            this.Immagine = immagine;
            this.Prezzo = Prezzo;
        }
    }
}
