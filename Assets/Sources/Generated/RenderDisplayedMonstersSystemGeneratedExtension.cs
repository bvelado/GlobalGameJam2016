namespace Entitas {
    public partial class Pool {
        public ISystem CreateRenderDisplayedMonstersSystem() {
            return this.CreateSystem<RenderDisplayedMonstersSystem>();
        }
    }
}