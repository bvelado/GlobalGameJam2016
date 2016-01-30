using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class GameController : MonoBehaviour {
    Systems _systems;

    void Start()
    {
        Random.seed = 42;

        _systems = createSystems(Pools.pool);
        _systems.Initialize();
    }

    void Update()
    {
        _systems.Execute();
    }

    Systems createSystems(Pool pool)
    {
#if (UNITY_EDITOR)
        return new DebugSystems()
#else
        return new Systems()
#endif
            // Monsters
            .Add(pool.CreateSystem<CreateMonstersSystem>())

            // Views
            .Add(pool.CreateSystem<AddSlotView>())

            // Slots
            .Add(pool.CreateSystem<CreateSlotsSystem>())
            .Add(pool.CreateSystem<RenderSlotsSystem>())
            
            // Destroy
            .Add(pool.CreateSystem<DestroySystem>())

            // Test
            .Add(pool.CreateSystem<TestInitSystem>())
            .Add(pool.CreateSystem<TestReactiveSystem>());
    }
}
