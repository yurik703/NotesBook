using System.Threading.Tasks;
using Android.App;
using Notes.Core.Interfaces;

namespace Notes.Services
{
    public class AlertService : IAlertsService
    {
        public Task<bool> ShowAlert(string title, string message)
        {
            var tcs = new TaskCompletionSource<bool>();

            AlertDialog.Builder alert = new AlertDialog.Builder(Application.Context);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetPositiveButton("OK", (sender, args) =>
            {
                tcs.SetResult(true);
            });

            Application.SynchronizationContext.Post(_ =>
            {
                alert.Show();
            }, null);

            return tcs.Task;
        }
    }
}