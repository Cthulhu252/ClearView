using ClearView.Windows;
using CombatCursorContainment;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.Config;
using Dalamud.Plugin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearView
{
    internal class ClearView
    {
                
        public static uint GetNamePlateNameTitleTypeSelf()
        {
             return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTitleTypeSelf.ToString());
         }

        internal static void SetNamePlateNameTitleTypeSelf(uint value)
        {
            Services.GameConfig.UiConfig.Set(UiConfigOption.NamePlateNameTitleTypeSelf.ToString(), value);
        }
        public static uint GetNamePlateNameTitleTypeParty()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTitleTypeParty.ToString());
        }

        internal static void SetNamePlateNameTitleTypeParty(uint value)
        {
            Services.GameConfig.UiConfig.Set(UiConfigOption.NamePlateNameTitleTypeParty.ToString(), value);
        }
        public static uint GetNamePlateNameTitleTypeAlliance()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTitleTypeAlliance.ToString());
        }

        internal static void SetNamePlateNameTitleTypeAlliance(uint value)
        {
            Services.GameConfig.UiConfig.Set(UiConfigOption.NamePlateNameTitleTypeAlliance.ToString(), value);
        }
        public static uint GetNamePlateNameTitleTypeOther()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTitleTypeOther.ToString());
        }

        internal static void SetNamePlateNameTitleTypeOther(uint value)
        {
            Services.GameConfig.UiConfig.Set(UiConfigOption.NamePlateNameTitleTypeOther.ToString(), value);
        }

        public static uint GetNamePlateNameTypeSelf()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTypeSelf.ToString());
        }
        internal static void SetNameNamePlateNameTypeSelf(uint value)
        {
            Services.GameConfig.UiConfig.Set(UiConfigOption.NamePlateNameTypeSelf.ToString(), value);
        }
        public static uint GetNamePlateNameTypeParty()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTypeParty.ToString());
        }
        internal static void SetNameNamePlateNameTypeParty(uint value)
        {
            Services.GameConfig.UiConfig.Set(UiConfigOption.NamePlateNameTypeParty.ToString(), value);
        }
        public static uint GetNamePlateNameTypeAlliance()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTypeAlliance.ToString());
        }
        internal static void SetNameNamePlateNameTypeAlliance(uint value)
        {
            Services.GameConfig.UiConfig.Set(UiConfigOption.NamePlateNameTypeAlliance.ToString(), value);
        }
        public static uint GetNamePlateNameTypeOther()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTypeOther.ToString());
        }
        internal static void SetNameNamePlateNameTypeOther(uint value)
        {
            Services.GameConfig.UiConfig.Set(UiConfigOption.NamePlateNameTypeOther.ToString(), value);
        }


        internal static void SetAll()
        {
            
            //To be updates to set values from a settings screen
            
            ClearView.SetNamePlateNameTitleTypeSelf(0);
            ClearView.SetNamePlateNameTitleTypeParty(0);
            ClearView.SetNamePlateNameTitleTypeAlliance(0);
            ClearView.SetNamePlateNameTitleTypeOther(0);


            
            ClearView.SetNameNamePlateNameTypeSelf(3);
            ClearView.SetNameNamePlateNameTypeParty(3);
            ClearView.SetNameNamePlateNameTypeAlliance(3);
            ClearView.SetNameNamePlateNameTypeOther(3);


            
        }

        internal static void RestoreAll()
        {
            // Restores the values saved when plugin loaded
            //ClearView.SetNamePlateNameTitleTypeSelf(Storage.InitialNamePlateNameTitleTypeSelf);
            //ClearView.SetNamePlateNameTitleTypeParty(Storage.InitialNamePlateNameTitleTypeParty);
            //ClearView.SetNamePlateNameTitleTypeAlliance(Storage.InitialNamePlateNameTitleTypeAlliance);
            //ClearView.SetNamePlateNameTitleTypeOther(Storage.InitialNamePlateNameTitleTypeOther); 
            //ClearView.SetNameNamePlateNameTypeSelf(Storage.InitialNamePlateNameTypeSelf);
            //ClearView.SetNameNamePlateNameTypeParty(Storage.InitialNamePlateNameTypeParty);
            //ClearView.SetNameNamePlateNameTypeAlliance(Storage.InitialNamePlateNameTypeAlliance);
            //ClearView.SetNameNamePlateNameTypeOther(Storage.InitialNamePlateNameTypeOther);
            ClearView.SetNamePlateNameTitleTypeSelf(1);
            ClearView.SetNamePlateNameTitleTypeParty(1);
            ClearView.SetNamePlateNameTitleTypeAlliance(1);
            ClearView.SetNamePlateNameTitleTypeOther(1);
            ClearView.SetNameNamePlateNameTypeSelf(0);
            ClearView.SetNameNamePlateNameTypeParty(0);
            ClearView.SetNameNamePlateNameTypeAlliance(0);
            ClearView.SetNameNamePlateNameTypeOther(0);

            // Services.ChatGui.Print("Titles restored to: " + Storage.InitialNamePlateNameTitleTypeSelf);
        }

        

        public static void OnConditionChange(ConditionFlag flag, bool value)
        {
            if (flag != ConditionFlag.InCombat) return;
           // Services.ChatGui.Print("OnConditionChane got checked");
            if (value)
            {
                SetAll();
            }
            else
            {
                RestoreAll();
            }
        }










        }
 }






    
