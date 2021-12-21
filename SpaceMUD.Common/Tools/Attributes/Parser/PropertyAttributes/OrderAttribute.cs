using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Tools.Attributes.Parser.PropertyAttributes
{
    [Credit("ghord", "https://stackoverflow.com/questions/9062235/get-properties-in-order-of-declaration-using-reflection")]
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute
    {
        private readonly int order_;
        public OrderAttribute([CallerLineNumber]int order = 0)
        {
            order_ = order;
        }

        public int Order { get { return order_; } }
    }
}
