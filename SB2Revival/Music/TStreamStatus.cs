// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TStreamStatus.cs=
// = 10/17/2014 =
// =SB2Revival=
using System.Runtime.InteropServices;
namespace SB2Revival.Music
{
    [StructLayout(LayoutKind.Explicit)]
    public struct TStreamStatus
    {
        [FieldOffset(0)]
        public bool fPlay;
        [FieldOffset(4)]
        public bool fPause;
        [FieldOffset(8)]
        public bool fEcho;
        [FieldOffset(12)]
        public bool fEqualizer;
        [FieldOffset(16)]
        public bool fVocalCut;
        [FieldOffset(20)]
        public bool fSideCut;
        [FieldOffset(24)]
        public bool fChannelMix;
        [FieldOffset(28)]
        public bool fSlideVolume;
        [FieldOffset(32)]
        public int nLoop;
        [FieldOffset(36)]
        public bool fReverse;
        [FieldOffset(40)]
        public int nSongIndex;
        [FieldOffset(44)]
        public int nSongsInQueue;
    }
}