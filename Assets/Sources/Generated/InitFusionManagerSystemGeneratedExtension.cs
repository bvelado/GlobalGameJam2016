namespace Entitas {
    public partial class Pool {
        public ISystem CreateInitFusionManagerSystem() {
            return this.CreateSystem<InitFusionManagerSystem>();
        }
    }
}