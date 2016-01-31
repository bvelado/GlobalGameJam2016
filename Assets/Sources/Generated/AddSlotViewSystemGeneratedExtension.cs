namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddSlotViewSystem() {
            return this.CreateSystem<AddSlotViewSystem>();
        }
    }
}