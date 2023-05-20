using Microsoft.AspNetCore.Mvc;
using Teretana.Models;
using Teretana.Models.EFRepository;

namespace Teretana.Controllers
{
    public class MagacinController : Controller
    {
        private ProizvodiRepository _proizvodiRepository = new ProizvodiRepository();
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
                return View(_proizvodiRepository.VratiProizvode(""));
            }
            
        }
        [HttpPost]
        public IActionResult Pretraga(string pretraga)
        {
            if (pretraga == null)
                pretraga = "";

            return View("Index", _proizvodiRepository.VratiProizvode(pretraga));
        }
        public IActionResult Unos()
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
                return View();
            }
        }
        public IActionResult Izmeni(string id)
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
                ViewBag.Izmena = 1;

                ProizvodBO proizvod = _proizvodiRepository.VratiProizvod(id);
                ViewBag.ID = proizvod.ProizvodId;

                return View("Unos", proizvod);
            }
        }
        [HttpPost]
        public IActionResult UnozIzmena(ProizvodBO proizvod, string submit)
        {
            switch (submit)
            {
                case "Unesi":
                    if (!ModelState.IsValid)
                    {
                        ViewBag.Greska = 1;
                        ViewBag.ID = proizvod.ProizvodId;
                        return View("Unos", proizvod);
                    }
                    else
                    {
                        string rez = _proizvodiRepository.UnosProizvoda(proizvod);
                        if (rez == "GreskaID")
                        {
                            ViewBag.GreskaID = 1;
                            ViewBag.ID = proizvod.ProizvodId;
                            return View("Unos", proizvod);
                        }
                        return View("Index", _proizvodiRepository.VratiProizvode(""));
                    }

                case "Izmeni":
                    if (!ModelState.IsValid)
                    {
                        ViewBag.Greska = 1;
                        ViewBag.Izmena = 1;
                        ViewBag.ID = proizvod.ProizvodId;
                        return View("Unos", proizvod);
                    }
                    else
                    {
                        _proizvodiRepository.IzmenaProizvoda(proizvod);
                        return View("Index", _proizvodiRepository.VratiProizvode(""));
                    }

                default:
                    return View("Index", _proizvodiRepository.VratiProizvode(""));
            }
        }
        public IActionResult Obrisi(string id)
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
                _proizvodiRepository.ObrisiProizvod(id);

                return View("Index", _proizvodiRepository.VratiProizvode(""));
            }
        }
    }
}
