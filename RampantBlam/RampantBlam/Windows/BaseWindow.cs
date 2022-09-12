using ImGuiNET;

namespace BlamTool.Windows;

public class BaseWindow
{
    public BaseTab          Tab;
    public string           Name   = string.Empty;
    public ImGuiWindowFlags Flags  = ImGuiWindowFlags.None;
    public bool             IsOpen = true;

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
        if (ImGui.Begin(Name, ref IsOpen)) {
            Draw();
            ImGui.End();
        }
    }

    public virtual void Draw()
    {
    }
}