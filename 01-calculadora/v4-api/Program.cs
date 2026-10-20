var app = WebApplication.CreateBuilder(args).Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/calcular", (CalculoRequest req) =>
{
    string texto = req.Expressao ?? "";

    if (string.IsNullOrWhiteSpace(texto))
        return Results.BadRequest(new { erro = "Informe uma expressão" });

    if (!Calculo.ResolverParenteses(ref texto) ||
        !Calculo.EntradaTexto(texto, out decimal total))
        return Results.BadRequest(new { erro = "expressão inválida" });

    return Results.Ok(new { resultado = total });
});

app.Run();

record CalculoRequest(string Expressao);