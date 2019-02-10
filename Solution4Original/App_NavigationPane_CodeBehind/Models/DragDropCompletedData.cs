﻿using System.Collections.Generic;

using Windows.ApplicationModel.DataTransfer;

namespace App_NavigationPane_CodeBehind.Models
{
    public class DragDropCompletedData
    {
        public DataPackageOperation DropResult { get; set; }

        public IReadOnlyList<object> Items { get; set; }
    }
}
