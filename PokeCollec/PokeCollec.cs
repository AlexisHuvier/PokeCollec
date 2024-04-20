using PokeCollec.Model;
using PokeCollec.Repository;
using PokeCollec.Scene;
using SharpEngine.Core;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokeCollec;

public class PokeCollec: Window
{
    public static List<Data> Datas { get; set; } = null!;
    public static PokeRepository PokeRepository { get; set; } = new PokeRepository();
    public static CacheRepository CacheRepository { get; set; }

    public PokeCollec(): base(1300, 900, "PokeCollec", Color.AliceBlue, null, true, true, true)
    {
        CacheRepository = new CacheRepository(this);

        Datas = "data.json".LoadData();
        Datas = Datas.OrderBy(d => d.Serie.Name).ThenBy(d => d.Set.Name).ToList();

        FontManager.AddFont("70", "Resource/font.ttf", 70);
        FontManager.AddFont("50", "Resource/font.ttf", 50);
        FontManager.AddFont("30", "Resource/font.ttf", 30);
        FontManager.AddFont("20", "Resource/font.ttf", 20);

        AddScene(new MainScene());
        AddScene(new CollectionScene());
        AddScene(new StatistiquesScene());
        AddScene(new RechercheScene());

        IndexCurrentScene = 0;
    }
}
