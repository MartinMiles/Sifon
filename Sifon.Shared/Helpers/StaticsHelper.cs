using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sifon.Shared.Helpers
{
    internal static class StaticsHelper
    {
        private static Type _passedType;
        private static readonly Lazy<Dictionary<string, string>> ConstantsDictionary = new Lazy<Dictionary<string, string>>(CreateDictionary);

        internal static Dictionary<string, string> AsDictionary(Type type)
        {
            _passedType = type;
            return ConstantsDictionary.Value;
        }

        private static Dictionary<string, string> CreateDictionary()
        {
            var fields = _passedType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            var constants = fields.Where(f => f.IsLiteral && !f.IsInitOnly).ToList();
            var result = new Dictionary<string, string>();
            constants.ForEach(constant => result.Add(constant.Name, constant.GetValue(null).ToString()));
            return result;
        }
    }
}
