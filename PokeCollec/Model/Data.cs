using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Model;

public struct Data
{
    public NamedData Serie { get; set; }
    public NamedData Set { get; set; }
    public int Purchases { get; set; }
    public List<string> Cards { get; set; }
}

public struct NamedData
{
    public string Name { get; set; }
    public string Id { get; set; }
}