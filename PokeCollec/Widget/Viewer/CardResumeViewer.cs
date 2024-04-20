using PokeCollec.Model.TCGDex;
using PokeCollec.Scene;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Widget.Viewer;

public class CardResumeViewer : BaseViewer<CardResume>
{
    private Label Title { get; }
    private Image Logo { get; }


    public CardResumeViewer(Vec2 position) : base(position, new Vec2(200, 200))
    {
        Title = AddChild(new Label(new Vec2(0, -80), "Title", "20"));
        Logo = AddChild(new Image(new Vec2(0, 0), scale: new Vec2(0.5f), zLayer: -5));
        AddChild(new Button(new Vec2(-65, 80), "C", "20", new Vec2(30, 30), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += AddClicked;
        AddChild(new Button(new Vec2(65, 80), "D", "20", new Vec2(30, 30), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += DetailsClicked;
    }

    private void AddClicked(object? sender, EventArgs e)
    {
        if(PokeCollec.Datas.Any(x => x.Cards.Contains(Title.Text.Split(" (")[^1][..^1])))
            Scene!.Window!.GetScene<CollectionScene>(1).RemoveCard(Title.Text.Split(" (")[^1][..^1]);
        else
            Scene!.Window!.GetScene<CollectionScene>(1).AddCard(Title.Text.Split(" (")[^1][..^1]);
    }

    private void DetailsClicked(object? sender, EventArgs e)
    {
        Scene!.Window!.GetScene<RechercheScene>(3).SetSearch("carte", Title.Text.Split(" (")[^1][..^1]);
        Scene!.Window!.IndexCurrentScene = 3;
    }

    public override void SetValue(CardResume value)
    {
        Title.Text = $"{value.Name} ({value.Id})";
        if (value.Image != null)
            Logo.Texture = PokeCollec.CacheRepository.Get($"{value.Id}.png", $"{value.Image}/low.png");
        else
            Logo.Texture = "";
    }
}