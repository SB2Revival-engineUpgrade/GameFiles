// =SB2Revival Engine Upgrade=
// =C#/XNA convertion from Rpg Maker=
// =Programmers=
// =Mute Lovestone=
// =ErrorFileNotFound.cs=
// = 10/17/2014 =
// =SB2Revival=
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SB2Revival.Errors
{
    public class ErrorFileNotFound : Exception
    {
        public string MessAge = "The file the game was trying to read could not be found, please check with the dev's or check your own work";
        public ErrorFileNotFound()
        {
        }
    }
}