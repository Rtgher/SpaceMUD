﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Commands.Base
{
    public class CommandData
    {
        public Dictionary<string, string> Values { get; set; }

        protected void ExtractData(dynamic processedData)
        {
            var members = ((Type)processedData.GetType()).GetProperties(System.Reflection.BindingFlags.SetProperty);

            foreach (var pair in Values)
            {
                foreach (var memberInfo in members)
                {
                    if (pair.Key.Equals(memberInfo.Name, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        memberInfo.SetValue(processedData, pair.Value);
                        break;
                    }
                }
            }
        }
    }
}
