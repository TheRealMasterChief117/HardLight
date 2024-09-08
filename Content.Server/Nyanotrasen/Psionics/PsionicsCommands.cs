using Content.Server.Administration;
using Content.Shared.Administration;
using Content.Shared.Abilities.Psionics;
using Content.Shared.Mobs.Components;
using Robust.Shared.Console;
using Robust.Server.GameObjects;
using Content.Shared.Actions;
using Robust.Shared.Player;
using Content.Server.Abilities.Psionics;
using Robust.Shared.Prototypes;
using Content.Shared.Psionics;

namespace Content.Server.Psionics;

[AdminCommand(AdminFlags.Logs)]
public sealed class ListPsionicsCommand : IConsoleCommand
{
    public string Command => "lspsionics";
    public string Description => Loc.GetString("command-lspsionic-description");
    public string Help => Loc.GetString("command-lspsionic-help");
    public async void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        SharedActionsSystem actions = default!;
        var entMan = IoCManager.Resolve<IEntityManager>();
        foreach (var (actor, mob, psionic, meta) in entMan.EntityQuery<ActorComponent, MobStateComponent, PsionicComponent, MetaDataComponent>()){
            // filter out xenos, etc, with innate telepathy
            actions.TryGetActionData( psionic.PsionicAbility, out var actionData );
            if (actionData == null || actionData.ToString() == null)
                return;

            var psiPowerName = actionData.ToString();
            if (psiPowerName == null)
                return;

            shell.WriteLine(meta.EntityName + " (" + meta.Owner + ") - " + actor.PlayerSession.Name + Loc.GetString(psiPowerName));
        }
    }
}

[AdminCommand(AdminFlags.Fun)]
public sealed class AddPsionicPowerCommand : IConsoleCommand
{
    public string Command => "addpsionicpower";
    public string Description => Loc.GetString("command-addpsionicpower-description");
    public string Help => Loc.GetString("command-addpsionicpower-help");
    public async void Execute(IConsoleShell shell, string argStr, string[] args)
    {
        var entMan = IoCManager.Resolve<IEntityManager>();
        var psionicPowers = IoCManager.Resolve<PsionicAbilitiesSystem>();
        var protoMan = IoCManager.Resolve<IPrototypeManager>();

        if (args.Length != 2)
        {
            shell.WriteError(Loc.GetString("shell-need-exactly-one-argument"));
            return;
        }

        if (!EntityUid.TryParse(args[0], out var uid))
        {
            shell.WriteError(Loc.GetString("addpsionicpower-args-one-error"));
            return;
        }

        if (!protoMan.TryIndex<PsionicPowerPrototype>(args[1], out var powerProto))
        {
            shell.WriteError(Loc.GetString("addpsionicpower-args-two-error"));
            return;
        }

        entMan.EnsureComponent<PsionicComponent>(uid, out var psionic);
        psionicPowers.InitializePsionicPower(uid, powerProto, psionic);
    }
}
