using Windows.UI.Notifications;

namespace App_HorizontalNavigationPane_Prism.Services
{
    internal interface IToastNotificationsService
    {
        void ShowToastNotification(ToastNotification toastNotification);

        void ShowToastNotificationSample();
    }
}
