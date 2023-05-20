using Microsoft.AspNetCore.Mvc;
using Teretana.Models;
using Teretana.Models.EFRepository;

namespace Teretana.Controllers
{
    public class SignupController : Controller
    {
        private AccountRepository _accountRepository = new AccountRepository();
        public IActionResult Index()
        {
            Ulogovan.UlogovanRadnik = "";
            Ulogovan.UlogovanKlijent = 0;

            NarucivanjeController.stavke.Clear();
            OcitavanjeController.klijenti.Clear();
            ProdavnicaController.korpa.Clear();

            ViewBag.ObrisanProfil = TempData["ObrisanProfil"];
            return View();
        }
        [HttpPost]
        public IActionResult PravljenjeNaloga(KlijentBO klijent)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Greska = 1;
                return View("Index", klijent);
            }
            else
            {
                if(_accountRepository.NapraviNalog(klijent) == "")
                    return RedirectToAction("Index", "Nalog");
                else if (_accountRepository.NapraviNalog(klijent) == "greskaEmail")
                {
                    ViewBag.GreskaEmail = 1;
                    return View("Index", klijent);
                }

                return View("Index", klijent);
            }
        }
    }
}
