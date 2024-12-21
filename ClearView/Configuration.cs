using Dalamud.Configuration;
using Dalamud.Plugin;
using System;

namespace ClearView;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 0;

    public string DisplayTypeSelf { get; set; }
    public string DisplayTypeParty { get; set; }
    public string DisplayTypeAlliance { get; set; }
    public string DisplayTypeOther { get; set; }

    public string TitleDisplaySelf { get; set; }
    public string TitleDisplayParty { get; set; }
    public string TitleDisplayAlliance { get; set; }
    public string TitleDisplayOther { get; set; }

    public string CombatDisplayTypeSelf { get; set; }
    public string CombatDisplayTypeParty { get; set; }
    public string CombatDisplayTypeAlliance { get; set; }
    public string CombatDisplayTypeOther { get; set; }

    public string CombatTitleDisplaySelf { get; set; }
    public string CombatTitleDisplayParty { get; set; }
    public string CombatTitleDisplayAlliance { get; set; }
    public string CombatTitleDisplayOther { get; set; }

    // the below exist just to make saving less cumbersome
    public void Save()
    {
        Plugin.PluginInterface.SavePluginConfig(this);
    }
}
