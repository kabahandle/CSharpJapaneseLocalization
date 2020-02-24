using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDummySQL.DAOs
{
    public class AccessConstring
    {
        //public static string conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\\Data\\main.mdb";
        public static string jpDBConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\App_Data\\JPDB.mdb";
        public static string SettingConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\App_Data\\setting.mdb";
        //public static string FormSettingConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\App_Data\\formsettings.mdb";
        //public static string FuncsConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\App_Data\\funcs.mdb";
        //public static string TemplatesConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\App_Data\\templates.mdb";

        /* //ACE は Office32bitに入っていない１
        public static string conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\App_Data\\main.mdb";
        public static string SettingConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\App_Data\\setting.mdb";
        public static string FormSettingConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\App_Data\\formsettings.mdb";
        public static string FuncsConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\App_Data\\funcs.mdb";
        public static string TemplatesConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\App_Data\\templates.mdb";
         */
    }
}
