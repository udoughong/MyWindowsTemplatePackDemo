using System.Threading.Tasks;

namespace App_HorizontalNavigationPane_Prism.Services
{
    public interface IFirstRunDisplayService
    {
        Task ShowIfAppropriateAsync();
    }
}
