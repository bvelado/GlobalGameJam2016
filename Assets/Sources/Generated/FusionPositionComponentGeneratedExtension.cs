using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public FusionPositionComponent fusionPosition { get { return (FusionPositionComponent)GetComponent(ComponentIds.FusionPosition); } }

        public bool hasFusionPosition { get { return HasComponent(ComponentIds.FusionPosition); } }

        static readonly Stack<FusionPositionComponent> _fusionPositionComponentPool = new Stack<FusionPositionComponent>();

        public static void ClearFusionPositionComponentPool() {
            _fusionPositionComponentPool.Clear();
        }

        public Entity AddFusionPosition(int newPosition) {
            var component = _fusionPositionComponentPool.Count > 0 ? _fusionPositionComponentPool.Pop() : new FusionPositionComponent();
            component.position = newPosition;
            return AddComponent(ComponentIds.FusionPosition, component);
        }

        public Entity ReplaceFusionPosition(int newPosition) {
            var previousComponent = hasFusionPosition ? fusionPosition : null;
            var component = _fusionPositionComponentPool.Count > 0 ? _fusionPositionComponentPool.Pop() : new FusionPositionComponent();
            component.position = newPosition;
            ReplaceComponent(ComponentIds.FusionPosition, component);
            if (previousComponent != null) {
                _fusionPositionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveFusionPosition() {
            var component = fusionPosition;
            RemoveComponent(ComponentIds.FusionPosition);
            _fusionPositionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherFusionPosition;

        public static IMatcher FusionPosition {
            get {
                if (_matcherFusionPosition == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.FusionPosition);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherFusionPosition = matcher;
                }

                return _matcherFusionPosition;
            }
        }
    }
}
