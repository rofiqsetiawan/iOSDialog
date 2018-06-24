// Created by Gennaro Daniele Acciaro
// http://gdacciaro.com
// acciarogennaro@gmail.com
// on 18/02/18.
// Ported by Rofiq Setiawan (rofiqsetiawan@gmail.com)

using System;
using Android.Content;
using Android.Graphics;

namespace GDAcciaro.Lib
{
    public class IOSDialogBuilder
    {
        private Typeface _tf;
        private bool _bold, _cancelable;
        private string _title, _subtitle, _positiveLabel, _negativeLabel;
        private readonly Context _context;
        private IiOSDialogClickListener _positiveListener;
        private IiOSDialogClickListener _negativeListener;

        public IOSDialogBuilder(Context context)
        {
            _context = context;
        }

        public IOSDialogBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public IOSDialogBuilder SetSubtitle(string subtitle)
        {
            _subtitle = subtitle;
            return this;
        }

        public IOSDialogBuilder SetBoldPositiveLabel(bool bold)
        {
            _bold = bold;
            return this;
        }

        public IOSDialogBuilder SetFont(Typeface font)
        {
            _tf = font;
            return this;
        }

        public IOSDialogBuilder SetCancelable(bool cancelable)
        {
            _cancelable = cancelable;
            return this;
        }

        public IOSDialogBuilder SetNegativeListener(string negativeLabel, Action<IOSDialog> listener)
            => SetNegativeListener(negativeLabel, new IOSDialogClickListener(dialog => listener?.Invoke(dialog)));

        public IOSDialogBuilder SetNegativeListener(string negativeLabel, IiOSDialogClickListener listener)
        {
            _negativeListener = listener;
            _negativeLabel = negativeLabel;
            return this;
        }

        public IOSDialogBuilder SetPositiveListener(string positiveLabel, Action<IOSDialog> listener)
            => SetPositiveListener(positiveLabel, new IOSDialogClickListener(dialog => listener?.Invoke(dialog)));

        public IOSDialogBuilder SetPositiveListener(string positiveLabel, IiOSDialogClickListener listener)
        {
            _positiveListener = listener;
            _positiveLabel = positiveLabel;
            return this;
        }

        public IOSDialog Build()
        {
            var dialog = new IOSDialog(_context, _title, _subtitle, _bold, _tf, _cancelable);
            dialog.SetNegative(_negativeLabel, _negativeListener);
            dialog.SetPositive(_positiveLabel, _positiveListener);
            return dialog;
        }
    }
}