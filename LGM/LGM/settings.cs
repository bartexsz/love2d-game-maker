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
                    File.WriteAllText(Application.StartupPath+"\\settings.cfg","0 ALPHA " + Application.ProductVersion + Environment.NewLine + "1 " + Application.StartupPath + "\\love2d");
                }
                catch (Exception ex)
                {
                    System.Media.SystemSounds.Hand.Play();
                    Main.Error(2,"The settings.cfg file could not be created! Please try re-starting the" + Environment.NewLine + "program as an administrator.");
                }
            }

            foreach (string setting in File.ReadAllLines(Application.StartupPath + "\\settings.cfg"))
            {
                switch (setting.Substring(0,1))
                {
                    case "0":
                        //Version number
                        break;
                    case "1":
                        //LOVE 2D File Path
                        if (setting.Substring(2) != "null")
                        {
                            if (IsLove2DFolder(setting.Substring(2)))
                            {
                                //We found our LOVE 2D folder!
                                love2dpath = setting.Substring(2);
                            }
                        }
                        else
                        {
                            if (IsLove2DFolder(Application.StartupPath + "\\love2d"))
                            {
                                //We found our LOVE 2D folder!
                                love2dpath = Application.StartupPath + "\\love2d";
                            }
                        }
                        break;
                }
            }
        }
        
        public static bool IsLove2DFolder(string pth)
        {
            //Checks to see if the set folder has the required files for LOVE2D.
            return Directory.Exists(pth) && File.Exists(pth + "\\love.exe") && File.Exists(pth + "\\SDL2.dll") && File.Exists(pth + "\\OpenAL32.dll") && File.Exists(pth + "\\license.txt") && File.Exists(pth + "\\DevIL.dll") && File.Exists(pth + "\\love.dll") && File.Exists(pth + "\\lua51.dll") && File.Exists(pth + "\\mpg123.dll") && File.Exists(pth + "\\msvcp110.dll") && File.Exists(pth + "\\msvcr110.dll");
        }
    }

    
}
