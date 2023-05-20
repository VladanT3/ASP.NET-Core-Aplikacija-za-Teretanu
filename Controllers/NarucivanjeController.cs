using Microsoft.AspNetCore.Mvc;
using Teretana.Models;
using Teretana.Models.EFRepository;

namespace Teretana.Controllers
{
    public class NarucivanjeController : Controller
    {
        ProizvodiRepository _proizvodiRepository = new ProizvodiRepository();
        NarucivanjeRepository _narucivanjeRepository = new NarucivanjeRepository();

        private static StavkaPorudzbeniceBO stavka = new StavkaPorudzbeniceBO();
        public static List<StavkaPorudzbeniceBO> stavke = new List<StavkaPorudzbeniceBO>();
        private static double ukupnaCena = 0;
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
                ViewBag.BrojStavki = stavke.Count;
                ViewBag.Dobavljaci = _narucivanjeRepository.VratiDobavljace();
                ViewBag.UkupnaCena = ukupnaCena;
                ViewBag.Stavke = stavke;
                return View(_proizvodiRepository.VratiProizvode(""));
            }
        }
        public IActionResult IzborProizvoda(string id)
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
                stavka = _narucivanjeRepository.PrebaciProizvodUStavku(id);
                ViewBag.IzabranProizvod = true;

                ViewBag.BrojStavki = stavke.Count;
                ViewBag.Dobavljaci = _narucivanjeRepository.VratiDobavljace();
                ViewBag.UkupnaCena = ukupnaCena;
                ViewBag.Stavke = stavke;
                return View("Index", _proizvodiRepository.VratiProizvode(""));
            }
        }
        [HttpPost]
        public IActionResult DodajStavku(int kolicina)
        {
            stavka.Kolicina = kolicina;
            stavke = _narucivanjeRepository.AzurirajStavke(stavke, stavka);
            ukupnaCena = _narucivanjeRepository.VratiUkupnuCenu(stavke);

            ViewBag.BrojStavki = stavke.Count;
            ViewBag.Dobavljaci = _narucivanjeRepository.VratiDobavljace();
            ViewBag.UkupnaCena = ukupnaCena;
            ViewBag.Stavke = stavke;
            return View("Index", _proizvodiRepository.VratiProizvode(""));
        }
        public IActionResult ObrisiStavku(string id)
        {
            stavke = _narucivanjeRepository.BrisanjeStavke(stavke, id);
            ukupnaCena = _narucivanjeRepository.VratiUkupnuCenu(stavke);

            ViewBag.BrojStavki = stavke.Count;
            ViewBag.Dobavljaci = _narucivanjeRepository.VratiDobavljace();
            ViewBag.UkupnaCena = ukupnaCena;
            ViewBag.Stavke = stavke;
            return View("Index", _proizvodiRepository.VratiProizvode(""));
        }
        [HttpPost]
        public IActionResult ObrisiNarudzbenicu()
        {
            stavke.Clear();
            ukupnaCena = 0;

            ViewBag.BrojStavki = stavke.Count;
            ViewBag.Dobavljaci = _narucivanjeRepository.VratiDobavljace();
            ViewBag.UkupnaCena = ukupnaCena;
            ViewBag.Stavke = stavke;
            return View("Index", _proizvodiRepository.VratiProizvode(""));
        }
        [HttpPost]
        public IActionResult Naruci(string dobavljac)
        {
            if (dobavljac == "0")
            {
                ViewBag.GreskaDobavljac = 1;

                ViewBag.BrojStavki = stavke.Count;
                ViewBag.Dobavljaci = _narucivanjeRepository.VratiDobavljace();
                ViewBag.UkupnaCena = ukupnaCena;
                ViewBag.Stavke = stavke;
                return View("Index", _proizvodiRepository.VratiProizvode(""));
            }
            else
            {
                _narucivanjeRepository.NapraviPorudzbenicu(stavke, ukupnaCena, dobavljac);
                stavke.Clear();
                ukupnaCena = 0;

                return RedirectToAction("Index", "Magacin");
            }
        }
    }
}
