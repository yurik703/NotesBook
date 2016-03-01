using AutoMapper;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Notes.Core.Interfaces;
using Notes.Core.Models;
using Notes.Core.Storages;
using Notes.Core.ViewModels;
using Notes.Database;
using Notes.Database.Schema;

namespace Notes.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<ILocalStorage>(new LocalStorage());

            new DataRepository().CreateDatabaseIfNotExist();

            RegisterAppStart<MainViewModel>();
            
            Mapper.Initialize(x => x.CreateMap<NoteModel, LocalNote>().ReverseMap());
        }
    }
}
