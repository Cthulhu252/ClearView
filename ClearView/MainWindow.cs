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

    private Plugin vPlugin;


    
    public MainWindow(Plugin plugin)
        : base("ClearView", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(375, 330),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };


        vPlugin = plugin;

    }

    public void Dispose() { }

    public override void Draw()
    {
        
        // This is debug stuff
        
        var namePlateSetting = ClearView.GetNamePlateNameTitleTypeSelf();
        var namePlateSettingStr = namePlateSetting.ToString();
        ImGui.Text("Name Plate Title Setting: " + namePlateSettingStr);

        var namePlateSetting2 = ClearView.GetNamePlateNameTypeSelf();
        var namePlateSettingStr2 = namePlateSetting2.ToString();
        ImGui.Text("Name Plate Name Type: " + namePlateSettingStr2);


        var CombatCheck = Services.Condition[ConditionFlag.InCombat];
        var CombatCheckStr = CombatCheck.ToString();
        ImGui.Text("Combat State: " + CombatCheckStr);


        var initialName2 = Storage.InitialNamePlateNameTitleTypeSelf;
        var initialNameStr2 = initialName2.ToString();
        ImGui.Text($"Initial Name Plate Title :" + initialNameStr2);

        var initialName3 = Storage.InitialNamePlateNameTypeSelf;
        var initialNameStr3 = initialName3.ToString();
        ImGui.Text($"Initial Name Plate Type :" + initialNameStr3);

        




        // if (ImGui.Button("Show Settings"))
        //{
        //    vPlugin.ToggleConfigUI();


        //}

        ImGui.Text("If you changed your displayname setting push this button to save them to be restored when combat ends");
        ImGui.Spacing();
        if (ImGui.Button("Update Default to Current Setting"))
        {
            Storage.refreshInitial();
        }











    }
}
