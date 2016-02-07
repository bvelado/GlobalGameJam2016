using Entitas;
using Entitas.CodeGenerator;

[SingleEntity]
public class TimerComponent : IComponent {
    public float secondsLeft;
}
