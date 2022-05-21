using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab6v_p.Views
{
    public partial class FirstView : UserControl
    {
        public FirstView()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}