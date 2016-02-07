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
    public const int OneShotClip = 11;
    public const int ProcessFusion = 12;
    public const int RelativeSlotViewPosition = 13;
    public const int Resource = 14;
    public const int Running = 15;
    public const int ScrollSlot = 16;
    public const int Slot = 17;
    public const int SlotManager = 18;
    public const int SlotPosition = 19;
    public const int SlotView = 20;
    public const int SoundManager = 21;
    public const int Timer = 22;
    public const int TimerView = 23;
    public const int UpdateSlotView = 24;
    public const int View = 25;

    public const int TotalComponents = 26;

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
        "OneShotClip",
        "ProcessFusion",
        "RelativeSlotViewPosition",
        "Resource",
        "Running",
        "ScrollSlot",
        "Slot",
        "SlotManager",
        "SlotPosition",
        "SlotView",
        "SoundManager",
        "Timer",
        "TimerView",
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
        typeof(OneShotClipComponent),
        typeof(ProcessFusionComponent),
        typeof(RelativeSlotViewPositionComponent),
        typeof(ResourceComponent),
        typeof(RunningComponent),
        typeof(ScrollSlotComponent),
        typeof(SlotComponent),
        typeof(SlotManagerComponent),
        typeof(SlotPositionComponent),
        typeof(SlotViewComponent),
        typeof(SoundManagerComponent),
        typeof(TimerComponent),
        typeof(TimerViewComponent),
        typeof(UpdateSlotViewComponent),
        typeof(ViewComponent)
    };
}