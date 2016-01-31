using UnityEngine;
using Entitas;
using System.Collections.Generic;

public class RemoveFusionViewSystem : IReactiveSystem, ISetPool {
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Fusable.OnEntityRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            if (e.hasFusionView)
            {
                GameObject.Destroy(e.fusionView.view);
                e.RemoveFusionView();
                e.RemoveFusionPosition();

                e.IsInteractable(false);
            }
        }
    }
}
