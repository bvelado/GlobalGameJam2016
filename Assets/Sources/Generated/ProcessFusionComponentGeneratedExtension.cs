using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public ProcessFusionComponent processFusion { get { return (ProcessFusionComponent)GetComponent(ComponentIds.ProcessFusion); } }

        public bool hasProcessFusion { get { return HasComponent(ComponentIds.ProcessFusion); } }

        static readonly Stack<ProcessFusionComponent> _processFusionComponentPool = new Stack<ProcessFusionComponent>();

        public static void ClearProcessFusionComponentPool() {
            _processFusionComponentPool.Clear();
        }

        public Entity AddProcessFusion(int newMonsterId1, int newMonsterId2) {
            var component = _processFusionComponentPool.Count > 0 ? _processFusionComponentPool.Pop() : new ProcessFusionComponent();
            component.monsterId1 = newMonsterId1;
            component.monsterId2 = newMonsterId2;
            return AddComponent(ComponentIds.ProcessFusion, component);
        }

        public Entity ReplaceProcessFusion(int newMonsterId1, int newMonsterId2) {
            var previousComponent = hasProcessFusion ? processFusion : null;
            var component = _processFusionComponentPool.Count > 0 ? _processFusionComponentPool.Pop() : new ProcessFusionComponent();
            component.monsterId1 = newMonsterId1;
            component.monsterId2 = newMonsterId2;
            ReplaceComponent(ComponentIds.ProcessFusion, component);
            if (previousComponent != null) {
                _processFusionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveProcessFusion() {
            var component = processFusion;
            RemoveComponent(ComponentIds.ProcessFusion);
            _processFusionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherProcessFusion;

        public static IMatcher ProcessFusion {
            get {
                if (_matcherProcessFusion == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.ProcessFusion);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherProcessFusion = matcher;
                }

                return _matcherProcessFusion;
            }
        }
    }
}
