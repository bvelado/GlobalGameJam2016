using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public SlotManagerComponent slotManager { get { return (SlotManagerComponent)GetComponent(ComponentIds.SlotManager); } }

        public bool hasSlotManager { get { return HasComponent(ComponentIds.SlotManager); } }

        static readonly Stack<SlotManagerComponent> _slotManagerComponentPool = new Stack<SlotManagerComponent>();

        public static void ClearSlotManagerComponentPool() {
            _slotManagerComponentPool.Clear();
        }

        public Entity AddSlotManager(int newMinDisplayedPosition) {
            var component = _slotManagerComponentPool.Count > 0 ? _slotManagerComponentPool.Pop() : new SlotManagerComponent();
            component.minDisplayedPosition = newMinDisplayedPosition;
            return AddComponent(ComponentIds.SlotManager, component);
        }

        public Entity ReplaceSlotManager(int newMinDisplayedPosition) {
            var previousComponent = hasSlotManager ? slotManager : null;
            var component = _slotManagerComponentPool.Count > 0 ? _slotManagerComponentPool.Pop() : new SlotManagerComponent();
            component.minDisplayedPosition = newMinDisplayedPosition;
            ReplaceComponent(ComponentIds.SlotManager, component);
            if (previousComponent != null) {
                _slotManagerComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveSlotManager() {
            var component = slotManager;
            RemoveComponent(ComponentIds.SlotManager);
            _slotManagerComponentPool.Push(component);
            return this;
        }
    }

    public partial class Pool {
        public Entity slotManagerEntity { get { return GetGroup(Matcher.SlotManager).GetSingleEntity(); } }

        public SlotManagerComponent slotManager { get { return slotManagerEntity.slotManager; } }

        public bool hasSlotManager { get { return slotManagerEntity != null; } }

        public Entity SetSlotManager(int newMinDisplayedPosition) {
            if (hasSlotManager) {
                throw new EntitasException("Could not set slotManager!\n" + this + " already has an entity with SlotManagerComponent!",
                    "You should check if the pool already has a slotManagerEntity before setting it or use pool.ReplaceSlotManager().");
            }
            var entity = CreateEntity();
            entity.AddSlotManager(newMinDisplayedPosition);
            return entity;
        }

        public Entity ReplaceSlotManager(int newMinDisplayedPosition) {
            var entity = slotManagerEntity;
            if (entity == null) {
                entity = SetSlotManager(newMinDisplayedPosition);
            } else {
                entity.ReplaceSlotManager(newMinDisplayedPosition);
            }

            return entity;
        }

        public void RemoveSlotManager() {
            DestroyEntity(slotManagerEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherSlotManager;

        public static IMatcher SlotManager {
            get {
                if (_matcherSlotManager == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.SlotManager);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSlotManager = matcher;
                }

                return _matcherSlotManager;
            }
        }
    }
}
