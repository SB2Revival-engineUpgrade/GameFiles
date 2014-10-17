// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TWaveOutFunctionality.cs=
// = 10/17/2014 =
// =SB2Revival=
namespace SB2Revival.Music
{
    public enum TWaveOutFunctionality : uint
    {
        supportPitchControl = 1,
        supportPlaybackRateControl = 2,
        supportVolumeControl = 4,
        supportSeparateLeftRightVolume = 8,
        supportSync = 16,
        supportSampleAccuratePosition = 32,
        supportDirectSound = 6
    }
}