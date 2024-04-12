using PokeCollec.Model.TCGDex;
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
    private ListViewer<SetResumeViewer, SetResume> SetsViewer { get; }


    public SerieViewer(Vec2 position) : base(position, new Vec2(1100, 650))
    {
        SetsViewer = AddChild(new ListViewer<SetResumeViewer, SetResume>(new Vec2(0, -175), "Sets", 2, 1));
    }

    public override void SetValue(Serie value)
    {
        SetsViewer.SetValues(value.Sets);
    }
}