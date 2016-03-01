using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using Notes.Core;
using Notes.Core.Interfaces;
using Notes.Database.Interfaces;

namespace Notes
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.RegisterSingleton<ISQLite>(new Services.SQLite());
            Mvx.RegisterSingleton<IAlertsService>(new Services.AlertService());
            base.InitializeFirstChance();
        }
    }
}
