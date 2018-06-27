using System.Runtime.InteropServices;

using JetBrains.Annotations;

namespace Afonin.Common.ClrTypes
{
    [PublicAPI]
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct EntityInfo
    {
        [FieldOffset(0)]
        public readonly int SyncBlockIndex;

        [FieldOffset(4)]
        public MethodTableInfo* MethodTable;
    }
}