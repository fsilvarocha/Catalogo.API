using Catalogo.API.Context;
using Catalogo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.API.ApiEndPoints;

public static class ProdutoEndPoints
{
    public static void MapProdutosEndpoints(this WebApplication app)
    {
        app.MapGet("/produto", async (CatalogoDbContext db) => await db.Produtos.ToListAsync())
            .Produces<List<Produto>>(StatusCodes.Status200OK)
            .WithTags("Produto");

        app.MapGet("/produto/{id:int}", async (int id, CatalogoDbContext db) =>
        {
            return await db.Produtos.FindAsync(id)
            is Produto produto ? Results.Ok(produto) : Results.NotFound("Produto não cadastrada ou não encontrada!");
        }).WithTags("Produto");

        app.MapPost("/produto", async (Produto produto, CatalogoDbContext db) =>
        {
            db.Produtos.Add(produto);
            await db.SaveChangesAsync();

            return Results.Created($"/produto/{produto.Id}", produto);
        }).WithTags("Produto");

        app.MapPut("/produto", async (Produto produto, CatalogoDbContext db) =>
        {
            db.Produtos.Update(produto);
            await db.SaveChangesAsync();

            return Results.Created($"/produto/{produto.Id}", produto);
        }).WithTags("Produto");

        app.MapDelete("/produto/{id:int}", async (int id, CatalogoDbContext db) =>
        {
            var produto = await db.Produtos.FindAsync(id);

            if (produto is null)
                return Results.NotFound("Produto não cadastrada ou não encontrada!");

            db.Produtos.Remove(produto);
            await db.SaveChangesAsync();

            return Results.NoContent();
        }).WithTags("Produto");
    }
}
