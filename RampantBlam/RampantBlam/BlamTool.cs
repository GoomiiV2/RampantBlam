using System;
using System.IO;
using BlamTool.Systems;
using ImTool;
using ImTool.SDL;

namespace BlamTool
{
    public class BlamTool : Tool<BlamTool, BlamToolConfig>
    {
        public static LogWindow<LogCategories> Log = new LogWindow<LogCategories>("Logs");
        
        protected override bool Initialize(string[] args)
        {
            BlamToolConfig.Inst = Config;

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
            Blam.Stop();
        }
    }
}