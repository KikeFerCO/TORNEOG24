using Torneo.App.Dominio;

namespace Torneo.App.Persistencia
{
    public interface IRepositorioPartido
    {
        public Partido AddPartido(Partido partido, int local, int visitante );
        public IEnumerable<Partido> GetAllPartidos();
    }
}