using Microsoft.EntityFrameworkCore;
using Minimal_API.DataBase;
using Minimal_API.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("Produtos"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Produtos", async (Context db) =>
await db.Produtos.ToListAsync<Produto>()
);

app.MapGet("/Produtos/EmEstoque", async (Context db) =>
await db.Produtos.Where(p => p.quatidadeEmEstoque >= 1).ToListAsync<Produto>()
);

app.MapGet("/Produtos/ForaDeEstoque", async (Context db) =>
await db.Produtos.Where(p => p.quatidadeEmEstoque == 0).ToListAsync<Produto>()
);

app.MapGet("/Produtos/{id}", async (Context db, int id) =>
    await db.Produtos.FindAsync(id)
    is Produto produto
    ? Results.Ok(produto)
    : Results.NotFound()
);

app.Run();
