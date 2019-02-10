using Windows.ApplicationModel.DataTransfer;

namespace App_HorizontalNavigationPane_MvvmLight.Models
{
    public class DragDropData
    {
        public DataPackageOperation AcceptedOperation { get; set; }

        public DataPackageView DataView { get; set; }
    }
}
