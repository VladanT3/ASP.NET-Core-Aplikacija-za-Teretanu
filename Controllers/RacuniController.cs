using Microsoft.AspNetCore.Mvc;
using Teretana.Models;
using Teretana.Models.EFRepository;

namespace Teretana.Controllers
{
    public class RacuniController : Controller
    {
        private RacunRepository _racunRepository = new RacunRepository();
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
                return View(_racunRepository.VratiNeuknjizeneRacune());
            }
        }
        public IActionResult DetaljiRacuna(int id)
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
                ViewBag.PrikaziStavke = 1;
                ViewBag.Stavke = _racunRepository.VratiStavkeRacuna(id);

			    return View("Index", _racunRepository.VratiNeuknjizeneRacune());
            }
        }
        [HttpPost]
        public IActionResult Uknjizi(int[] uknjizen)
        {
            _racunRepository.UknjiziRacune(uknjizen);
            return View("Index", _racunRepository.VratiNeuknjizeneRacune());
        }
    }
}
