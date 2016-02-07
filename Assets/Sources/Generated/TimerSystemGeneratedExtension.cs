namespace Entitas {
    public partial class Pool {
        public ISystem CreateTimerSystem() {
            return this.CreateSystem<TimerSystem>();
        }
    }
}