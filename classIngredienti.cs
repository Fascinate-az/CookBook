using System.Text.Json.Serialization;

namespace CookBook;

abstract class Ingredienti
{
    //[JsonIgnore]
    public abstract string Nome { get; set; }  
    public abstract int Id { get; set; }
    [JsonIgnore]
    public abstract string Informazioni { get; set; }  
    
    public override string ToString()
    {
        return Nome;
    }
    public List<Ingredienti> ListaDegliIngredienti(List<Ingredienti>listaIngredienti)
    {
        return listaIngredienti;
    }
}

class WheatFlour:Ingredienti
{
    public override string Nome { get; set; } = "Wheat flour";
    public override int Id { get; set; } = 1;
    public override string Informazioni { get; set; } = "Sieve. Add to other ingredients.";

    
}

class CoconutFlour : Ingredienti
{
    public override string Nome { get; set; }  = "CoconutFlour";
    public override int Id { get; set; } = 2;
    public override string Informazioni { get; set; } = "Sieve. Add to other ingredients.";
}
class Butter:Ingredienti
{
    public override string Nome { get; set; } = "Butter";
    public override int Id { get; set; } = 3;
    public override string Informazioni { get; set; } = "Melt on low heat. Add to other ingredients.";
}

class Chocolate : Ingredienti
{
    public override string Nome { get; set; }  = "Chocolate";
    public override int Id { get; set; } = 4;
    public override string Informazioni { get; set; } = "Melt in a water bath. Add to other ingredients.";
}

class Sugar : Ingredienti
{
    public override string Nome { get; set; }  = "Sugar";
    public override int Id { get; set; } = 5;
    public override string Informazioni { get; set; } = "Add to other ingredients.";
}
class Cardamom:Ingredienti
{
    public override string Nome { get; set; }  = "Cardamom";
    public override int Id { get; set; } = 6;
    public override string Informazioni { get; set; } = "Take half a teaspoon. Add to other ingredients.";
}

class Cinnamon : Ingredienti
{
    public override string Nome { get; set; } = "Cinnamon";
    public override int Id { get; set; } = 7;
    public override string Informazioni { get; set; } = "Take half a teaspoon. Add to other ingredients.";
}

class CocoaPowder : Ingredienti
{
    public override string Nome { get; set; } = "Cocoa powder";
    public override int Id { get; set; } = 8;
    public override string Informazioni { get; set; } = "Add to other ingredients.";
}
