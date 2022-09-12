using System;
using System.IO;
using ImTool;
using ImTool.SDL;

namespace BlamTool
{
    public class BlamTool : Tool<BlamTool, BlamToolConfig>
    {
        protected override bool Initialize(string[] args)
        {
            return true;
        }

        protected override void Load()
        {
            Window.AddTab(new TagExplorerTab(this));

            Window.AddWindowButton("Test button", () =>
            {
                Console.WriteLine("Test window button clicked :>");
            });
        }

        protected override void Unload()
        {
            
        }
    }
}