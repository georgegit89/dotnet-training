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
app.MapGet("/hello", () =>
{
    return "Hello World!";
});

app.MapGet("/api/products", () =>
{
    return new[]
    {
        new { Id = 1, Name = "Gerbera", Price = 9.99 },
        new { Id = 2, Name = "Rose", Price = 19.99 },
        new { Id = 3, Name = "Tulip", Price = 29.99 }
    };
});

app.MapPost("/api/products", (dynamic product) =>
{
    // Logic to add the product
    // Serialization
    //Mongo DB

    return Results.Created($"/api/products/{product.Id}", product);
});

app.MapPut("/api/products/{id}", (int id, dynamic product) =>
{
    // Logic to update the product
    // Serialization
    //Mongo DB

    return Results.Ok(product);
});

app.MapDelete("/api/products/{id}", (int id) =>
{
    // Logic to delete the product
    // Mongo DB


    return Results.NoContent();
});




app.Run();