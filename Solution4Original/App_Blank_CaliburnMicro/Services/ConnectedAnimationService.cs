﻿using System;

using Microsoft.Toolkit.Uwp.UI.Animations;

using Windows.UI.Xaml.Controls;

namespace App_Blank_CaliburnMicro.Services
{
    public class ConnectedAnimationService : IConnectedAnimationService
    {
        private Frame _frame;

        public ConnectedAnimationService(Frame frame)
        {
            _frame = frame;
        }

        public void SetListDataItemForNextConnectedAnnimation(object item)
        {
            _frame.SetListDataItemForNextConnectedAnnimation(item);
        }
    }
}
