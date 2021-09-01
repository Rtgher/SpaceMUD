using System;

namespace SpaceMUD.Common.Tools.Attributes
{
    internal class CreditAttribute : Attribute
    {
        private string _name;
        private string _url;

        public CreditAttribute(string name, string url)
        {
            _name = name;
            _url = url;
        }
    }
}