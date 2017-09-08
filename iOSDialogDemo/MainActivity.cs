// Made with love (and coffee and pizza) by Acciaro Gennaro Daniele in Naples, Italy! 
// Ported to Xamarin.Android by Rofiq Setiawan (rofiqsetiawan@gmail.com)

using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using GDAcciaro.Lib;
using R = iOSDialogDemo.Resource;

namespace iOSDialogDemo
{
	[Activity(Label = "iOSDialog Demo", MainLauncher = true, Icon = "@mipmap/ic_launcher", RoundIcon = "@mipmap/ic_launcher", Theme = "@style/AppTheme")]
	public class MainActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(R.Layout.activity_main);

			// Single button
			FindViewById<Button>(R.Id.btn_single_btn).Click += (sender, e) =>
			{
				var singleBtnDialog = new iOSDialog(this);
				singleBtnDialog.SetTitle("I'm Single");
				singleBtnDialog.SetSubtitle("Seriously");
				singleBtnDialog.SetPositiveLabel("Ok");
				singleBtnDialog.SetBoldPositiveLabel(true);
				singleBtnDialog.SetPositiveListener(new iOSDialog.DialogClickListener(
					v =>
					{
						Toast.MakeText(this, "Forever alone :(", ToastLength.Short).Show();
						singleBtnDialog.Dismiss();
					}
				));
				singleBtnDialog.Show();
			};


			// Double button
			FindViewById<Button>(R.Id.btn_double_btn).Click += (sender, e) =>
			{
				var doubleBtnDialog = new iOSDialog(this);
				doubleBtnDialog.SetTitle("How's your day?");
				doubleBtnDialog.SetSubtitle("Just asking..");
				doubleBtnDialog.SetNegativeLabel("Bad");
				doubleBtnDialog.SetPositiveLabel("Good");
				doubleBtnDialog.SetBoldPositiveLabel(true);

				doubleBtnDialog.SetPositiveListener(new iOSDialog.DialogClickListener(
					v =>
					{
						Toast.MakeText(this, "You have good day", ToastLength.Short).Show();
						doubleBtnDialog.Dismiss();
					}
				));
				doubleBtnDialog.SetNegativeListener(new iOSDialog.DialogClickListener(
					v =>
					{
						Toast.MakeText(this, "You have bad day :(", ToastLength.Short).Show();
						doubleBtnDialog.Dismiss();
					}
				));

				doubleBtnDialog.Show();
			};


		}
	}
}

