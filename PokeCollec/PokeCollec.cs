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
    public static CacheRepository CacheRepository { get; set; } = new CacheRepository();

    public PokeCollec(): base(1300, 900, "PokeCollec", Color.AliceBlue, null, true, true, true)
    {
        RenderImGui = DebugManager.SeRenderImGui;
        Datas = "data.json".LoadData();

        FontManager.AddFont("70", "Resource/font.ttf", 70);
        FontManager.AddFont("50", "Resource/font.ttf", 50);
        FontManager.AddFont("30", "Resource/font.ttf", 30);

        AddScene(new MainScene());

        IndexCurrentScene = 0;
    }
}
