using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace Notes.Views
{
    [Activity(Label = "Note")]
    public class NoteView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NoteView);
        }
    }
}