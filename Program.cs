using TaskFlowApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddSingleton<LibroService>();
builder.Services.AddSingleton<ProductoService>();
//Registrar el servicio dentro de ASP.NET Core
//Crear una unica instancia del servicio para toda la aplicación
// mientras este ejecutandose
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("PermitirAngular");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();