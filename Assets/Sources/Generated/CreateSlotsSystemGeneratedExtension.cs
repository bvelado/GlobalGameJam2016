namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateSlotsSystem() {
            return this.CreateSystem<CreateSlotsSystem>();
        }
    }
}