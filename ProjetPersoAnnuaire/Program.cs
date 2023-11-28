using Microsoft.EntityFrameworkCore;
using ProjetPersoAnnuaire.Context;
using ProjetPersoAnnuaire.Services.DepartementService;
using ProjetPersoAnnuaire.Services.EmployeService;
using ProjetPersoAnnuaire.Services.SitesService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddScoped<IDepartementService, DepartementService>();
builder.Services.AddScoped<IEmployeService, EmployeService>();

builder.Services.AddDbContext<DataContextAnnuaire>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
