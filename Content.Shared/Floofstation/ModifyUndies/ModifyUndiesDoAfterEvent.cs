using Content.Shared.DoAfter;
using Content.Shared.Humanoid.Markings;
using Robust.Shared.Serialization;

namespace Content.Shared.Floofstation;

[Serializable, NetSerializable]
public sealed partial class ModifyUndiesDoAfterEvent : DoAfterEvent
{
    /// <summary>
    ///     The marking prototype that is being modified.
    /// </summary>
    public Marking Marking;

    /// <summary>
    ///     Localized string for the marking prototype.
    /// </summary>
    public string MarkingPrototypeName;

    /// <summary>
    ///     Whether or not the marking is visible at the moment.
    /// </summary>
    public bool IsVisible;

    public ModifyUndiesDoAfterEvent(Marking marking, string markingPrototypeName, bool isVisible)
    {
        Marking = marking;
        MarkingPrototypeName = markingPrototypeName;
        IsVisible = isVisible;
    }

    public override DoAfterEvent Clone()
    {
        return this;
    }
}
