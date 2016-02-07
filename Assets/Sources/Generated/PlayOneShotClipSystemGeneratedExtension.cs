namespace Entitas {
    public partial class Pool {
        public ISystem CreatePlayOneShotClipSystem() {
            return this.CreateSystem<PlayOneShotClipSystem>();
        }
    }
}