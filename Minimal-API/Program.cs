using Microsoft.EntityFrameworkCore;
using Minimal_API.DataBase;
using Minimal_API.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("Produtos"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Produto", async (Context db) =>
await db.Produtos.ToListAsync<Produto>()
);

app.MapGet("/Produto/EmEstoque", async (Context db) =>
await db.Produtos.Where(p => p.quatidadeEmEstoque >= 1).ToListAsync<Produto>()
);

app.MapGet("/Produto/ForaDeEstoque", async (Context db) =>
await db.Produtos.Where(p => p.quatidadeEmEstoque == 0).ToListAsync<Produto>()
);

app.MapGet("/Produto/{id}", async (Context db, int id) =>
    await db.Produtos.FindAsync(id)
    is Produto produto
    ? Results.Ok(produto)
    : Results.NotFound()
);

app.MapPost("/Produto", async (Context db, Produto produto) =>
{
    db.Produtos.Add(produto);
    await db.SaveChangesAsync();
    return Results.Created($"/Produtos/{produto.id}", produto);
});

app.MapPut("/Produto/{id}", async (Context db, int id, Produto produto) =>
{
    Produto produtoDb = await db.Produtos.FindAsync(id);
    if (produtoDb is null) return Results.NotFound();
    else
    {
        produtoDb.nome = produto.nome;
        produtoDb.codigo = produto.codigo;
        produtoDb.preco = produto.preco;
        produtoDb.descricao = produto.descricao;
        produtoDb.categoria = produto.categoria;

        await db.SaveChangesAsync();

        return Results.NoContent();
    }
});


app.Run();
