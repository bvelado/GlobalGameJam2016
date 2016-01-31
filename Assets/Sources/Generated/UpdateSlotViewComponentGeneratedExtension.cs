namespace Entitas {
    public partial class Entity {
        static readonly UpdateSlotViewComponent updateSlotViewComponent = new UpdateSlotViewComponent();

        public bool isUpdateSlotView {
            get { return HasComponent(ComponentIds.UpdateSlotView); }
            set {
                if (value != isUpdateSlotView) {
                    if (value) {
                        AddComponent(ComponentIds.UpdateSlotView, updateSlotViewComponent);
                    } else {
                        RemoveComponent(ComponentIds.UpdateSlotView);
                    }
                }
            }
        }

        public Entity IsUpdateSlotView(bool value) {
            isUpdateSlotView = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherUpdateSlotView;

        public static IMatcher UpdateSlotView {
            get {
                if (_matcherUpdateSlotView == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.UpdateSlotView);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherUpdateSlotView = matcher;
                }

                return _matcherUpdateSlotView;
            }
        }
    }
}
