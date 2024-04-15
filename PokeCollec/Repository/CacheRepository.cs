using SharpEngine.Core;
using SharpEngine.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PokeCollec.Repository;

public class CacheRepository
{
    public static HttpClient Client { get; set; } = new HttpClient();
    private Window Window { get; }

    public CacheRepository(Window window)
    {
        if (!Directory.Exists("cache"))
            Directory.CreateDirectory("cache");
        else
            foreach (var file in Directory.GetFiles("cache"))
                window.TextureManager.AddTexture(Path.GetFileName(file), file);

        Window = window;
    }

    public string Get(string name, string url)
    {
        if (!File.Exists($"cache/{name}"))
        {
            using var stream = Client.GetStreamAsync(url).Result;
            using var fileStream = File.Create($"cache/{name}");
            stream.CopyTo(fileStream);
            fileStream.Close();
            Window.TextureManager.AddTexture(name, $"cache/{name}");
        }
        else if(!Window.TextureManager.HasTexture(name))
            Window.TextureManager.AddTexture(name, $"cache/{name}");
        return name;

    }

    public void Clear()
    {
        foreach (var file in Directory.GetFiles("cache"))
        {
            if (Window.TextureManager.HasTexture(Path.GetFileName(file)))
                Window.TextureManager.RemoveTexture(Path.GetFileName(file));
            File.Delete(file);
        }
    }
}
