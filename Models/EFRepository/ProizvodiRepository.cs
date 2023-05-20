using Teretana.Models.Interfaces;

namespace Teretana.Models.EFRepository
{
    public class ProizvodiRepository : IProizvodiRepository
    {
        public TeretanaContext teretana = new TeretanaContext();
        public List<ProizvodBO> VratiProizvode(string naziv)
        {
            List<ProizvodBO> proizvodi = new List<ProizvodBO>();
            foreach(Proizvod proizvod in teretana.Proizvods.Where(p => p.NazivProizvoda.Contains(naziv)))
            {
                if(proizvod.ProizvodId != "DEL")
                {
                    ProizvodBO proizvodBO = new ProizvodBO()
                    {
                        ProizvodId = proizvod.ProizvodId,
                        NazivProizvoda = proizvod.NazivProizvoda,
                        ProdajnaCena = proizvod.ProdajnaCena,
                        NabavnaCena = proizvod.NabavnaCena,
                        Kolicina = proizvod.Kolicina,
                        Slika = proizvod.Slika
                    };
                    proizvodi.Add(proizvodBO);
                }
            }
            return proizvodi;
        }
        public ProizvodBO VratiProizvod(string id)
        {
            Proizvod proizvod = teretana.Proizvods.Where(p => p.ProizvodId == id).Single();
            ProizvodBO proizvodBO = new ProizvodBO()
            {
                ProizvodId = proizvod.ProizvodId,
                NazivProizvoda = proizvod.NazivProizvoda,
                Kolicina = proizvod.Kolicina,
                ProdajnaCena = proizvod.ProdajnaCena,
                NabavnaCena = proizvod.NabavnaCena,
                Slika = proizvod.Slika
            };
            return proizvodBO;
        }

        public string UnosProizvoda(ProizvodBO proizvod)
        {
            if(teretana.Proizvods.Any(p => p.ProizvodId == proizvod.ProizvodId))
            {
                return "GreskaID";
            }
            Proizvod noviProizvod = new Proizvod()
            {
                ProizvodId = proizvod.ProizvodId,
                NazivProizvoda = proizvod.NazivProizvoda,
                Kolicina = 0,
                NabavnaCena = proizvod.NabavnaCena,
                ProdajnaCena = proizvod.ProdajnaCena,
                Slika = proizvod.Slika
            };
            teretana.Proizvods.Add(noviProizvod);
            teretana.SaveChanges();
            return "";
        }

        public void IzmenaProizvoda(ProizvodBO proizvod)
        {
            Proizvod izmenaProizvoda = teretana.Proizvods.Where(p => p.ProizvodId == proizvod.ProizvodId).Single();

            izmenaProizvoda.NazivProizvoda = proizvod.NazivProizvoda;
            izmenaProizvoda.ProdajnaCena = proizvod.ProdajnaCena;
            izmenaProizvoda.NabavnaCena = proizvod.NabavnaCena;
            izmenaProizvoda.Slika = proizvod.Slika;

            teretana.SaveChanges();
        }

        public void ObrisiProizvod(string id)
        {
            Proizvod proizvod = teretana.Proizvods.Where(p => p.ProizvodId == id).Single();

            foreach(var stavkaRacuna in teretana.StavkaRacunas.Where(sr => sr.ProizvodId == proizvod.ProizvodId).ToList())
                stavkaRacuna.ProizvodId = "DEL";
            
            foreach (var stavkaPor in teretana.StavkaPorudzbenices.Where(sp => sp.ProizvodId == proizvod.ProizvodId).ToList())
                stavkaPor.ProizvodId = "DEL";

            teretana.SaveChanges();

            teretana.Proizvods.Remove(proizvod);
            teretana.SaveChanges();
        }
    }
}
