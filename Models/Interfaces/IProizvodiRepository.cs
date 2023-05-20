namespace Teretana.Models.Interfaces
{
    public interface IProizvodiRepository
    {
        List<ProizvodBO> VratiProizvode(string naziv);
        ProizvodBO VratiProizvod(string id);
        string UnosProizvoda(ProizvodBO proizvod);
        void IzmenaProizvoda(ProizvodBO proizvod);
        void ObrisiProizvod(string id);
    }
}
