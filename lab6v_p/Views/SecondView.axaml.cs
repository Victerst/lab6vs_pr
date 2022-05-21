using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab6v_p.Views
{
    public partial class SecondView : UserControl
    {
        public SecondView()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}