using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class AddSlotPositionSystem : IReactiveSystem, ISetPool
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
            return Matcher.Available.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            if(!e.hasSlotPosition)
            {
                e.AddSlotPosition(_pool.GetEntities(Matcher.SlotPosition).Length);
            }
        }
    }

    
}
