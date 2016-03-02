using System.Threading.Tasks;
using Android.App;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Exceptions;
using Notes.Core.Interfaces;

namespace Notes.Services
{
    public class AlertService : IAlertsService
    {
        public Task<bool> ShowAlert(string title, string message)
        {
            var tcs = new TaskCompletionSource<bool>();

            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;
            if (act == null)
            {
                // this can happen during transitions
                // - you need to be sure that this won't happen for your code
                throw new MvxException("Cannot get current top activity");
            }

            AlertDialog.Builder alert = new AlertDialog.Builder(act);
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

        public Task<bool> ShowAlert(string title, string message, string positive, string negative)
        {
            var tcs = new TaskCompletionSource<bool>();

            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;
            if (act == null)
            {
                // this can happen during transitions
                // - you need to be sure that this won't happen for your code
                throw new MvxException("Cannot get current top activity");
            }

            AlertDialog.Builder alert = new AlertDialog.Builder(act);
            alert.SetTitle(title);
            alert.SetMessage(message);
            alert.SetPositiveButton(positive, (sender, args) =>
            {
                tcs.SetResult(true);
            });

            alert.SetNegativeButton(negative, (sender, args) =>
            {
                tcs.SetResult(false);
            });

            Application.SynchronizationContext.Post(_ =>
            {
                alert.Show();
            }, null);

            return tcs.Task;
        }
    }
}