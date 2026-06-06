# API de Contactos

API RESTful desarrollada en .NET 8, diseñada para la gestión de contactos en memoria. El proyecto sigue principios de **Clean Architecture** y está enfocado en la robustez, escalabilidad y mantenibilidad.

##Características Principales

- **Arquitectura en Capas**: Separación clara de responsabilidades (Controller, Service/BusinessLogic, DataLogic, Domain).
- **Concurrencia Segura**: Implementación de `ConcurrentDictionary` y bloqueos de sincronización (`lock`) para asegurar operaciones *thread-safe*.
- **Patrones de Diseño**: Repository Pattern, Result Pattern (para manejo funcional de errores) e Inyección de Dependencias.
- **Robustez**: 
    - Middleware personalizado para manejo global de excepciones.
    - Logging estructurado con `ILogger`.
    - Validación de datos mediante *Data Annotations*.
- **Documentación y Versionado**:
    - API versionada (`v1`).
    - Documentación interactiva mediante **Swagger/OpenAPI**.
- **Testing**: Cobertura con tests unitarios (xUnit) y tests de integración (`WebApplicationFactory`).

## Tecnologías Utilizadas

- **Framework**: .NET 8.0
- **Testing**: xUnit, Microsoft.AspNetCore.Mvc.Testing
- **Documentación**: Swashbuckle.AspNetCore

## Instrucciones de Ejecución

### Requisitos previos
- [.NET 8 SDK](https://dotnet.microsoft.com/download) instalado.

### Clonar y Ejecutar
1. Clona este repositorio.
2. Navega a la carpeta de la solución.
3. Ejecuta la API desde la terminal:
   ```bash
   dotnet run --project ContactosApi