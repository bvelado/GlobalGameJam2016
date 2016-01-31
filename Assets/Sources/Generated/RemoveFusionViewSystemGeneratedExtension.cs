namespace Entitas {
    public partial class Pool {
        public ISystem CreateRemoveFusionViewSystem() {
            return this.CreateSystem<RemoveFusionViewSystem>();
        }
    }
}