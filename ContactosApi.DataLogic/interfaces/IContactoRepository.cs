using ContactosApi.Entities;

namespace ContactosApi.DataLogic.interfaces
{
    public interface IContactoRepository
    {
        IEnumerable<Contacto> GetAll();
        Contacto? GetById(int id);
        void Add(Contacto contacto);
        bool Exists(string telefono);
    }
}