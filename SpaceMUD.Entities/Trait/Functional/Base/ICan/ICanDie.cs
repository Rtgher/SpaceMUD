﻿using SpaceMUD.Entities.Trait.Functional.Base.IDo;


namespace SpaceMUD.Entities.Trait.Functional.Base.ICan
{
    public interface ICanDie 
    {
        IDoDie DoDie { get; }
    }
}
