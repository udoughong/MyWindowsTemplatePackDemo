using System;

namespace App_Blank_CodeBehind.EventHandlers
{
    public class CameraControlEventArgs : EventArgs
    {
        public string Photo { get; set; }

        public CameraControlEventArgs(string photo)
        {
            Photo = photo;
        }
    }
}
