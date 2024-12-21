using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using System.IO;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin.Services;
using ClearView.Windows;
using CombatCursorContainment;
using Dalamud.Game.Config;
using System;
using Dalamud.Utility;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Common.Lua;
using Dalamud.Game.ClientState.Conditions;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClearView;



public sealed class Plugin : IDalamudPlugin
{
    [PluginService] internal static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
    [PluginService] internal static ITextureProvider TextureProvider { get; private set; } = null!;
    [PluginService] internal static ICommandManager CommandManager { get; private set; } = null!;



    private const string CommandName = "/clearview";

    public Configuration Configuration { get; init; }

    public readonly WindowSystem WindowSystem = new("ClearView");
    private ConfigWindow ConfigWindow { get; init; }
    private MainWindow MainWindow { get; init; }

    


    public Plugin(IDalamudPluginInterface pluginInterface)
    {

        pluginInterface.Create<Services>();

        Services.Config = Services.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();

        // you might normally want to embed resources and load them from the manifest stream
        //var goatImagePath = Path.Combine(PluginInterface.AssemblyLocation.Directory?.FullName!, "goat.png");

        


        ConfigWindow = new ConfigWindow(this);
        MainWindow = new MainWindow(this);

        WindowSystem.AddWindow(ConfigWindow);
        WindowSystem.AddWindow(MainWindow);

        CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
        {
            HelpMessage = "Opens the config window"
        });

        PluginInterface.UiBuilder.Draw += DrawUI;

        // This adds a button to the plugin installer entry of this plugin which allows
        // to toggle the display status of the configuration ui
        PluginInterface.UiBuilder.OpenConfigUi += ToggleConfigUI;

        // Adds another button that is doing the same but for the main ui of the plugin
        PluginInterface.UiBuilder.OpenMainUi += ToggleMainUI;

        Services.Condition.ConditionChange += ClearView.OnConditionChange;
        //Services.GameConfig.Changed += OnGameConfigChanged;

       // Services.GameConfig.Changed += (sender, args) =>
       // {
       //     if (!Services.Condition[ConditionFlag.InCombat])
       //     {
                // Your code here
                // ... other actions based on configuration change
                //Storage.refreshInitial();
                //Services.ChatGui.Print("Config Changed got checked");
        //    }
        //};

    }

   


    public void Dispose()
    {
        WindowSystem.RemoveAllWindows();

        ConfigWindow.Dispose();
        MainWindow.Dispose();

        CommandManager.RemoveHandler(CommandName);
    }

    private void OnCommand(string command, string args)
    {
        // in response to the slash command, just toggle the display status of our main ui
        ToggleMainUI();
    }

    private void DrawUI() => WindowSystem.Draw();

    public void ToggleConfigUI() => ConfigWindow.Toggle();
    public void ToggleMainUI() => MainWindow.Toggle();


    

}
