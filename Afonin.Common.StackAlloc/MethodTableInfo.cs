using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Afonin.Common.StackAlloc
{
    [StructLayout(LayoutKind.Explicit)]
    [PublicAPI]
    public unsafe struct MethodTableInfo
    {
        #region Basic Type Info

        [FieldOffset(0)]
        public readonly int Flags;

        [FieldOffset(4)]
        public readonly int Size;

        [FieldOffset(8)]
        public readonly short AdditionalFlags;

        [FieldOffset(10)]
        public readonly short MethodsCount;

        [FieldOffset(12)]
        public readonly short VirtMethodsCount;

        [FieldOffset(14)]
        public readonly short InterfacesCount;

        [FieldOffset(16)]
        public readonly MethodTableInfo* ParentTable;

        #endregion

        [FieldOffset(20)]
        public readonly ObjectTypeInfo* ModuleInfo;

        [FieldOffset(24)]
        public readonly ObjectTypeInfo* EEClass;

        [FieldOffset(28)]
        public readonly void* _;

        [FieldOffset(32)]
        public readonly void* __;

        [FieldOffset(36)]
        public readonly void* ___;
    }
}