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

public class SetResumeViewer : BaseViewer<SetResume>
{
    private Label SetName { get; }
    private Label SetId { get; }

    public SetResumeViewer(Vec2 position) : base(position, new Vec2(1000, 180))
    {
        SetName = AddChild(new Label(new Vec2(0, -50), "Set Name : SET", "30"));
        SetId = AddChild(new Label(new Vec2(0, 0), "Set ID : SV04", "30"));
        AddChild(new Button(new Vec2(0, 50), "Détails", "30", null, Color.Black, Color.AliceBlue.Darker()))
            .Clicked += DetailsClicked;
    }
    private void DetailsClicked(object? sender, EventArgs e)
    {
        GetSceneAs<RechercheScene>()?.SetSearch("set", SetId.Text.Split(" : ")[^1]);
    }

    public override void SetValue(SetResume value)
    {
        SetName.Text = $"Set Name : {value.Name}";
        SetId.Text = $"Set ID : {value.Id}";
    }
}
