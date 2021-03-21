using System.Windows;

namespace NLPTextEditor
{
    public partial class MergeWordWindow : Window
    {
        public MergeWordWindow() => InitializeComponent();

        private void OK_Click(object sender, RoutedEventArgs e) => DialogResult = true;
    }
}
