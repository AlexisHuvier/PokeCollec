using PokeCollec.Model.TCGDex;
using PokeCollec.Widget.Viewer;
using SharpEngine.Core;
using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Scene;

internal class RechercheScene: SharpEngine.Core.Scene
{
    private Selector Selector { get; set; } = null!;
    private LineInput LineInput { get; set; } = null!;

    private ListViewer<SetResumeViewer, SetResume> SetsViewer { get; } = new ListViewer<SetResumeViewer, SetResume>(new Vec2(650, 200), "Sets");
    private ListViewer<SerieResumeViewer, SerieResume> SeriesViewer { get; } = new ListViewer<SerieResumeViewer, SerieResume>(new Vec2(650, 200), "Series");

    public RechercheScene()
    {
        AddWidget(new Widget.Menu());
        Selector = AddWidget(new Selector(new Vec2(280, 150), ["sets", "set", "carte", "séries", "série"], "30"));
        LineInput = AddWidget(new LineInput(new Vec2(650, 150), "", "30", new Vec2(500, 60)));
        AddWidget(new Button(new Vec2(1000, 150), "Valider", "30", new Vec2(150, 45), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += Valider;
        AddWidget(SetsViewer);
        AddWidget(SeriesViewer);

        Selector.LeftButton.BackgroundColor = Color.AliceBlue.Darker();
        Selector.RightButton.BackgroundColor = Color.AliceBlue.Darker();
        SetsViewer.Displayed = false;
        SeriesViewer.Displayed = false;
    }

    private void Valider(object? sender, EventArgs e)
    {
        var type = Selector.Selected;
        var value = LineInput.Text;

        switch(type)
        {
            case "sets":
                Display(SetsViewer, [SeriesViewer]);
                if(value == "")
                    SetsViewer.SetValues(PokeCollec.PokeRepository.GetSets() ?? []);
                else
                    SetsViewer.SetValues(PokeCollec.PokeRepository.GetSerie(value)?.Sets ?? []);
                break;
            case "set":
                DebugManager.Log(LogLevel.LogDebug, $"Result : {PokeCollec.PokeRepository.GetSet(value)}");
                break;
            case "carte":
                DebugManager.Log(LogLevel.LogDebug, $"Result : {PokeCollec.PokeRepository.GetCard(value)}");
                break;
            case "séries":
                Display(SeriesViewer, [SetsViewer]);
                SeriesViewer.SetValues(PokeCollec.PokeRepository.GetSeries() ?? []);
                break;
            case "série":
                DebugManager.Log(LogLevel.LogDebug, $"Result : {PokeCollec.PokeRepository.GetSerie(value)}");
                break;
        }

    }

    private void Display(SharpEngine.Core.Widget.Widget display, List<SharpEngine.Core.Widget.Widget> notDisplay)
    {
        display.Displayed = true;
        foreach (var item in notDisplay)
            item.Displayed = false;
    }
}
