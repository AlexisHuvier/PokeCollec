using PokeCollec.Commands;
using PokeCollec.Models;
using PokeCollec.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokeCollec;

public class PokeCollec
{
    public List<Data> Datas { get; set; } = null!;
    public PokeRepository Repository { get; set; } = new PokeRepository();
    public List<IBaseCommand> Commands { get; set; } = [
        new ListCommand(),
        new HelpCommand(),
        new InfoCommand()
    ];

    public void ProcessCommand(string userInput)
    {
        var parts = userInput.Split(' ');
        if (parts.Length == 0)
            return;

        foreach (var command in Commands)
        {
            if (parts[0] == command.Name)
            {
                command.Process(this, parts);
                return;
            }
        }

        Console.WriteLine("Commande inconnue");
    }

    public void LoadData()
    {
        Datas = JsonSerializer.Deserialize<List<Data>>(File.ReadAllText("data.json"))!;
    }

    public void SaveData()
    {
        File.WriteAllText("data.json", JsonSerializer.Serialize(Datas));
    }
}
