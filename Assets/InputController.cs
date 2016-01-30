using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    public void ScrollLeft()
    {
        Pools.pool.ReplaceInput(InputIntent.ScrollLeft);
    }

    public void ScrollRight()
    {
        Pools.pool.ReplaceInput(InputIntent.ScrollRight);
    }

    public void Fuse()
    {
        Pools.pool.ReplaceInput(InputIntent.Fuse);
    }

    public void AddMonster(int slot)
    {
        switch(slot)
        {
            case 1:
                Pools.pool.ReplaceInput(InputIntent.AddMonsterSlot1);
                break;
            case 2:
                Pools.pool.ReplaceInput(InputIntent.AddMonsterSlot2);
                break;
            case 3:
                Pools.pool.ReplaceInput(InputIntent.AddMonsterSlot3);
                break;
            case 4:
                Pools.pool.ReplaceInput(InputIntent.AddMonsterSlot4);
                break;
        }
        
    }
}
