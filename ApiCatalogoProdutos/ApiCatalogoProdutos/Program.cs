using ApiCatalogoProdutos.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configurar o contexto do banco de dados
string stringConexaoBancoSqlServer = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContexto>(opcoes =>
{
    opcoes.UseSqlServer(stringConexaoBancoSqlServer);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*
 setando para que quando estiver no ambiente de produção,
 caso uma exceção não seja tratada, será redirecionado para o endpoint /Error
 */
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
