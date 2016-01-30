namespace Entitas {
    public partial class Pool {
        public ISystem CreateCreateMonstersSystem() {
            return this.CreateSystem<CreateMonstersSystem>();
        }
    }
}