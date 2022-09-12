using BlamTool.Windows;
using ImTool;

namespace BlamTool;

public class BaseTab : WorkspaceTab
{
    public override string           Name          { get; }
    public override string           WorkspaceName { get; }
    
    public  Tool<BlamTool, BlamToolConfig> Tool;
    public  List<BaseWindow>               Windows        = new ();
    private List<BaseWindow>               WindowsToClose = new(5);

    public BaseTab(Tool<BlamTool, BlamToolConfig> tool)
    {
        Tool          = tool;
    }

    public BaseWindow OpenWindow<T>(T window) where T : BaseWindow
    {
        Windows.Add(window);
        window.OnOpen(this);
        return window;
    }

    public void CloseWindow(BaseWindow window)
    {
        window.OnClose(this);
        Windows.Remove(window);
    }

    public void ToggleWindow<T>(T window) where T : BaseWindow
    {
        if (Windows.Contains(window)) {
            CloseWindow(window);
        }
        else {
            OpenWindow(window);
        }
    }
    
    protected override void SubmitContent()
    {
        foreach (var window in Windows) {
            window.DrawWindow();
            if (!window.IsOpen) {
                WindowsToClose.Add(window);
            }
        }

        bool hadWindowsToClose = false;
        foreach (var window in WindowsToClose) {
            CloseWindow(window);
            hadWindowsToClose = true;
        }

        if (hadWindowsToClose) {
            WindowsToClose.Clear();
        }
    }
}