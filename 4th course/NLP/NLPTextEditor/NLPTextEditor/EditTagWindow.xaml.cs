using System.Windows;

namespace NLPTextEditor
{
    public partial class EditTagWindow : Window
    {
        public Tag CurrentTag { get; set; }

        public EditTagWindow(Tag tag)
        {
            CurrentTag = tag;
            InitializeComponent();

            NameTextBox.Text = CurrentTag.Name;
            DescriptionTextBox.Text = CurrentTag.Description;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentTag.Name = NameTextBox.Text;
            CurrentTag.Description = DescriptionTextBox.Text;
            DialogResult = true;
            Close();
        }
    }
}
