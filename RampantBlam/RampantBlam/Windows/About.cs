using System.Numerics;
using System.Reflection;
using ImGuiNET;
using Veldrid.ImageSharp;

namespace BlamTool.Windows;

public class About : BaseWindow
{
    private ImageSharpTexture AboutImage;
    private IntPtr            TexBinding;

    public About()
    {
        Name  = "About";
        Flags = ImGuiWindowFlags.NoDocking;
    }

    public override void OnOpen(BaseTab tab)
    {
        base.OnOpen(tab);
        Stream? resFilestream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"RampantBlam.Assets.Cortana.png");
        AboutImage = new ImageSharpTexture(resFilestream);
        TexBinding = tab.Tool.Window.GetOrCreateTextureBinding(AboutImage);
    }

    public override void OnClose(BaseTab tab)
    {
        base.OnClose(tab);
        //tab.Tool.Window.DisposeTextureBinding(AboutImage);
        AboutImage = null;
    }

    public override void Draw()
    {
        ImGui.Image(TexBinding, new Vector2(383, 421));
        ImGui.TextWrapped("Rampant Blam is a test tool to explore the ManagedBlam.dll that came with the Halo Reach mod tools.");
    }
}