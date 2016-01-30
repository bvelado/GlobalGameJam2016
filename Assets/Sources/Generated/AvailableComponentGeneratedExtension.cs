namespace Entitas {
    public partial class Entity {
        static readonly AvailableComponent availableComponent = new AvailableComponent();

        public bool isAvailable {
            get { return HasComponent(ComponentIds.Available); }
            set {
                if (value != isAvailable) {
                    if (value) {
                        AddComponent(ComponentIds.Available, availableComponent);
                    } else {
                        RemoveComponent(ComponentIds.Available);
                    }
                }
            }
        }

        public Entity IsAvailable(bool value) {
            isAvailable = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherAvailable;

        public static IMatcher Available {
            get {
                if (_matcherAvailable == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Available);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherAvailable = matcher;
                }

                return _matcherAvailable;
            }
        }
    }
}
