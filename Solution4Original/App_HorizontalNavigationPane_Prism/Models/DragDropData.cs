using Windows.ApplicationModel.DataTransfer;

namespace App_HorizontalNavigationPane_Prism.Models
{
    public class DragDropData
    {
        public DataPackageOperation AcceptedOperation { get; set; }

        public DataPackageView DataView { get; set; }
    }
}
