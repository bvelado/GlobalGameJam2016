using Entitas;

public class CreateMonstersSystem : IInitializeSystem, ISetPool
{
    Pool _pool;

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }

    public void Initialize()
    {
        for (int i = 0; i < PoolExtensions._monsters.Length; i++)
        {
            PoolExtensions.CreateMonster(_pool, i, i);
        }
    }
}