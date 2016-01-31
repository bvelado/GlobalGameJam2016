namespace Entitas {
    public partial class Pool {
        public ISystem CreateUpdateSlotViewSystem() {
            return this.CreateSystem<UpdateSlotViewSystem>();
        }
    }
}