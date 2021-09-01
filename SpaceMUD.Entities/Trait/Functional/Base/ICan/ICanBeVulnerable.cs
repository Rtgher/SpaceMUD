using SpaceMUD.Entities.Trait.Functional.Base.IDo;
using System.Collections.Generic;


namespace SpaceMUD.Entities.Trait.Functional.Base.ICan
{
    public interface ICanBeVulnerable
    {
        IList<IDoVulnerable> Vulnerabilities { get; }
    }
}
