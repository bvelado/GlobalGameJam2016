using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class UpdateSlotViewSystem : IReactiveSystem, ISetPool
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
            return Matcher.UpdateSlotView.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            if(e.hasRelativeSlotViewPosition)
            {
                MoveSlotViewPosition(e);
            }

            e.IsUpdateSlotView(false);
        }
    }

    void MoveSlotViewPosition(Entity e)
    {
        e.slotView.view.GetComponent<RectTransform>().anchorMin = new Vector2(e.relativeSlotViewPosition.position * 0.25f, 0.0f);
        e.slotView.view.GetComponent<RectTransform>().anchorMax = new Vector2(0.25f + (e.relativeSlotViewPosition.position * 0.25f), 1.0f);
        e.slotView.view.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        e.slotView.view.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        e.slotView.view.transform.localScale = Vector3.one;
    }
}
