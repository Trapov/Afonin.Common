using System;
using System.Runtime.CLR;

using Afonin.Common.ClrTypes;

namespace Afonin.Common.SohObjects
{
    public static class Program
    {
        public static void Main()
        {
            var startObj = new Box();

            var _ = new Box();
            var __ = new Box();
            var ___ = new Box();

            var endObject = new BetterBox();

            foreach (var obj in SohUtil.GetObjectsInSoh(startObj, endObject, mt => mt != 0))
                Console.WriteLine(" - object adress: {0}, type: {1}, size: {2}",
                    EntityPtr.ToPointer(obj.Item),
                    obj.Item.GetType().Name,
                    ClrUtil.SizeOf(obj.Item)
                );

            Console.ReadLine();
        }

        private class Box
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
            public int D { get; set; }
            public int G { get; set; }
        }

        private class BetterBox
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
            public int D { get; set; }
            public int G { get; set; }
        }
    }
}