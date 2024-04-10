using PokeCollec.Model.TCGDex;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Widget.Viewer;

public class SerieResumeViewer : BaseViewer<SerieResume>
{
    private Label SerieName { get; }
    private Label SerieId { get; }

    public SerieResumeViewer(Vec2 position) : base(position, new Vec2(1000, 180))
    {
        SerieName = AddChild(new Label(new Vec2(0, -50), "Serie Name : SET", "30"));
        SerieId = AddChild(new Label(new Vec2(0, 0), "Serie ID : SV04", "30"));
        AddChild(new Button(new Vec2(0, 50), "Détails", "30", null, Color.Black, Color.AliceBlue.Darker()));
    }

    public override void SetValue(SerieResume value)
    {
        SerieName.Text = $"Serie Name : {value.Name}";
        SerieId.Text = $"Serie ID : {value.Id}";
    }
}
