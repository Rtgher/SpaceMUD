using SpaceMUD.Common.Interfaces;
using SpaceMUD.Common.Tools.Attributes.Parser;
using SpaceMUD.Common.Tools.Attributes.Parser.PropertyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Commands.Base
{
    public class CommandData
    {
        public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
        public List<string> UnspecifiedArguments { get; } = new List<string>();
        public List<string> AdverbValues { get; } = new List<string>();
        private static ILog Log = Dependency.DependencyContainer.Provider.GetService(typeof(ILog)) as ILog;

        protected static void ExtractData(dynamic data)
        {
            Type type = (Type)data.GetType();
            var members = type.GetProperties();
            var properties = from property in members
                             where Attribute.IsDefined(property, typeof(OrderAttribute)) 
                             orderby ((OrderAttribute)property
                                       .GetCustomAttributes(typeof(OrderAttribute), false)
                                       .Single()).Order ascending
                             select property;
            foreach (var memberInfo in properties)
            {
                string[] synonyms = null;
                try { 
                    synonyms = ((PartOfSpeechAttribute)memberInfo.GetCustomAttributes(typeof(PartOfSpeechAttribute), true).Single()).Synonyms;
                    synonyms = synonyms.Append(memberInfo.Name).ToArray();
                }
                catch (ArgumentNullException nE)
                {
                    Log.LogError($"The property '{memberInfo.Name}' in class '{type.Name}' did not have a correct PoS attribute assigned, although decorated with an Order, meaning it should. Perhaps an oversight?", nE);
                    throw;
                }
                string key = null;
                key = synonyms.FirstOrDefault(synonym => data.Values.ContainsKey(synonym.ToLowerInvariant()));
                if (key!=null)
                {
                    memberInfo.SetValue(data, data.Values[key]);
                    continue;
                }
                //in case of unspecified arguments, we assign them assuming their declaration order is the same as the order they were given (asc via ORDER attribute)
                if (data.UnspecifiedArguments.Count > 0)
                {
                    if (memberInfo.GetValue(data) == null)
                    {
                        memberInfo.SetValue(data,((List<string>) data.UnspecifiedArguments).First());
                        data.UnspecifiedArguments.Remove(((List<string>)data.UnspecifiedArguments).First<string>());
                        if (data.UnspecifiedArguments.Count == 0) break;
                    }
                }
            }
        }
    }
}
