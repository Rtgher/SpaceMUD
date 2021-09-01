using SpaceMUD.Common.Enums.Data.Functional;

namespace SpaceMUD.Entities.Trait.Functional.Base.IDo
{
    public interface IDoVulnerable
    {
        DamageType VulnerableToType { get; }
        float Modifier { get; }
    }
}