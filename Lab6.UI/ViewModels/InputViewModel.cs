using Lab6.Base;

namespace Lab6.ViewModels
{
    class InputViewModel: BaseViewModel
    {
        public InputViewModel(string initialInput = "")
        {
            _input = initialInput;
        }

        private string _input = "";
        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                OnPropertyChanged("Input");
            }
        }
    }
}
