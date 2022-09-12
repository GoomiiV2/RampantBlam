namespace BlamTool.Systems;

public static class Blam
{
    public static bool IsBlamSetup = false;
    
    public static void Start()
    {
        if (IsBlamSetup)
            return;

        Bungie.ManagedBlamSystem.AllowUnsafeResourceUseOnOtherThreads = true;
        Bungie.ManagedBlamSystem.Start(BlamToolConfig.Inst.ReachEKPath, info =>
        {
            BlamTool.Log.AddLogError(LogCategories.System, $"Bungie.Blam Error: {info.File} {info.Line} {info.Type}: {info.Message}");
        });

        IsBlamSetup = true;
    }

    public static void Stop()
    {
        Bungie.ManagedBlamSystem.Stop();
        IsBlamSetup = false;
    }
}