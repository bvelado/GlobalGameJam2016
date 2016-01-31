using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public FusionViewComponent fusionView { get { return (FusionViewComponent)GetComponent(ComponentIds.FusionView); } }

        public bool hasFusionView { get { return HasComponent(ComponentIds.FusionView); } }

        static readonly Stack<FusionViewComponent> _fusionViewComponentPool = new Stack<FusionViewComponent>();

        public static void ClearFusionViewComponentPool() {
            _fusionViewComponentPool.Clear();
        }

        public Entity AddFusionView(UnityEngine.GameObject newView) {
            var component = _fusionViewComponentPool.Count > 0 ? _fusionViewComponentPool.Pop() : new FusionViewComponent();
            component.view = newView;
            return AddComponent(ComponentIds.FusionView, component);
        }

        public Entity ReplaceFusionView(UnityEngine.GameObject newView) {
            var previousComponent = hasFusionView ? fusionView : null;
            var component = _fusionViewComponentPool.Count > 0 ? _fusionViewComponentPool.Pop() : new FusionViewComponent();
            component.view = newView;
            ReplaceComponent(ComponentIds.FusionView, component);
            if (previousComponent != null) {
                _fusionViewComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveFusionView() {
            var component = fusionView;
            RemoveComponent(ComponentIds.FusionView);
            _fusionViewComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherFusionView;

        public static IMatcher FusionView {
            get {
                if (_matcherFusionView == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.FusionView);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherFusionView = matcher;
                }

                return _matcherFusionView;
            }
        }
    }
}
