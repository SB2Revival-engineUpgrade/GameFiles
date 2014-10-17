// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TStreamFormat.cs=
// = 10/17/2014 =
// =SB2Revival=
namespace SB2Revival.Music
{
    public enum TStreamFormat : int
    {
        sfUnknown = 0,
        sfMp3 = 1,
        sfOgg = 2,
        sfWav = 3,
        sfPCM = 4,
        sfFLAC = 5,
        sfFLACOgg = 6,
        sfAC3 = 7,
        sfAacADTS = 8,
        sfWaveIn = 9,
        sfAutodetect = 1000
    }
}