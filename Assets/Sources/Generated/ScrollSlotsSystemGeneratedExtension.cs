namespace Entitas {
    public partial class Pool {
        public ISystem CreateScrollSlotsSystem() {
            return this.CreateSystem<ScrollSlotsSystem>();
        }
    }
}