using SharpEngine.Core;
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

    public RechercheScene()
    {
        AddWidget(new Widget.Menu());
        Selector = AddWidget(new Selector(new Vec2(280, 200), ["sets", "set", "carte", "séries", "série"], "30"));
        LineInput = AddWidget(new LineInput(new Vec2(650, 200), "", "30", new Vec2(500, 60)));
        AddWidget(new Button(new Vec2(1000, 200), "Valider", "30", new Vec2(150, 45), Color.Black, Color.AliceBlue.Darker()))
            .Clicked += Valider;

        Selector.LeftButton.BackgroundColor = Color.AliceBlue.Darker();
        Selector.RightButton.BackgroundColor = Color.AliceBlue.Darker();
    }

    private void Valider(object? sender, EventArgs e)
    {
        var type = Selector.Selected;
        var value = LineInput.Text;

    }
}
