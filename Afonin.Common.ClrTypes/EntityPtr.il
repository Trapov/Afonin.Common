// Metadata version: v2.0.50215
#define CORELIB "System.Runtime"
#define netcoreapp

// Metadata version: v4.0.30319
.assembly extern CORELIB
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )
  .ver 4:0:0:0
}

.assembly EntityPtr
{
    .custom instance void [netstandard]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = (
        01 00 00 00
    )
    .custom instance void [netstandard]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = (
        01 00 08 00 00 00 00 00
    )
    .custom instance void [netstandard]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = (
        01 00 01 00 54 02 16 57 72 61 70 4e 6f 6e 45 78
        63 65 70 74 69 6f 6e 54 68 72 6f 77 73 01
    )
    .custom instance void [netstandard]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [netstandard]System.Diagnostics.DebuggableAttribute/DebuggingModes) = (
        01 00 02 00 00 00 00 00
    )
    .custom instance void [netstandard]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = (
        01 00 19 2e 4e 45 54 53 74 61 6e 64 61 72 64 2c
        56 65 72 73 69 6f 6e 3d 76 32 2e 30 01 00 54 0e
        14 46 72 61 6d 65 77 6f 72 6b 44 69 73 70 6c 61
        79 4e 61 6d 65 00
    )
    .custom instance void [netstandard]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = (
        01 00 0e 63 72 61 66 74 77 6f 72 6b 67 61 6d 65
        73 00 00
    )
    .custom instance void [netstandard]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = (
        01 00 07 52 65 6c 65 61 73 65 00 00
    )
    .custom instance void [netstandard]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = (
        01 00 1f 49 74 20 6d 61 6b 65 73 20 4d 6f 6e 6f
        47 61 6d 65 20 6d 6f 72 65 20 61 77 65 73 6f 6d
        65 2e 00 00
    )
    .custom instance void [netstandard]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = (
        01 00 07 31 2e 30 2e 30 2e 30 00 00
    )
    .custom instance void [netstandard]System.Reflection.AssemblyInformationalVersionAttribute::.ctor(string) = (
        01 00 0b 31 2e 30 2e 30 2d 61 6c 70 68 61 00 00
    )
    .custom instance void [netstandard]System.Reflection.AssemblyProductAttribute::.ctor(string) = (
        01 00 11 4d 6f 6e 6f 47 61 6d 65 2e 45 78 74 65
        6e 64 65 64 00 00
    )
    .custom instance void [netstandard]System.Reflection.AssemblyTitleAttribute::.ctor(string) = (
        01 00 11 4d 6f 6e 6f 47 61 6d 65 2e 45 78 74 65
        6e 64 65 64 00 00
    )
    .hash algorithm 0x00008004 // SHA1
    .ver 1:0:0:0
}


.module EntityPtr.dll
// MVID: {A224F460-A049-4A03-9E71-80A36DBBBCD3}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY

// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi abstract sealed beforefieldinit System.Runtime.CLR.EntityPtr
    extends [mscorlib]System.Object
{             
    .method public hidebysig static 
        native int ToPointer<TType> (
            !!TType input
        ) cil managed 
    {
        // Method begins at RVA 0x2254
        // Code size 7 (0x7)
        .maxstack 2
        .locals init (
            [0] native int CSS
        )

        ldarg.0
        conv.i4
        ldc.i4 4
        sub
        conv.i
        ret
    } // end of method Converter::ToPointer

    .method public hidebysig static 
        native int ToPointerWithOffset<TType> (
            !!TType input
        ) cil managed 
    {
        // Method begins at RVA 0x2254
        // Code size 7 (0x7)
        .maxstack 2
        .locals init (
            [0] native int CSS
        )

        ldarg.0
        ret
    } // end of method Converter::ToPointer

    // Methods
    .method public hidebysig static 
        !!TType ToInstance<TType> (
            native int input
        ) cil managed 
    {
        // Method begins at RVA 0x2254
        // Code size 7 (0x7)
        .maxstack 2
        .locals init (
            [0] native int CSS
        )

        ldarg.0
        conv.i4
        ldc.i4 4
        add
        conv.i
        ret
} // end of method Converter::ToInstance

        .method public hidebysig static
                !!TType CastRef<TType> (
                        object input
                ) cil managed
        {
               .maxstack 2
               ldarg.0
               ret
        }

    .method public hidebysig static 
        !!TType ToInstanceWithOffset<TType> (
            native int input
        ) cil managed 
    {
        // Method begins at RVA 0x2254
        // Code size 7 (0x7)
        .maxstack 2
        .locals init (
            [0] native int CSS
        )

        ldarg.0
        ret
    } // end of method Converter::ToInstance

} // end of class sandbox.Converter