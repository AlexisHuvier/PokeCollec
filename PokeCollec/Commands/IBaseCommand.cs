using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Commands;

public interface IBaseCommand
{
    public string Name { get; }
    public string Help { get; }

    public void Process(PokeCollec collec, string[] parts);
}
