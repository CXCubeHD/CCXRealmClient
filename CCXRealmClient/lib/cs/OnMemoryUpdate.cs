using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CCXRealmClient
{
    static class OnMemoryUpdate
    {
        public static bool Status_Process_Open = false;
        public static int pID = 0;
        public static Mem m = new Mem();

        public static float PosX = 0;
        public static float PosY = 0;
        public static float PosZ = 0;

        public static void StartOnMemoryUpdate_CheckProcess()
        {
            pID = m.getProcIDFromName(Data.procName);
            Status_Process_Open = false;
            if (pID != 0)
            {
                Status_Process_Open = m.OpenProcess(pID);
            }

            BackgroundWorker OnMemoryUpdateWorker_CheckProcess = new BackgroundWorker();
            OnMemoryUpdateWorker_CheckProcess.DoWork += new DoWorkEventHandler(OnMemoryUpdateWorker_CheckProcess_DoWork);

            if (!OnMemoryUpdateWorker_CheckProcess.IsBusy)
            {
                OnMemoryUpdateWorker_CheckProcess.RunWorkerAsync();
            }
        }

        public static void StartOnMemoryUpdate()
        {
            BackgroundWorker OnMemoryUpdateWorker = new BackgroundWorker();
            OnMemoryUpdateWorker.DoWork += new DoWorkEventHandler(OnMemoryUpdateWorker_DoWork);

            if (!OnMemoryUpdateWorker.IsBusy)
            {
                OnMemoryUpdateWorker.RunWorkerAsync();
            }
        }

        public static void  StartModuleWorker()
        {
            // Modules
            BackgroundWorker ModuleWorker_Rapidhit = new BackgroundWorker();

            // SetDoWork
            ModuleWorker_Rapidhit.DoWork += new DoWorkEventHandler(ModuleWorker_Slow1_DoWork);

            // Start
            ModuleWorker_Rapidhit.RunWorkerAsync();
        }

        private static void ModuleWorker_Slow1_DoWork(object sender, EventArgs e)
        {
            while (true)
            {
                if (Status_Process_Open)
                {
                    if (Data.Module.Status.Rapidhit == true)
                    {
                        try
                        {
                            m.writeMemory(Data.Pointer.Rapidhit, "byte", "0x00");
                        }
                        catch
                        {

                        }
                    }

                    if (Data.Module.Status.FakeGamemode == true)
                    {
                        try
                        {
                            m.writeMemory(Data.Pointer.FakeGamemode, "byte", Data.Module.Value.FakeGamemode.ToString());
                            m.writeMemory(Data.Pointer.FakeGamemodeHelp, "byte", Data.Module.Value.FakeGamemode.ToString());
                        } catch
                        {

                        }
                    }
                }
                Thread.Sleep(100);
            }
        }

        private static void OnMemoryUpdateWorker_DoWork(object sender, EventArgs e)
        {
            while (true)
            {
                PosX = Module_Read.GetXPos();
                PosY = Module_Read.GetYPos();
                PosZ = Module_Read.GetZPos();

                if (Status_Process_Open)
                {
                    Thread.Sleep(30);

                    if (Data.Module.Status.Airjump == true)
                    {
                        try
                        {
                            m.writeMemory(Data.Pointer.Onground, "bytes", "01 00 01 01");
                        } catch
                        {

                        }
                    }

                    if (Data.Module.Status.Speed == true)
                    {
                        try
                        {
                            m.writeMemory(Data.Pointer.Speed, "float", Data.Module.Value.Speed.ToString());
                        } catch
                        {

                        }
                    }

                    if (Data.Module.Status.Nofall == true)
                    {
                        try
                        {
                            m.writeMemory(Data.Pointer.Nofall, "float", "0");
                        } catch
                        {

                        }
                    }

                    if (Data.Module.Status.ShowCoordinates == true)
                    {
                        try
                        {
                            m.writeMemory(Data.Pointer.ShowCoordinates, "byte", "1");
                        } catch
                        {

                        }
                    }

                    if (Data.Module.Status.Glide == true)
                    {
                        try
                        {
                            m.writeMemory(Data.Pointer.VelocityY, "float", Data.Module.Value.GlideVelocityY.ToString());
                        } catch
                        {

                        }
                    }
                }
            }
        }

        private static void OnMemoryUpdateWorker_CheckProcess_DoWork(object sender, EventArgs e)
        {
            while (true)
            {
                pID = m.getProcIDFromName(Data.procName);
                Status_Process_Open = false;
                if (pID != 0)
                {
                    Status_Process_Open = m.OpenProcess(pID);
                }

                Thread.Sleep(200);
            }
        }

        public static class Module_Trigger
        {
            public static void Teleport(float posX, float posY, float posZ, bool relativeX = false, bool relativeY = false, bool relativeZ = false)
            {
                if (Status_Process_Open)
                {
                    try
                    {
                        if (!relativeX)
                        {
                            m.writeMemory(Data.Pointer.PosX, "float", (posX + 0.20f).ToString());
                            m.writeMemory(Data.Pointer.Pos2X, "float", (posX + 0.80f).ToString());
                            Debug.WriteLine("PosX, 2X: " + posX.ToString() + "  " + (posX + 0.60f).ToString());
                        }
                        else
                        {

                        }

                        if (!relativeY)
                        {
                            m.writeMemory(Data.Pointer.PosY, "float", posY.ToString());
                            m.writeMemory(Data.Pointer.Pos2Y, "float", (posY + 1.80f).ToString());
                            Debug.WriteLine("PosY, 2Y: " + posY.ToString() + "  " + (posY + 1.80f).ToString());
                        }
                        else
                        {

                        }

                        if (!relativeZ)
                        {
                            m.writeMemory(Data.Pointer.PosZ, "float", (posZ + 0.20f).ToString());
                            m.writeMemory(Data.Pointer.Pos2Z, "float", (posZ + 0.80f).ToString());
                            Debug.WriteLine("PosZ, 2Z: " + posZ.ToString() + "  " + (posZ + 0.60f).ToString());
                        }
                        else
                        {

                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        public static class Module_Read
        {

            public static float GetXPos()
            {
                float value = 0f;
                if (Status_Process_Open)
                {
                    try
                    {
                        value = m.readFloat(Data.Pointer.PosX) + 0.3f;
                    } catch
                    {

                    }
                }
                return value;
            }
            public static float GetYPos()
            {
                float value = 0f;
                if (Status_Process_Open)
                {
                    try
                    {
                        value = m.readFloat(Data.Pointer.PosY);
                    } catch
                    {

                    }
                }
                return value;
                
            }
            public static float GetZPos()
            {
                float value = 0f;
                if (Status_Process_Open)
                {
                    try
                    {
                        value = m.readFloat(Data.Pointer.PosZ) + 0.3f;
                    }
                    catch
                    {

                    }
                }
                return value;
            }
        }
    }
}
