namespace Entitas {
    public partial class Pool {
        public ISystem CreateInitSoundManagerSystem() {
            return this.CreateSystem<InitSoundManagerSystem>();
        }
    }
}