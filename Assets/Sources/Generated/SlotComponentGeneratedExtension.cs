using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public SlotComponent slot { get { return (SlotComponent)GetComponent(ComponentIds.Slot); } }

        public bool hasSlot { get { return HasComponent(ComponentIds.Slot); } }

        static readonly Stack<SlotComponent> _slotComponentPool = new Stack<SlotComponent>();

        public static void ClearSlotComponentPool() {
            _slotComponentPool.Clear();
        }

        public Entity AddSlot(int newPosition, UnityEngine.GameObject newButton) {
            var component = _slotComponentPool.Count > 0 ? _slotComponentPool.Pop() : new SlotComponent();
            component.position = newPosition;
            component.button = newButton;
            return AddComponent(ComponentIds.Slot, component);
        }

        public Entity ReplaceSlot(int newPosition, UnityEngine.GameObject newButton) {
            var previousComponent = hasSlot ? slot : null;
            var component = _slotComponentPool.Count > 0 ? _slotComponentPool.Pop() : new SlotComponent();
            component.position = newPosition;
            component.button = newButton;
            ReplaceComponent(ComponentIds.Slot, component);
            if (previousComponent != null) {
                _slotComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveSlot() {
            var component = slot;
            RemoveComponent(ComponentIds.Slot);
            _slotComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherSlot;

        public static IMatcher Slot {
            get {
                if (_matcherSlot == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Slot);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSlot = matcher;
                }

                return _matcherSlot;
            }
        }
    }
}
