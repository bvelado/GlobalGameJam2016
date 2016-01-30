using Entitas;

public static class PoolExtensions {

    public static readonly string[] _monsters = {
        Monsters.Monster0,
        Monsters.Monster1,
        Monsters.Monster2,
        Monsters.Monster3,
        Monsters.Monster4,
        Monsters.Monster5,
        Monsters.Monster6,
        Monsters.Monster7
    };

    public static Entity CreateMonster(Pool pool, int id, int monsterIndex)
    {
        return pool.CreateEntity()
            .AddMonster(id)
            .AddResource(_monsters[monsterIndex])
            .IsAvailable(true);
    }
}
