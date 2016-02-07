using UnityEngine;
using Entitas;
using System;

public class InitSoundManagerSystem : IInitializeSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Initialize()
    {
        _pool.CreateEntity().AddSoundManager(CreateGameObject());
    }

    GameObject CreateGameObject()
    {
        GameObject gameObject = null;
        var res = Resources.Load<GameObject>("Prefabs/SoundManager");

        try
        {
            gameObject = GameObject.Instantiate(res);
        }
        catch (Exception)
        {
            Debug.Log("Cannot instantiate " + res);
        }

        if (gameObject != null)
        {
            gameObject.name = "SoundManager";
        }

        return gameObject;
    }
}
