﻿using Windows.ApplicationModel.DataTransfer;

namespace App_Blank_CaliburnMicro.Models
{
    public class DragDropData
    {
        public DataPackageOperation AcceptedOperation { get; set; }

        public DataPackageView DataView { get; set; }
    }
}
