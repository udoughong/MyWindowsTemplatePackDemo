﻿using Windows.UI.Input.Inking;

namespace App_Blank_Prism.EventHandlers.Ink
{
    public class RemoveEventArgs
    {
        public InkStroke RemovedStroke { get; set; }

        public RemoveEventArgs(InkStroke removedStroke)
        {
            RemovedStroke = removedStroke;
        }
    }
}
