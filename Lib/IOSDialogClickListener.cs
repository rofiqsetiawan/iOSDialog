// Created by Rofiq Setiawan (rofiqsetiawan@gmail.com)

using System;

namespace GDAcciaro.Lib
{
    public sealed class IOSDialogClickListener : IiOSDialogClickListener
    {
        private readonly Action<IOSDialog> _onClickCallback;
        
        public IOSDialogClickListener(Action<IOSDialog> onClickCallback)
        {
            _onClickCallback = onClickCallback;
        }
        
        public void OnClick(IOSDialog dialog) => _onClickCallback?.Invoke(dialog);
    }
}