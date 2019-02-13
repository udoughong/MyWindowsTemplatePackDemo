using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using App_NavigationPane_Prism_MasterDetail.Core.Models;

namespace App_NavigationPane_Prism_MasterDetail.Core.Services
{
    // This interface specifies methods used by some generated pages to show how they can be used.
    // TODO WTS: Delete this file once your app is using real data.
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetSampleModelDataAsync();
    }
}
