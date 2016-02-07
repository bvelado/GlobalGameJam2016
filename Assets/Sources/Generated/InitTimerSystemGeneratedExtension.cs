namespace Entitas {
    public partial class Pool {
        public ISystem CreateInitTimerSystem() {
            return this.CreateSystem<InitTimerSystem>();
        }
    }
}