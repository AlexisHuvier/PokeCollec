using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Commands;

public class HelpCommand: IBaseCommand
{
    public string Name => "help";
    public string Help => "help [command] : affiche la liste des commandes ou l'aide d'une commande";

    public void Process(PokeCollec collec, string[] parts)
    {
        if(parts.Length == 1)
            Console.WriteLine($"Liste des commandes : {string.Join(", ", collec.Commands.Select(x => x.Name))}");
        else
        {
            var command = collec.Commands.FirstOrDefault(x => x.Name == parts[1]);
            if(command == null)
                Console.WriteLine("Commande inconnue");
            else
                Console.WriteLine(command.Help);
        }   
    }
}
