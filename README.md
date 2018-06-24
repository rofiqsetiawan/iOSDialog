# iOSDialog - iOS UIAlertView on Xamarin.Android
With this library you can use iOS `UIAlertView` on Xamarin.Android.
This library is Xamarin.Android (C#) version of [iOSDialog](https://github.com/MagicDog707/iOSDialog) by Acciaro Gennaro Daniele.

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
PM> Install-Package Karamunting.Android.MagicDog707.iOSDialog -Version 1.0.3
```

## Usage
### Single Button
```csharp
// 1 Button
new IOSDialogBuilder(this)
    .SetTitle("I'm Single")
    .SetSubtitle("Seriously")
    .SetPositiveListener(
        positiveLabel: "Ok",
        listener: dlg =>
        {
            Toast.MakeText(this, "I'm single button", ToastLength.Short).Show();
            dlg.Dismiss();
        }
    )
    .Build()
    .Show();
```

### Double Buttons
```csharp
// 2 buttons
new IOSDialogBuilder(this)
    .SetTitle("How's your day?")
    .SetSubtitle("Just asking..")
    .SetPositiveListener(
        "Good",
        dlg =>
        {
            Toast.MakeText(this, "You have good day", ToastLength.Short).Show();
            dlg.Dismiss();
        }
    )
    .SetNegativeListener(
        "Bad",
        dlg =>
        {
            Toast.MakeText(this, "You have bad day :(", ToastLength.Short).Show();
            dlg.Dismiss();
        }
    )
    .Build()
    .Show();
```

---	
	
If you liked this library, feel free to make a donation to Acciaro Gennaro Daniele :D
<a href="http://paypal.me/gdacciaro"><img src="https://www.paypalobjects.com/webstatic/paypalme/images/social/pplogo384.png" width=64></a>
