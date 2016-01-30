using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public MonsterComponent monster { get { return (MonsterComponent)GetComponent(ComponentIds.Monster); } }

        public bool hasMonster { get { return HasComponent(ComponentIds.Monster); } }

        static readonly Stack<MonsterComponent> _monsterComponentPool = new Stack<MonsterComponent>();

        public static void ClearMonsterComponentPool() {
            _monsterComponentPool.Clear();
        }

        public Entity AddMonster(int newId) {
            var component = _monsterComponentPool.Count > 0 ? _monsterComponentPool.Pop() : new MonsterComponent();
            component.id = newId;
            return AddComponent(ComponentIds.Monster, component);
        }

        public Entity ReplaceMonster(int newId) {
            var previousComponent = hasMonster ? monster : null;
            var component = _monsterComponentPool.Count > 0 ? _monsterComponentPool.Pop() : new MonsterComponent();
            component.id = newId;
            ReplaceComponent(ComponentIds.Monster, component);
            if (previousComponent != null) {
                _monsterComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveMonster() {
            var component = monster;
            RemoveComponent(ComponentIds.Monster);
            _monsterComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherMonster;

        public static IMatcher Monster {
            get {
                if (_matcherMonster == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Monster);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherMonster = matcher;
                }

                return _matcherMonster;
            }
        }
    }
}
