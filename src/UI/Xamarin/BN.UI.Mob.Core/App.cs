using MvvmCross.IoC;
using MvvmCross.ViewModels;
using BN.UI.Mob.Core.ViewModels.Main;

namespace BN.UI.Mob.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
