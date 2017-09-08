// Made with love (and coffee and pizza) by Acciaro Gennaro Daniele in Naples, Italy! 
// Ported and modified to Xamarin.Android by Rofiq Setiawan (rofiqsetiawan@gmail.com)
//
//  __
// // ""--.._
// ||  (_)  _ "-._
// ||    _ (_)    '-.
// ||   (_)   __..-'
// \\__..--"
//
//
//


using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using Android.Widget;
using R = GDAcciaro.Lib.Resource;

/**
 * Created by Gennaro Daniele Acciaro
 * http://gdacciaro.com
 * acciarogennaro@gmail.com
 * on 04/09/17.
 */
namespace GDAcciaro.Lib
{
	[Android.Runtime.Register("com.gdacciaro.iOSDialog.iOSDialog")]
    public class iOSDialog
    {
		private readonly Dialog _dialog;
		private TextView _dialogButtonOk, _dialogButtonNo;
		private TextView _titleLbl, _subtitleLbl;
		private View _separator;
		private bool _negativeExist;

		public iOSDialog(Context context)
		{
			_dialog = new Dialog(context);
			_dialog.SetContentView(R.Layout.alerts_two_buttons);
		    _dialog.Window?.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));

		    InitViews();
		}


		public void SetPositiveListener(View.IOnClickListener okListener)
		{
			_dialogButtonOk.SetOnClickListener(okListener);
		}

		public void SetNegativeListener(View.IOnClickListener okListener)
		{
			if (!_negativeExist)
			{
				Log.Error(nameof(iOSDialog), $"Negative button isn't visible, set it with {nameof(SetNegativeLabel)}()");
			}
			_dialogButtonNo.SetOnClickListener(okListener);
		}

		public void Show()
		{
			if (!_negativeExist)
			{
				_dialogButtonNo.Visibility = ViewStates.Gone;
				_separator.Visibility = ViewStates.Gone;
			}
			_dialog.Show();
		}

		public void Dismiss()
		{
			_dialog.Dismiss();
		}

		public void SetTitle(string title)
		{
			_titleLbl.Text = title;
		}

        public void SetSubtitle(string subtitle)
		{
			_subtitleLbl.Text = subtitle;
		}

		public void SetPositiveLabel(string positive)
		{
			_dialogButtonOk.Text = positive;
		}
		public void SetNegativeLabel(string negative)
		{
			_negativeExist = true;
			_dialogButtonNo.Text = negative;
		}
		public void SetBoldPositiveLabel(bool bold)
		{
		    _dialogButtonOk.SetTypeface(null, bold ? TypefaceStyle.Bold : TypefaceStyle.Normal);
		}

		public void SetTipefaces(Typeface appleFont)
		{
			_titleLbl.Typeface = appleFont;
			_subtitleLbl.Typeface = appleFont;
			_dialogButtonOk.Typeface = appleFont;
			_dialogButtonNo.Typeface = appleFont;
		}


		private void InitViews()
		{
			_titleLbl = _dialog.FindViewById<TextView>(R.Id.title);
			_subtitleLbl = _dialog.FindViewById<TextView>(R.Id.subtitle);
			_dialogButtonOk = _dialog.FindViewById<TextView>(R.Id.dialogButtonOK);
			_dialogButtonNo = _dialog.FindViewById<TextView>(R.Id.dialogButtonNO);
			_separator = _dialog.FindViewById<View>(R.Id.separator);
		}

        public class DialogClickListener : Java.Lang.Object, View.IOnClickListener
        {
            private readonly Action<View> _action;

            public DialogClickListener(Action<View> action)
            {
                _action = action;
            }

            public void OnClick(View v)
            {
                _action(v);
            }
        }
    }
}
