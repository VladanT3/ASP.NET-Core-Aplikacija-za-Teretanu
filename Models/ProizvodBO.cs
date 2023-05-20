using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Teretana.Models
{
	public class ProizvodBO
	{
		[Display(Name = "ID")]
        [Required(ErrorMessage = "Morate uneti ID proizvoda!")]
        public string ProizvodId { get; set; }

        [Display(Name = "Naziv Proizvoda")]
        [Required(ErrorMessage = "Morate uneti naziv proizvoda!")]
        public string NazivProizvoda { get; set; }

        public int Kolicina { get; set; }

        [Display(Name = "Nabavna Cena")]
        [Required]
        public double NabavnaCena { get; set; }

        [Display(Name = "Prodajna Cena")]
        [Required]
        public double ProdajnaCena { get; set; }

        [Display(Name = "Naziv slike sa ekstenzijom")]
        public string? Slika { get; set; }

    }
}
