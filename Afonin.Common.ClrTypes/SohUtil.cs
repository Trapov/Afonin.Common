using System;
using System.Collections.Generic;

using System.Runtime.CLR;

namespace Afonin.Common.ClrTypes
{
    public static class SohUtil
    {
        public class SohEnumeratorItem
        {
            public object Item;
            public bool IsArrayItem;
        }

        public static IEnumerable<SohEnumeratorItem> GetObjectsInSoh(object starting, object last,
            Predicate<long> checker)
        {
            var current = starting;
            var enumItem = new SohEnumeratorItem();

            while (TryGetNextInSoh(current, checker, out current))
            {
                enumItem.Item = current;
                yield return enumItem;

                if (current is Array array &&
                    !(array.GetType().GetElementType() ??
                      throw new ArgumentNullException($"Element type of {array} is null")).IsValueType)
                {
                    enumItem.IsArrayItem = true;
                    foreach (var item in array)
                    {
                        enumItem.Item = item;
                        if (item != null)
                        {
                            yield return enumItem;
                        }
                    }

                    enumItem.IsArrayItem = false;
                }

                if (current == last)
                    yield break;
            }
        }

        private static unsafe bool TryGetNextInSoh(object current, Predicate<long> checker, out object nextObject)
        {
            nextObject = null;

            try
            {
                var offset = (int) EntityPtr.ToPointer(current);
                var size = ClrUtil.SizeOf(current);
                offset += size;

                var mt = (long) *(IntPtr*) (offset + IntPtr.Size);

                if (size == 0 || !checker(mt))
                    return false;

                current = EntityPtr.ToInstance<object>((IntPtr) offset);
                nextObject = current;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}