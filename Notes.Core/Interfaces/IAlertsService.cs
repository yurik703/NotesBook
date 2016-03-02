using System.Threading.Tasks;

namespace Notes.Core.Interfaces
{
    public interface IAlertsService
    {
        Task<bool> ShowAlert(string title, string message);

        Task<bool> ShowAlert(string title, string message, string positive, string negative);
    }
}
