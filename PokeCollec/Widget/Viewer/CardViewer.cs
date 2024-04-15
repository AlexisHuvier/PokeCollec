using PokeCollec.Model.TCGDex;
using PokeCollec.Scene;
using Raylib_cs;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = SharpEngine.Core.Widget.Image;
using Color = SharpEngine.Core.Utils.Color;

namespace PokeCollec.Widget.Viewer;

public class CardViewer : BaseViewer<Card>
{
    private Label Title { get; }
    private Image Logo { get; }

    private Label Informations { get; }
    private Label Description { get; }

    private string SetId { get; set; } = "";


    public CardViewer(Vec2 position) : base(position, new Vec2(1100, 650))
    {
        Title = AddChild(new Label(new Vec2(0, -300), "Title", "30"));
        Logo = AddChild(new Image(new Vec2(250, -50), zLayer: -5));

        Informations = AddChild(new Label(new Vec2(-400, 0), "Informations", "30", centerAllLines: true));
        AddChild(new Label(new Vec2(0, 175), "Description :", "30", centerAllLines: true));
        Description = AddChild(new Label(new Vec2(0, 200), "Description", "20", centerAllLines: true));
        AddChild(new Button(new Vec2(-200, 260), "Ajouter à la collection", "30", new Vec2(300, 60), Color.Black, Color.AliceBlue.Darker()));
        AddChild(new Button(new Vec2(200, 260), "Détails du Set", "30", new Vec2(300, 60), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += SetClicked;
    }

    private void SetClicked(object? sender, EventArgs e)
    {
        GetSceneAs<RechercheScene>()?.SetSearch("set", SetId);
    }

    public override void SetValue(Card value)
    {
        SetId = value.Set.Id;


        Title.Text = $"{value.Name} ({value.Id})";
        if (value.Image != null)
            Logo.Texture = PokeCollec.CacheRepository.Get($"{value.Id}.png", $"{value.Image}/low.png");
        else
            Logo.Texture = "";

        Informations.Text = $"ID Local : {value.LocalId}\nCatégorie : {value.Category}\nIllustrateur : {value.Illustrator}\nRareté : {value.Rarity}\nVariantes : {value.Variants}\nSet : {value.Set.Name} ({value.Set.Id})\nDexId : {string.Join(", ", value.DexId ?? [])}\nHP : {value.HP}\nTypes : {string.Join(", ", value.Types)}\nEvolution : {value.EvolveFrom}\nLevel : {value.Level}\nStage : {value.Stage}\nSuffix : {value.Suffix}";
        var size = Raylib.MeasureTextEx(Scene!.Window!.FontManager.GetFont("30"), Informations.Text, 30f, 2f);
        Informations.Position = new Vec2(-450 + size.X / 2, -50 -size.Y / 2);

        Description.Text = value.Description ?? "";
    }
}