using SharpEngine.Core;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Scene;

internal class StatistiquesScene: SharpEngine.Core.Scene
{
    public StatistiquesScene()
    {
        AddWidget(new Widget.Menu());
        AddWidget(new Label(new SharpEngine.Core.Math.Vec2(650, 400), "Statistiques Placeholder", "30", centerAllLines: true));
    }
}
