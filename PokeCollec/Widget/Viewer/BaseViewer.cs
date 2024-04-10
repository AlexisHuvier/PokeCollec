using SharpEngine.Core.Math;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Widget.Viewer;

public abstract class BaseViewer<T>(Vec2 position, Vec2 size) : Frame(position, size)
{
    public abstract void SetValue(T value);
}
