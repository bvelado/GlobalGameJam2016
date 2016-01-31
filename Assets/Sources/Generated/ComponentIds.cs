public static class ComponentIds {
    public const int Available = 0;
    public const int Destroy = 1;
    public const int Displayed = 2;
    public const int Empty = 3;
    public const int Fusable = 4;
    public const int FusionManager = 5;
    public const int FusionPosition = 6;
    public const int FusionView = 7;
    public const int Input = 8;
    public const int Interactable = 9;
    public const int Monster = 10;
    public const int ProcessFusion = 11;
    public const int RelativeSlotViewPosition = 12;
    public const int Resource = 13;
    public const int ScrollSlot = 14;
    public const int Slot = 15;
    public const int SlotManager = 16;
    public const int SlotPosition = 17;
    public const int SlotView = 18;
    public const int UpdateSlotView = 19;
    public const int View = 20;

    public const int TotalComponents = 21;

    public static readonly string[] componentNames = {
        "Available",
        "Destroy",
        "Displayed",
        "Empty",
        "Fusable",
        "FusionManager",
        "FusionPosition",
        "FusionView",
        "Input",
        "Interactable",
        "Monster",
        "ProcessFusion",
        "RelativeSlotViewPosition",
        "Resource",
        "ScrollSlot",
        "Slot",
        "SlotManager",
        "SlotPosition",
        "SlotView",
        "UpdateSlotView",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(AvailableComponent),
        typeof(DestroyComponent),
        typeof(DisplayedComponent),
        typeof(EmptyComponent),
        typeof(FusableComponent),
        typeof(FusionManagerComponent),
        typeof(FusionPositionComponent),
        typeof(FusionViewComponent),
        typeof(InputComponent),
        typeof(InteractableComponent),
        typeof(MonsterComponent),
        typeof(ProcessFusionComponent),
        typeof(RelativeSlotViewPositionComponent),
        typeof(ResourceComponent),
        typeof(ScrollSlotComponent),
        typeof(SlotComponent),
        typeof(SlotManagerComponent),
        typeof(SlotPositionComponent),
        typeof(SlotViewComponent),
        typeof(UpdateSlotViewComponent),
        typeof(ViewComponent)
    };
}