namespace Entitas {
    public partial class Pool {
        public ISystem CreateRenderSlotsSystem() {
            return this.CreateSystem<RenderSlotsSystem>();
        }
    }
}