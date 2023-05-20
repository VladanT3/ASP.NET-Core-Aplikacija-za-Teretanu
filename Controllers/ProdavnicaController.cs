using Microsoft.AspNetCore.Mvc;
using Teretana.Models;
using Teretana.Models.EFRepository;

namespace Teretana.Controllers
{
    public class ProdavnicaController : Controller
    {
        private ProizvodiRepository _proizvodiRepository = new ProizvodiRepository();
        private ProdavnicaRepository _prodavnicaRepository = new ProdavnicaRepository();
        private AccountRepository _accountRepository = new AccountRepository();
        
        public static List<StavkaRacunaBO> korpa = new List<StavkaRacunaBO>();
        public IActionResult Index()
        {
            if (Ulogovan.UlogovanRadnik == "" && Ulogovan.UlogovanKlijent == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Ulogovan.UlogovanKlijent != 0)
            {
                ViewBag.Stavke = korpa;
                ViewBag.BrojStavki = korpa.Count;
                ViewBag.UkupnaCena = _prodavnicaRepository.VratiUkupnuCenu(korpa);
                return View(_proizvodiRepository.VratiProizvode(""));
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
            
        }
        [HttpPost]
        public IActionResult DodajUKorpu(IFormCollection collection)
        {
            string idProizvoda = collection["idProizvoda"];
            int kolicina = int.Parse(collection[idProizvoda]);

            StavkaRacunaBO stavka = _prodavnicaRepository.PrebaciProizvodUStavku(idProizvoda, kolicina);
            korpa = _prodavnicaRepository.AzurirajKorpu(korpa, stavka);

            ViewBag.Stavke = korpa;
            ViewBag.BrojStavki = korpa.Count;
            ViewBag.UkupnaCena = _prodavnicaRepository.VratiUkupnuCenu(korpa);
            return View("Index", _proizvodiRepository.VratiProizvode(""));
        }
        public IActionResult SmanjiKolicinu(string id)
        {
            if (Ulogovan.UlogovanRadnik == "" && Ulogovan.UlogovanKlijent == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Ulogovan.UlogovanKlijent != 0)
            {
                korpa = _prodavnicaRepository.AzurirajKolicinu(korpa, _proizvodiRepository.VratiProizvod(id));

                ViewBag.Stavke = korpa;
                ViewBag.BrojStavki = korpa.Count;
                ViewBag.UkupnaCena = _prodavnicaRepository.VratiUkupnuCenu(korpa);
                return View("Index", _proizvodiRepository.VratiProizvode(""));
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        public IActionResult IzbaciArtikal(string id)
        {
            if (Ulogovan.UlogovanRadnik == "" && Ulogovan.UlogovanKlijent == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Ulogovan.UlogovanKlijent != 0)
            {
                korpa = _prodavnicaRepository.ObrisiProizvod(korpa, id);

                ViewBag.Stavke = korpa;
                ViewBag.BrojStavki = korpa.Count;
                ViewBag.UkupnaCena = _prodavnicaRepository.VratiUkupnuCenu(korpa);
                return View("Index", _proizvodiRepository.VratiProizvode(""));
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        public IActionResult Kupovanje()
        {
            if (Ulogovan.UlogovanRadnik == "" && Ulogovan.UlogovanKlijent == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Ulogovan.UlogovanKlijent != 0)
            {
                ViewBag.Stavke = korpa;
                ViewBag.UkupnaCena = _prodavnicaRepository.VratiUkupnuCenu(korpa);
                return View("Checkout", _accountRepository.VratiKlijenta(Ulogovan.UlogovanKlijent));
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        [HttpPost]
        public IActionResult Placanje()
        {
            _prodavnicaRepository.NapraviRacun(korpa, _prodavnicaRepository.VratiUkupnuCenu(korpa));
            korpa.Clear();

            TempData["UspesnaKupovina"] = true;
            return RedirectToAction("Index", "Nalog");
        }
    }
}
