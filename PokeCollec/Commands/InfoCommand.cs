using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Commands;

public class InfoCommand : IBaseCommand
{
    public string Name => "info";

    public string Help => "info <type> <id> : donne les informations de l'objet <id> de type <type>\nTypes disponibles : serie, set, card";

    public void Process(PokeCollec collec, string[] parts)
    {

        if (parts.Length <= 2)
        {
            Console.WriteLine("info <type> <id>");
            return;
        }

        if (parts[1] == "serie")
            InfoSerie(collec, parts[2]);
        else if (parts[1] == "set")
            InfoSet(collec, parts[2]);
        else if (parts[1] == "card")
            InfoCard(collec, parts[2]);
        else
            Console.WriteLine("Type possible : serie, set, card");
    }

    private void InfoSerie(PokeCollec collec, string serieId)
    {
        var serie = collec.Repository.GetSerie(serieId);
        if (serie?.Id == null)
        {
            Console.WriteLine("Serie inconnue");
            return;
        }

        Console.WriteLine($"{serie?.Name} ({serie?.Id})");
        Console.WriteLine($"Sets ({serie?.Sets.Count}) :");
        foreach (var set in serie?.Sets ?? [])
            Console.WriteLine($"  {set.Name} ({set.Id})");
    }

    private void InfoSet(PokeCollec collec, string setId)
    {
        var set = collec.Repository.GetSet(setId);
        if (set?.Id == null)
        {
            Console.WriteLine("Set inconnu");
            return;
        }

        Console.WriteLine($"{set?.Name} ({set?.Id})");
        Console.WriteLine($"Nombre de cartes : {set?.Cards.Count}");
    }

    private void InfoCard(PokeCollec collec, string cardId)
    {
        var card = collec.Repository.GetCard(cardId);
        if (card?.Id == null)
        {
            Console.WriteLine("Carte inconnue");
            return;
        }

        Console.WriteLine($"{card?.Name} ({card?.Id})");
    }
}
