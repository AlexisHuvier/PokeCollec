using SharpEngine.Core;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Widget;

internal class Menu : SharpEngine.Core.Widget.Widget
{
    public Menu() : base(Vec2.Zero, 9999)
    {
        AddChild(new Button(new Vec2(200, 60), "Accueil", "30", new Vec2(250, 60), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += (s, e) => ChangeScene(0);
        AddChild(new Button(new Vec2(500, 60), "Collection", "30", new Vec2(250, 60), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += (s, e) => ChangeScene(1);
        AddChild(new Button(new Vec2(800, 60), "Statistiques", "30", new Vec2(250, 60), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += (s, e) => ChangeScene(2);
        AddChild(new Button(new Vec2(1100, 60), "Recherche", "30", new Vec2(250, 60), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += (s, e) => ChangeScene(3);
    }

    public void Enabled(bool enabled)
    {
        foreach (var child in Children)
        {
            if (child is Button button)
                button.Active = enabled;
        }
    }

    private void ChangeScene(int idScene) => Scene!.Window!.IndexCurrentScene = idScene;
}
