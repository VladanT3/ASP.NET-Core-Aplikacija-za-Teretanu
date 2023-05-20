using Microsoft.AspNetCore.Mvc;
using Teretana.Models;
using Teretana.Models.EFRepository;

namespace Teretana.Controllers
{
	public class LoginController : Controller
	{
		private AccountRepository _accountRepository = new AccountRepository();
		public IActionResult Index()
		{
			Ulogovan.UlogovanRadnik = "";
			Ulogovan.UlogovanKlijent = 0;

			NarucivanjeController.stavke.Clear();
			OcitavanjeController.klijenti.Clear();
			ProdavnicaController.korpa.Clear();

			return View();
		}
		[HttpPost]
        public IActionResult Ulogovanje(string inputEmail, string inputSifra)
        {
            string logovanje  = _accountRepository.Ulogovanje(inputEmail, inputSifra);
			if(logovanje == "radnik")
			{
                return RedirectToAction("Index", "Admin");
            }
			else if(logovanje == "klijent")
			{
                return RedirectToAction("Index", "Nalog");
            }
			ViewBag.Greska = 1;
			ViewBag.Email = inputEmail;
			ViewBag.Sifra = inputSifra;
			return View("Index");
        }
    }
}
