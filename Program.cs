using PokemonAPI.Models;

using PokemonAPI.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


List<Pokemon> pokemonList = new List<Pokemon>
{
    new Pokemon("Pikachu", 25, "Electric", false, false, 24),
    new Pokemon("Charmander", 4, "Fire", false, false, 12),
    new Pokemon("Bulbasaur", 1, "Grass", false, false, 12),
    new Pokemon("Squirtle", 7, "Water", false, false, 12)
};


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/hello", () => {
    return "Hello World!";
});

//Get the Pokemon List
app.MapGet("/pokemonList", () => {
    var pokemonDTOs = pokemonList.Select(pokemon => new PokemonDTO
    {
        Name = pokemon.Name,
        Id = pokemon.Id,
        Type = pokemon.Type,
        Captured = pokemon.Captured,
        Evolved = pokemon.Evolved
    });
    return pokemonDTOs;
});


//Add a Pokemon to the List
app.MapPost("/addPokemon", (PokemonDetailDTO pokemonDetailDTO) => {
    var newPokemon = new Pokemon(pokemonDetailDTO.Name, pokemonDetailDTO.Id, pokemonDetailDTO.Type, pokemonDetailDTO.Captured, pokemonDetailDTO.Evolved, pokemonDetailDTO.Level);
    pokemonList.Add(newPokemon);
    return Results.Created($"/pokemonList/{newPokemon.Id}", newPokemon);
});



//Delete a Pokemon from the List by Id
app.MapDelete("/deletePokemon/{id}", (int id) => {
    var pokemonToDelete = pokemonList.FirstOrDefault(pokemon => pokemon.Id == id);
    if (pokemonToDelete == null)
    {
        return Results.NotFound();
    }
    pokemonList.Remove(pokemonToDelete);
    return Results.NoContent();
});


//Update a Pokemon in the List by Id
app.MapPut("/updatePokemon/{id}", (int id, PokemonDTO updatedPokemon) => {
    var pokemonToUpdate = pokemonList.FirstOrDefault(pokemon =>pokemon.Id==id);

    if (pokemonToUpdate == null)
    {
        return Results.NotFound();
    }
    pokemonToUpdate.Name = updatedPokemon.Name;
    pokemonToUpdate.Type = updatedPokemon.Type;
    pokemonToUpdate.Captured = updatedPokemon.Captured;
    pokemonToUpdate.Evolved = updatedPokemon.Evolved;

    return Results.Ok(pokemonToUpdate);
});


//Get a Pokemon from the List by Id
app.MapGet("/pokemonList/{id}", (int id) => {
    var pokemon = pokemonList.FirstOrDefault(pokemon => pokemon.Id == id);
    if (pokemon == null)
    {
        return Results.NotFound($"Pokemon not found with ID {id}");
    }
    var detailedPokemon = new PokemonDetailDTO
    {
        Name = pokemon.Name,
        Id = pokemon.Id,
        Type = pokemon.Type,
        Captured = pokemon.Captured,
        Evolved = pokemon.Evolved,
        Level = pokemon.Level
    };
    return Results.Ok(detailedPokemon);
});


app.Run();

