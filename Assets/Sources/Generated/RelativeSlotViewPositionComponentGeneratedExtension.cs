using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public RelativeSlotViewPositionComponent relativeSlotViewPosition { get { return (RelativeSlotViewPositionComponent)GetComponent(ComponentIds.RelativeSlotViewPosition); } }

        public bool hasRelativeSlotViewPosition { get { return HasComponent(ComponentIds.RelativeSlotViewPosition); } }

        static readonly Stack<RelativeSlotViewPositionComponent> _relativeSlotViewPositionComponentPool = new Stack<RelativeSlotViewPositionComponent>();

        public static void ClearRelativeSlotViewPositionComponentPool() {
            _relativeSlotViewPositionComponentPool.Clear();
        }

        public Entity AddRelativeSlotViewPosition(int newPosition) {
            var component = _relativeSlotViewPositionComponentPool.Count > 0 ? _relativeSlotViewPositionComponentPool.Pop() : new RelativeSlotViewPositionComponent();
            component.position = newPosition;
            return AddComponent(ComponentIds.RelativeSlotViewPosition, component);
        }

        public Entity ReplaceRelativeSlotViewPosition(int newPosition) {
            var previousComponent = hasRelativeSlotViewPosition ? relativeSlotViewPosition : null;
            var component = _relativeSlotViewPositionComponentPool.Count > 0 ? _relativeSlotViewPositionComponentPool.Pop() : new RelativeSlotViewPositionComponent();
            component.position = newPosition;
            ReplaceComponent(ComponentIds.RelativeSlotViewPosition, component);
            if (previousComponent != null) {
                _relativeSlotViewPositionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveRelativeSlotViewPosition() {
            var component = relativeSlotViewPosition;
            RemoveComponent(ComponentIds.RelativeSlotViewPosition);
            _relativeSlotViewPositionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherRelativeSlotViewPosition;

        public static IMatcher RelativeSlotViewPosition {
            get {
                if (_matcherRelativeSlotViewPosition == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.RelativeSlotViewPosition);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherRelativeSlotViewPosition = matcher;
                }

                return _matcherRelativeSlotViewPosition;
            }
        }
    }
}
