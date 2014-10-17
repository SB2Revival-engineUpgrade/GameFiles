// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TStreamLoadInfo.cs=
// = 10/17/2014 =
// =SB2Revival=
using System.Runtime.InteropServices;
namespace SB2Revival.Music
{
    [StructLayout(LayoutKind.Explicit)]
    public struct TStreamLoadInfo
    {
        [FieldOffset(0)]
        public uint NumberOfBuffers;
        [FieldOffset(4)]
        public uint NumberOfBytes;
    }
}