namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddSlotView() {
            return this.CreateSystem<AddSlotView>();
        }
    }
}