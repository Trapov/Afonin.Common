using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Afonin.Common.StackAlloc
{
    [StructLayout(LayoutKind.Explicit)]
    [PublicAPI]
    public unsafe struct EntityInfo
    {
        [FieldOffset(0)]
        public readonly int SyncBlockIndex;

        [FieldOffset(4)]
        public MethodTableInfo* MethodTable;
    }
}