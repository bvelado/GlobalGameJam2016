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
}
