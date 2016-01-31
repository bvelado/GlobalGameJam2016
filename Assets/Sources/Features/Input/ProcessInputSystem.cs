using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class ProcessInputSystem : IReactiveSystem, ISetPool
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
            return Matcher.Input.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            switch(e.input.intent)
            {
                case InputIntent.ScrollLeft:
                    _pool.slotManagerEntity.AddScrollSlot(false);

                    break;

                case InputIntent.ScrollRight:
                    _pool.slotManagerEntity.AddScrollSlot(true);

                    break;

                case InputIntent.Fuse:
                    List<int> fusableMonsters = new List<int>();

                    foreach(var monster in _pool.GetEntities(Matcher.Fusable))
                    {
                        fusableMonsters.Add(monster.monster.id);
                    }

                    if(fusableMonsters.Count > 1)
                    {
                        _pool.fusionManagerEntity.AddProcessFusion(fusableMonsters[0], fusableMonsters[1]);
                    }

                    break;
            }
        }
    }
}
