using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SDxDeveloper.Services
{
    public class SettingManager
    {
        private const string FILEPATH = "usersettings.xml";

        public string? GetSetting(string settingName)
        {
            var settings = new XmlDocument();
            settings.Load(FILEPATH);

            if (settings.DocumentElement != null)
            {
                foreach (XmlNode node in settings.DocumentElement)
                {
                    if (node.Name == settingName)
                    {
                        return node.InnerText;
                    }
                }
            }

            return null;
        }

        public void SetSetting(string settingName, string value)
        {
            var settings = new XmlDocument();
            settings.Load(FILEPATH);
            // set..


            var s = GetSetting("DefaultFileExplorePath");
            var s1 = GetSetting("SomeSetting");


            // s была равна значению настройки DefaultFileExplorePath
            // s1 была равна значению настпойки SomeSetting


            var settings = new XmlDocument();
            settings.Load(FILEPATH);

            if (settings.DocumentElement != null)
            {
                foreach (XmlNode node in settings.DocumentElement)
                {
                    if (node.Name == "DefaultFileExplorePath")
                    {
                        s = node.InnerText;
                    }
                }
            }

            settings.Load(FILEPATH);

            if (settings.DocumentElement != null)
            {
                foreach (XmlNode node in settings.DocumentElement)
                {
                    if (node.Name == "SomeSetting")
                    {
                        s1 = node.InnerText;
                    }
                }
            }
        }
    }
}
