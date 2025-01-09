using ApiCatalogoProdutos.Contexto;
using ApiCatalogoProdutos.Repositorios;
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

// implementar aqui as injeções de dependência do projeto
builder.Services.AddScoped<ICategoriaProdutoRepositorio, CategoriaRepositorioNovo>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorioNovo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
    // app.UseExceptionHandler("/Error");
}

// é na classe Program por meio desse objeto app que eu defino os middlewarees da aplicação

// middlewaree que define que as requisições serão https
app.UseHttpsRedirection();

// middlewaree que define que posso utilizar autorização
app.UseAuthorization();

// middlewaree que mapeia as minhas controllers
app.MapControllers();

app.Run();
