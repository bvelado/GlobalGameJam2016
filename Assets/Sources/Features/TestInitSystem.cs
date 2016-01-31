using System;
using Entitas;
using UnityEngine;
using System.Collections;

public class TestInitSystem : IInitializeSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Initialize()
    {

    }
}
