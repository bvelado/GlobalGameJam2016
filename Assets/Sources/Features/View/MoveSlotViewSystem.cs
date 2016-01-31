using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class MoveSlotViewSystem : IReactiveSystem, ISetPool
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
            return Matcher.AllOf(Matcher.ScrollSlot, Matcher.SlotManager).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        
        foreach (var e in entities)
        {
            if (e.hasScrollSlot)
            {
                Group _availableMonstersGroup = _pool.GetGroup(Matcher.AllOf(Matcher.Available, Matcher.SlotPosition));

                // Si on scroll vers la droite et que la derniere position affichée n'est pas la derniere disponible
                if (e.scrollSlot.scrollRight && _availableMonstersGroup.count > (e.slotManager.minDisplayedPosition + 4))
                {
                    _pool.slotManager.minDisplayedPosition++;
                    foreach (var _availableMonster in _availableMonstersGroup.GetEntities())
                    {
                        if (_availableMonster.slotPosition.position >= e.slotManager.minDisplayedPosition && _availableMonster.slotPosition.position < (e.slotManager.minDisplayedPosition + 3))
                        {
                            _availableMonster.IsDisplayed(true);
                            Debug.Log("Displayed " +_availableMonster);
                        } else
                        {
                            _availableMonster.IsDisplayed(false);
                        }
                    }
                }
                // Si on scroll vers la gauche et que la premiere position affichée est supérieure ou égale à 0
                else if (!e.scrollSlot.scrollRight && (e.slotManager.minDisplayedPosition > 0))
                {
                    _pool.slotManager.minDisplayedPosition--;
                    foreach (var _availableMonster in _availableMonstersGroup.GetEntities())
                    {
                        if (_availableMonster.slotPosition.position >= e.slotManager.minDisplayedPosition && _availableMonster.slotPosition.position < (e.slotManager.minDisplayedPosition + 3))
                        {
                            _availableMonster.IsDisplayed(true);

                            Debug.Log("Displayed " + _availableMonster);
                        }
                        else
                        {
                            _availableMonster.IsDisplayed(false);
                        }
                    }
                }

                e.RemoveScrollSlot();
            }

            Debug.Log(_pool.slotManager.minDisplayedPosition);
        }
    }
}
