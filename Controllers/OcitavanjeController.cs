using Microsoft.AspNetCore.Mvc;
using Teretana.Models;
using Teretana.Models.EFRepository;

namespace Teretana.Controllers
{
    public class OcitavanjeController : Controller
    {
        private AccountRepository _accountRepository = new AccountRepository();
        public static List<KlijentBO> klijenti = new List<KlijentBO>();
        public IActionResult Index()
        {
            if (Ulogovan.UlogovanRadnik == "" && Ulogovan.UlogovanKlijent == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Ulogovan.UlogovanKlijent != 0)
            {
                return RedirectToAction("Index", "Nalog");
            }
            else
            {
                return View(klijenti);
            }
        }
        [HttpPost]
        public IActionResult DodajKlijenta(int id)
        {
            KlijentBO klijent = _accountRepository.VratiKlijenta(id);
            if (klijent == null)
            {
                ViewBag.GreskaKlijent = 1;
                return View("Index", klijenti);
            }
            if (klijent.ClanarinaId == "N0")
            {
                ViewBag.GreskaClanarina = 1;
                return View("Index", klijenti);
            }
            klijenti = _accountRepository.OcitavanjeKlijenta(klijenti, klijent);
            return View("Index", klijenti);
        }
        public IActionResult DetaljiClanarine(int id)
        {
            if (Ulogovan.UlogovanRadnik == "" && Ulogovan.UlogovanKlijent == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Ulogovan.UlogovanKlijent != 0)
            {
                return RedirectToAction("Index", "Nalog");
            }
            else
            {
                KlijentBO klijent = _accountRepository.VratiKlijenta(id);

                ViewBag.Naziv = _accountRepository.VratiNazivClanarine(id);
                ViewBag.DatumPocetka = klijent.DatumPocetkaClanarine.ToShortDateString();
                ViewBag.DatumIsteka = klijent.DatumIstekaClanarine.ToShortDateString();
                ViewBag.BrojTermina = klijent.BrojTermina;

                return View("Index", klijenti);
            }
        }
        public IActionResult BrisanjeListe()
        {
            klijenti.Clear();

            return RedirectToAction("Index", "Admin");
        }

    }
}
