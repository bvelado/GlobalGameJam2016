namespace Entitas {
    public partial class Entity {
        static readonly EmptyComponent emptyComponent = new EmptyComponent();

        public bool isEmpty {
            get { return HasComponent(ComponentIds.Empty); }
            set {
                if (value != isEmpty) {
                    if (value) {
                        AddComponent(ComponentIds.Empty, emptyComponent);
                    } else {
                        RemoveComponent(ComponentIds.Empty);
                    }
                }
            }
        }

        public Entity IsEmpty(bool value) {
            isEmpty = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherEmpty;

        public static IMatcher Empty {
            get {
                if (_matcherEmpty == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Empty);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherEmpty = matcher;
                }

                return _matcherEmpty;
            }
        }
    }
}
