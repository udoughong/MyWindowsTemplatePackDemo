using System.Collections.Generic;

using Windows.UI.Input.Inking;

namespace App_NavigationPane_Prism.EventHandlers.Ink
{
    public class CopyPasteStrokesEventArgs
    {
        public IEnumerable<InkStroke> Strokes { get; set; }

        public CopyPasteStrokesEventArgs(IEnumerable<InkStroke> strokes)
        {
            Strokes = strokes;
        }
    }
}
