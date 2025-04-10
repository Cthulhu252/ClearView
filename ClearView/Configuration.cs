using Dalamud.Configuration;
using Dalamud.Plugin;
using System;

namespace ClearView;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 0;

    public string DisplayTypeSelf { get; set; } = string.Empty;
    public string DisplayTypeParty { get; set; } = string.Empty;
    public string DisplayTypeAlliance { get; set; } = string.Empty;
    public string DisplayTypeOther { get; set; } = string.Empty;

    public string TitleDisplaySelf { get; set; } = string.Empty;
    public string TitleDisplayParty { get; set; } = string.Empty;
    public string TitleDisplayAlliance { get; set; } = string.Empty;
    public string TitleDisplayOther { get; set; } = string.Empty;

    public string CombatDisplayTypeSelf { get; set; } = string.Empty;
    public string CombatDisplayTypeParty { get; set; } = string.Empty;
    public string CombatDisplayTypeAlliance { get; set; } = string.Empty;
    public string CombatDisplayTypeOther { get; set; } = string.Empty;

    public string CombatTitleDisplaySelf { get; set; } = string.Empty;
    public string CombatTitleDisplayParty { get; set; } = string.Empty;
    public string CombatTitleDisplayAlliance { get; set; } = string.Empty;
    public string CombatTitleDisplayOther { get; set; } = string.Empty;

    // the below exist just to make saving less cumbersome
    public void Save()
    {
        Plugin.PluginInterface.SavePluginConfig(this);
    }
}
