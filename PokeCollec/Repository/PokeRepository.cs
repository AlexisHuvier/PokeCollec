using PokeCollec.Model.TCGDex;
using SharpEngine.Core.Manager;
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

    public List<SerieResume> GetSeries() => Call<List<SerieResume>>($"{BaseUrl}/series");

    public List<SetResume> GetSets() => Call<List<SetResume>>($"{BaseUrl}/sets");
    public Serie GetSerie(string id) => Call<Serie>($"{BaseUrl}/series/{id}");
    public Set GetSet(string id) => Call<Set>($"{BaseUrl}/sets/{id}");
    public Card GetCard(string id) => Call<Card>($"{BaseUrl}/cards/{id}");

    private T Call<T>(string route) => Client.GetAsync(route).Result.Content.ReadFromJsonAsync<T>().Result!;
}
