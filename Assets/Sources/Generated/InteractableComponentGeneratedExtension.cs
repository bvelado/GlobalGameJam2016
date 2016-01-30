namespace Entitas {
    public partial class Entity {
        static readonly InteractableComponent interactableComponent = new InteractableComponent();

        public bool isInteractable {
            get { return HasComponent(ComponentIds.Interactable); }
            set {
                if (value != isInteractable) {
                    if (value) {
                        AddComponent(ComponentIds.Interactable, interactableComponent);
                    } else {
                        RemoveComponent(ComponentIds.Interactable);
                    }
                }
            }
        }

        public Entity IsInteractable(bool value) {
            isInteractable = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherInteractable;

        public static IMatcher Interactable {
            get {
                if (_matcherInteractable == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Interactable);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherInteractable = matcher;
                }

                return _matcherInteractable;
            }
        }
    }
}
