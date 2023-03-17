using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;

namespace MauiApp1;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode
        | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    static ActivityResultLauncher _launcher;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        _launcher = RegisterForActivityResult(new ActivityResultContracts.PickContact(), new GetIntResultCallback());
        base.OnCreate(savedInstanceState);
    }

    public static void Launch() => _launcher.Launch(null);
}

public class GetIntResultCallback : Java.Lang.Object, IActivityResultCallback
{
    public GetIntResultCallback()
    {
        
    }
    
    public void OnActivityResult(Java.Lang.Object? result)
    {
        System.Diagnostics.Debug.WriteLine($"Contact Result: {result ?? "null"}");
    }
}