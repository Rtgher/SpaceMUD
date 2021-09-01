using SpaceMUD.Common.Enums.Data.Functional;


namespace SpaceMUD.Entities.Trait.Descriptive.Base.IDo
{
    /// <summary>
    /// Runs on the idea that whatever implements IAmmo runs almost as a sort of magazine.
    /// </summary>
    public interface IAmmo
    {
        /// <summary>
        /// The maximum ammo available to the Magazin/ammo pack.
        /// </summary>
        int MaxAmmo { get; }
        /// <summary>
        /// The current amount of 'bullets' available to the magazine.
        /// </summary>
        int CurrentAmmo { get; set; }
    }
}
