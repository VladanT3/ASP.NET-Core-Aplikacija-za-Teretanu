using Microsoft.AspNetCore.Mvc;
using Teretana.Models;
using Teretana.Models.EFRepository;

namespace Teretana.Controllers
{
    public class ClanarinaController : Controller
    {
        private ClanarinaRepository _clanarinaRepository = new ClanarinaRepository();
        public IActionResult Index()
        {
            if (Ulogovan.UlogovanRadnik == "" && Ulogovan.UlogovanKlijent == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (Ulogovan.UlogovanKlijent != 0)
            {
                return View(_clanarinaRepository.VratiClanarine());
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
            
        }
        [HttpPost]
        public IActionResult IzborClanarine(ClanarinaBO clanarina)
        {
            _clanarinaRepository.DodeliClanarinu(Ulogovan.UlogovanKlijent, clanarina.ClanarinaId, clanarina.BrojTermina);

            TempData["UspesnaDodelaClanarine"] = true;
            return RedirectToAction("Index", "Nalog");
        }
    }
}
