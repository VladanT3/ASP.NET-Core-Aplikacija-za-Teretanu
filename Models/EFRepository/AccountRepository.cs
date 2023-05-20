using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Reflection.Metadata.Ecma335;
using Teretana.Models.Interfaces;

namespace Teretana.Models.EFRepository
{
	public class AccountRepository : IAccountRepository
	{
		private TeretanaContext teretana = new TeretanaContext();
		
		public string Ulogovanje(string email, string sifra)
		{
			int proveraRadnik = teretana.Radniks.Count(r => r.Email == email && r.Sifra == sifra);
			int proveraKlijent = teretana.Klijents.Count(k => k.Email == email && k.Sifra == sifra);

			if(proveraRadnik == 1)
			{
				Radnik radnik = teretana.Radniks.Where(r => r.Email == email && r.Sifra == sifra).Single();
				Ulogovan.UlogovanRadnik = radnik.RadnikId;

				return "radnik";
			}
			else if(proveraKlijent == 1)
			{
				Klijent klijent = teretana.Klijents.Where(k => k.Email == email && k.Sifra == sifra).Single();
				if (klijent.KlijentId == 1)
					return "";
				Ulogovan.UlogovanKlijent = klijent.KlijentId;

				return "klijent";
			}
			else
			{
				return "";
			}
		}

        public string NapraviNalog(KlijentBO klijent)
        {
			int proveraEmail = teretana.Klijents.Count(k => k.Email == klijent.Email) + teretana.Radniks.Count(r => r.Email == klijent.Email);
			if(proveraEmail > 0)
			{
				return "greskaEmail";
			}

			Klijent noviKlijent = new Klijent()
			{
				Ime = klijent.Ime,
				Prezime = klijent.Prezime,
				Adresa = klijent.Adresa,
				BrojTelefona = klijent.BrojTelefona,
				Email = klijent.Email,
				Sifra = klijent.Sifra,
				DatumRodjenja = klijent.DatumRodjenja,
				ClanarinaId = "N0",
				BrojTermina = 0,
				DatumPocetkaClanarine = DateTime.Now,
				DatumIstekaClanarine = DateTime.Now
			};
			teretana.Klijents.Add(noviKlijent);
			teretana.SaveChanges();

			int poslednjiKlijent = teretana.Klijents.Max(k => k.KlijentId);
			Ulogovan.UlogovanKlijent = poslednjiKlijent;

			return "";
        }

        public void ObrisiNalog(int id)
        {
			Klijent klijent = teretana.Klijents.Where(k => k.KlijentId == id).Single();

			foreach(Racun racun in teretana.Racuns.Where(r => r.KlijentId == id))
				racun.KlijentId = 1;
			teretana.SaveChanges();

			teretana.Klijents.Remove(klijent);
			teretana.SaveChanges();
        }

        public KlijentBO VratiKlijenta(int id)
        {
			try
			{
                Klijent klijent = teretana.Klijents.Where(k => k.KlijentId == id).Single();
				if(klijent.KlijentId == 1)
				{
					return null;
				}
                KlijentBO klijentBO = new KlijentBO()
                {
                    KlijentId = klijent.KlijentId,
                    Ime = klijent.Ime,
                    Prezime = klijent.Prezime,
                    Email = klijent.Email,
                    Adresa = klijent.Adresa,
                    BrojTelefona = klijent.BrojTelefona,
                    DatumRodjenja = klijent.DatumRodjenja,
					ClanarinaId = klijent.ClanarinaId,
                    DatumPocetkaClanarine = klijent.DatumPocetkaClanarine,
                    DatumIstekaClanarine = klijent.DatumIstekaClanarine,
                    BrojTermina = klijent.BrojTermina
                };
                return klijentBO;
            }
			catch (Exception)
			{
				return null;
			}
        }

		public RadnikBO VratiRadnika(string id)
		{
			Radnik radnik = teretana.Radniks.Where(r => r.RadnikId == id).Single();
			RadnikBO radnikBO = new RadnikBO()
			{
				Ime = radnik.Ime,
				Prezime = radnik.Prezime,
				Email = radnik.Email,
				Adresa = radnik.Adresa,
				BrojTelefona = radnik.BrojTelefona,
				DatumRodjenja = radnik.DatumRodjenja
			};
			return radnikBO;
		}

		public string VratiNazivClanarine(int klijentID)
		{
			Klijent klijent = teretana.Klijents.Where(k => k.KlijentId == klijentID).Single();
			Clanarina clanarina = teretana.Clanarinas.Where(c => c.ClanarinaId == klijent.ClanarinaId).Single();

			return clanarina.NazivClanarine;
		}

		public string IzmenaPodataka(KlijentBO noviPodaci)
		{
			Klijent klijent = teretana.Klijents.Where(k => k.KlijentId == Ulogovan.UlogovanKlijent).Single();

			if(klijent.Email == noviPodaci.Email)
			{
                klijent.Ime = noviPodaci.Ime;
                klijent.Prezime = noviPodaci.Prezime;
                klijent.Sifra = noviPodaci.Sifra;
                klijent.Adresa = noviPodaci.Adresa;
                klijent.BrojTelefona = noviPodaci.BrojTelefona;
            }
			else
			{
                int proveraEmail = teretana.Klijents.Count(k => k.Email == noviPodaci.Email);
				if(proveraEmail > 0)
				{
					return "GreskaEmail";
				}
				else
				{
                    klijent.Ime = noviPodaci.Ime;
                    klijent.Prezime = noviPodaci.Prezime;
					klijent.Email = noviPodaci.Email;
                    klijent.Sifra = noviPodaci.Sifra;
                    klijent.Adresa = noviPodaci.Adresa;
                    klijent.BrojTelefona = noviPodaci.BrojTelefona;
                }
            }
			teretana.SaveChanges();

			return "";
		}

		public List<KlijentBO> OcitavanjeKlijenta(List<KlijentBO> klijenti, KlijentBO noviKlijent)
		{
			Klijent klijent = teretana.Klijents.Where(k => k.KlijentId == noviKlijent.KlijentId).Single();
			klijent.BrojTermina--;
			if(klijent.BrojTermina == 0)
			{
				klijent.ClanarinaId = "N0";
				klijent.DatumPocetkaClanarine = DateTime.Now;
				klijent.DatumIstekaClanarine = DateTime.Now;
			}
			teretana.SaveChanges();

			klijenti.Add(noviKlijent);
			return klijenti;
		}
    }
}
