using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDummySQL.DAOs
{
    class SettingsSingleton
    {
        #region //設定のキー
        public static string KeyMainFormTop = "KeyMainFormTop";
        public static string KeyMainFormLeft = "KeyMainFormLeft";
        public static string KeyMainFormHeight = "KeyMainFormHeight";
        public static string KeyMainFormWidth = "KeyMainFormWidth";
        public static string KeySaveDlgFormTop = "KeySaveDlgFormTop";
        public static string KeySaveDlgFormLeft = "KeySaveDlgFormLeft";
        //public static string KeySaveDlgFormHeight = "KeySaveDlgFormHeight";
        //public static string KeySaveDlgFormWidth = "KeySaveDlgFormWidth";
        public static string KeyA = "KeyA";
        public static string KeySetFuncFormTop = "KeySetFuncFormTop";
        public static string KeySetFuncFormLeft = "KeySetFuncFormLeft";
        public static string KeySetFuncFormHeight = "KeySetFuncFormHeight";
        public static string KeySetFuncFormWidth = "KeySetFuncFormWidth";
        public static string KeyAddTemplateFormTop = "KeyAddTemplateFormTop";
        public static string KeyAddTemplateFormLeft = "KeyAddTemplateFormLeft";
        public static string KeyFromTemplateFormTop = "KeyFromTemplateFormTop";
        public static string KeyFromTemplateFormLeft = "KeyFromTemplateFormLeft";
        public static string KeyFromTemplateFormHeight = "KeyFromTemplateFormHeight";
        public static string KeyFromTemplateFormWidth = "KeyFromTemplateFormWidth";
        public static string KeySubDummyFormTop = "KeySubDummyFormTop";
        public static string KeySubDummyFormLeft = "KeySubDummyFormLeft";
        public static string KeySubDummyFormHeight = "KeySubDummyFormHeight";
        public static string KeySubDummyFormWidth = "KeySubDummyFormWidth";
        public static string KeyTemplateFormNotApplyInitialCategory = "KeyTemplateFormNotApplyInitialCategory";
        public static string KeyTemplateFormGridColumnWidth = "KeyTemplateFormGridColumnWidth_";
        public const string KeyLicenseKey = "KeyLisenceKey";
        public const string KeyEmail = "KeyEmail";

        public const string KeyNDocTop = "KeyNDocTop";
        public const string KeyNDocLeft = "KeyNDocLeft";
        public const string KeyNDocWidth = "KeyNDocWidth";
        public const string KeyNDocHeight = "KeyNDocHeight";

        /*
        public const string KeyMainFormTop = "KeyMainFormTop";
        public const string KeyMainFormLeft = "KeyMainFormLeft";
        public const string KeyMainFormWidth = "KeyMainFormWidth";
        public const string KeyMainFormHeight = "KeyMainFormHeight";
        */
        #endregion

        #region //定数
        public static string TRUE = "true";
        public static string FALSE = "false";
        #endregion

        public class values
        {
            public int intValue = 0;
            public string strgValue = "";
            public values(int intvalue, string strgvalue)
            {
                this.intValue = intvalue;
                this.strgValue = strgvalue;
            }
        }
        private static Dictionary<string, values> cache_ = new Dictionary<string,values>();
        private static SettingsSingleton sigleton_ = new SettingsSingleton();

        SettingsSingleton()
        {
        }

        public SettingsSingleton getInstance()
        {
            return SettingsSingleton.sigleton_;
        }

        public static bool isExistsIntValue(string strgKey)
        {
            Dictionary<string,values> c = SettingsSingleton.cache_;

            if (c.ContainsKey(strgKey))
            {

                values v = c[strgKey];
                if (v != null)
                {
                    if (v.intValue != Int32.MinValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool isExistsStringValue(string strgKey)
        {
            Dictionary<string, values> c = SettingsSingleton.cache_;

            if (c.ContainsKey(strgKey))
            {
                values v = c[strgKey];
                if (v != null)
                {
                    if (v.strgValue != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void getValue(string strgKey, out int intValue)
        {
            intValue = 0;

            if (!SettingsSingleton.isExistsIntValue(strgKey))
            {
                //キャッシュになし
                //DBから読み込む
                using (DAOContext con = new DAOContext(AccessConstring.SettingConString))
                {
                    con.OpenConnection();
                    SettingsDAO dao = new SettingsDAO(con);

                    dao.selectSetting(strgKey, out intValue);

                    con.CloseConnection();

                    SettingsSingleton.cache_[strgKey] = new values(intValue, null);
                }
            }
            else
            {
                //キャッシュにあり
                //キャッシュの値を返す
                values v = SettingsSingleton.cache_[strgKey];
                intValue = v.intValue;
            }
        }
        public static void getValue(DAOContext con, string strgKey, out int intValue)
        {
            intValue = 0;

            if (!SettingsSingleton.isExistsIntValue(strgKey))
            {
                //キャッシュになし
                //DBから読み込む
                SettingsDAO dao = new SettingsDAO(con);

                dao.selectSetting(strgKey, out intValue);

                SettingsSingleton.cache_[strgKey] = new values(intValue, null);
            }
            else
            {
                //キャッシュにあり
                //キャッシュの値を返す
                values v = SettingsSingleton.cache_[strgKey];
                intValue = v.intValue;
            }
        }
        public static void getValue(string strgKey, out string strgValue)
        {
            strgValue = "";

            if (!SettingsSingleton.isExistsStringValue(strgKey))
            {
                //キャッシュになし
                //DBから読み込む
                using (DAOContext con = new DAOContext(AccessConstring.SettingConString))
                {
                    con.OpenConnection();
                    SettingsDAO dao = new SettingsDAO(con);

                    dao.selectSetting(strgKey, out strgValue);

                    con.CloseConnection();

                    SettingsSingleton.cache_[strgKey] = new values(Int32.MinValue, strgValue);
                }
            }
            else
            {
                //キャッシュにあり
                //キャッシュの値を返す
                values v = SettingsSingleton.cache_[strgKey];
                strgValue = v.strgValue;
            }
        }
        public static void getValue(DAOContext con,string strgKey, out string strgValue)
        {
            strgValue = "";

            if (!SettingsSingleton.isExistsStringValue(strgKey))
            {
                //キャッシュになし
                //DBから読み込む
                SettingsDAO dao = new SettingsDAO(con);

                dao.selectSetting(strgKey, out strgValue);

                SettingsSingleton.cache_[strgKey] = new values(Int32.MinValue, strgValue);
            }
            else
            {
                //キャッシュにあり
                //キャッシュの値を返す
                values v = SettingsSingleton.cache_[strgKey];
                strgValue = v.strgValue;
            }
        }

        public static bool isEqualsIntValue(values v, int intValue)
        {
            if (v != null)
            {
                if (v.intValue == intValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool isEqualsStringValue(values v, string strgValue)
        {
            if (v != null)
            {
                if (v.strgValue.Equals(strgValue))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static void setValue(string strgKey, int intValue)
        {
            using (DAOContext con = new DAOContext(AccessConstring.SettingConString))
            {
                con.OpenConnection();
                SettingsDAO dao = new SettingsDAO(con);
                dao.mergeSettings(strgKey, intValue);
                con.CloseConnection();
            }
            SettingsSingleton.cache_[strgKey] = new values(intValue, null);
        }
        public static void setValue(string strgKey, string strgValue)
        {
            using (DAOContext con = new DAOContext(AccessConstring.SettingConString))
            {
                con.OpenConnection();
                SettingsDAO dao = new SettingsDAO(con);
                dao.mergeSettings(strgKey, strgValue);
                con.CloseConnection();
            }
            SettingsSingleton.cache_[strgKey] = new values(Int32.MinValue, strgValue);
        }
        public static void setValue(DAOContext con,string strgKey, int intValue)
        {
            SettingsDAO dao = new SettingsDAO(con);
            dao.mergeSettings(strgKey, intValue);
            SettingsSingleton.cache_[strgKey] = new values(intValue, null);
        }
        public static void setValue(DAOContext con,string strgKey, string strgValue)
        {
            SettingsDAO dao = new SettingsDAO(con);
            dao.mergeSettings(strgKey, strgValue);
            SettingsSingleton.cache_[strgKey] = new values(Int32.MinValue, strgValue);
        }
    }
}
