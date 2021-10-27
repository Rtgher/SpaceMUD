﻿using SpaceMUD.Common.Enums.Data.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Common.Enums.Parser;

namespace SpaceMUD.Common.Tools.Attributes.Parser
{
    /// <summary>
    /// Declares the decorated class as a verb.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
    public class VerbAttribute : PartOfSpeechAttribute
    {
        public TargetType TargetType;

        public VerbAttribute(TargetType target, params string[] synonyms) : base(WordTypeEnum.Verb,synonyms)
        {
            TargetType = target;
        }
    }
}
