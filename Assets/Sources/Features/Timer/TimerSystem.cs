using UnityEngine;
using Entitas;
using System.Collections.Generic;
using System;

public class TimerSystem : IReactiveSystem, IExecuteSystem ,ISetPool
{

    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            if(e.isRunning)
            {
                e.timer.secondsLeft -= Time.deltaTime;
            }
        }
    }

    public void Execute()
    {
        throw new NotImplementedException();
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Timer, Matcher.Running).OnEntityAddedOrRemoved();
        }
    }

    
}
