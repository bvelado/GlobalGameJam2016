using Entitas;
using Entitas.CodeGenerator;
using System.Collections.Generic;

[SingleEntity]
public class FusionManagerComponent : IComponent {
    public Dictionary<int, int[]> recipes; 
}
