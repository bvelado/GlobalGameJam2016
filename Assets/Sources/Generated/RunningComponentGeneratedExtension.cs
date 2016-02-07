namespace Entitas {
    public partial class Entity {
        static readonly RunningComponent runningComponent = new RunningComponent();

        public bool isRunning {
            get { return HasComponent(ComponentIds.Running); }
            set {
                if (value != isRunning) {
                    if (value) {
                        AddComponent(ComponentIds.Running, runningComponent);
                    } else {
                        RemoveComponent(ComponentIds.Running);
                    }
                }
            }
        }

        public Entity IsRunning(bool value) {
            isRunning = value;
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherRunning;

        public static IMatcher Running {
            get {
                if (_matcherRunning == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Running);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherRunning = matcher;
                }

                return _matcherRunning;
            }
        }
    }
}
