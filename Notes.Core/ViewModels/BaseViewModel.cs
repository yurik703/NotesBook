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
        protected readonly IAlertsService AlertsService = Mvx.Resolve<IAlertsService>();
        protected readonly ILocalStorage LocalStorage = Mvx.Resolve<ILocalStorage>();
        protected readonly IMvxMessenger Messenger = Mvx.Resolve<IMvxMessenger>();
    }
}
