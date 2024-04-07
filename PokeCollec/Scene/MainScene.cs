using SharpEngine.Core;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Scene;

internal class MainScene: SharpEngine.Core.Scene
{
    public MainScene()
    {
        AddWidget(new Button(new SharpEngine.Core.Math.Vec2(200, 60), "Accueil", "30", new SharpEngine.Core.Math.Vec2(250, 60), Color.Black, Color.AliceBlue.Darker()));
        AddWidget(new Button(new SharpEngine.Core.Math.Vec2(500, 60), "Collection", "30", new SharpEngine.Core.Math.Vec2(250, 60), Color.Black, Color.AliceBlue.Darker()));
        AddWidget(new Button(new SharpEngine.Core.Math.Vec2(800, 60), "Statistiques", "30", new SharpEngine.Core.Math.Vec2(250, 60), Color.Black, Color.AliceBlue.Darker()));
        AddWidget(new Button(new SharpEngine.Core.Math.Vec2(1100, 60), "Recherche", "30", new SharpEngine.Core.Math.Vec2(250, 60), Color.Black, Color.AliceBlue.Darker()));
        AddWidget(new Label(new SharpEngine.Core.Math.Vec2(650, 300), "PokeCollec", "50"));
    }
}
