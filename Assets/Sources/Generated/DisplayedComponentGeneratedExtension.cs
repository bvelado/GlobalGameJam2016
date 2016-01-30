namespace Entitas {
    public partial class Entity {
        static readonly DisplayedComponent displayedComponent = new DisplayedComponent();

        public bool isDisplayed {
            get { return HasComponent(ComponentIds.Displayed); }
            set {
                if (value != isDisplayed) {
                    if (value) {
                        AddComponent(ComponentIds.Displayed, displayedComponent);
                    } else {
                        RemoveComponent(ComponentIds.Displayed);
                    }
                }
            }
        }

        public Entity IsDisplayed(bool value) {
            isDisplayed = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherDisplayed;

        public static IMatcher Displayed {
            get {
                if (_matcherDisplayed == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Displayed);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherDisplayed = matcher;
                }

                return _matcherDisplayed;
            }
        }
    }
}
