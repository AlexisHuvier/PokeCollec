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
    private SerieViewer SerieViewer { get; } = new SerieViewer(new Vec2(650, 530));

    public RechercheScene()
    {
        AddWidget(new Widget.Menu());
        Selector = AddWidget(new Selector(new Vec2(280, 150), ["sets", "set", "carte", "séries", "série"], "30"));
        LineInput = AddWidget(new LineInput(new Vec2(650, 150), "", "30", new Vec2(500, 60)));
        AddWidget(new Button(new Vec2(1000, 150), "Valider", "30", new Vec2(150, 45), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += Valider;
        AddWidget(SetsViewer);
        AddWidget(SeriesViewer);
        AddWidget(SerieViewer);

        Selector.LeftButton.BackgroundColor = Color.AliceBlue.Darker();
        Selector.RightButton.BackgroundColor = Color.AliceBlue.Darker();
        SetsViewer.Displayed = false;
        SeriesViewer.Displayed = false;
        SerieViewer.Displayed = false;
    }

    private void Valider(object? sender, EventArgs e)
    {
        var type = Selector.Selected;
        var value = LineInput.Text;

        switch (type)
        {
            case "sets":
                List<SetResume>? setsValue = value switch
                {
                    "" => GetValue<List<SetResume>?>(PokeCollec.PokeRepository.GetSets),
                    _ => GetValue<Serie?>(() => PokeCollec.PokeRepository.GetSerie(value))?.Sets
                };

                if (setsValue != null) {
                    Display(SetsViewer, [SeriesViewer, SerieViewer]);
                    SetsViewer.SetValues(setsValue);
                }
                break;
            case "set":
                DebugManager.Log(LogLevel.LogDebug, $"Result : {GetValue(() => PokeCollec.PokeRepository.GetSet(value))}");
                break;
            case "carte":
                DebugManager.Log(LogLevel.LogDebug, $"Result : {GetValue(() => PokeCollec.PokeRepository.GetCard(value))}");
                break;
            case "séries":
                var seriesValue = GetValue<List<SerieResume>?>(PokeCollec.PokeRepository.GetSeries);

                if(seriesValue != null)
                {
                    Display(SeriesViewer, [SetsViewer, SerieViewer]);
                    SeriesViewer.SetValues(seriesValue);
                }
                break;
            case "série":
                var serieValue = GetValue<Serie?>(() => PokeCollec.PokeRepository.GetSerie(value));

                if(serieValue != null)
                {
                    Display(SerieViewer, [SetsViewer, SeriesViewer]);
                    SerieViewer.SetValue(serieValue.Value);
                }
                break;
        }

    }

    private T? GetValue<T>(Func<T> function)
    {
        try
        {
            return function();
        }
        catch (Exception)
        {
            return default;
        }
    }

    private void Display(SharpEngine.Core.Widget.Widget display, List<SharpEngine.Core.Widget.Widget> notDisplay)
    {
        display.Displayed = true;
        foreach (var item in notDisplay)
            item.Displayed = false;
    }
}
