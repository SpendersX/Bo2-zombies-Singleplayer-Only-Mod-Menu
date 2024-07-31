using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClickableTransparentOverlay;
using ImGuiNET;
using memoryedit;

namespace Hook
{

    class LoadHook
    {
        static void Main(string[] args)
        {
            memoryedit.MemoryEditCode memoryEditCode = new memoryedit.MemoryEditCode();
            memoryEditCode.loop();
        }
    }
}
