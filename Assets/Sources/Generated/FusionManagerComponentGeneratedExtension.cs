using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public FusionManagerComponent fusionManager { get { return (FusionManagerComponent)GetComponent(ComponentIds.FusionManager); } }

        public bool hasFusionManager { get { return HasComponent(ComponentIds.FusionManager); } }

        static readonly Stack<FusionManagerComponent> _fusionManagerComponentPool = new Stack<FusionManagerComponent>();

        public static void ClearFusionManagerComponentPool() {
            _fusionManagerComponentPool.Clear();
        }

        public Entity AddFusionManager(System.Collections.Generic.Dictionary<int, int[]> newRecipes) {
            var component = _fusionManagerComponentPool.Count > 0 ? _fusionManagerComponentPool.Pop() : new FusionManagerComponent();
            component.recipes = newRecipes;
            return AddComponent(ComponentIds.FusionManager, component);
        }

        public Entity ReplaceFusionManager(System.Collections.Generic.Dictionary<int, int[]> newRecipes) {
            var previousComponent = hasFusionManager ? fusionManager : null;
            var component = _fusionManagerComponentPool.Count > 0 ? _fusionManagerComponentPool.Pop() : new FusionManagerComponent();
            component.recipes = newRecipes;
            ReplaceComponent(ComponentIds.FusionManager, component);
            if (previousComponent != null) {
                _fusionManagerComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveFusionManager() {
            var component = fusionManager;
            RemoveComponent(ComponentIds.FusionManager);
            _fusionManagerComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity fusionManagerEntity { get { return GetGroup(Matcher.FusionManager).GetSingleEntity(); } }

        public FusionManagerComponent fusionManager { get { return fusionManagerEntity.fusionManager; } }

        public bool hasFusionManager { get { return fusionManagerEntity != null; } }

        public Entity SetFusionManager(System.Collections.Generic.Dictionary<int, int[]> newRecipes) {
            if (hasFusionManager) {
                throw new EntitasException("Could not set fusionManager!\n" + this + " already has an entity with FusionManagerComponent!",
                    "You should check if the pool already has a fusionManagerEntity before setting it or use pool.ReplaceFusionManager().");
            }
            var entity = CreateEntity();
            entity.AddFusionManager(newRecipes);
            return entity;
        }

        public Entity ReplaceFusionManager(System.Collections.Generic.Dictionary<int, int[]> newRecipes) {
            var entity = fusionManagerEntity;
            if (entity == null) {
                entity = SetFusionManager(newRecipes);
            } else {
                entity.ReplaceFusionManager(newRecipes);
            }

            return entity;
        }

        public void RemoveFusionManager() {
            DestroyEntity(fusionManagerEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherFusionManager;

        public static IMatcher FusionManager {
            get {
                if (_matcherFusionManager == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.FusionManager);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherFusionManager = matcher;
                }

                return _matcherFusionManager;
            }
        }
    }
}
