using System;
using Entitas;
using UnityEngine;

public class InitFusionManagerSystem : IInitializeSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Initialize()
    {
        _pool.CreateEntity().AddFusionManager(PoolExtensions.InitRecipes());
    }

    
}
