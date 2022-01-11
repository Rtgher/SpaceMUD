using MUS.Common.Enums.Data.Functional;

namespace MUS.Entities.Trait.Functional.Base.IDo
{
    public interface IDoVulnerable
    {
        DamageType VulnerableToType { get; }
        float Modifier { get; }
    }
}