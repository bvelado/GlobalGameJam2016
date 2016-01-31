using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public ScrollSlotComponent scrollSlot { get { return (ScrollSlotComponent)GetComponent(ComponentIds.ScrollSlot); } }

        public bool hasScrollSlot { get { return HasComponent(ComponentIds.ScrollSlot); } }

        static readonly Stack<ScrollSlotComponent> _scrollSlotComponentPool = new Stack<ScrollSlotComponent>();

        public static void ClearScrollSlotComponentPool() {
            _scrollSlotComponentPool.Clear();
        }

        public Entity AddScrollSlot(bool newScrollRight) {
            var component = _scrollSlotComponentPool.Count > 0 ? _scrollSlotComponentPool.Pop() : new ScrollSlotComponent();
            component.scrollRight = newScrollRight;
            return AddComponent(ComponentIds.ScrollSlot, component);
        }

        public Entity ReplaceScrollSlot(bool newScrollRight) {
            var previousComponent = hasScrollSlot ? scrollSlot : null;
            var component = _scrollSlotComponentPool.Count > 0 ? _scrollSlotComponentPool.Pop() : new ScrollSlotComponent();
            component.scrollRight = newScrollRight;
            ReplaceComponent(ComponentIds.ScrollSlot, component);
            if (previousComponent != null) {
                _scrollSlotComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveScrollSlot() {
            var component = scrollSlot;
            RemoveComponent(ComponentIds.ScrollSlot);
            _scrollSlotComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherScrollSlot;

        public static IMatcher ScrollSlot {
            get {
                if (_matcherScrollSlot == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.ScrollSlot);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherScrollSlot = matcher;
                }

                return _matcherScrollSlot;
            }
        }
    }
}
