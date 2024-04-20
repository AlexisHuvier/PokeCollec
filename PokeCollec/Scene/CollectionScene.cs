using PokeCollec.Model;
using PokeCollec.Widget.Viewer;
using SharpEngine.Core;
using SharpEngine.Core.Utils;
using SharpEngine.Core.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCollec.Scene;

internal class CollectionScene: SharpEngine.Core.Scene
{
    private Selector SetSelector { get; set; }
    private ListCardViewer ListCardViewer { get; set; }
    private float timer = 0;

    public CollectionScene()
    {
        AddWidget(new Widget.Menu());
        
        if (PokeCollec.Datas.Count > 0)
        {
            ListCardViewer = AddWidget(new ListCardViewer(new SharpEngine.Core.Math.Vec2(640, 530), new SharpEngine.Core.Math.Vec2(1100, 700), 3, 3));
            SetSelector = AddWidget(new Selector(new SharpEngine.Core.Math.Vec2(640, 130), PokeCollec.Datas.Select(x => $"{x.Serie.Name} - {x.Set.Name}").ToList(), "50"));
            
            SetSelector.ValueChanged += SelectorChanged;
            SetSelector.LeftButton.BackgroundColor = Color.AliceBlue.Darker();
            SetSelector.RightButton.BackgroundColor = Color.AliceBlue.Darker();

            SelectorChanged(null, new SharpEngine.Core.Utils.EventArgs.ValueEventArgs<string> { NewValue = "", OldValue = "" });
        }
    }

    public override void Update(float delta)
    {
        base.Update(delta);
        if (timer > 0)
            timer -= delta;
    }

    private void SelectorChanged(object? sender, SharpEngine.Core.Utils.EventArgs.ValueEventArgs<string> e)
    {
        var data = PokeCollec.Datas[SetSelector.SelectedIndex];
        
        var setResult = PokeCollec.PokeRepository.GetSet(data.Set.Id);
        if (setResult.Id == null)
            throw new Exception("Set not found");

        ListCardViewer.SetValue(setResult.Cards.Where(x => x.Id != null && data.Cards.Contains(x.Id)).ToList());
    }

    public void Update()
    {
        if(SetSelector != null)
            RemoveWidget(SetSelector);
        if(ListCardViewer != null)
            RemoveWidget(ListCardViewer);

        if (PokeCollec.Datas.Count > 0)
        {
            ListCardViewer = AddWidget(new ListCardViewer(new SharpEngine.Core.Math.Vec2(640, 530), new SharpEngine.Core.Math.Vec2(1100, 700), 3, 3));
            SetSelector = AddWidget(new Selector(new SharpEngine.Core.Math.Vec2(640, 130), PokeCollec.Datas.Select(x => $"{x.Serie.Name} - {x.Set.Name}").ToList(), "50"));

            SetSelector.ValueChanged += SelectorChanged;
            SetSelector.LeftButton.BackgroundColor = Color.AliceBlue.Darker();
            SetSelector.RightButton.BackgroundColor = Color.AliceBlue.Darker();

            SetSelector.Load();
            SelectorChanged(null, new SharpEngine.Core.Utils.EventArgs.ValueEventArgs<string> { NewValue = "", OldValue = "" });
        }
    }

    public void AddCard(string card)
    {
        if (timer > 0)
            return;
        timer = 0.5f;

        var set = card.Split("-")[0];
        var setResult = PokeCollec.PokeRepository.GetSet(set);
        if (setResult.Id == null)
            throw new Exception("Set not found");

        var found = false;
        foreach(var i in PokeCollec.Datas)
        {
            if (i.Set.Id == setResult.Id)
            {
                if (i.Cards.Contains(card))
                    return;

                i.Cards.Add(card);
                found = true;
                break;
            }
        }

        if(!found)
        {
            PokeCollec.Datas.Add(new Data
            {
                Serie = new NamedData { Name = setResult.Serie.Name, Id = setResult.Serie.Id },
                Set = new NamedData { Name = setResult.Name, Id = setResult.Id },
                Purchases = 0,
                Cards = [card]
            });
        }

        PokeCollec.Datas = PokeCollec.Datas.OrderBy(d => d.Serie.Name).ThenBy(d => d.Set.Name).ToList();
        PokeCollec.Datas.SaveData("data.json");
        Update();
    }

    public void RemoveCard(string card)
    {
        if(timer > 0)
            return;
        timer = 0.5f;

        var set = card.Split("-")[0];

        foreach(var i in PokeCollec.Datas)
        {
            if (i.Set.Id == set)
            {
                if (!i.Cards.Contains(card))
                    return;

                i.Cards.Remove(card);
                if (i.Cards.Count == 0)
                    PokeCollec.Datas.Remove(i);
                break;
            }
        }

        PokeCollec.Datas = PokeCollec.Datas.OrderBy(d => d.Serie.Name).ThenBy(d => d.Set.Name).ToList();
        PokeCollec.Datas.SaveData("data.json");
        Update();
    }
}
