using Catalogo.API.Models;
using Catalogo.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Catalogo.API.ApiEndPoints;

public static class AutenticacaoEndPoints
{
    public static void MapAutenticacaoEndpoints(this WebApplication app)
    {
        app.MapPost("/login", [AllowAnonymous] (UserModel userModel, ITokenService tokenService) =>
        {
            if (userModel == null)
                return Results.BadRequest("Login Inválido");

            if (userModel.UserName == "fabricio" && userModel.Password == "123456")
            {
                var tokenString = tokenService.GerarToken(app.Configuration["Jwt:key"],
                    app.Configuration["Jwt:Issuer"],
                    app.Configuration["Jwt:Audience"],
                    userModel);
                return Results.Ok(new { token = tokenString });
            }
            else
            {
                return Results.BadRequest("Login Inválidos");
            }
        })
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status200OK)
            .WithName("Login")
            .WithTags("Autenticação");
    }
}
