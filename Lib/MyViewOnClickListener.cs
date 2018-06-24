// Created by Rofiq Setiawan (rofiqsetiawan@gmail.com)

using System;
using Android.Views;

namespace GDAcciaro.Lib
{
    internal sealed class MyViewOnClickListener : Java.Lang.Object, View.IOnClickListener
    {
        private readonly Action<View> _onClickAction;

        public MyViewOnClickListener(Action<View> onClickAction)
        {
            _onClickAction = onClickAction;
        }

        public void OnClick(View v) => _onClickAction?.Invoke(v);
    }
}