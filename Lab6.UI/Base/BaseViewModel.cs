using System.ComponentModel;
using System.Windows;

namespace Lab6.Base
{
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private SimpleCommand _onClosing;
        public SimpleCommand OnClosing
        {
            get => _onClosing ?? (_onClosing = new SimpleCommand(o => Release()));
        }

        protected virtual void Release() { }

        protected void CloseWindow(object window) {
            ((Window)window).Close();
        }
    }
}
