using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class RenderDisplayedMonstersSystem : IReactiveSystem, ISetPool
{
    Group _group;

    public void SetPool(Pool pool)
    {
        _group = pool.GetGroup(Matcher.Displayed);
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Monster, Matcher.SlotView, Matcher.Displayed).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        
    }
}
