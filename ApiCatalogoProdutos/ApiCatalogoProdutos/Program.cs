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

// implementar aqui as inje��es de depend�ncia do projeto
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
 setando para que quando estiver no ambiente de produ��o,
 caso uma exce��o n�o seja tratada, ser� redirecionado para o endpoint /Error
 */
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Error");
}

// � na classe Program por meio desse objeto app que eu defino os middlewarees da aplica��o

// middlewaree que define que as requisi��es ser�o https
app.UseHttpsRedirection();

// middlewaree que define que posso utilizar autoriza��o
app.UseAuthorization();

// middlewaree que mapeia as minhas controllers
app.MapControllers();

app.Run();
