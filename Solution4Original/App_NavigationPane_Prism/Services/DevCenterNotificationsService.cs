using System;
using System.Threading.Tasks;

using Microsoft.Services.Store.Engagement;

namespace App_NavigationPane_Prism.Services
{
    internal class DevCenterNotificationsService : IDevCenterNotificationsService
    {
        public async Task InitializeAsync()
        {
            try
            {
                var engagementManager = StoreServicesEngagementManager.GetDefault();
                await engagementManager.RegisterNotificationChannelAsync();
            }
            catch (Exception)
            {
                // TODO WTS: Channel registration call can fail, please handle exceptions as appropriate to your scenario.
            }
        }
    }
}
