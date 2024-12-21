using CombatCursorContainment;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearView
{
    public class Storage
    {
        public static uint InitialNamePlateNameTitleTypeSelf { get; set; }
        public static uint InitialNamePlateNameTitleTypeParty { get; set; }
        public static uint InitialNamePlateNameTitleTypeAlliance { get; set; }
        public static uint InitialNamePlateNameTitleTypeOther { get; set; }
        public static uint InitialNamePlateNameTypeSelf { get; set; }
        public static uint InitialNamePlateNameTypeParty { get; set; }
        public static uint InitialNamePlateNameTypeAlliance { get; set; }
        public static uint InitialNamePlateNameTypeOther { get; set; }

        public static uint CombatNamePlateNameTitleTypeSelf { get; set; }
        public static uint CombatNamePlateNameTitleTypeParty { get; set; }
        public static uint CombatNamePlateNameTitleTypeAlliance { get; set; }
        public static uint CombatNamePlateNameTitleTypeOther { get; set; }
        public static uint CombatNamePlateNameTypeSelf { get; set; }
        public static uint CombatNamePlateNameTypeParty { get; set; }
        public static uint CombatNamePlateNameTypeAlliance { get; set; }
        public static uint CombatNamePlateNameTypeOther { get; set; }

        //static Storage()
        //{
        //    InitialNamePlateNameTitleTypeSelf = GetNamePlateNameTitleTypeSelf();
        //    InitialNamePlateNameTitleTypeParty = GetNamePlateNameTitleTypeParty();
        //    InitialNamePlateNameTitleTypeAlliance = GetNamePlateNameTitleTypeAlliance();
        //    InitialNamePlateNameTitleTypeOther = GetNamePlateNameTitleTypeOther();
        //    InitialNamePlateNameTypeSelf = GetNamePlateNameTypeSelf();
        //    InitialNamePlateNameTypeParty = GetNamePlateNameTypeParty();
        //    InitialNamePlateNameTypeAlliance = GetNamePlateNameTypeAlliance();
        //    InitialNamePlateNameTypeOther = GetNamePlateNameTypeOther();
            
        //}

        //public static void refreshInitial()
        //{
        //    InitialNamePlateNameTitleTypeSelf = GetNamePlateNameTitleTypeSelf();
        //    InitialNamePlateNameTitleTypeParty = GetNamePlateNameTitleTypeParty();
        //    InitialNamePlateNameTitleTypeAlliance = GetNamePlateNameTitleTypeAlliance();
         //   InitialNamePlateNameTitleTypeOther = GetNamePlateNameTitleTypeOther();
         //   InitialNamePlateNameTypeSelf = GetNamePlateNameTypeSelf();
         //   InitialNamePlateNameTypeParty = GetNamePlateNameTypeParty();
         //   InitialNamePlateNameTypeAlliance = GetNamePlateNameTypeAlliance();
         //   InitialNamePlateNameTypeOther = GetNamePlateNameTypeOther();

        //}

        private static uint GetNamePlateNameTitleTypeSelf()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTitleTypeSelf.ToString());
        }



        private static uint GetNamePlateNameTitleTypeParty()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTitleTypeParty.ToString());
        }


        private static uint GetNamePlateNameTitleTypeAlliance()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTitleTypeAlliance.ToString());
        }


        private static uint GetNamePlateNameTitleTypeOther()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTitleTypeOther.ToString());
        }



        private static uint GetNamePlateNameTypeSelf()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTypeSelf.ToString());
        }


        private static uint GetNamePlateNameTypeParty()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTypeParty.ToString());
        }

        private static uint GetNamePlateNameTypeAlliance()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTypeAlliance.ToString());
        }

        private static uint GetNamePlateNameTypeOther()
        {
            return Services.GameConfig.UiConfig.GetUInt(UiConfigOption.NamePlateNameTypeOther.ToString());
        }

        private void OnGameConfigChanged(object sender, EventArgs e)
        {
            // Update your configuration or call your desired code here
            //_config = Services.GameConfig.GetSettings<Configuration>();
            //MyCodeToRunOnChange(); // Replace with your actual code to execute
        }

    }
}
