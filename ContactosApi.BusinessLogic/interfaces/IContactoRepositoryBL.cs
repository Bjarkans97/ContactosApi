using ContactosApi.BusinessLogic.Common;
using ContactosApi.Entities;

namespace ContactosApi.BusinessLogic.interfaces
{
    public interface IContactoRepositoryBL
    {
        IEnumerable<Contacto> ObtenerTodos();
        Contacto? ObtenerPorId(int id);
        Result<Contacto> Crear(string nombre, string telefono);
    }
}