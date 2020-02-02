using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using static CCXRealmClient.Data;

namespace CCXRealmClient
{
    public static class Listener
    {
        public static void StartListener()
        {
            /*BackgroundWorker Listener_HotKey = new BackgroundWorker();
            Listener_HotKey.DoWork += new DoWorkEventHandler(Listener_HotKey_DoWork);

            if (!Listener_HotKey.IsBusy)
            {
                Listener_HotKey.RunWorkerAsync();
            }*/
            Thread Listener_HotKey = new Thread(new ThreadStart(Listener_HotKey_DoWork));
            Listener_HotKey.SetApartmentState(ApartmentState.STA);
            Listener_HotKey.Start();
        }

        private static void Listener_HotKey_DoWork()
        {
            while (true)
            {
                if (Data.ClientSettings.EnableDevSettings)
                {
                    if (Keyboard.IsKeyDown(Data.DefaultHotKeyProfiles.AirJump))
                    {
                        Data.Module.Status.Airjump = !Data.Module.Status.Airjump;
                        Thread.Sleep(300);
                    }

                    if (Keyboard.IsKeyDown(Data.DefaultHotKeyProfiles.Speed))
                    {
                        Data.Module.Status.Speed = !Data.Module.Status.Speed;
                        Thread.Sleep(300);
                    }

                    if (Keyboard.IsKeyDown(Data.DefaultHotKeyProfiles.Rapidhit))
                    {
                        Data.Module.Status.Rapidhit = !Data.Module.Status.Rapidhit;
                        Thread.Sleep(300);
                    }

                    if (Keyboard.IsKeyDown(Data.DefaultHotKeyProfiles.Nofall))
                    {
                        Data.Module.Status.Nofall = !Data.Module.Status.Nofall;
                        Thread.Sleep(300);
                    }

                    if (Keyboard.IsKeyDown(Data.DefaultHotKeyProfiles.ShowCoordinates))
                    {
                        Data.Module.Status.ShowCoordinates = !Data.Module.Status.ShowCoordinates;
                        Thread.Sleep(300);
                    }

                    if (Keyboard.IsKeyDown(Data.DefaultHotKeyProfiles.FakeCreative))
                    {
                        Data.Module.Status.FakeGamemode = !Data.Module.Status.FakeGamemode;
                        Thread.Sleep(300);
                    }

                    if (Keyboard.IsKeyDown(Data.DefaultHotKeyProfiles.Glide))
                    {
                        Data.Module.Status.Glide = !Data.Module.Status.Glide;
                        Thread.Sleep(300);
                    }
                }

                Thread.Sleep(20);
            }
        }
    }

    public static class DynamicData
    {
        public static class Hotkeys
        {
            public static class activeHotkeys
            {
                public static class Modules
                {
                    public static Key Speed = Data.DefaultHotKeyProfiles.Speed;
                    public static Key AirJump = Data.DefaultHotKeyProfiles.AirJump;
                    public static Key Rapidhit = Data.DefaultHotKeyProfiles.Rapidhit;
                    public static Key Nofall = Data.DefaultHotKeyProfiles.Nofall;
                    public static Key ShowCoordinates = Data.DefaultHotKeyProfiles.ShowCoordinates;
                    public static Key FakeCreative = Data.DefaultHotKeyProfiles.FakeCreative;
                    public static Key Glide = Data.DefaultHotKeyProfiles.Glide;
                    //public static Key ModuleName = Data.DefaultHotKeyProfiles.;
                    //public static Key ModuleName = Data.DefaultHotKeyProfiles.;
                    //public static Key ModuleName = Data.DefaultHotKeyProfiles.;
                    //public static Key ModuleName = Data.DefaultHotKeyProfiles.;
                    //public static Key ModuleName = Data.DefaultHotKeyProfiles.;
                }
            }

            public static void LoadHotkeys()
            {
                
            }
        }
    }
}
