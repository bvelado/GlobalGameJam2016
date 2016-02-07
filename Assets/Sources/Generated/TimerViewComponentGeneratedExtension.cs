using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public TimerViewComponent timerView { get { return (TimerViewComponent)GetComponent(ComponentIds.TimerView); } }

        public bool hasTimerView { get { return HasComponent(ComponentIds.TimerView); } }

        static readonly Stack<TimerViewComponent> _timerViewComponentPool = new Stack<TimerViewComponent>();

        public static void ClearTimerViewComponentPool() {
            _timerViewComponentPool.Clear();
        }

        public Entity AddTimerView(UnityEngine.GameObject newView) {
            var component = _timerViewComponentPool.Count > 0 ? _timerViewComponentPool.Pop() : new TimerViewComponent();
            component.view = newView;
            return AddComponent(ComponentIds.TimerView, component);
        }

        public Entity ReplaceTimerView(UnityEngine.GameObject newView) {
            var previousComponent = hasTimerView ? timerView : null;
            var component = _timerViewComponentPool.Count > 0 ? _timerViewComponentPool.Pop() : new TimerViewComponent();
            component.view = newView;
            ReplaceComponent(ComponentIds.TimerView, component);
            if (previousComponent != null) {
                _timerViewComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveTimerView() {
            var component = timerView;
            RemoveComponent(ComponentIds.TimerView);
            _timerViewComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTimerView;

        public static IMatcher TimerView {
            get {
                if (_matcherTimerView == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TimerView);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTimerView = matcher;
                }

                return _matcherTimerView;
            }
        }
    }
}
