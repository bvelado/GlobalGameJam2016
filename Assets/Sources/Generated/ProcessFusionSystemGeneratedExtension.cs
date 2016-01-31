namespace Entitas {
    public partial class Pool {
        public ISystem CreateProcessFusionSystem() {
            return this.CreateSystem<ProcessFusionSystem>();
        }
    }
}