namespace Entitas {
    public partial class Entity {
        static readonly FusableComponent fusableComponent = new FusableComponent();

        public bool isFusable {
            get { return HasComponent(ComponentIds.Fusable); }
            set {
                if (value != isFusable) {
                    if (value) {
                        AddComponent(ComponentIds.Fusable, fusableComponent);
                    } else {
                        RemoveComponent(ComponentIds.Fusable);
                    }
                }
            }
        }

        public Entity IsFusable(bool value) {
            isFusable = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherFusable;

        public static IMatcher Fusable {
            get {
                if (_matcherFusable == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Fusable);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherFusable = matcher;
                }

                return _matcherFusable;
            }
        }
    }
}
