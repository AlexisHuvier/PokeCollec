using PokeCollec.Model.TCGDex;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Widget.Viewer;

public class SetViewer : BaseViewer<Set>
{
    private Label Title { get; }
    private Image Logo { get; }
    private Label CardCount { get; }
    private Label Info { get; }
    private SerieResumeViewer SerieResumeViewer { get; }


    /*
    public List<CardResume> Cards { get; set; }
    public SerieResume Serie { get; set; }*/

    public SetViewer(Vec2 position) : base(position, new Vec2(1100, 650))
    {
        Title = AddChild(new Label(new Vec2(0, -300), "Title", "30"));
        Logo = AddChild(new Image(new Vec2(0, -225), zLayer: -5));

        CardCount = AddChild(new Label(new Vec2(-400, -250), "Nombre de Cartes :", "30", centerAllLines: true));
        Info = AddChild(new Label(new Vec2(400, -250), "Informations :", "30", centerAllLines: true));
        SerieResumeViewer = AddChild(new SerieResumeViewer(new Vec2(0, -50)));
    }

    public override void SetValue(Set value)
    {
        Title.Text = $"{value.Name} ({value.Id})";
        if (value.Logo != null)
            Logo.Texture = PokeCollec.CacheRepository.Get($"{value.Id}.png", $"{value.Logo}.png");
        else
            Logo.Texture = "";

        CardCount.Text = $"Nombre de Cartes :\n- Officiel : {value.CardCount.Official}\n- Total : {value.CardCount.Total}";
        Info.Text = $"Informations :\nDate : {value.ReleaseDate}\n{(value.Legal.Standard ? "Valide" : "Invalide")} - {(value.Legal.Expanded ? "Valide" : "Invalide")}\nTCG : {(value.TcgOnline != null && value.TcgOnline.Length > 0 ? value.TcgOnline : "/")}";
        SerieResumeViewer.SetValue(value.Serie);
    }
}