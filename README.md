# iOSDialog - iOS UIAlertView on Xamarin.Android
This library is Xamarin.Android (C#) version of [iOSDialog](https://github.com/MagicDog707/iOSDialog) by Acciaro Gennaro Daniele.
With this library you can use iOS UIAlertView on Xamarin.Android.
Ported and modified by me.

<br>
<table>
<tr>
<td><img src="http://i.imgur.com/E2BYMfG.jpg" width=250><br>Two Buttons</td>
<td><img src="http://i.imgur.com/L2QNRS4.jpg" width=250><br>One Button</td>
</tr>
</table>
<br>

To install the library just execute this command on Package Manager Console:

```
PM> Install-Package Karamunting.Android.MagicDog707.iOSDialog -Version 1.0.2
```

## Usage

```csharp
// Single Button
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

// Double button
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
```
	
	
If you liked this library, feel free to make a donation to Acciaro Gennaro Daniele :D
<a href="http://paypal.me/gdacciaro"><img src="https://www.paypalobjects.com/webstatic/paypalme/images/social/pplogo384.png" width=64></a>



