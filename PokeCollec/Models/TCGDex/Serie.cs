using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Models.TCGDex;

public struct Serie
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public List<SetResume> Sets { get; set; }
}

public struct SerieResume
{
    public string Id { get; set; }
    public string Name { get; set; }
}
