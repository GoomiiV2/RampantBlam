using System;
using System.Threading.Tasks;
using ImTool;

namespace BlamTool
{
    class Program
    {
        static async Task Main()
        {
            try
            {
                await BlamTool.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}