using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class RemoveSlotViewSystem : IReactiveSystem, ISetPool {

    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Displayed.OnEntityRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            if(e.hasSlotView)
            {
                GameObject.Destroy(e.slotView.view);
                e.RemoveSlotView();
            }
        }
    }
}
