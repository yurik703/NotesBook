using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Notes.Views
{
    [Activity(Label = "New Notes")]
    public class NewNoteView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.NewNoteView);
        }
    }
}