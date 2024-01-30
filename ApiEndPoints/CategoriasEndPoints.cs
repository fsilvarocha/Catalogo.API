using Catalogo.API.Context;
using Catalogo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.API.ApiEndPoints;

public static class CategoriasEndPoints
{
    public static void MapCategoriasEndpoints(this WebApplication app)
    {
        app.MapGet("/categoria", async (CatalogoDbContext db) =>  await db.Categoria
        .ToListAsync())
        .WithTags("Categoria")
        .RequireAuthorization();

        app.MapGet("/categoria/{id:int}", async (int id, CatalogoDbContext db) =>
        {
            return await db.Categoria.FindAsync(id)
            is Categoria categoria ? Results.Ok(categoria) : Results.NotFound("Categoria não cadastrada ou não encontrada!");
        }).WithTags("Categoria");

        app.MapPost("/categoria", async (Categoria categoria, CatalogoDbContext db) =>
        {
            db.Categoria.Add(categoria);
            await db.SaveChangesAsync();

            return Results.Created($"/categoria/{categoria.Id}", categoria);
        }).WithTags("Categoria");

        app.MapPut("/categoria", async (Categoria categoria, CatalogoDbContext db) =>
        {
            db.Categoria.Update(categoria);
            await db.SaveChangesAsync();

            return Results.Created($"/categoria/{categoria.Id}", categoria);
        }).WithTags("Categoria");

        app.MapDelete("/categoria/{id:int}", async (int id, CatalogoDbContext db) =>
        {
            var categoria = await db.Categoria.FindAsync(id);

            if (categoria is null)
                return Results.NotFound("Categoria não cadastrada ou não encontrada!");

            db.Categoria.Remove(categoria);
            await db.SaveChangesAsync();

            return Results.NoContent();
        }).WithTags("Categoria");
    }
}
