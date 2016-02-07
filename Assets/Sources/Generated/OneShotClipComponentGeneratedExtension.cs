namespace Entitas {
    public partial class Entity {
        static readonly OneShotClipComponent oneShotClipComponent = new OneShotClipComponent();

        public bool isOneShotClip {
            get { return HasComponent(ComponentIds.OneShotClip); }
            set {
                if (value != isOneShotClip) {
                    if (value) {
                        AddComponent(ComponentIds.OneShotClip, oneShotClipComponent);
                    } else {
                        RemoveComponent(ComponentIds.OneShotClip);
                    }
                }
            }
        }

        public Entity IsOneShotClip(bool value) {
            isOneShotClip = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherOneShotClip;

        public static IMatcher OneShotClip {
            get {
                if (_matcherOneShotClip == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.OneShotClip);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherOneShotClip = matcher;
                }

                return _matcherOneShotClip;
            }
        }
    }
}
