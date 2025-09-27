using Content.Shared.Humanoid;
using Robust.Shared.Audio;
using Robust.Shared.GameStates;

namespace Content.Shared.Floofstation.ModifyUndies;

/// <summary>
/// Component that allows removing and adding underwear to humanoid entities through a verb.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class ModifyUndiesComponent : Component
{
    /// <summary>
    ///     The bodypart target enums for the undies.
    /// </summary>
    [DataField, AutoNetworkedField]
    public List<HumanoidVisualLayers> BodyPartTargets =
    [
        HumanoidVisualLayers.UndergarmentTop,
        HumanoidVisualLayers.UndergarmentBottom
    ];

    /// <summary>
    ///     The sound played when underwear is removed or added.
    /// </summary>
    [DataField, AutoNetworkedField]
    public SoundSpecifier Sound = new SoundPathSpecifier("/Audio/Effects/thudswoosh.ogg")
    {
        Params = new()
        {
            Variation = 0.5f,
            Volume = 0.5f
        }
    };
}
