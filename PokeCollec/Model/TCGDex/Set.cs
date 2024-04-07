using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Model.TCGDex;

public struct Set
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Symbol { get; set; }
    public CardCount CardCount { get; set; }
    public List<CardResume> Cards { get; set; }
    public SerieResume Serie { get; set; }
    public string TcgOnline { get; set; }
    public string ReleaseDate { get; set; }
    public Legal Legal { get; set; }
}

public struct CardCount
{
    public int Total { get; set; }
    public int Official { get; set; }
    public int FirstEd { get; set; }
    public int Holo { get; set; }
    public int Reverse { get; set; }
}

public struct SetResume
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Symbol { get; set; }
    public CardCountResume CardCount { get; set; }
}

public struct CardCountResume
{
    public int Total { get; set; }
    public int Official { get; set; }
}
