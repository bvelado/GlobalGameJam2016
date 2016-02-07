using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public TimerComponent timer { get { return (TimerComponent)GetComponent(ComponentIds.Timer); } }

        public bool hasTimer { get { return HasComponent(ComponentIds.Timer); } }

        static readonly Stack<TimerComponent> _timerComponentPool = new Stack<TimerComponent>();

        public static void ClearTimerComponentPool() {
            _timerComponentPool.Clear();
        }

        public Entity AddTimer(float newSecondsLeft) {
            var component = _timerComponentPool.Count > 0 ? _timerComponentPool.Pop() : new TimerComponent();
            component.secondsLeft = newSecondsLeft;
            return AddComponent(ComponentIds.Timer, component);
        }

        public Entity ReplaceTimer(float newSecondsLeft) {
            var previousComponent = hasTimer ? timer : null;
            var component = _timerComponentPool.Count > 0 ? _timerComponentPool.Pop() : new TimerComponent();
            component.secondsLeft = newSecondsLeft;
            ReplaceComponent(ComponentIds.Timer, component);
            if (previousComponent != null) {
                _timerComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveTimer() {
            var component = timer;
            RemoveComponent(ComponentIds.Timer);
            _timerComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity timerEntity { get { return GetGroup(Matcher.Timer).GetSingleEntity(); } }

        public TimerComponent timer { get { return timerEntity.timer; } }

        public bool hasTimer { get { return timerEntity != null; } }

        public Entity SetTimer(float newSecondsLeft) {
            if (hasTimer) {
                throw new EntitasException("Could not set timer!\n" + this + " already has an entity with TimerComponent!",
                    "You should check if the pool already has a timerEntity before setting it or use pool.ReplaceTimer().");
            }
            var entity = CreateEntity();
            entity.AddTimer(newSecondsLeft);
            return entity;
        }

        public Entity ReplaceTimer(float newSecondsLeft) {
            var entity = timerEntity;
            if (entity == null) {
                entity = SetTimer(newSecondsLeft);
            } else {
                entity.ReplaceTimer(newSecondsLeft);
            }

            return entity;
        }

        public void RemoveTimer() {
            DestroyEntity(timerEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTimer;

        public static IMatcher Timer {
            get {
                if (_matcherTimer == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Timer);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTimer = matcher;
                }

                return _matcherTimer;
            }
        }
    }
}
