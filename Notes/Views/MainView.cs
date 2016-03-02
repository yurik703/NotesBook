using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
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
            var lv = FindViewById<ListView>(Resource.Id.notes_listview);
            RegisterForContextMenu(lv);
            var searchView = FindViewById<SearchView>(Resource.Id.searchView);
            searchView.SetIconifiedByDefault(false);
            searchView.Focusable = false;
            searchView.QueryTextChange += SearchViewOnQueryTextChange;
            searchView.QueryTextSubmit += SearchViewOnQueryTextSubmit;
        }

        private void SearchViewOnQueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            ((MainViewModel)ViewModel).FilterByTitleCommand.Execute(e.Query);
        }

        private void SearchViewOnQueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            ((MainViewModel)ViewModel).FilterByTitleCommand.Execute(e.NewText);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBarMenu, menu);
            return true;
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            base.OnCreateContextMenu(menu, v, menuInfo);
            if (v.Id == Resource.Id.notes_listview)
            {
                MenuInflater.Inflate(Resource.Menu.Menu_notes_list, menu);
            }
        }

        public override bool OnContextItemSelected(IMenuItem item)
        {
            var info = (AdapterView.AdapterContextMenuInfo)item.MenuInfo;
            switch (item.ItemId)
            {
                case Resource.Id.edit:
                    ((MainViewModel)ViewModel).EditNoteCommand.Execute(info.Position);
                    return true;
                case Resource.Id.delete:
                    ((MainViewModel)ViewModel).RemoveNoteCommand.Execute(info.Position);
                    return true;
                default:
                    return base.OnContextItemSelected(item);
            }
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
