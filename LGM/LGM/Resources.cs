using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LGM
{
    class Resources
    {
        public static int resourcecnt = 0;
        public enum Types { Sprite, Object, Background, Sound, Room, Script};
        public static Types[] resourcetypes = {Types.Sprite};
        public static string[] resourcenames = {"Sprite0"};
        public static string[] resourcedata = {""};
    }
}
