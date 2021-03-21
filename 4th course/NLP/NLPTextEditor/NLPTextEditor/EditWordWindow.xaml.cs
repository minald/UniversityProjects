using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace NLPTextEditor
{
    public partial class EditWordWindow : Window
    {
        private readonly DictionaryContext db = new DictionaryContext();
        public Word Word { get; }

        public EditWordWindow(Word word)
        {
            Word = word;
            InitializeComponent();

            WordTextBox.Text = Word.Name;
            CountTextBox.Text = Word.Amount.ToString();
            FilesTextBox.Text = Word.Files;
            TagsTextBox.Text = Word.Tags;
            LemmaTextBox.Text = Word.Canonical;
            CanonicalTagTextBox.Text = Word.CanonicalTag;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var name = WordTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Word shouldn't be empty", "Error");
                return;
            }

            var same = db.Words.FirstOrDefault(x => x.Name == name);
            if (same != null && same.Id != Word.Id)
            {
                MessageBox.Show("This word already exist", "Error");
                return;
            }

            int.TryParse(CountTextBox.Text, out var amount);
            Word.Name = name;
            Word.Amount = amount;
            Word.Files = FilesTextBox.Text;
            Word.Tags = TagsTextBox.Text;
            Word.Canonical = LemmaTextBox.Text;
            Word.CanonicalTag = CanonicalTagTextBox.Text;

            DialogResult = true;
            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
