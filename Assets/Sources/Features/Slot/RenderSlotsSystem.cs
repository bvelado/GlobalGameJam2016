using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class RenderSlotsSystem : IReactiveSystem, ISetPool
{
    Pool _pool;
    Group _group;

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _group = pool.GetGroup(Matcher.Slot);
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Slot, Matcher.Empty).OnEntityAddedOrRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            if(e.isEmpty)
            {
                if (!TryFillSlot(e))
                {
                    HideSlot(e);
                }
            } else
            {
                ShowSlot(e);
            }
        }
    }

    void HideSlot(Entity e)
    {
        e.slot.button.SetActive(false);
    }

    void ShowSlot(Entity e)
    {
        e.slot.button.SetActive(true);
    }

    bool TryFillSlot(Entity e)
    {
        Debug.Log("Essaye de remplir.");

        Group _availableMonstersGroup = _pool.GetGroup(Matcher.AllOf(Matcher.Monster, Matcher.Available).NoneOf(Matcher.Displayed));

        if (_availableMonstersGroup.count > 0)
        {
            _availableMonstersGroup.GetEntities()[0].slotView.view.transform.SetParent(e.slot.button.transform);
            _availableMonstersGroup.GetEntities()[0].slotView.view.transform.localScale = Vector3.one;
            _availableMonstersGroup.GetEntities()[0].slotView.view.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            _availableMonstersGroup.GetEntities()[0].slotView.view.GetComponent<RectTransform>().offsetMax = Vector2.zero;

            _availableMonstersGroup.GetEntities()[0].IsDisplayed(true);
            e.IsEmpty(false);

            return true;
        } else
        {
            return false;
        }
    }
}
