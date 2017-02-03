using System;
using System.Globalization;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Helpers
{
    public static class TileHelper
    {
        public static void ShowTileNotification(string message)
        {
            var nowTimeString = DateTime.Now.ToString(CultureInfo.CurrentCulture);

            var xml = $@"
                <tile version='3'>
                    <visual branding='nameAndLogo'>

                        <binding template='TileMedium'>
                            <text hint-wrap='true'>{message}</text>
                            <text hint-wrap='true' hint-style='captionSubtle'>{nowTimeString}</text>
                        </binding>

                        <binding template='TileWide'>
                            <text hint-wrap='true'>{message}</text>
                            <text hint-wrap='true' hint-style='captionSubtle'>{nowTimeString}</text>
                        </binding>

                        <binding template='TileLarge'>
                            <text hint-wrap='true'>{message}</text>
                            <text hint-wrap='true' hint-style='captionSubtle'>{nowTimeString}</text>
                        </binding>

                </visual>
            </tile>";

            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var notification = new TileNotification(doc);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }
    }
}
