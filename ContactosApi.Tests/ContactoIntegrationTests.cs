using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;
using Xunit;

public class ContactoIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ContactoIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostContacto_CuandoEsValido_DeberiaRetornar201Created()
    {
        var nuevoContacto = new { nombre = "Test Integración", telefono = "123456789" };

        var response = await _client.PostAsJsonAsync("/api/v1/Contactos", nuevoContacto);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task GetContactos_DeberiaRetornar200Ok()
    {
        var response = await _client.GetAsync("/api/v1/Contactos");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}