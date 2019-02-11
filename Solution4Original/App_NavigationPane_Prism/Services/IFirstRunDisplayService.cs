using System.Threading.Tasks;

namespace App_NavigationPane_Prism.Services
{
    public interface IFirstRunDisplayService
    {
        Task ShowIfAppropriateAsync();
    }
}
