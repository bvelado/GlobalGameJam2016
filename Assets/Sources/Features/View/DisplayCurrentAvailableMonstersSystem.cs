using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class DisplayCurrentAvailableMonstersSystem : IReactiveSystem, ISetPool {

    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.SlotPosition.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        
        foreach (var e in entities)
        {
            if(e.slotPosition.position >= _pool.slotManager.minDisplayedPosition && e.slotPosition.position < (_pool.slotManager.minDisplayedPosition + 4))
            {
                e.IsDisplayed(true);
            }
        }
    }
}
