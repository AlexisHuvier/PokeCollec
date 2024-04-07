using PokeCollec.Model.TCGDex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokeCollec.Repository;

public class PokeRepository
{
    public static HttpClient Client { get; set; } = new HttpClient();
    public const string BaseUrl = "https://api.tcgdex.net/v2/fr";

    public List<SerieResume>? GetSeries() => Client.GetAsync($"{BaseUrl}/series").Result.Content.ReadFromJsonAsync<List<SerieResume>>().Result!;
    public List<SetResume>? GetSets() => Client.GetAsync($"{BaseUrl}/sets").Result.Content.ReadFromJsonAsync<List<SetResume>>().Result!;
    public Serie? GetSerie(string id) => Client.GetAsync($"{BaseUrl}/series/{id}").Result.Content.ReadFromJsonAsync<Serie>().Result!;
    public Set? GetSet(string id) => Client.GetAsync($"{BaseUrl}/sets/{id}").Result.Content.ReadFromJsonAsync<Set>().Result!;
    public Card? GetCard(string id) => Client.GetAsync($"{BaseUrl}/cards/{id}").Result.Content.ReadFromJsonAsync<Card>().Result!;
}
