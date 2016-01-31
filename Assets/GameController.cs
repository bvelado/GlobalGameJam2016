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

        Pools.pool.CreateEntity().AddSlotManager(0);
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

            .Add(pool.CreateSystem<AddSlotPositionSystem>())

            .Add(pool.CreateSystem<DisplayCurrentAvailableMonstersSystem>())

            .Add(pool.CreateSystem<AddSlotView>())
            .Add(pool.CreateSystem<RemoveSlotViewSystem>())

            // Views
            //.Add(pool.CreateSystem<AddSlotView>())

            // Slots
            //.Add(pool.CreateSystem<CreateSlotsSystem>())
            //.Add(pool.CreateSystem<RenderSlotsSystem>())
            //.Add(pool.CreateSystem<ScrollSlotsSystem>())

            // Inputs
            .Add(pool.CreateSystem<ProcessInputSystem>())

            // Destroys
            .Add(pool.CreateSystem<DestroySystem>())

            // Test
            .Add(pool.CreateSystem<TestInitSystem>())
            .Add(pool.CreateSystem<TestReactiveSystem>());
    }
}
