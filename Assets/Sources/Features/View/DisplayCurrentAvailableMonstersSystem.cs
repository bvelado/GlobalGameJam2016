using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class DisplayCurrentAvailableMonstersSystem : IReactiveSystem, ISetPool {

    Pool _pool;
    Group _availableMonstersGroup;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public TriggerOnEvent trigger
    {
        get
        {
            _availableMonstersGroup = _pool.GetGroup(Matcher.AllOf(Matcher.Available, Matcher.SlotPosition));
            return Matcher.AllOf(Matcher.SlotManager, Matcher.ScrollSlot).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            if(e.hasScrollSlot)
            {
                // Si on scroll vers la droite et que la derniere position affichée n'est pas la derniere disponible
                if(e.scrollSlot.scrollRight && _availableMonstersGroup.count > e.slotManager.minDisplayedPosition + 4)
                {
                    foreach(var _availableMonster in _availableMonstersGroup.GetEntities())
                    {
                        if(_availableMonster.slotPosition.position > e.slotManager.minDisplayedPosition && _availableMonster.slotPosition.position < e.slotManager.minDisplayedPosition +4)
                        {
                            _availableMonster.IsDisplayed(true);
                        }
                    }
                }
            }
        }
    }
}
