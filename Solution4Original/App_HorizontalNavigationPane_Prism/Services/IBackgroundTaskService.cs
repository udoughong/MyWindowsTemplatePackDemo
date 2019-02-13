using System.Threading.Tasks;

using Windows.ApplicationModel.Background;

namespace App_HorizontalNavigationPane_Prism.Services
{
    internal interface IBackgroundTaskService
    {
        Task RegisterBackgroundTasksAsync();

        void Start(IBackgroundTaskInstance taskInstance);
    }
}
