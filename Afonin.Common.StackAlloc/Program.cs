using System;
using System.Runtime.CLR;

using JetBrains.Annotations;

namespace Afonin.Common.StackAlloc
{
    public static class Program
    {
        [PublicAPI]
        private class Person
        {
            public int X { get; }
            public int Y { get; }
        }

        public static void Main()
        {
            unsafe
            {
                var data = stackalloc int[10];

                var person = EntityPtr.ToInstance<Person>((IntPtr) data);
                SetType<Person>(person);

                data[3] = 10;
                Console.WriteLine(
                    $"{person.X}, {person.Y}, \n Type: {person.GetType()} \n IsValueType: {person.GetType().IsValueType}");
          
                data[3] = 20;
                Console.WriteLine($"{person.X}, {person.Y}");

                Console.ReadLine();
            }
        }

        #region Helpers

        private static unsafe void SetType<TType>(object obj)
        {
            SetMethodTable(obj, (MethodTableInfo*)typeof(TType).TypeHandle.Value.ToPointer());
        }

        private static unsafe void SetMethodTable(object obj, MethodTableInfo* methodTable)
        {
            var contents = (EntityInfo*)EntityPtr.ToPointer(obj);
            contents->MethodTable = methodTable;
        }

        #endregion
    }
}