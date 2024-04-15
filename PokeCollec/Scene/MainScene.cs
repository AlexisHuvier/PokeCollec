using PokeCollec.Repository;
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
        AddWidget(new Widget.Menu());
        AddWidget(new Label(new SharpEngine.Core.Math.Vec2(650, 325), "PokeCollec est une application créé par LavaPower.\n\nCelle-ci a pour but de suivre une collection pokémon ainsi\nqu'en sortir des statistiques.", "30", centerAllLines: true));
        AddWidget(new Button(new SharpEngine.Core.Math.Vec2(650, 475), "Supprimer le cache", "30", new SharpEngine.Core.Math.Vec2(275, 50), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += (_, _) => PokeCollec.CacheRepository.Clear();
    }
}
