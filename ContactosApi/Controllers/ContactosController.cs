using Asp.Versioning;
using ContactosApi.BusinessLogic.interfaces;
using ContactosApi.DTOs;
using ContactosApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactosApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContactosController : ControllerBase
    {
        private readonly IContactoRepositoryBL _service;

        public ContactosController(IContactoRepositoryBL service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.ObtenerTodos());

        [HttpPost]
        public IActionResult Create([FromBody] CrearContactoDto dto)
        {
            var result = _service.Crear(dto.Nombre, dto.Telefono);

            if (!result.Success)
            {
                return Conflict(new { message = result.Error });
            }

            var nuevo = result.Value!;
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contacto = _service.ObtenerPorId(id);
            return contacto == null ? NotFound() : Ok(contacto);
        }
    }
}