using JetBrains.Annotations;

using System.Runtime.InteropServices;

namespace Afonin.Common.ClrTypes
{
    [PublicAPI]
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct ObjectTypeInfo
    {
        [FieldOffset(0)]
        public readonly ObjectTypeInfo* ParentClass;

        [FieldOffset(16)]
        public readonly MethodTableInfo* MethodsTable;
    }
}