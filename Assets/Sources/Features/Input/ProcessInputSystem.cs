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


                    break;

                case InputIntent.ScrollRight:

                    break;

                case InputIntent.Fuse:

                    break;

                case InputIntent.AddMonsterSlot:

                    break;
            }
        }
    }
}
