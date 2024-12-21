using System;
using System.Linq;
using System.Numerics;
using CombatCursorContainment;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.Config;
using Dalamud.Interface.Internal;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Common.Lua;
using FFXIVClientStructs.FFXIV.Component.GUI;
using ImGuiNET;

namespace ClearView;

public class MainWindow : Window, IDisposable
{
    public Plugin vPlugin;

    public MainWindow(Plugin plugin)
        : base("ClearView", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        vPlugin = plugin;

        // Run the "Update All" logic when the MainWindow is first created
        UpdateAll();
    }

    private void UpdateAll()
    {
        var displayTypeOptions = new[] { "Full Name", "Surname Abbreviated", "Forename Abbreviated", "Initials" };
        var titleDisplayOptions = new[] { "Hide", "Show" };

        var selectedDisplayTypeSelf = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.DisplayTypeSelf);
        var selectedDisplayTypeParty = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.DisplayTypeParty);
        var selectedDisplayTypeAlliance = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.DisplayTypeAlliance);
        var selectedDisplayTypeOther = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.DisplayTypeOther);

        var selectedTitleDisplaySelf = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.TitleDisplaySelf);
        var selectedTitleDisplayParty = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.TitleDisplayParty);
        var selectedTitleDisplayAlliance = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.TitleDisplayAlliance);
        var selectedTitleDisplayOther = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.TitleDisplayOther);

        var selectedCombatDisplayTypeSelf = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.CombatDisplayTypeSelf);
        var selectedCombatDisplayTypeParty = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.CombatDisplayTypeParty);
        var selectedCombatDisplayTypeAlliance = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.CombatDisplayTypeAlliance);
        var selectedCombatDisplayTypeOther = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.CombatDisplayTypeOther);

        var selectedCombatTitleDisplaySelf = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.CombatTitleDisplaySelf);
        var selectedCombatTitleDisplayParty = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.CombatTitleDisplayParty);
        var selectedCombatTitleDisplayAlliance = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.CombatTitleDisplayAlliance);
        var selectedCombatTitleDisplayOther = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.CombatTitleDisplayOther);

        Storage.InitialNamePlateNameTypeSelf = (uint)selectedDisplayTypeSelf;
        Storage.InitialNamePlateNameTypeParty = (uint)selectedDisplayTypeParty;
        Storage.InitialNamePlateNameTypeAlliance = (uint)selectedDisplayTypeAlliance;
        Storage.InitialNamePlateNameTypeOther = (uint)selectedDisplayTypeOther;

        Storage.InitialNamePlateNameTitleTypeSelf = (uint)selectedTitleDisplaySelf;
        Storage.InitialNamePlateNameTitleTypeParty = (uint)selectedTitleDisplayParty;
        Storage.InitialNamePlateNameTitleTypeAlliance = (uint)selectedTitleDisplayAlliance;
        Storage.InitialNamePlateNameTitleTypeOther = (uint)selectedTitleDisplayOther;

        Storage.CombatNamePlateNameTypeSelf = (uint)selectedCombatDisplayTypeSelf;
        Storage.CombatNamePlateNameTypeParty = (uint)selectedCombatDisplayTypeParty;
        Storage.CombatNamePlateNameTypeAlliance = (uint)selectedCombatDisplayTypeAlliance;
        Storage.CombatNamePlateNameTypeOther = (uint)selectedCombatDisplayTypeOther;

        Storage.CombatNamePlateNameTitleTypeSelf = (uint)selectedCombatTitleDisplaySelf;
        Storage.CombatNamePlateNameTitleTypeParty = (uint)selectedCombatTitleDisplayParty;
        Storage.CombatNamePlateNameTitleTypeAlliance = (uint)selectedCombatTitleDisplayAlliance;
        Storage.CombatNamePlateNameTitleTypeOther = (uint)selectedCombatTitleDisplayOther;

        vPlugin.Configuration.Save();
    }

    public void Dispose() { }

    public override void Draw()
    {
       

        ImGui.Separator();
        ImGui.Text("Out of Combat");
        ImGui.Separator();

        var displayTypeOptions = new[] { "Full Name", "Surname Abbreviated", "Forename Abbreviated", "Initials" };

        var selectedDisplayTypeSelf = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.DisplayTypeSelf);
        if (ImGui.Combo("Display Type Self", ref selectedDisplayTypeSelf, displayTypeOptions, displayTypeOptions.Length))
        {
            vPlugin.Configuration.DisplayTypeSelf = displayTypeOptions[selectedDisplayTypeSelf];
            

            // Update Storage.InitialNamePlateNameTitleTypeSelf based on selected display type
            Storage.InitialNamePlateNameTypeSelf = (uint)(selectedDisplayTypeSelf);
            vPlugin.Configuration.Save();
        }

        var selectedDisplayTypeParty = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.DisplayTypeParty);
        if (ImGui.Combo("Display Type Party", ref selectedDisplayTypeParty, displayTypeOptions, displayTypeOptions.Length))
        {
            vPlugin.Configuration.DisplayTypeParty = displayTypeOptions[selectedDisplayTypeParty];
            vPlugin.Configuration.Save();

            // Update Storage.InitialNamePlateNameTitleTypeParty based on selected display type
            Storage.InitialNamePlateNameTypeParty = (uint)(selectedDisplayTypeParty);
        }

        var selectedDisplayTypeAlliance = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.DisplayTypeAlliance);
        if (ImGui.Combo("Display Type Alliance", ref selectedDisplayTypeAlliance, displayTypeOptions, displayTypeOptions.Length))
        {
            vPlugin.Configuration.DisplayTypeAlliance = displayTypeOptions[selectedDisplayTypeAlliance];
            vPlugin.Configuration.Save();

            // Update Storage.InitialNamePlateNameTitleTypeAlliance based on selected display type
            Storage.InitialNamePlateNameTypeAlliance = (uint)(selectedDisplayTypeAlliance);
        }

        var selectedDisplayTypeOther = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.DisplayTypeOther);
        if (ImGui.Combo("Display Type Other", ref selectedDisplayTypeOther, displayTypeOptions, displayTypeOptions.Length))
        {
            vPlugin.Configuration.DisplayTypeOther = displayTypeOptions[selectedDisplayTypeOther];
            vPlugin.Configuration.Save();

            // Update Storage.InitialNamePlateNameTitleTypeOther based on selected display type
            Storage.InitialNamePlateNameTypeOther = (uint)(selectedDisplayTypeOther);
        }

        var titleDisplayOptions = new[] { "Hide", "Show" };
        var selectedTitleDisplaySelf = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.TitleDisplaySelf);
        if (ImGui.Combo("Title Display Self", ref selectedTitleDisplaySelf, titleDisplayOptions, titleDisplayOptions.Length))
        {
            vPlugin.Configuration.TitleDisplaySelf = titleDisplayOptions[selectedTitleDisplaySelf];
            vPlugin.Configuration.Save();

            // Update Storage.InitialNamePlateNameTypeSelf based on selected title display
            Storage.InitialNamePlateNameTitleTypeSelf = (uint)(selectedTitleDisplaySelf);
        }

        var selectedTitleDisplayParty = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.TitleDisplayParty);
        if (ImGui.Combo("Title Display Party", ref selectedTitleDisplayParty, titleDisplayOptions, titleDisplayOptions.Length))
        {
            vPlugin.Configuration.TitleDisplayParty = titleDisplayOptions[selectedTitleDisplayParty];
            vPlugin.Configuration.Save();

            // Update Storage.InitialNamePlateNameTypeParty based on selected title display
            Storage.InitialNamePlateNameTitleTypeParty = (uint)(selectedTitleDisplayParty);
        }

        var selectedTitleDisplayAlliance = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.TitleDisplayAlliance);
        if (ImGui.Combo("Title Display Alliance", ref selectedTitleDisplayAlliance, titleDisplayOptions, titleDisplayOptions.Length))
        {
            vPlugin.Configuration.TitleDisplayAlliance = titleDisplayOptions[selectedTitleDisplayAlliance];
            vPlugin.Configuration.Save();

            // Update Storage.InitialNamePlateNameTypeAlliance based on selected title display
            Storage.InitialNamePlateNameTitleTypeAlliance = (uint)(selectedTitleDisplayAlliance);
        }

        var selectedTitleDisplayOther = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.TitleDisplayOther);
        if (ImGui.Combo("Title Display Other", ref selectedTitleDisplayOther, titleDisplayOptions, titleDisplayOptions.Length))
        {
            vPlugin.Configuration.TitleDisplayOther = titleDisplayOptions[selectedTitleDisplayOther];
            vPlugin.Configuration.Save();

            // Update Storage.InitialNamePlateNameTypeOther based on selected title display
            Storage.InitialNamePlateNameTitleTypeOther = (uint)(selectedTitleDisplayOther);
        }

        ImGui.Separator();
        ImGui.Text("In Combat");
        ImGui.Separator();

        var selectedCombatDisplayTypeSelf = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.CombatDisplayTypeSelf);
        if (ImGui.Combo("Combat Display Type Self", ref selectedCombatDisplayTypeSelf, displayTypeOptions, displayTypeOptions.Length))
        {
            vPlugin.Configuration.CombatDisplayTypeSelf = displayTypeOptions[selectedCombatDisplayTypeSelf];
            vPlugin.Configuration.Save();

            // Update Storage.CombatNamePlateNameTitleTypeSelf based on selected display type
            Storage.CombatNamePlateNameTypeSelf = (uint)(selectedCombatDisplayTypeSelf);
        }

        var selectedCombatDisplayTypeParty = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.CombatDisplayTypeParty);
        if (ImGui.Combo("Combat Display Type Party", ref selectedCombatDisplayTypeParty, displayTypeOptions, displayTypeOptions.Length))
        {
            vPlugin.Configuration.CombatDisplayTypeParty = displayTypeOptions[selectedCombatDisplayTypeParty];
            vPlugin.Configuration.Save();

            // Update Storage.CombatNamePlateNameTitleTypeParty based on selected display type
            Storage.CombatNamePlateNameTypeParty = (uint)(selectedCombatDisplayTypeParty);
        }

        var selectedCombatDisplayTypeAlliance = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.CombatDisplayTypeAlliance);
        if (ImGui.Combo("Combat Display Type Alliance", ref selectedCombatDisplayTypeAlliance, displayTypeOptions, displayTypeOptions.Length))
        {
            vPlugin.Configuration.CombatDisplayTypeAlliance = displayTypeOptions[selectedCombatDisplayTypeAlliance];
            vPlugin.Configuration.Save();

            // Update Storage.CombatNamePlateNameTitleTypeAlliance based on selected display type
            Storage.CombatNamePlateNameTypeAlliance = (uint)(selectedCombatDisplayTypeAlliance);
        }

        var selectedCombatDisplayTypeOther = Array.IndexOf(displayTypeOptions, vPlugin.Configuration.CombatDisplayTypeOther);
        if (ImGui.Combo("Combat Display Type Other", ref selectedCombatDisplayTypeOther, displayTypeOptions, displayTypeOptions.Length))
        {
            vPlugin.Configuration.CombatDisplayTypeOther = displayTypeOptions[selectedCombatDisplayTypeOther];
            vPlugin.Configuration.Save();

            // Update Storage.CombatNamePlateNameTitleTypeOther based on selected display type
            Storage.CombatNamePlateNameTypeOther = (uint)(selectedCombatDisplayTypeOther);
        }

        var selectedCombatTitleDisplaySelf = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.CombatTitleDisplaySelf);
        if (ImGui.Combo("Combat Title Display Self", ref selectedCombatTitleDisplaySelf, titleDisplayOptions, titleDisplayOptions.Length))
        {
            vPlugin.Configuration.CombatTitleDisplaySelf = titleDisplayOptions[selectedCombatTitleDisplaySelf];
            vPlugin.Configuration.Save();

            // Update Storage.CombatNamePlateNameTypeSelf based on selected title display
            Storage.CombatNamePlateNameTitleTypeSelf = (uint)(selectedCombatTitleDisplaySelf);
        }

        var selectedCombatTitleDisplayParty = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.CombatTitleDisplayParty);
        if (ImGui.Combo("Combat Title Display Party", ref selectedCombatTitleDisplayParty, titleDisplayOptions, titleDisplayOptions.Length))
        {
            vPlugin.Configuration.CombatTitleDisplayParty = titleDisplayOptions[selectedCombatTitleDisplayParty];
            vPlugin.Configuration.Save();

            // Update Storage.CombatNamePlateNameTypeParty based on selected title display
            Storage.CombatNamePlateNameTitleTypeParty = (uint)(selectedCombatTitleDisplayParty);
        }

        var selectedCombatTitleDisplayAlliance = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.CombatTitleDisplayAlliance);
        if (ImGui.Combo("Combat Title Display Alliance", ref selectedCombatTitleDisplayAlliance, titleDisplayOptions, titleDisplayOptions.Length))
        {
            vPlugin.Configuration.CombatTitleDisplayAlliance = titleDisplayOptions[selectedCombatTitleDisplayAlliance];
            vPlugin.Configuration.Save();

            // Update Storage.CombatNamePlateNameTypeAlliance based on selected title display
            Storage.CombatNamePlateNameTitleTypeAlliance = (uint)(selectedCombatTitleDisplayAlliance);
        }

        var selectedCombatTitleDisplayOther = Array.IndexOf(titleDisplayOptions, vPlugin.Configuration.CombatTitleDisplayOther);
        if (ImGui.Combo("Combat Title Display Other", ref selectedCombatTitleDisplayOther, titleDisplayOptions, titleDisplayOptions.Length))
        {
            vPlugin.Configuration.CombatTitleDisplayOther = titleDisplayOptions[selectedCombatTitleDisplayOther];
            vPlugin.Configuration.Save();

            // Update Storage.CombatNamePlateNameTypeOther based on selected title display
            Storage.CombatNamePlateNameTitleTypeOther = (uint)(selectedCombatTitleDisplayOther);
        }

        ImGui.Separator();
        ImGui.Text("Current Values");
        ImGui.Separator();

        ImGui.Text($"InitialNamePlateNameTitleTypeSelf: {Storage.InitialNamePlateNameTitleTypeSelf}");
        ImGui.Text($"InitialNamePlateNameTitleTypeParty: {Storage.InitialNamePlateNameTitleTypeParty}");
        ImGui.Text($"InitialNamePlateNameTitleTypeAlliance: {Storage.InitialNamePlateNameTitleTypeAlliance}");
        ImGui.Text($"InitialNamePlateNameTitleTypeOther: {Storage.InitialNamePlateNameTitleTypeOther}");
        ImGui.Text($"InitialNamePlateNameTypeSelf: {Storage.InitialNamePlateNameTypeSelf}");
        ImGui.Text($"InitialNamePlateNameTypeParty: {Storage.InitialNamePlateNameTypeParty}");
        ImGui.Text($"InitialNamePlateNameTypeAlliance: {Storage.InitialNamePlateNameTypeAlliance}");
        ImGui.Text($"InitialNamePlateNameTypeOther: {Storage.InitialNamePlateNameTypeOther}");

        ImGui.Separator();

        ImGui.Text($"CombatNamePlateNameTitleTypeSelf: {Storage.CombatNamePlateNameTitleTypeSelf}");
        ImGui.Text($"CombatNamePlateNameTitleTypeParty: {Storage.CombatNamePlateNameTitleTypeParty}");
        ImGui.Text($"CombatNamePlateNameTitleTypeAlliance: {Storage.CombatNamePlateNameTitleTypeAlliance}");
        ImGui.Text($"CombatNamePlateNameTitleTypeOther: {Storage.CombatNamePlateNameTitleTypeOther}");
        ImGui.Text($"CombatNamePlateNameTypeSelf: {Storage.CombatNamePlateNameTypeSelf}");
        ImGui.Text($"CombatNamePlateNameTypeParty: {Storage.CombatNamePlateNameTypeParty}");
        ImGui.Text($"CombatNamePlateNameTypeAlliance: {Storage.CombatNamePlateNameTypeAlliance}");
        ImGui.Text($"CombatNamePlateNameTypeOther: {Storage.CombatNamePlateNameTypeOther}");

        
    }
}
