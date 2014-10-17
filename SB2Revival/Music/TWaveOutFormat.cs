// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =TWaveOutFormat.cs=
// = 10/17/2014 =
// =SB2Revival=
namespace SB2Revival.Music
{
    public enum TWaveOutFormat : uint
    {
        format_invalid = 0,
        format_11khz_8bit_mono = 1,
        format_11khz_8bit_stereo = 2,
        format_11khz_16bit_mono = 4,
        format_11khz_16bit_stereo = 8,
        format_22khz_8bit_mono = 16,
        format_22khz_8bit_stereo = 32,
        format_22khz_16bit_mono = 64,
        format_22khz_16bit_stereo = 128,
        format_44khz_8bit_mono = 256,
        format_44khz_8bit_stereo = 512,
        format_44khz_16bit_mono = 1024,
        format_44khz_16bit_stereo = 2048
    }
}