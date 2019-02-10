using System;

using App_Blank_CaliburnMicro.Helpers;

using Caliburn.Micro;

namespace App_Blank_CaliburnMicro.ViewModels
{
    public class TabbedViewModel : Conductor<Screen>.Collection.OneActive
    {
        public TabbedViewModel()
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            // WTS Add view models to the Items collection to display them in the Tabs
            Items.Add(new ExampleTabViewModel { DisplayName = "TabbedExampleTabPage1_DisplayName".GetLocalized() });
            Items.Add(new ExampleTabViewModel { DisplayName = "TabbedExampleTabPage2_DisplayName".GetLocalized() });
        }
    }
}
