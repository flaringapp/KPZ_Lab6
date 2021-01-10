using System.Windows;
using System.Windows.Controls;

namespace Lab6.Views.Common
{
    public partial class InputView : UserControl
    {

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "InputTitle",
            typeof(string),
            typeof(InputView),
            new PropertyMetadata(default(string))
        );

        public InputView()
        {
            InitializeComponent();
        }

        [Localizability(LocalizationCategory.Text)]
        public string InputTitle
        {
            get => (string)GetValue(TitleProperty);
            set 
            {
                SetValue(TitleProperty, value);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            OnTitleChanged();
        }

        private void OnTitleChanged()
        {
            var titleView = FindName("title") as TextBlock;
            titleView.Text = InputTitle;
        }
    }
}
