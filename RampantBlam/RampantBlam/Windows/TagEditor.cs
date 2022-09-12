using System.IO.IsolatedStorage;
using System.Numerics;
using Bungie.Tags;
using ImGuiNET;
using ImTool;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Veldrid.ImageSharp;

namespace BlamTool.Windows;

public class TagEditor : BaseWindow
{
    public  Bungie.Tags.TagPath TagPath;
    public  Bungie.Tags.TagFile TagFile;
    private IntPtr              TagBaseAddr = IntPtr.Zero;
    private HexView             HexTagView = new ();
    
    private ImageSharpTexture Image;
    private IntPtr            TexBinding;

    public TagEditor(string path)
    {
        TagPath = Bungie.Tags.TagPath.FromFilename(path);
        TagFile = new TagFile(TagPath);

        var tagData = TagFile.Serialize();
        HexTagView.SetData(tagData, Array.Empty<HexView.HighlightSection>());

        Name = TagPath.ShortName;
    }

    public override void Draw()
    {
        ImGui.BeginChild("LeftPanel", new Vector2(500, -1));
        {
            ImGui.Image(TexBinding, new Vector2(383, 421));

            ImGui.Text($"{TagFile.FieldPath}");
            ImGui.Text($"{TagFile.Size}");

            foreach (var tagField in TagFile.Fields) {
                if (TagBaseAddr == IntPtr.Zero) {
                    TagBaseAddr = tagField.Address;
                }

                if (ImGui.CollapsingHeader($"{tagField.DisplayName}###{tagField.FieldPath}")) {
                    DrawTagFieldMetaInfo(tagField);

                    ImGui.Indent();
                    if (tagField is TagFieldBlock tagBlock) {
                        DrawTagBlock(tagBlock);
                    }

                    ImGui.Unindent();
                }
            }
        }
        ImGui.EndChild();
        
        ImGui.SameLine();
        
        ImGui.BeginChild("RightPanel", new Vector2(800, -1));
        {
            HexTagView.Draw();
        }
        ImGui.EndChild();

        /*foreach (var tagField in TagFile.Fields) {
            ImGui.Text($"{tagField.DisplayName}, [{tagField.Description}] ({tagField.FieldType}) {{{tagField.GetType()}");

            if (tagField is TagFieldBlock tagBlock) {
                ImGui.Indent();
                foreach (var element in tagBlock.Elements) {
                    foreach (var elementField in element.Fields) {
                        ImGui.Text($"{elementField.FieldPath}: {elementField.DisplayName} = {elementField.FieldType}");
                    }
                }
                ImGui.Unindent();
            }
        }*/
    }

    public void DrawTagBlock(TagFieldBlock block)
    {
        foreach (var blockItem in block) {
            foreach (var item in blockItem.Fields) {
                ImGui.Text($"DisplayName: {item.DisplayName}");
                DrawTagFieldMetaInfo(item);
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Spacing();
                ImGui.Spacing();
            }
        }
    }

    private void DrawTagFieldMetaInfo(TagField tagField)
    {
        ImGui.Text($"Field Path: {tagField.FieldPath}");
        ImGui.Text($"Address: {tagField.Address} ({tagField.Address.ToInt64() - TagBaseAddr.ToInt64()})");
        ImGui.Text($"Description: {tagField.Description}");
        ImGui.Text($"Units: {tagField.Units}");
        ImGui.Text($"Size: {tagField.Size}");
        ImGui.Text($"FieldSubtype: {tagField.FieldSubtype}");
        ImGui.Text($"FieldType: {tagField}");
        ImGui.Text($"FieldType: {tagField}");
    }
}