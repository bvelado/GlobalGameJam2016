using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProcessFusionSystem : IReactiveSystem, ISetPool
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
            return Matcher.ProcessFusion.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            int result_monster_id = -1;

            int[] monster_combination = new int[2] { e.processFusion.monsterId1, e.processFusion.monsterId2 };

            

            foreach (var monster_recipes in _pool.fusionManager.recipes)
            {
                if ((monster_combination[0] == monster_recipes.Value[0] && monster_combination[1] == monster_recipes.Value[1]) || (monster_combination[0] == monster_recipes.Value[1] && monster_combination[1] == monster_recipes.Value[0]))
                {
                    result_monster_id = monster_recipes.Key;
                    Debug.Log("GGWP !" + result_monster_id);
                }
            }

            foreach(var monster in _pool.GetEntities(Matcher.Monster))
            {
                if(monster.monster.id == result_monster_id)
                {
                    monster.IsAvailable(true);
                }
            }

            e.RemoveProcessFusion();
        }
    }

    
}
