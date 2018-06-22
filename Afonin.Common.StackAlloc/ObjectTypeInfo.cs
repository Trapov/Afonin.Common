using System.Runtime.InteropServices;

using JetBrains.Annotations;

namespace Afonin.Common.StackAlloc
{
    [StructLayout(LayoutKind.Explicit)]
    [PublicAPI]
    public unsafe struct ObjectTypeInfo
    {
        [FieldOffset(0)]
        public readonly ObjectTypeInfo* ParentClass;

        [FieldOffset(16)]
        public readonly MethodTableInfo* MethodsTable;
    }
}