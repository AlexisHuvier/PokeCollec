using PokeCollec.Model.TCGDex;
using SharpEngine.Core.Math;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Widget.Viewer
{
    public class ListCardViewer : BaseViewer<List<CardResume>>
    {
        private int CurrentPage = 0;
        private int NbLine = 3;
        private int NbColumn = 3;

        private List<CardResumeViewer> Items { get; }
        private List<CardResume> Values { get; set; } = [];

        public ListCardViewer(Vec2 position, Vec2 size, int nbLine = 3, int nbColumn = 3, int zLayer = 0) : base(position, size)
        {
            NbLine = nbLine;
            NbColumn = nbColumn;
            ZLayer = zLayer;
            AddChild(new Button(new Vec2(-450, 0), "<", "30", new Vec2(75, 40), Color.Black, Color.AliceBlue.Darker()))
                .Clicked += Back;
            AddChild(new Button(new Vec2(450, 0), ">", "30", new Vec2(75, 40), Color.Black, Color.AliceBlue.Darker()))
                .Clicked += Next;

            Items = [];

            for (int y = 0; y < NbLine; y++)
                for (int x = 0; x < NbColumn; x++)
                    Items.Add(AddChild(new CardResumeViewer(new Vec2(250 * (x - NbColumn / 2), 225 * (y - NbLine / 2)))));
        }

        public void SetTitle(string title) => ((Label)Children[0]).Text = title;

        public override void SetValue(List<CardResume> value)
        {
            Values = value;
            CurrentPage = 0;
            UpdateDisplay();
        }

        private void Next(object? sender, EventArgs e)
        {
            if (CurrentPage < Values.Count / (NbLine * NbColumn))
                CurrentPage++;
            else
                CurrentPage = 0;
            UpdateDisplay();
        }

        private void Back(object? sender, EventArgs e)
        {
            if (CurrentPage > 0)
                CurrentPage--;
            else
                CurrentPage = Values.Count / (NbLine * NbColumn);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Values.Count > i + CurrentPage * (NbLine * NbColumn))
                {
                    Items[i].Displayed = true;
                    Items[i].SetValue(Values[i + CurrentPage * (NbLine * NbColumn)]);
                }
                else
                    Items[i].Displayed = false;
            }
        }
    }
}
