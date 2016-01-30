using Entitas;
using System.Collections.Generic;

public class TestReactiveSystem : IReactiveSystem, ISetPool {

    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Resource, Matcher.Monster).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        
    }
}
