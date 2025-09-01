using Robust.Shared.GameStates;

namespace Content.Shared.Abilities.Psionics
{
    /// <summary>
    ///     Component for entities that are psionic familiars.
    /// </summary>
    [RegisterComponent, NetworkedComponent]
    public sealed partial class PsionicFamiliarComponent : Component
    {
        /// <summary>
        ///     The entity that summoned this familiar.
        /// </summary>
        [DataField("master")]
        public EntityUid? Master = null;

        /// <summary>
        ///     Whether the familiar can be controlled by the master.
        /// </summary>
        [DataField("controllable")]
        public bool Controllable = true;

        /// <summary>
        ///     Maximum distance the familiar can be from its master.
        /// </summary>
        [DataField("maxDistance")]
        public float MaxDistance = 15.0f;

        /// <summary>
        ///     Whether the familiar will automatically return to the master if too far away.
        /// </summary>
        [DataField("autoReturn")]
        public bool AutoReturn = true;
    }
}
