using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public SlotPositionComponent slotPosition { get { return (SlotPositionComponent)GetComponent(ComponentIds.SlotPosition); } }

        public bool hasSlotPosition { get { return HasComponent(ComponentIds.SlotPosition); } }

        static readonly Stack<SlotPositionComponent> _slotPositionComponentPool = new Stack<SlotPositionComponent>();

        public static void ClearSlotPositionComponentPool() {
            _slotPositionComponentPool.Clear();
        }

        public Entity AddSlotPosition(int newPosition) {
            var component = _slotPositionComponentPool.Count > 0 ? _slotPositionComponentPool.Pop() : new SlotPositionComponent();
            component.position = newPosition;
            return AddComponent(ComponentIds.SlotPosition, component);
        }

        public Entity ReplaceSlotPosition(int newPosition) {
            var previousComponent = hasSlotPosition ? slotPosition : null;
            var component = _slotPositionComponentPool.Count > 0 ? _slotPositionComponentPool.Pop() : new SlotPositionComponent();
            component.position = newPosition;
            ReplaceComponent(ComponentIds.SlotPosition, component);
            if (previousComponent != null) {
                _slotPositionComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveSlotPosition() {
            var component = slotPosition;
            RemoveComponent(ComponentIds.SlotPosition);
            _slotPositionComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherSlotPosition;

        public static IMatcher SlotPosition {
            get {
                if (_matcherSlotPosition == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.SlotPosition);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSlotPosition = matcher;
                }

                return _matcherSlotPosition;
            }
        }
    }
}
