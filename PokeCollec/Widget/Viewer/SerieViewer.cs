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

public class SerieViewer : BaseViewer<Serie>
{
    private Label Title { get; }
    private Image Logo { get; }
    private ListViewer<SetResumeViewer, SetResume> SetsViewer { get; }


    public SerieViewer(Vec2 position) : base(position, new Vec2(1100, 650))
    {
        Title = AddChild(new Label(new Vec2(0, -300), "Title", "30"));
        Logo = AddChild(new Image(new Vec2(0, -225)));
        SetsViewer = AddChild(new ListViewer<SetResumeViewer, SetResume>(new Vec2(0, -175), "Sets", 2, 1));
    }

    public override void SetValue(Serie value)
    {
        Title.Text = $"{value.Name} ({value.Id})";
        if (value.Logo != null)
            Logo.Texture = PokeCollec.CacheRepository.Get($"{value.Id}.png", $"{value.Logo}.png");
        else
            Logo.Texture = "";
        SetsViewer.SetValues(value.Sets ?? []);
    }
}