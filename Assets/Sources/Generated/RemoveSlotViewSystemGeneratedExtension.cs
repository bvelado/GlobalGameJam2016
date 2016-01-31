namespace Entitas {
    public partial class Pool {
        public ISystem CreateRemoveSlotViewSystem() {
            return this.CreateSystem<RemoveSlotViewSystem>();
        }
    }
}