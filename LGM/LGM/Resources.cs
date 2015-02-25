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
        public static int resourcecnt = 0; //The amount of resources in the current project.
        public static int[] resourcetypecnt = new int[9000]; //0=Number of sprites, 1=Number of Objects, 2=Number of Backgrounds, etc.
        public static Types[,] resourcetypes = new Types[9000,9000]; //The types of resources corrisponding to each node on the resourcelist treeview.
        public static string[,] resourcenames = new string[9000,9000]; //The names of the resources.
        public static string[,] resourcedata = new string[9000, 9000]; //The resource's data, such as code for objects/scripts.

        public enum Types { Sprite, Object, Background, Sound, Room, Script }; //The types of resources which can be added.

        public static void DefineResourceArrays()
        {
            //Define all those arrays declared above
            for (int i = 0; i < 9000; i++)
            {
                resourcetypecnt[i] = 0;
                for (int x = 0; x < 9000; x++)
                {
                    resourcetypes[i, x] = Types.Sprite;
                    resourcenames[i, x] = "Untitled Resource";
                    resourcedata[i, x] = "";
                }
            }
        }
    }
}
