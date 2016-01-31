public static class ComponentIds {
    public const int Available = 0;
    public const int Destroy = 1;
    public const int Displayed = 2;
    public const int Empty = 3;
    public const int Fusable = 4;
    public const int Input = 5;
    public const int Interactable = 6;
    public const int Monster = 7;
    public const int RelativeSlotViewPosition = 8;
    public const int Resource = 9;
    public const int ScrollSlot = 10;
    public const int Slot = 11;
    public const int SlotManager = 12;
    public const int SlotPosition = 13;
    public const int SlotView = 14;
    public const int UpdateSlotView = 15;
    public const int View = 16;

    public const int TotalComponents = 17;

    public static readonly string[] componentNames = {
        "Available",
        "Destroy",
        "Displayed",
        "Empty",
        "Fusable",
        "Input",
        "Interactable",
        "Monster",
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
        typeof(InputComponent),
        typeof(InteractableComponent),
        typeof(MonsterComponent),
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