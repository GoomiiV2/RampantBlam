using ImTool;

namespace BlamTool;

public class BlamToolConfig : Configuration
{
    public static BlamToolConfig Inst;
    
    public        string ReachEKPath { get; set; }
    
    public BlamToolConfig()
    {
        Title                 = "Rampant Blam";
        GithubRepositoryOwner = "GoomiiV2";
        GithubRepositoryName  = "RampantBlam";
        GithubReleaseName     = "BlamTool";
        DisableSettingsPane   = false;
    }
}