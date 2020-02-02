using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CCXRealmClient
{
    public static class Data
    {
        public static class NAME
        {
            public static readonly string client = "CCXRealmClient";
            public static readonly string creator = "CXCubeHD";
        }

        public static string procName = "Minecraft.Windows";

        public static class Pointer
        {
            // POS
            public static string PosX  = "Minecraft.Windows.exe+0x02980000,0x58,0x18,0x130,0x320,0x0,0x40,0x0,0xde8";
            public static string PosY  = "Minecraft.Windows.exe+0x02980000,0x58,0x18,0x130,0x320,0x0,0x40,0x0,0xdec";
            public static string PosZ  = "Minecraft.Windows.exe+0x02980000,0x58,0x18,0x130,0x320,0x0,0x40,0x0,0xdf0";
            public static string Pos2X = "Minecraft.Windows.exe+0x02980000,0x58,0x18,0x130,0x320,0x0,0x40,0x0,0xdf4";
            public static string Pos2Y = "Minecraft.Windows.exe+0x02980000,0x58,0x18,0x130,0x320,0x0,0x40,0x0,0xdf8";
            public static string Pos2Z = "Minecraft.Windows.exe+0x02980000,0x58,0x18,0x130,0x320,0x0,0x40,0x0,0xdfc";

            // Velocity
            public static string VelocityY = "Minecraft.Windows.exe+0x0297FF70,0x58,0x18,0xc8,0xe10";

            // Onground
            public static string Onground = "Minecraft.Windows.exe+0x0297FF18,0x58,0x18,0xC8,0x168";

            // Speed
            public static string Speed = "Minecraft.Windows.exe+0x0297FF70,0x58,0x18,0xc8,0xdc0,0x18,0xe0,0x8,0x9c";

            // Rapidhit
            public static string Rapidhit = "Minecraft.Windows.exe+0x2999D60,0x120,0x398,0x8,0x380,0x50,0x2e0,0x88,0x50";

            // Nofall
            public static string Nofall = "Minecraft.Windows.exe+0x0297FF70,0x58,0x38,0x30,0x8,0x178";

            // IngameCoordinates
            public static string ShowCoordinates = "Minecraft.Windows.exe+0x297FF18,0x58,0x10,0x150,0x9a4";

            // FakeCreative (1/2)
            public static string FakeGamemode = "Minecraft.Windows.exe+0x0297FFB0,0x58,0x18,0xf8,0x8,0xf98,0x0,0xc1c";

            // FakeCrative Help (2/2)
            public static string FakeGamemodeHelp = "Minecraft.Windows.exe+0x0299A838,0x80,0x18,0x10,0x40,0x0,0xf98,0x0,0xc1c";
        }

        public static class Module
        {
            public static class Status
            {
                public static bool ChangeOnNextCheck = false;

                public static bool Airjump = false;
                public static bool Speed = false;
                public static bool Rapidhit = false;
                public static bool Nofall = false;
                public static bool ShowCoordinates = false;
                public static bool FakeGamemode = false;
                public static bool Glide = false;
            }

            public static class Value
            {
                public static float Speed = 0.13f;
                public static float GlideVelocityY = 0.02f;
                public static int FakeGamemode = 1;
            }
        }

        public static class DefaultHotKeyProfiles
        {
            public static Key AirJump = Key.NumPad9;
            public static Key Speed = Key.NumPad8;
            public static Key Rapidhit = Key.NumPad0;
            public static Key Nofall = Key.NumPad1;
            public static Key ShowCoordinates = Key.NumPad7;
            public static Key FakeCreative = Key.NumPad4;
            public static Key Glide = Key.F;
        }

        public static class ClientSettings
        {
            public static bool EnableDevSettings = false;
        }

        public static class DefaultColors
        {
            public static class gbutton
            {
                public static string on = "#B29600FF";
                public static string off = "#339600FF";
                public static string locked = "#7F646464";
                public static string trigger = "#7F6400FF";
            }

            public static class gbutton_radio
            {
                public static string active = "#7F9664FF";
                public static string inactive = "#7F646464";
            }
        }

        public static class GButtonStatus
        {
            public static class Locked
            {
                public static bool gbutton_module_airjump = false;
                public static bool gbutton_module_speed = false;
                public static bool gbutton_module_glide = false;
                public static bool gbutton_module_rapidhit = false;
                public static bool gbutton_module_nofall = false;
                public static bool gbutton_module_fallfromhightplace = false;
                public static bool gbutton_module_showcoordinates = false;
                public static bool gbutton_module_fakegamemode = false;
                public static bool gbutton_module_teleport = false;
            }
        }
    }
}
