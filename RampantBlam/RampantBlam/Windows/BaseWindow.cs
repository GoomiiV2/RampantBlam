using ImGuiNET;

namespace BlamTool.Windows;

public class BaseWindow
{
    public    BaseTab          Tab;
    public    string           Name           = string.Empty;
    public    ImGuiWindowFlags Flags          = ImGuiWindowFlags.None;
    protected bool             HasCloseButton = true;
    public    bool             IsOpen         = true;

    public virtual void OnOpen(BaseTab tab)
    {
        Tab    = tab;
        IsOpen = true;
    }

    public virtual void OnClose(BaseTab tab)
    {
    }


    public virtual void DrawWindow()
    {
        var shouldShow = HasCloseButton ? ImGui.Begin(Name, ref IsOpen) : ImGui.Begin(Name);
        if (shouldShow) {
            Draw();
            ImGui.End();
        }
    }

    public virtual void Draw()
    {
    }
}