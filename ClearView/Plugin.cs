using Dalamud.Game.Command;
using Dalamud.IoC;
using Dalamud.Plugin;
using System.IO;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin.Services;
using CombatCursorContainment;
using Dalamud.Game.Config;
using System;
using Dalamud.Utility;
using Dalamud.Logging;
using FFXIVClientStructs.FFXIV.Common.Lua;
using Dalamud.Game.ClientState.Conditions;
using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace ClearView
{
    public sealed class Plugin : IDalamudPlugin
    {
        [PluginService] internal static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
        [PluginService] internal static ITextureProvider TextureProvider { get; private set; } = null!;
        [PluginService] internal static ICommandManager CommandManager { get; private set; } = null!;

        private const string CommandName = "/clearview";

        public Configuration Configuration { get; init; }

        public readonly WindowSystem WindowSystem = new("ClearView");
        // private ConfigWindow { get; init; }
        private MainWindow MainWindow { get; init; }

        public Plugin(IDalamudPluginInterface pluginInterface)
        {
            pluginInterface.Create<Services>();

            Services.Config = Services.PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
            Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();

            // ConfigWindow = new ConfigWindow(this);
            MainWindow = new MainWindow(this);

            // WindowSystem.AddWindow(ConfigWindow);
            WindowSystem.AddWindow(MainWindow);

            CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "Opens the config window"
            });

            PluginInterface.UiBuilder.Draw += DrawUI;

            // PluginInterface.UiBuilder.OpenConfigUi += ToggleConfigUI;
            PluginInterface.UiBuilder.OpenMainUi += ToggleMainUI;

            Services.Condition.ConditionChange += ClearView.OnConditionChange;
        }

        public void Dispose()
        {
            WindowSystem.RemoveAllWindows();

            // ConfigWindow.Dispose();
            MainWindow.Dispose();

            CommandManager.RemoveHandler(CommandName);
        }

        private void OnCommand(string command, string args)
        {
            ToggleMainUI();
        }

        private void DrawUI() => WindowSystem.Draw();

        // public void ToggleConfigUI() => ConfigWindow.Toggle();
        public void ToggleMainUI() => MainWindow.Toggle();
    }
}
