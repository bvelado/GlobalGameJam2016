namespace Entitas {
    public partial class Pool {
        public ISystem CreateAddFusionViewSystem() {
            return this.CreateSystem<AddFusionViewSystem>();
        }
    }
}