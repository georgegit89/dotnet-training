var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
//Cors enabling
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

//Request Processing Logic

//rest API  with HTTP Get Request using minimal APIs
app.MapGet("/welcome", () =>
{
    return "Welcome to the E-Store API!";
});

app.MapGet("/api/products", () =>
{
    return new[]
    {
        new { Id = 1, Name = "Soap", Price = 9.99 },
        new { Id = 2, Name = "Mattress", Price = 19.99 },
        new { Id = 3, Name = "CoffeeMaker", Price = 29.99 }
    };
});

app.MapPost("/api/products", (dynamic product) =>
{

    return Results.Created($"/api/products/{product.Id}", product);
});

app.MapPut("/api/products/{id}", (int id, dynamic product) =>
{

    return Results.Ok(product);
});

app.MapDelete("/api/products/{id}", (int id) =>
{
    
    return Results.NoContent();
});




app.Run();