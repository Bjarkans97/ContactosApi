using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ContactosApi.Entities;
using ContactosApi.DataLogic.interfaces;

namespace ContactosApi.DataLogic.clases
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly ConcurrentDictionary<int, Contacto> _contactos = new();

        public IEnumerable<Contacto> GetAll() => _contactos.Values;
        public Contacto? GetById(int id) => _contactos.GetValueOrDefault(id);
        public void Add(Contacto contacto) => _contactos.TryAdd(contacto.Id, contacto);
        public bool Exists(string telefono) => _contactos.Values.Any(c => c.Telefono == telefono);
    }
}