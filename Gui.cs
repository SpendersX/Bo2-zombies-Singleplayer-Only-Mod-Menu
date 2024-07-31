using ClickableTransparentOverlay;
using GuiStyle;
using ImGuiNET;
using System.Numerics;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;

namespace Gui
{
    public class Renderer : Overlay
    {
        Vector2 windowsize = new Vector2(630, 400);

        public bool c1 = false;
        public bool c2 = false;
        public bool c3 = false;
        public bool c4 = false;
        public bool c5 = false;
        public bool c6 = false;
        public bool c7 = false;
        public bool c8 = false;
        public bool c9 = false;
        public bool c10 = false;

        public int monneyvaule = 500;
        public int weaponvauleid = 0;
        public int currentroundvaule = 0;
        public int roundvaule = 0;

        public float fovvaule = 65;

        public bool button1 = false;

        protected override void Render()
        {
            // Gui Render
            StyleGui styleGui = new StyleGui();
            styleGui.styleGui();
            ImGui.Begin(" ", ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize);
            ImGui.SetWindowSize(windowsize);


            if (ImGui.BeginTabBar("tabar1"))
            {
                if (ImGui.BeginTabItem("Player"))
                {
                    ImGui.Checkbox("God Mode", ref c1);
                    ImGui.Checkbox("Inf Amo", ref c2);
                    ImGui.Checkbox("Rapid Fire", ref c3);
                    ImGui.Checkbox("Fly", ref c7);
                    if (c7 == true)
                    {
                        ImGui.SameLine();
                        ImGui.Checkbox("No Fall", ref c8);
                    }

                    ImGui.Separator();
                    ImGui.Checkbox("Monney slider", ref c4);
                    if (c4 == true)
                    {
                        ImGui.SameLine();
                        ImGui.SliderInt("Monney Slider", ref monneyvaule, 500, 999999);
                    }
                    ImGui.Checkbox("Weapon Changer slot 1", ref c6);
                    if (c6 == true)
                    {
                        ImGui.SameLine();
                        ImGui.SliderInt("Weapon Id Changer", ref weaponvauleid, 0, 100);
                    }

                    ImGui.Checkbox("Round change slider", ref c9);
                    if (c9 == true)
                    {
                        ImGui.SameLine();
                        ImGui.SliderInt("Round Slider", ref roundvaule, 0, 999);
                    }

                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("Visuals"))
                {
                    ImGui.Checkbox("Fov slider", ref c5);
                    if (c5 == true)
                    {
                        ImGui.SameLine();
                        ImGui.SliderFloat("Fov Slider", ref fovvaule, 65, 165);
                    }

                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("World"))
                {
                    if (ImGui.Button("End Game"))
                    {
                        button1 = true;
                    }

                    ImGui.EndTabItem();
                }

                ImGui.EndTabBar();
            }


            ImGui.End();
        }
    }
}