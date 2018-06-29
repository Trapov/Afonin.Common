using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Afonin.Common.PrototypeParadigm
{
    public class Binder : DynamicObject
    {
        private readonly object _decorated;
        private readonly object _context;

        public Binder(Func<object> decorated, Func<object> context)
        {
            _decorated = decorated.Invoke();
            _context = context.Invoke();
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var merged = (IDictionary<string, object>) Merge(_decorated, _context);
            return (result = (merged[binder.Name] as Delegate).DynamicInvoke(args)) != null;
        }

        public static dynamic Merge(object item1, object item2)
        {
            if (item1 == null || item2 == null)
                return item1 ?? item2 ?? new ExpandoObject();

            dynamic expando = new ExpandoObject();
            var result = expando as IDictionary<string, object>;

            Dictionary<string, object> prpt1;
            if (item1 is ExpandoObject expandoObject)
            {
                prpt1 = expandoObject.ToDictionary(pairs => pairs.Key, pairs => pairs.Value);
            }
            else
            {
                var prt = item1.GetType().GetProperties();
                prpt1 = prt.GetType().GetProperties().ToDictionary(info => info.Name, info => info.GetValue(item1, null));
            }

            foreach (var fi in prpt1)
                result[fi.Key] = fi.Value;

            Dictionary<string, object> prpt2;
            if (item2 is ExpandoObject expandoObject2)
            {
                prpt2 = expandoObject2.ToDictionary(pairs => pairs.Key, pairs => pairs.Value);
            }
            else
            {
                var prt = item2.GetType().GetProperties();
                prpt2 = prt.ToDictionary(info => info.Name, info => info.GetValue(item2, null));
            }

            foreach (var fi in prpt2)
                result[fi.Key] = fi.Value;

            return result;
        }
    }
}