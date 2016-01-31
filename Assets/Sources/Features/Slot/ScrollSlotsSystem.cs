using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScrollSlotsSystem : IReactiveSystem, IInitializeSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.ScrollSlot.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            
        }
    }

    public void Initialize()
    {

    }
}
