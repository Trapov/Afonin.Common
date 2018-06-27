﻿using System;
using System.Runtime.CLR;
using System.Runtime.InteropServices;

namespace Afonin.Common.ClrTypes
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct ArrayInfo
    {
        [FieldOffset(0)]
        private EntityInfo BasicInfo;

        [FieldOffset(8)]
        private int Lengthes;

        public bool IsMultidimentional => (BasicInfo.MethodTable->Flags & MethodTableFlags.IfArrayThenMultidim) == 0;

        public bool IsValueTypes =>
            (BasicInfo.MethodTable->Flags & MethodTableFlags.IfArrayThenSharedByReferenceTypes) == 0;

        public int Dimensions
        {
            get
            {
                if (IsMultidimentional)
                {
                    fixed (int* cur = &Lengthes)
                    {
                        var count = 0;
                        while (cur[count] != 0) count++;
                        return count;
                    }
                }

                return 1;
            }
        }

        private int GetLength(int dim)
        {
            var maxDim = Dimensions;
            if (maxDim < dim)
                throw new ArgumentOutOfRangeException(nameof(dim));

            fixed (int* addr = &Lengthes)
            {
                return addr[dim];
            }
        }

        public int SizeOf()
        {
            var total = 0;
            int elementsize;

            fixed (EntityInfo* entity = &BasicInfo)
            {
                var arr = EntityPtr.ToInstance<Array>(new IntPtr(entity));
                var elementType = arr.GetType().GetElementType() ??
                                  throw new ArgumentNullException($"Type is null, {arr}");

                if (elementType.IsValueType)
                {
                    var typecode = Type.GetTypeCode(elementType);

                    switch (typecode)
                    {
                        case TypeCode.Byte:
                        case TypeCode.SByte:
                        case TypeCode.Boolean:
                            elementsize = 1;
                            break;
                        case TypeCode.Int16:
                        case TypeCode.UInt16:
                        case TypeCode.Char:
                            elementsize = 2;
                            break;
                        case TypeCode.Int32:
                        case TypeCode.UInt32:
                        case TypeCode.Single:
                            elementsize = 4;
                            break;
                        case TypeCode.Int64:
                        case TypeCode.UInt64:
                        case TypeCode.Double:
                            elementsize = 8;
                            break;
                        case TypeCode.Decimal:
                            elementsize = 12;
                            break;
                        default:
                            var info = (MethodTableInfo*) elementType.TypeHandle.Value;
                            elementsize = info->Size - sizeof(EntityInfo);
                            break;
                    }
                }
                else
                {
                    elementsize = IntPtr.Size;
                }

                // Header
                total += sizeof(EntityInfo);
                total += elementType.IsValueType ? 0 : 4; // MethodsTable for refTypes
                total += IsMultidimentional ? Dimensions * 8 : 4;
            }

            // Contents
            if (!IsMultidimentional)
            {
                total += Lengthes * elementsize;
            }
            else
            {
                var res = 1;
                for (int i = 1, len = Dimensions; i < len; i++)
                {
                    res *= GetLength(i);
                }

                total += res * elementsize;
            }

            // align size to IntPtr
            if ((total & 3) != 0) total += 4 - total % 4;

            return total;
        }
    }
}