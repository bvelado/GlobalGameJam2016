namespace Entitas {
    public partial class Pool {
        public ISystem CreateDisplayCurrentAvailableMonstersSystem() {
            return this.CreateSystem<DisplayCurrentAvailableMonstersSystem>();
        }
    }
}