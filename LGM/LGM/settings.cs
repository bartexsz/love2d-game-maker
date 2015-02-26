using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace LGM
{
    class settings
    {
        public static string love2dpath;

        public static void LoadSettings()
        {
            //Loads the settings from settings.cfg
            if (!File.Exists(Application.StartupPath+"\\settings.cfg"))
            {
                //It doesn't exist! Let's create it!
                //TODO: Show tutorial/welcome messsage.
                
                try
                {
                    File.WriteAllText(Application.StartupPath+"\\settings.cfg","LGM v1.0");
                }
                catch (Exception ex)
                {
                    System.Media.SystemSounds.Hand.Play();
                    Main.Error(2,"The settings.cfg file could not be created! Please try re-starting the" + Environment.NewLine + "program as an administrator.");
                }
            }
        }
    }
}
