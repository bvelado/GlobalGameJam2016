namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddSlotPositionSystem() {
            return this.CreateSystem<AddSlotPositionSystem>();
        }
    }
}