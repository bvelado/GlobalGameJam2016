namespace Entitas {
    public partial class Pool {
        public ISystem CreateMoveSlotViewSystem() {
            return this.CreateSystem<MoveSlotViewSystem>();
        }
    }
}