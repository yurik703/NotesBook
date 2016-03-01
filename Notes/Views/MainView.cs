using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;
using Notes.Core.ViewModels;

namespace Notes.Views
{
    [Activity(Label = "Notes")]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarMenu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.addNoteMenuItem:
                    ((MainViewModel)ViewModel).NewNoteCommand.Execute(null);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}
