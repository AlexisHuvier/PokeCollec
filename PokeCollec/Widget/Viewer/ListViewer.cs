using SharpEngine.Core.Manager;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Widget.Viewer;

public class ListViewer<TWidget, TItem> : SharpEngine.Core.Widget.Widget where TWidget : BaseViewer<TItem>
{
    private List<TWidget> Items { get; }
    private List<TItem> Values { get; set; } = [];
    private int CurrentPage { get; set; } = 0;
    private int PageNumber { get; set; } = 3;

    public ListViewer(Vec2 position, string title, int pageNumber = 3, int zLayer = 0) : base(position, zLayer)
    {
        AddChild(new Label(new Vec2(0, 50), title, "30"));
        AddChild(new Button(new Vec2(-300, 50), "<", "30", null, Color.Black, Color.AliceBlue.Darker()))
            .Clicked += Back;
        AddChild(new Button(new Vec2(300, 50), ">", "30", null, Color.Black, Color.AliceBlue.Darker()))
            .Clicked += Next;

        PageNumber = pageNumber;

        Items = [];

        for (int i = 0; i < PageNumber; i++)
            Items.Add(AddChild((TWidget)Activator.CreateInstance(typeof(TWidget), [new Vec2(0, 175 + 200 * i)])!));
    }

    public void SetTitle(string title) => ((Label)Children[0]).Text = title;

    public void SetValues(List<TItem> items)
    {
        Values = items;
        CurrentPage = 0;
        UpdateDisplay();
    }

    private void Next(object? sender, EventArgs e)
    {
        if(CurrentPage < Values.Count / PageNumber)
            CurrentPage++;
        else
            CurrentPage = 0;
        UpdateDisplay();
    }

    private void Back(object? sender, EventArgs e)
    {
        if(CurrentPage > 0)
            CurrentPage--;
        else
            CurrentPage = Values.Count / PageNumber;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    { 
        for (int i = 0; i < Items.Count; i++)
        {
            if (Values.Count > i + CurrentPage * PageNumber)
            {
                Items[i].Displayed = true;
                Items[i].SetValue(Values[i + CurrentPage * PageNumber]);
            }
            else
                Items[i].Displayed = false;
        }
    }
}
