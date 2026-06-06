using ContactosApi.BusinessLogic.clases;
using ContactosApi.BusinessLogic.interfaces;
using ContactosApi.DataLogic.clases;
using ContactosApi.DataLogic.interfaces;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IContactoRepository, ContactoRepository>();
builder.Services.AddSingleton<IContactoRepositoryBL, ContactoRepositoryBL>();
builder.Services.AddApiVersioning(options => {
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(), 
        new HeaderApiVersionReader("api-version") 
    );
})
.AddApiExplorer(options => {
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Contactos V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<ContactosApi.Middlewares.ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }