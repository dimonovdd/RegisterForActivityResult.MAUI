using Android.Content;
using Android.Views;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;

namespace AndroidApp1;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {

        var launcher = RegisterForActivityResult(new ActivityResultContracts.PickContact(), new GetIntResultCallback());
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource

        var button = new AppCompatButton(this)
        {
            Text = "Get result"
        };
        button.Click += (sender, ev) =>
        {
            launcher.Launch(null);
        };

        SetContentView(button, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent));

    }
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