using Microsoft.AspNetCore.Mvc;
using Teretana.Models.EFRepository;
using Teretana.Models;

namespace Teretana.Controllers
{
	public class AdminController : Controller
	{
		private AccountRepository _accountRepository = new AccountRepository();
		public IActionResult Index()
		{
			if(Ulogovan.UlogovanRadnik == "" && Ulogovan.UlogovanKlijent == 0)
			{
				return RedirectToAction("Index", "Login");
			}
			else if(Ulogovan.UlogovanKlijent != 0)
			{
				return RedirectToAction("Index", "Nalog");
			}
			else
			{
				return View(_accountRepository.VratiRadnika(Ulogovan.UlogovanRadnik));
			}
		}
	}
}
