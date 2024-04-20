using PokeCollec.Repository;
using PokeCollec.Widget;
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
    private ProgressBar ProgressBar { get; }
    private Label Label { get; }
    private Menu Menu { get; }

    public MainScene()
    {
        Menu = AddWidget(new Menu());
        AddWidget(new Label(new SharpEngine.Core.Math.Vec2(650, 325), "PokeCollec est une application créé par LavaPower.\n\nCelle-ci a pour but de suivre une collection pokémon ainsi\nqu'en sortir des statistiques.", "30", centerAllLines: true));
        AddWidget(new Button(new SharpEngine.Core.Math.Vec2(650, 475), "Supprimer le cache", "30", new SharpEngine.Core.Math.Vec2(275, 50), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += (_, _) => PokeCollec.CacheRepository.Clear();
        ProgressBar = AddWidget(new ProgressBar(new SharpEngine.Core.Math.Vec2(650, 600), new SharpEngine.Core.Math.Vec2(500, 50), Color.AliceBlue.Darker(), 0));
        Label = AddWidget(new Label(new SharpEngine.Core.Math.Vec2(650, 650), "Chargement des images... (0/0)", "30", centerAllLines: true));
        
        Menu.Enabled(false);
    }

    public override void Update(float delta)
    {
        base.Update(delta);
        PokeCollec.CacheRepository.Update();

        if (PokeCollec.CacheRepository.CurrentLoaded == PokeCollec.CacheRepository.TotalToLoad)
        {
            Menu.Enabled(true);
            ProgressBar.Value = 100;
            Label.Text = "Chargement terminé !";
        }
        else
        {
            ProgressBar.Value = (float)PokeCollec.CacheRepository.CurrentLoaded / PokeCollec.CacheRepository.TotalToLoad * 100;
            Label.Text = $"Chargement des images... ({PokeCollec.CacheRepository.CurrentLoaded}/{PokeCollec.CacheRepository.TotalToLoad})";
        }
    }
}
