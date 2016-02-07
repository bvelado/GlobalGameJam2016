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

        InitGame();
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
            /// INIT
            // Inits
            .Add(pool.CreateSystem<InitFusionManagerSystem>())
            .Add(pool.CreateSystem<InitSoundManagerSystem>())

            // Monsters
            .Add(pool.CreateSystem<CreateMonstersSystem>())

            // ...
            .Add(pool.CreateSystem<AddSlotPositionSystem>())

            // Display newly discovered monsters
            .Add(pool.CreateSystem<DisplayCurrentAvailableMonstersSystem>())

            // Slot view
            .Add(pool.CreateSystem<AddSlotViewSystem>())
            .Add(pool.CreateSystem<RemoveSlotViewSystem>())
            .Add(pool.CreateSystem<UpdateSlotViewSystem>())

            // Fusion view
            .Add(pool.CreateSystem<AddFusionViewSystem>())
            .Add(pool.CreateSystem<RemoveFusionViewSystem>())

            // Fusion
            .Add(pool.CreateSystem<ProcessFusionSystem>())

            //
            .Add(pool.CreateSystem<ScrollSlotsSystem>())

            // Sound
            .Add(pool.CreateSystem<PlayOneShotClipSystem>())

            // Timer
            .Add(pool.CreateSystem<InitTimerSystem>())
            .Add(pool.CreateSystem<TimerSystem>())

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

    void InitGame()
    {
        // Create the SlotManager entity
        Pools.pool.CreateEntity().AddSlotManager(0);

        // Set the first 2 monsters available
        foreach (var e in Pools.pool.GetEntities(Matcher.Monster))
        {
            if(e.monster.id < 2)
            {
                e.IsAvailable(true);
            }
        }

        // Start playing the background music
        Pools.pool.soundManager.manager.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(Sound.backgroundMusic);
        Pools.pool.soundManager.manager.GetComponent<AudioSource>().Play();
    }
}
