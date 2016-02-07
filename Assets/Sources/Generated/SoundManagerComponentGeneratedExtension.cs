using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public SoundManagerComponent soundManager { get { return (SoundManagerComponent)GetComponent(ComponentIds.SoundManager); } }

        public bool hasSoundManager { get { return HasComponent(ComponentIds.SoundManager); } }

        static readonly Stack<SoundManagerComponent> _soundManagerComponentPool = new Stack<SoundManagerComponent>();

        public static void ClearSoundManagerComponentPool() {
            _soundManagerComponentPool.Clear();
        }

        public Entity AddSoundManager(UnityEngine.GameObject newManager) {
            var component = _soundManagerComponentPool.Count > 0 ? _soundManagerComponentPool.Pop() : new SoundManagerComponent();
            component.manager = newManager;
            return AddComponent(ComponentIds.SoundManager, component);
        }

        public Entity ReplaceSoundManager(UnityEngine.GameObject newManager) {
            var previousComponent = hasSoundManager ? soundManager : null;
            var component = _soundManagerComponentPool.Count > 0 ? _soundManagerComponentPool.Pop() : new SoundManagerComponent();
            component.manager = newManager;
            ReplaceComponent(ComponentIds.SoundManager, component);
            if (previousComponent != null) {
                _soundManagerComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveSoundManager() {
            var component = soundManager;
            RemoveComponent(ComponentIds.SoundManager);
            _soundManagerComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity soundManagerEntity { get { return GetGroup(Matcher.SoundManager).GetSingleEntity(); } }

        public SoundManagerComponent soundManager { get { return soundManagerEntity.soundManager; } }

        public bool hasSoundManager { get { return soundManagerEntity != null; } }

        public Entity SetSoundManager(UnityEngine.GameObject newManager) {
            if (hasSoundManager) {
                throw new EntitasException("Could not set soundManager!\n" + this + " already has an entity with SoundManagerComponent!",
                    "You should check if the pool already has a soundManagerEntity before setting it or use pool.ReplaceSoundManager().");
            }
            var entity = CreateEntity();
            entity.AddSoundManager(newManager);
            return entity;
        }

        public Entity ReplaceSoundManager(UnityEngine.GameObject newManager) {
            var entity = soundManagerEntity;
            if (entity == null) {
                entity = SetSoundManager(newManager);
            } else {
                entity.ReplaceSoundManager(newManager);
            }

            return entity;
        }

        public void RemoveSoundManager() {
            DestroyEntity(soundManagerEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherSoundManager;

        public static IMatcher SoundManager {
            get {
                if (_matcherSoundManager == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.SoundManager);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSoundManager = matcher;
                }

                return _matcherSoundManager;
            }
        }
    }
}
