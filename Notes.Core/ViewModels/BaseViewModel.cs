using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;
using Notes.Core.Interfaces;
using PropertyChanged;

namespace Notes.Core.ViewModels
{
    [ImplementPropertyChanged]
    public class BaseViewModel : MvxViewModel
    {
        private CancellationTokenSource ts = new CancellationTokenSource();

        protected readonly IAlertsService AlertsService = Mvx.Resolve<IAlertsService>();
        protected readonly ILocalStorage LocalStorage = Mvx.Resolve<ILocalStorage>();
        protected readonly IMvxMessenger Messenger = Mvx.Resolve<IMvxMessenger>();

        /// <summary>
        /// Executes action that can be interrupted by same action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        protected async Task ExecuteDefferedAction(Action action)
        {
            if (ts != null)
                ts.Cancel();
            ts = new CancellationTokenSource();
            var ct = ts.Token;
            await Task.Factory.StartNew(async () =>
            {
                await Task.Delay(250, ct);
                if (!ct.IsCancellationRequested)
                    action();
            }, ct);
        }
    }
}
