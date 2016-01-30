namespace Entitas {
    public partial class Pool {
        public ISystem CreateTestInitSystem() {
            return this.CreateSystem<TestInitSystem>();
        }
    }
}