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
    public SerieViewer(Vec2 position) : base(position, new Vec2(1100, 600))
    {
        AddChild(new Label(new Vec2(0, 50), "Série", "30"));
    }

    public override void SetValue(Serie value)
    {
    }
}