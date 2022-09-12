using System.Numerics;
using System.Reflection;
using BlamTool.Windows;
using ImGuiNET;
using ImTool;
using Veldrid.ImageSharp;

namespace BlamTool;

public class TagExplorerTab : BaseTab
{
    public TagExplorerTab(BlamTool tool) : base(tool) => this.Tool = Tool;
    private About AboutWindow = new About();

    public override    string         WorkspaceName { get; } = "TagExplorer";
    protected override WorkspaceFlags Flags         { get; } = WorkspaceFlags.None;
    public override    string         Name          { get; } = "Tag Explorer";
        
    // if you want a custom default docking layout, this is the place to do that
    protected override void CreateDockSpace(Vector2 size)
    {
        // split
        ImGui.DockBuilderSplitNode(DockSpaceID, ImGuiDir.Left, 0.30f, out uint leftId, out uint centerId);
        ImGui.DockBuilderSplitNode(centerId, ImGuiDir.Down, 0.20f, out uint centerBottomId, out uint centerTopId);
        ImGui.DockBuilderSplitNode(centerTopId, ImGuiDir.Right, 0.40f, out uint centerRightId, out uint centerLeftId);
        ImGui.DockBuilderSplitNode(centerRightId, ImGuiDir.Down, 0.40f, out uint centerRightBottomId, out uint centerRightTopId);

        // assign
        //ImGui.DockBuilderDockWindow("Hex View", topLeftId);
        ImGui.DockBuilderDockWindow("Test Log Window", centerBottomId);
        ImGui.DockBuilderDockWindow("Dear ImGui Demo", leftId);
        ImGui.DockBuilderDockWindow("Dear ImGui Metrics/Debugger", centerRightTopId);
        ImGui.DockBuilderDockWindow("Extensions test :>", centerRightBottomId);
            
    }
    
    public override void Load()
    {

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
        
        ImGui.ShowDemoWindow();
        ImGui.ShowMetricsWindow();
    }

    // the "workspace" is the central node / free space in a tab
    // you can change its behavior by overriding the Flags property on this tab
    // for instance, WorkspaceFlags.SingleWorkspace is great if you have a small tool with a single tab
    // since it will disable docking in the workspace and remove the inner tab bar
    // it might also be a good idea to set AllowFloatingWindows = false in the config constructor to disable viewports
    // if you're using this mode
    //
    // you can sumbit controls directly to the workspace from this override as the workspace is contained in a imgui window
    protected override void SubmitWorkspaceContent()
    {
            
    }

    // anything you submit here appears on the settings pane
    // the "active" bool tells you if this tab is currently active
    protected override void SubmitSettings(bool active)
    {
        ImGui.Text($"Submitted from WorkspaceTab.SubmitSettings({active})");

        if (ImGui.Button("About")) {
            ToggleWindow(AboutWindow);
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