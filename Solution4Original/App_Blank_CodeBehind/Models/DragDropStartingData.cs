﻿using System.Collections.Generic;

using Windows.ApplicationModel.DataTransfer;

namespace App_Blank_CodeBehind.Models
{
    public class DragDropStartingData
    {
        public DataPackage Data { get; set; }

        public IList<object> Items { get; set; }
    }
}
