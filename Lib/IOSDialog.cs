// Made with love (and coffee and pizza) by Acciaro Gennaro Daniele in Naples, Italy! 
// Ported and modified to Xamarin.Android (C#) by Rofiq Setiawan (rofiqsetiawan@gmail.com)
//
//  __
// // ""--.._
// ||  (_)  _ "-._
// ||    _ (_)    '-.
// ||   (_)   __..-'
// \\__..--"
//
// Created by Gennaro Daniele Acciaro
// http://gdacciaro.com
// acciarogennaro@gmail.com
// on 04/09/17.


using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using Android.Widget;
using R = GDAcciaro.Lib.Resource;

namespace GDAcciaro.Lib
{
    [Android.Runtime.Register("com.gdacciaro.iOSDialog.iOSDialog")]
    public class IOSDialog
    {
        private const string MyTag = nameof(IOSDialog);

        private readonly Dialog _dialog;
        private TextView _dialogButtonOk, _dialogButtonNo;
        private TextView _titleLbl, _subtitleLbl;
        private View _separator;
        private IiOSDialogClickListener _positiveListener;
        private IiOSDialogClickListener _negativeListener;
        private bool _negativeExist;
        private const string LogError = "iOSDialog_ERROR";

        public IOSDialog(Context context, string title, string subtitle, bool bold, Typeface typeFace, bool cancelable)
        {
            _negativeExist = false;
            _dialog = new Dialog(context);
            _dialog.SetContentView(R.Layout.alerts_two_buttons);
            _dialog.Window?.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));

            InitViews();

            _dialog.SetCancelable(cancelable);
            SetTitle(title);
            SetSubtitle(subtitle);
            SetBoldPositiveLabel(bold);
            SetTypefaces(typeFace);

            InitEvents();
        }

        public void SetPositive(string okLabel, Action<IOSDialog> listener)
            => SetPositive(okLabel, new IOSDialogClickListener(dialog => listener?.Invoke(dialog)));

        public void SetPositive(string okLabel, IiOSDialogClickListener listener)
        {
            _positiveListener = listener;
            Dismiss();
            SetPositiveLabel(okLabel);
        }

        public void SetNegative(string koLabel, Action<IOSDialog> listener)
            => SetNegative(koLabel, new IOSDialogClickListener(dialog => listener?.Invoke(dialog)));

        public void SetNegative(string koLabel, IiOSDialogClickListener listener)
        {
            if (listener != null)
            {
                _negativeListener = listener;
                Dismiss();
                _negativeExist = true;
                SetNegativeLabel(koLabel);
            }
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

        public void Dismiss() => _dialog.Dismiss();

        public void SetTitle(string title)
        {
            _titleLbl.Text = title;
        }

        public void SetSubtitle(string subtitle)
        {
            _subtitleLbl.Text = subtitle;
        }

        private void SetPositiveLabel(string positive)
        {
            _dialogButtonOk.Text = positive;
        }

        private void SetNegativeLabel(string negative)
        {
            _dialogButtonNo.Text = negative;
        }

        private void SetBoldPositiveLabel(bool bold)
            => _dialogButtonOk.SetTypeface(null, bold ? TypefaceStyle.Bold : TypefaceStyle.Normal);

        private void SetTypefaces(Typeface appleFont)
        {
            if (appleFont != null)
            {
                _titleLbl.Typeface = appleFont;
                _subtitleLbl.Typeface = appleFont;
                _dialogButtonOk.Typeface = appleFont;
                _dialogButtonNo.Typeface = appleFont;
            }
        }

        private void InitViews()
        {
            _titleLbl = _dialog.FindViewById<TextView>(R.Id.title);
            _subtitleLbl = _dialog.FindViewById<TextView>(R.Id.subtitle);
            _dialogButtonOk = _dialog.FindViewById<TextView>(R.Id.dialogButtonOK);
            _dialogButtonNo = _dialog.FindViewById<TextView>(R.Id.dialogButtonNO);
            _separator = _dialog.FindViewById<View>(R.Id.separator);
        }

        private void InitEvents()
        {
            _dialogButtonOk.SetOnClickListener(new MyViewOnClickListener(v => _positiveListener?.OnClick(this)));
            _dialogButtonNo.SetOnClickListener(new MyViewOnClickListener(v => _negativeListener?.OnClick(this)));
        }
    }
}