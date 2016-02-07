namespace Entitas {
    public partial class Pool {
        public ISystem CreateUpdateTimerViewSystem() {
            return this.CreateSystem<UpdateTimerViewSystem>();
        }
    }
}