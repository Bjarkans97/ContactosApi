using ContactosApi.BusinessLogic.clases;
using ContactosApi.DataLogic.clases;
using Xunit;

public class ContactoServiceTests
{
    [Fact]
    public void Crear_DeberiaAsignarIdIncremental()
    {
        var repo = new ContactoRepository();
        var service = new ContactoRepositoryBL(repo);

        var c1 = service.Crear("Juan", "123");
        var c2 = service.Crear("Ana", "456");

        Assert.Equal(1, c1.Value!.Id);
        Assert.Equal(2, c2.Value!.Id);
    }
}