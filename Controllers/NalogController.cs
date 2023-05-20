using Microsoft.AspNetCore.Mvc;
using Teretana.Models;
using Teretana.Models.EFRepository;

namespace Teretana.Controllers
{
    public class NalogController : Controller
    {
        private AccountRepository _accountRepository = new AccountRepository();
        public IActionResult Index()
        {
            if (Ulogovan.UlogovanRadnik == "" && Ulogovan.UlogovanKlijent == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Ulogovan.UlogovanKlijent != 0)
            {
                ViewBag.UspesnaDodelaClanarine = TempData["UspesnaDodelaClanarine"];
                ViewBag.UspesnaKupovina = TempData["UspesnaKupovina"];
                ViewBag.Clanarina = _accountRepository.VratiNazivClanarine(Ulogovan.UlogovanKlijent);
                return View(_accountRepository.VratiKlijenta(Ulogovan.UlogovanKlijent));
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        [HttpPost]
		public IActionResult Brisanje()
        {
            _accountRepository.ObrisiNalog(Ulogovan.UlogovanKlijent);
            TempData["ObrisanProfil"] = true;
            return RedirectToAction("Index", "Signup");
        }
        public IActionResult Edit()
        {
            if (Ulogovan.UlogovanRadnik == "" && Ulogovan.UlogovanKlijent == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Ulogovan.UlogovanKlijent != 0)
            {
                return View("IzmenaPodataka", _accountRepository.VratiKlijenta(Ulogovan.UlogovanKlijent));
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        [HttpPost]
        public IActionResult IzmenaProfila(KlijentBO podaci)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Greska = 1;
                return View("IzmenaPodataka", podaci);
            }
            else
            {
                string rez = _accountRepository.IzmenaPodataka(podaci);
                if(rez == "GreskaEmail")
                {
                    ViewBag.GreskaEmail = 1;
                    return View("IzmenaPodataka", podaci);
                }
                else
                {
                    ViewBag.UspesnaPromenaProfila = true;
                    ViewBag.Clanarina = _accountRepository.VratiNazivClanarine(Ulogovan.UlogovanKlijent);
                    return View("Index", _accountRepository.VratiKlijenta(Ulogovan.UlogovanKlijent));
                }
            }
        }

    }
}
