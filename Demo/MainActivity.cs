// Made with love (and coffee and pizza) by Acciaro Gennaro Daniele in Naples, Italy! 
// Ported to Xamarin.Android by Rofiq Setiawan (rofiqsetiawan@gmail.com)

using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using GDAcciaro.Lib;
using R = IOSDialogDemo.Resource;

namespace IOSDialogDemo
{
    [Activity(Label = "iOSDialog Demo", MainLauncher = true, Icon = "@mipmap/ic_launcher",
        RoundIcon = "@mipmap/ic_launcher", Theme = "@style/AppTheme")]
    public sealed class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(R.Layout.activity_main);

            // Single button
            FindViewById<Button>(R.Id.btn_single_btn).Click += (sender, e) =>
            {
                new IOSDialogBuilder(this)
                    .SetTitle("I'm Single")
                    .SetSubtitle("Seriously")
                    .SetPositiveListener(
                        positiveLabel: "Ok",
                        listener: dlg =>
                        {
                            ToastMe("I'm single button");
                            dlg.Dismiss();
                        }
                    )
                    .Build()
                    .Show();
            };


            // Double button
            FindViewById<Button>(R.Id.btn_double_btn).Click += (sender, e) =>
            {
                new IOSDialogBuilder(this)
                    .SetTitle("How's your day?")
                    .SetSubtitle("Just asking..")
                    .SetPositiveListener(
                        "Good",
                        dlg =>
                        {
                            ToastMe("You have good day");
                            dlg.Dismiss();
                        }
                    )
                    .SetNegativeListener(
                        "Bad",
                        dlg =>
                        {
                            ToastMe("You have bad day :(");
                            dlg.Dismiss();
                        }
                    )
                    .Build()
                    .Show();
            };
        }

        private void ToastMe(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;

            Toast.MakeText(this, msg, ToastLength.Short).Show();
        }
    }
}