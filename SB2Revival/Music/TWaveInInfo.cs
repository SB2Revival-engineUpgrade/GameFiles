// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TWaveInInfo.cs=
// = 10/17/2014 =
// =SB2Revival=
using System.Runtime.InteropServices;
namespace SB2Revival.Music
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct TWaveInInfo
    {
        [FieldOffset(0)]
        public uint ManufacturerID;
        [FieldOffset(4)]
        public uint ProductID;
        [FieldOffset(8)]
        public uint DriverVersion;
        [FieldOffset(12)]
        public uint Formats;
        [FieldOffset(16)]
        public uint Channels;
        [FieldOffset(20)]
        public string ProductName;
    }
}