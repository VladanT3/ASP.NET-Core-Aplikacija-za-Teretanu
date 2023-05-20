using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Teretana.Models
{
	public class KlijentBO
	{
		public int? KlijentId { get; set; }

		[Required(ErrorMessage = "Morate uneti vaše ime!")]
		public string Ime { get; set; }

        [Required(ErrorMessage = "Morate uneti vaše prezime!")]
        public string Prezime { get; set; }

        [EmailAddress]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Morate uneti vaš e-mail!")]
        public string Email { get; set; }

        [Display(Name = "Šifra")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Morate uneti šifru!")]
        public string Sifra { get; set; }

        [Display(Name = "Datum Rodjenja")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DatumRodjenja { get; set; }

        [Required(ErrorMessage = "Morate uneti vašu adresu!")]
        public string Adresa { get; set; }

        [Display(Name = "Broj Telefona")]
        [Required(ErrorMessage = "Morate uneti vaš broj telefona!")]
        public string BrojTelefona { get; set; }

		public string? ClanarinaId { get; set; }

        [Display(Name = "Datum Početka:")]
        [DataType(DataType.Date)]
        public DateTime DatumPocetkaClanarine { get; set; }

        [Display(Name = "Datum Isteka:")]
        [DataType(DataType.Date)]
        public DateTime DatumIstekaClanarine { get; set; }

        [Display(Name = "Broj Termina:")]
        public int? BrojTermina { get; set; }

        [Display(Name = "Ime i Prezime")]
        public string? ImePrezime { get { return Ime + " " + Prezime; } }
	}
}
