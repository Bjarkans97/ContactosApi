using ContactosApi.BusinessLogic.Common;
using ContactosApi.BusinessLogic.interfaces;
using ContactosApi.DataLogic.interfaces;
using ContactosApi.Entities;

namespace ContactosApi.BusinessLogic.clases
{
    public class ContactoRepositoryBL : IContactoRepositoryBL
    {
        private readonly IContactoRepository _repository;
        private readonly object _syncLock = new();

        public ContactoRepositoryBL(IContactoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Contacto> ObtenerTodos() => _repository.GetAll();

        public Contacto? ObtenerPorId(int id) => _repository.GetById(id);

        public Result<Contacto> Crear(string nombre, string telefono)
        {
            lock (_syncLock)
            {
                if (_repository.Exists(telefono))
                    return Result<Contacto>.Fail("El teléfono ya existe.");

                var contactos = _repository.GetAll();
                int nuevoId = contactos.Any() ? contactos.Max(c => c.Id) + 1 : 1;

                var nuevoContacto = new Contacto
                {
                    Id = nuevoId,
                    Nombre = nombre,
                    Telefono = telefono
                };

                _repository.Add(nuevoContacto);
                return Result<Contacto>.Ok(nuevoContacto);
            }
        }
    }
}