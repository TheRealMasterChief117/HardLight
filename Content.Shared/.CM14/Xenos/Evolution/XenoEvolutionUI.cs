using System;
using Robust.Shared.Serialization;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;
using Robust.Shared.Player;
using Content.Shared.UserInterface;
using Content.Shared.Actions;

namespace Content.Shared.CM14.Xenos.Evolution;

// UI key used by shared evolution UI
public enum XenoEvolutionUIKey : byte { Key }

// Messages for the evolution BUI
public sealed class EvolveBuiMessage : BoundUserInterfaceMessage
{
    public required int Choice { get; init; }
}

// Action event to open the evolution UI
public sealed partial class XenoOpenEvolutionsEvent : InstantActionEvent
{
}
