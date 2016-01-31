using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScrollSlotsSystem : IReactiveSystem, IInitializeSystem, ISetPool
{
    List<Entity> orderedMonsterEntities = new List<Entity>();
    List<Entity> orderedSlotEntities = new List<Entity>();

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
        // Create an ordered by position list of slots
        foreach(var en in _pool.GetEntities(Matcher.Slot))
        {
            int position = 1000;
            Entity nextSlot = null;
            foreach (var e in _pool.GetEntities(Matcher.Slot))
            {
                if (!orderedSlotEntities.Contains(e) && e.slot.position < position)
                {
                    nextSlot = e;
                    position = e.slot.position;
                }
            }
            orderedSlotEntities.Add(nextSlot);
            //Debug.Log("Added " + nextSlot + " : " + nextSlot.slot.position + " to the ordered slot list.");
        }
        
        // Search for already availables monsters
        foreach(var e in _pool.GetEntities(Matcher.AllOf(Matcher.Monster, Matcher.Available)))
        {
            orderedMonsterEntities.Add(e);
        }

        // Fill the slots with available monsters
        foreach(var e in orderedMonsterEntities)
        {
            //
        }
    }
}
