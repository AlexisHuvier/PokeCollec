using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Commands;

public class ListCommand: IBaseCommand
{
    public string Name => "list";
    public string Help => "list <type> [serie|set] : liste les objets de type <type> (pouvant appartenir à une serie ou un set)\nTypes disponibles : series, sets";

    public void Process(PokeCollec collec, string[] parts)
    {
        if (parts.Length < 2)
        {
            Console.WriteLine("Liste possible : series, sets");
            return;
        }

        if (parts[1] == "series")
            ListSeries(collec);
        else if (parts[1] == "sets")
            ListSets(collec, parts.ElementAtOrDefault(2));
        else
            Console.WriteLine("Liste possible : series, sets");
    }

    private void ListSeries(PokeCollec collec)
    {
        foreach (var serie in collec.Repository.GetSeries() ?? [])
            Console.WriteLine($"{serie.Name} ({serie.Id})");
    }

    private void ListSets(PokeCollec collec, string? serieId)
    {
        if(serieId == null)
            foreach (var set in collec.Repository.GetSets() ?? [])
                Console.WriteLine($"{set.Name} ({set.Id})");
        else
            foreach (var set in collec.Repository.GetSerie(serieId)?.Sets ?? [])
                Console.WriteLine($"{set.Name} ({set.Id})");
    }
}
