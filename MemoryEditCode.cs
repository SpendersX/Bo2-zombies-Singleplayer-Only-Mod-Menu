using Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;
using Swed64;
using ImGuiNET;
using ClickableTransparentOverlay;
using Vortice.Mathematics;
using System.Diagnostics;

namespace memoryedit
{
    class MemoryEditCode
    {


        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vkey);

        InputSimulator inputSimulator = new InputSimulator();
        Vector2 mouseMovement = new Vector2(0, 0);

        public void loop()
        {

            Renderer renderer = new Renderer();
            renderer.Start().Wait();

            Swed swed = new Swed("t6zm");
            IntPtr t6zm_base = swed.GetModuleBase("t6zm.exe");

            while (true)
            {
                int LocalPlayer = 0x02346AD0;

                int Get_Health_Vaule = swed.ReadInt(t6zm_base, 0x1DC5868);
                int Get_Monney_Vaule = swed.ReadInt(t6zm_base, 0x1F4C068);
                int Get_Current_Weapon_Id_Vaule = swed.ReadInt(t6zm_base, 0x1F46CE8);
                int Gun_Amo_1_Vaule = swed.ReadInt(t6zm_base, 0x1F46EC8);
                int Gun_Amo_2_Vaule = swed.ReadInt(t6zm_base, 0x1F46ECC);
                int Gun_Amo_3_Vaule = swed.ReadInt(t6zm_base, 0x02346ED8);
                int Round_Vaule = swed.ReadInt(t6zm_base, 0x1F3FA10);
                int Rapid_Fire_1_Vaule = swed.ReadInt(t6zm_base, 0x02346AD0);
                int Rapid_Fire_2_Vaule = swed.ReadInt(t6zm_base, 0x02346AF4);
                float Read_Fov_Vaule = swed.ReadFloat(t6zm_base, 0x2618A20);
                float Read_Y_Velocity = swed.ReadFloat(t6zm_base, 0x02346ADC);

                IntPtr writerapid1 = swed.ReadPointer(t6zm_base, 0x02346AD0);

                if (renderer.c1)
                {
                    swed.WriteInt(t6zm_base, 0x1DC5868, 99999);
                }
                
                if (renderer.c2)
                {
                    swed.WriteInt(t6zm_base, 0x1F46EC8, 999);
                    swed.WriteInt(t6zm_base, 0x1F46ECC, 999);
                    swed.WriteInt(t6zm_base, 0x1F46ED4, 999);
                    swed.WriteInt(t6zm_base, 0x02346ED8, 999);
                }

                if (renderer.c3)
                {
                    swed.WriteInt(t6zm_base, 0x1F46AEC, 0);
                    swed.WriteInt(t6zm_base, 0x02346AF4, 0);
                }

                if (renderer.c4)
                {
                    swed.WriteInt(t6zm_base, 0x1F4C068, renderer.monneyvaule);
                }

                if (renderer.c5)
                {
                    swed.WriteFloat(t6zm_base, 0x2618A20, renderer.fovvaule);
                }

                if (renderer.c6)
                {
                    swed.WriteInt(t6zm_base, 0x1F46CE8, renderer.weaponvauleid);
                }

                if (renderer.c7)
                {
                    if (GetAsyncKeyState(0x20) < 0)
                    {
                        swed.WriteFloat(t6zm_base, 0x1F46ADC, 240);
                    }
                    else
                    {
                        if (GetAsyncKeyState(0xA0) < 0)
                        {
                            swed.WriteFloat(t6zm_base, 0x1F46ADC, -240);
                        }
                        else
                        {
                            if (renderer.c8)
                            {
                                swed.WriteFloat(t6zm_base, 0x1F46ADC, 0);
                                swed.WriteFloat(t6zm_base, 0x1F46ADC, 1);
                            }
                        }
                    }
                }


                if (renderer.c9)
                {
                    swed.WriteInt(t6zm_base, 0x1F3FA10, renderer.roundvaule);
                }

                if (renderer.button1)
                {
                    swed.WriteFloat(t6zm_base, 0x1F46AD0, 999999);
                    renderer.button1 = false;
                }



                Thread.Sleep(10);
            }
        }
    }
}
