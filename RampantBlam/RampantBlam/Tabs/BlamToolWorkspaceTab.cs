using System.Numerics;
using System.Reflection;
using BlamTool.Systems;
using BlamTool.Windows;
using ImGuiNET;
using ImTool;
using Veldrid.ImageSharp;

namespace BlamTool;

public class TagExplorerTab : BaseTab
{
    public TagExplorerTab(BlamTool tool) : base(tool) => this.Tool = Tool;
    private About       AboutWindow       = new About();
    private TagExplorer TagExplorerWindow = new();

    public override    string         WorkspaceName { get; } = "TagExplorer";
    protected override WorkspaceFlags Flags         { get; } = WorkspaceFlags.SingleWorkspace;
    public override    string         Name          { get; } = "Tag Explorer";
        
    // if you want a custom default docking layout, this is the place to do that
    protected override void CreateDockSpace(Vector2 size)
    {
        // split
        ImGui.DockBuilderSplitNode(DockSpaceID, ImGuiDir.Left, 0.2f, out var leftId, out var rightId);
        ImGui.DockBuilderSplitNode(rightId, ImGuiDir.Down, 0.2f, out var rightBottomId, out var rightTopId);

        ImGui.DockBuilderDockWindow("Packet DB", leftId);
        ImGui.DockBuilderDockWindow("Logs", rightBottomId);
        ImGui.DockBuilderDockWindow("Workspace", rightTopId);
            
    }
    
    public override void Load()
    {
        OpenWindow(TagExplorerWindow);
        
        if (!string.IsNullOrEmpty(BlamToolConfig.Inst.ReachEKPath)) {
            Blam.Start();
            
            var testTagEditor = new TagEditor(@$"{BlamToolConfig.Inst.ReachEKPath}\tags\levels\solo\m20\bitmaps\concrete\m20_concrete_pitted_diff.bitmap");
            OpenWindow(testTagEditor);
            
            var testTagEditor2 = new TagEditor(@$"{BlamToolConfig.Inst.ReachEKPath}\tags\multiplayer\megalo\global.megalo_string_id_table");
            OpenWindow(testTagEditor2);
        }
    }

    // unload gets called when the tab is removed from the window
    // time to do some cleanup :>
    public override void Unload()
    {
        
    }

    // here you can submit your own windows
    // happens on every frame
    protected override void SubmitContent()
    {
        base.SubmitContent();

        BlamTool.Log.DrawWindow();
    }

    // the "workspace" is the central node / free space in a tab
    // you can change its behavior by overriding the Flags property on this tab
    // for instance, WorkspaceFlags.SingleWorkspace is great if you have a small tool with a single tab
    // since it will disable docking in the workspace and remove the inner tab bar
    // it might also be a good idea to set AllowFloatingWindows = false in the config constructor to disable viewports
    // if you're using this mode
    //
    // you can sumbit controls directly to the workspace from this override as the workspace is contained in a imgui window
    protected override unsafe void SubmitWorkspaceContent()
    {
        var wClass = new ImGuiWindowClass();
        wClass.DockNodeFlagsOverrideSet = ImGuiDockNodeFlags.NoWindowMenuButton | ImGuiDockNodeFlags.NoCloseButton | ImGuiDockNodeFlags.NoDockingOverMe;
        ImGuiNative.igSetNextWindowClass(&wClass);
        ImGui.Begin("Workspace");
            
        ImGui.End();
    }
    
    protected override void SubmitSettings(bool active)
    {
        if (ImGui.Button("About")) {
            ToggleWindow(AboutWindow);
        }
        
        Settings_EditingKitPath();

        if (ImGui.Button("Save")) {
            BlamToolConfig.Inst.Save();
        }
    }

    private static void Settings_EditingKitPath()
    {
        ImGui.Text("Halo Reach EK Path:");
        var reachEKPath = BlamToolConfig.Inst.ReachEKPath ?? "";
        ImGui.InputText("###", ref reachEKPath, 500);
        BlamToolConfig.Inst.ReachEKPath = reachEKPath;
        ImGui.SameLine();
        if (ImGui.Button("...")) {
        }
    }

    // submit your file menu etc from here :)
    protected override void SubmitMainMenu()
    {
        if (ImGui.BeginMenu("File"))
        {
            ImGui.EndMenu();
        }
            
        if (ImGui.BeginMenu("Edit"))
        {
            ImGui.EndMenu();
        }
            
        if (ImGui.BeginMenu("View"))
        {
            ImGui.EndMenu();
        }
            
        if (ImGui.BeginMenu("Navigate"))
        {
            ImGui.EndMenu();
        }
        if (ImGui.BeginMenu("Help"))
        {
            ImGui.EndMenu();
        }
    }
}