using System;
using System.Runtime.CLR;

namespace Afonin.Common.ClrTypes
{
    public static class ClrUtil
    {
        public static unsafe int SizeOf(object obj)
        {
            var x = SizeOf((EntityInfo*) EntityPtr.ToPointer(obj));
            return x;
        }

        public static unsafe int SizeOf<T>() => ((MethodTableInfo*) typeof(T).TypeHandle.Value.ToPointer())->Size;

        private static unsafe int SizeOf(EntityInfo* entity)
        {
            var flags = (uint) entity->MethodTable->Flags;

            // if boxed elementary type
            if (flags == 0x00270000)
                return entity->MethodTable->Size;

            // Array
            if ((flags & 0xffff0000) == 0x800a0000)
                return ((ArrayInfo*) entity)->SizeOf();

            // ???
            if ((flags & 0xffff0000) == 0x01400200)
                return entity->MethodTable->Size;

            // COM interface: have no size and have no .Net class
            if ((flags & 0xffff0000) == 0x000c0000)
                return SizeOf<object>();

            // String
            if (entity->MethodTable != typeof(string).TypeHandle.Value.ToPointer()) return entity->MethodTable->Size;
            return Environment.Version.Major >= 4
                ? 4 * ((14 + 2 * *(int*) ((int) entity + 8) + 3) / 4)
                : 4 * ((16 + 2 * *(int*) ((int) entity + 12) + 3) / 4);
            // on 1.0 -> 3.5 string have additional RealLength field
        }
    }
}