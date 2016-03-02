using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Notes.Views
{
    [Activity(Label = "Edit Notes")]
    public class EditNoteView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.EditNoteView);
        }
    }
}