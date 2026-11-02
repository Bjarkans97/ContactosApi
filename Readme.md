# API de Contactos

[![CI](https://github.com/Bjarkans97/ContactosApi/actions/workflows/ci.yml/badge.svg)](https://github.com/Bjarkans97/ContactosApi/actions/workflows/ci.yml)

API RESTful desarrollada en **.NET 8** para la gestión de contactos en memoria. El proyecto sigue principios de **Clean Architecture** y está enfocado en la robustez, la escalabilidad y la mantenibilidad.

## Características principales

- **Arquitectura en capas**: separación clara de responsabilidades (Controller, BusinessLogic, DataLogic, Entities).
- **Concurrencia segura**: `ConcurrentDictionary` y bloqueos (`lock`) para operaciones *thread-safe*.
- **Patrones de diseño**: Repository Pattern, Result Pattern (manejo funcional de errores) e Inyección de Dependencias.
- **Robustez**:
  - Middleware personalizado para el manejo global de excepciones.
  - Logging estructurado con `ILogger`.
  - Validación de datos con *Data Annotations*.
- **Documentación y versionado**:
  - API versionada (`v1`).
  - Documentación interactiva con **Swagger/OpenAPI**.
- **Testing**: tests unitarios (xUnit) y tests de integración (`WebApplicationFactory`).

## Estructura

```
ContactosApi/                 → Web API: controllers, DTOs, middlewares
ContactosApi.BusinessLogic/   → Reglas de negocio y validaciones
ContactosApi.DataLogic/       → Repositorio en memoria (thread-safe)
ContactosApi.Entities/        → Modelos de dominio y Result Pattern
ContactosApi.Tests/           → Tests unitarios y de integración
```

## Endpoints

| Método | Endpoint | Descripción |
| :-- | :-- | :-- |
| GET | `/api/v1/Contactos` | Lista todos los contactos |
| GET | `/api/v1/Contactos/{id}` | Obtiene un contacto por ID |
| POST | `/api/v1/Contactos` | Crea un contacto (`409 Conflict` si ya existe) |

Ejemplo de creación:

```http
POST /api/v1/Contactos
Content-Type: application/json

{
  "nombre": "Juan Pérez",
  "telefono": "+56912345678"
}
```

## Tecnologías

- **Framework**: .NET 8.0
- **Testing**: xUnit, Microsoft.AspNetCore.Mvc.Testing
- **Documentación**: Swashbuckle.AspNetCore

## Cómo ejecutarlo

### Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Clonar y ejecutar

```bash
git clone https://github.com/Bjarkans97/ContactosApi.git
cd ContactosApi
dotnet run --project ContactosApi
```

Swagger queda disponible en `http://localhost:5192/swagger`.

### Ejecutar los tests

```bash
dotnet test
```
