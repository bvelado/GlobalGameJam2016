using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class PlayOneShotClipSystem : IReactiveSystem, ISetPool
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
            return Matcher.AllOf(Matcher.OneShotClip, Matcher.Resource).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            AudioClip res = Resources.Load(e.resource.path) as AudioClip;

            _pool.soundManager.manager.GetComponent<AudioSource>().PlayOneShot(res);

            e.IsDestroy(true);
        }
    }
}
