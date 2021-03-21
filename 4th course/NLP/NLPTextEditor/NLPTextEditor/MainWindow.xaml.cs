using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NLPTextEditor
{
    public partial class MainWindow : Window
    {
        public DictionaryContext db = new DictionaryContext();
        public ObservableCollection<Word> WordDictionary { get; set; } = new ObservableCollection<Word>();
        public static List<Tag> Tags { get; set; } = new List<Tag>();
        public bool OrderAsc { get; set; } = true;

        private List<TagPair> TagPairs { get; set; } = new List<TagPair>();

        public MainWindow()
        {
            InitializeComponent();
            WordDictionary = new ObservableCollection<Word>(db.Words);
            Tags = db.Tags.ToList();
            DataContext = this;
        }

        #region Events

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string text = File.ReadAllText(filePath);
                if (NLPEngine.TextIsTagged(text))
                {
                    db.AddText(new Text(filePath));
                    int counter = 0;
                    var matches = Regex.Matches(text, @"(?<word>[a-zA-Z][a-zA-Z-—']*)_(?<tag>[a-zA-Z?$]*)").Cast<Match>().ToArray();
                    var fileName = Path.GetFileName(filePath);
                    string previousTag = "NN";
                    foreach (var match in matches)
                    {
                        string word = match.Groups["word"].Value;
                        string tag = match.Groups["tag"].Value;
                        var currentWord = WordDictionary.FirstOrDefault(x => x.Name == word);
                        if (currentWord == null)
                        {
                            WordDictionary.Add(new Word(word, 1, tag + "_1", fileName));
                        }
                        else
                        {
                            currentWord.IncrementAmountAndAddNewTagAndFile(tag, fileName);
                        }

                        Tags.First(x => x.Name == previousTag).AddNewTag(tag);
                        var pair = TagPairs.FirstOrDefault(x => x.FirstTag == previousTag && x.SecondTag == tag);
                        if (pair == null)
                        {
                            pair = new TagPair
                            {
                                FirstTag = previousTag,
                                SecondTag = tag,
                                Amount = 0
                            };

                            TagPairs.Add(pair);
                        }

                        pair.Amount++;
                        previousTag = tag;
                        counter++;
                        if (counter % 100 == 0)
                        {
                            var progress = counter * 100.0 / matches.Length;
                            ProgressBar.Dispatcher.Invoke(() => ProgressBar.Value = progress, DispatcherPriority.Background);
                        }
                    }
                    ProgressBar.Dispatcher.Invoke(() => ProgressBar.Value = 0.0, DispatcherPriority.Background);
                    Task.Factory.StartNew(() => SaveWordDictionary());
                    StatusLine.Text = $"{openFileDialog.FileName} has been parsed.";
                }
                else
                {
                    MessageBox.Show("Please select new tagged text \nor tag current text using \"Tag text\" window.",
                        "This text is not tagged", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void ClearDatabase_Click(object sender, RoutedEventArgs e)
        {
            WordDictionary.Clear();
            db.TruncateWords();
            db.TruncateTexts();
            db.ClearTagsStatistics();
            StatusLine.Text = "Table has been cleared.";
        }

        private void TagsInfo_Click(object sender, RoutedEventArgs e) => new TagsInfoWindow().Show();

        private void MergeWord_Click(object sender, RoutedEventArgs e)
        {
            var modalWindow = new MergeWordWindow();
            if (modalWindow.ShowDialog() == true)
            {
                var newName = modalWindow.NewWordTextBox.Text;
                var oldName = modalWindow.OldWordTextBox.Text;
                if (!string.IsNullOrWhiteSpace(oldName) && !string.IsNullOrWhiteSpace(newName))
                {
                    db.Texts.ToList().ForEach(x => ReplaceWord(x.Path, oldName, newName));
                    var oldWordDbo = db.Words.First(x => x.Name == oldName);
                    var newWordDbo = db.Words.FirstOrDefault(x => x.Name == newName);
                    if (newWordDbo == null)
                    {
                        oldWordDbo.Name = newName;
                        WordDictionary.First(x => x.Id == oldWordDbo.Id).Name = newName;
                    }
                    else
                    {
                        newWordDbo.MergeWith(oldWordDbo);
                        db.Words.Remove(oldWordDbo);
                        WordDictionary.Remove(WordDictionary.First(x => x.Id == oldWordDbo.Id));
                    }

                    db.SaveChanges();
                }
            }
        }

        private void AddWord_Click(object sender, RoutedEventArgs e)
        {
            var word = new Word("", 0, "", "manual");
            var result = new EditWordWindow(word).ShowDialog();
            if (result == true)
            {
                WordDictionary.Add(word);
                db.Words.Add(word);
                db.SaveChanges();
            }
        }

        private void TableHeader_Click(object sender, RoutedEventArgs e)
        {
            OrderAsc = !OrderAsc;
            var bindingInfo = (sender as GridViewColumnHeader).Column.DisplayMemberBinding as System.Windows.Data.Binding;
            string bindingPropertyName = bindingInfo.Path.Path;
            Func<Word, object> keySelector = x => x.GetPropertyValue(bindingPropertyName);
            var sortedWordDictionary = OrderAsc ? WordDictionary.OrderBy(keySelector) : WordDictionary.OrderByDescending(keySelector);
            WordDictionary.Update(sortedWordDictionary.ToList());
        }

        private void WordDictionaryListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((sender as ListView).SelectedItem is Word word)
            {
                var result = new EditWordWindow(word).ShowDialog();
                if (result == true)
                {
                    db.SaveChanges();
                }
            }
        }

        #endregion

        #region Supporting functions

        private void SaveWordDictionary()
        {
            db.TruncateWords();
            db.Words.AddRange(WordDictionary.ToList());
            db.SaveChanges();
            Application.Current.Dispatcher.Invoke(() => { StatusLine.Text = $"Changes has been saved."; });
        }

        private void ReplaceWord(string filename, string oldWord, string newWord)
        {
            string text;
            using (FileStream fstream = File.OpenRead(filename))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                text = Encoding.UTF8.GetString(array);
            }

            text = text.Replace(oldWord, newWord);
            File.WriteAllText(filename, text);
        }

        #endregion

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new TagPairsInfoWindow(TagPairs).Show();
        }

        private void TagText_Click(object sender, RoutedEventArgs e)
        {
            new TaggedEditorWindow().Show();
        }
    }
}
