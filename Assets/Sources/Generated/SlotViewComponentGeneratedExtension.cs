using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public SlotViewComponent slotView { get { return (SlotViewComponent)GetComponent(ComponentIds.SlotView); } }

        public bool hasSlotView { get { return HasComponent(ComponentIds.SlotView); } }

        static readonly Stack<SlotViewComponent> _slotViewComponentPool = new Stack<SlotViewComponent>();

        public static void ClearSlotViewComponentPool() {
            _slotViewComponentPool.Clear();
        }

        public Entity AddSlotView(UnityEngine.GameObject newView) {
            var component = _slotViewComponentPool.Count > 0 ? _slotViewComponentPool.Pop() : new SlotViewComponent();
            component.view = newView;
            return AddComponent(ComponentIds.SlotView, component);
        }

        public Entity ReplaceSlotView(UnityEngine.GameObject newView) {
            var previousComponent = hasSlotView ? slotView : null;
            var component = _slotViewComponentPool.Count > 0 ? _slotViewComponentPool.Pop() : new SlotViewComponent();
            component.view = newView;
            ReplaceComponent(ComponentIds.SlotView, component);
            if (previousComponent != null) {
                _slotViewComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveSlotView() {
            var component = slotView;
            RemoveComponent(ComponentIds.SlotView);
            _slotViewComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherSlotView;

        public static IMatcher SlotView {
            get {
                if (_matcherSlotView == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.SlotView);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSlotView = matcher;
                }

                return _matcherSlotView;
            }
        }
    }
}
