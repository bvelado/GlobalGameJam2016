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
        Monsters.Monster7,
        Monsters.Monster8,
        Monsters.Monster9,
        Monsters.Monster10,
        Monsters.Monster11,
        Monsters.Monster12,
        Monsters.Monster13,
        Monsters.Monster14,
        Monsters.Monster15,
        Monsters.Monster16,
        Monsters.Monster17,
        Monsters.Monster18,
        Monsters.Monster19,
        Monsters.Monster20,
        Monsters.Monster21,
        Monsters.Monster22,
        Monsters.Monster23,
        Monsters.Monster24,
        Monsters.Monster25
    };

    public static Entity CreateMonster(Pool pool, int id, int monsterIndex)
    {
        return pool.CreateEntity()
            .AddMonster(id)
            .AddResource(_monsters[monsterIndex]);
    }
}
