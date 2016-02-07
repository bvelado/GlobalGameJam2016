using UnityEngine;
using Entitas;

public class InitTimerSystem : IInitializeSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    readonly GameObject _timerContainer = GameObject.Find("TimerPanel");

    public void Initialize()
    {
        // Create the Timer entity
        Pools.pool.CreateEntity().AddTimer(180.0f);

        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/TimerText"));
        go.transform.SetParent(_timerContainer.transform);

        go.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        go.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        go.transform.localScale = Vector3.one;

        _pool.timerEntity.AddTimerView(go)
            .IsRunning(true);
    }
}
