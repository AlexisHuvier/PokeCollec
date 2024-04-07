using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Models.TCGDex;

public struct Card
{
    public string Id { get; set; }
    public string LocalId { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Category { get; set; }
    public string Illustrator { get; set; }
    public string Rarity { get; set; }
    public Variants Variants { get; set; }
    public SetResume Set { get; set; }
    public List<int> DexId { get; set; }
    public int HP { get; set; }
    public List<string> Types { get; set; }
    public string? EvolveFrom { get; set; }
    public string Description { get; set; }
    public string? Level { get; set; }
    public string Stage { get; set; }
    public string? Suffix { get; set; }
    public Item? Item { get; set; }
    public List<Ability> Abilities { get; set; }
    public List<Attack> Attacks { get; set; }
    public List<TypedValue> Weaknesses { get; set; }
    public List<TypedValue> Resistances { get; set; }
    public int Retreat { get; set; }
    public string RegulationMark { get; set; }
    public Legal Legal { get; set; }
}

public struct Variants
{
    public bool Normal { get; set; }
    public bool Reverse { get; set; }
    public bool Holo { get; set; }
    public bool FirstEd { get; set; }
    public bool WPromo { get; set; }
}

public struct Item
{
    public string Name { get; set; }
    public string Effect { get; set; }
}

public struct Ability
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Effect { get; set; }
}

public struct Attack
{
    public List<string> Cost { get; set; }
    public string Name { get; set; }
    public string Effect { get; set; }
    public object Damage { get; set; }
}

public struct TypedValue
{
    public string Name { get; set; }
    public string Value { get; set; }
}

public struct CardResume
{
    public string Id { get; set; }
    public string LocalId { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
}
