using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokeCollec.Model;

public static class ModelExtensions
{
    public static List<Data> LoadData(this string file) => JsonSerializer.Deserialize<List<Data>>(File.ReadAllText(file))!;

    public static void SaveData(this List<Data> datas, string file) => File.WriteAllText(file, JsonSerializer.Serialize(datas));
}
