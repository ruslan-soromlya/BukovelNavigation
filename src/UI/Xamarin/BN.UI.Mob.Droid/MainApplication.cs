using System;

using Android.App;
using Android.Runtime;
using BN.UI.Mob.Core;
using MvvmCross.Platforms.Android.Views;

namespace BN.UI.Mob.Droid
{
#if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif
    public class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}