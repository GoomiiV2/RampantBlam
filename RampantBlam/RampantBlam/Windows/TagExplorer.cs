using ImGuiNET;

namespace BlamTool.Windows;

public class TagExplorer : BaseWindow
{
    public override void OnOpen(BaseTab tab)
    {
        base.OnOpen(tab);
        Name           = "Tag Explorer";
        HasCloseButton = false;

        BuildTagList();
    }

    public void BuildTagList()
    {
        
    }

    public override void Draw()
    {
        ImGui.TextWrapped("Tag Explorer");
    }
}