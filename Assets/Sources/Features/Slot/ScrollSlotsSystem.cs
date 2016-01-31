using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScrollSlotsSystem : IReactiveSystem, ISetPool
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
            Group _availableMonstersGroup = _pool.GetGroup(Matcher.AllOf(Matcher.Available, Matcher.SlotPosition));

            // Si on scroll vers la droite et que la derniere position affichée n'est pas la derniere disponible
            if (e.scrollSlot.scrollRight && _availableMonstersGroup.count > (_pool.slotManager.minDisplayedPosition + 4))
            {
                foreach(var _availableMonster in _availableMonstersGroup.GetEntities())
                {
                    // Restants au centre
                    if (_availableMonster.hasRelativeSlotViewPosition && _availableMonster.relativeSlotViewPosition.position > 0)
                    {
                        _availableMonster.relativeSlotViewPosition.position--;
                        _availableMonster.IsUpdateSlotView(true);
                    }
                    
                    // Sortant à gauche
                    else if (_availableMonster.hasRelativeSlotViewPosition && _availableMonster.relativeSlotViewPosition.position == 0)
                    {
                        _availableMonster.IsDisplayed(false);
                    }

                    // Entrant à droite
                    else if (_availableMonster.slotPosition.position == _pool.slotManager.minDisplayedPosition + 4)
                    {
                        _availableMonster.IsDisplayed(true);
                        _availableMonster.IsUpdateSlotView(true);
                    }

                    
                }

                _pool.slotManager.minDisplayedPosition++;
            }
            else if (!e.scrollSlot.scrollRight && (e.slotManager.minDisplayedPosition > 0))
            {
                foreach (var _availableMonster in _availableMonstersGroup.GetEntities())
                {
                    // Restant au centre
                    if (_availableMonster.hasRelativeSlotViewPosition && _availableMonster.relativeSlotViewPosition.position < 3)
                    {
                        _availableMonster.relativeSlotViewPosition.position++;
                        _availableMonster.IsUpdateSlotView(true);
                    }

                    // Sortant à droite
                    else if (_availableMonster.hasRelativeSlotViewPosition && _availableMonster.relativeSlotViewPosition.position == 3)
                    {
                        _availableMonster.IsDisplayed(false);
                    }

                    // Entrant à gauche
                    else if (_availableMonster.slotPosition.position == _pool.slotManager.minDisplayedPosition - 1)
                    {
                        _availableMonster.IsDisplayed(true);
                        _availableMonster.IsUpdateSlotView(true);
                    }
                }
                _pool.slotManager.minDisplayedPosition--;
            }

            e.RemoveScrollSlot();
        }
    }
}
