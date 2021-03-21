using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace NLPTextEditor
{
    public partial class TaggedEditorWindow : Window, INotifyPropertyChanged
    {
        #region Properties

        private string activeFilePath;
        public string ActiveFilePath
        {
            get => activeFilePath;
            set
            {
                activeFilePath = value;
                OnPropertyChanged(nameof(ActiveFileName));
            }
        }

        public string ActiveFileName => Path.GetFileName(activeFilePath) ?? "Untitled";

        public DictionaryContext db = new DictionaryContext();
        private const string OtherGroupTag = "";
        private readonly IDictionary<string, string> _tagsDictionary;
        private readonly IDictionary<string, string> _tagsGroupDictionary = new Dictionary<string, string>()
        {
            {"VB", "Verb"},
            {"NN", "Noun"},
            {"JJ", "Adjective"},
            {"RB", "Adverb"},
            {OtherGroupTag, "Other"}
        };

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

        public TaggedEditorWindow()
        {
            InitializeComponent();
            DataContext = this;
            var tags = db.Tags.ToDictionary(x => x.Name, x => x.Description);
            _tagsDictionary = new ConcurrentDictionary<string, string>(tags);
            RebuildEditContextMenu();
            DocumentText.Document = new FlowDocument();
        }

        #region Events

        public void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                FileName = ActiveFileName,
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };

            var result = dlg.ShowDialog();
            if (result == true)
            {
                ActiveFilePath = dlg.FileName;
                using (var tr = new StreamReader(ActiveFilePath))
                {
                    var text = tr.ReadToEnd();
                    DocumentText.Document = GetDocument(text);
                }
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ActiveFilePath))
            {
                SaveAsFile_Click(sender, e);
            }
            else
            {
                using (var tr = new StreamWriter(ActiveFilePath))
                {
                    tr.Write(GetText());
                }
            }
        }

        private void SaveAsFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                FileName = ActiveFileName,
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };

            var result = dlg.ShowDialog();
            if (result == true)
            {
                ActiveFilePath = dlg.FileName;
                using (TextWriter tr = new StreamWriter(ActiveFilePath))
                {
                    tr.Write(GetText());
                }
            }
        }

        private void SetTagsAutomatically_Click(object sender, RoutedEventArgs e)
        {
            var text = GetText();
            if (!NLPEngine.TextIsTagged(text))
            {
                var taggedText = NLPEngine.TagText(text);
                DocumentText.Document = GetDocument(taggedText);
            }
        }

        private void EditContextMenu_OnOpened(object sender, RoutedEventArgs e)
        {
            var caret = DocumentText.CaretPosition;
            var caretPos = caret.GetTextRunLength(LogicalDirection.Backward);
            var block = DocumentText.CaretPosition.Paragraph ?? new Paragraph();
            var oldText = new TextRange(block.ContentStart, block.ContentEnd).Text;
            foreach (var inline in block.Inlines)
            {
                if (inline.ContentStart.GetOffsetToPosition(caret) >= 0
                    && inline.ContentEnd.GetOffsetToPosition(caret) <= 0)
                {
                    break;
                }

                caretPos += inline.ContentStart.GetOffsetToPosition(inline.ContentEnd);
            }

            var startPos = FindStartOfWord(oldText, caretPos);
            var wordSize = FindEndOfWord(oldText, startPos);
            var word = oldText.Substring(startPos, wordSize);
            EditingWordMenu.Header = word.Replace("_", "__");
        }

        #endregion

        private static FlowDocument GetDocument(string text)
        {
            var lines = text.Replace("\r\n", "").Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim() + ".");
            var doc = new FlowDocument();
            foreach (var line in lines)
            {
                var p = new Paragraph();
                p.Inlines.AddRange(BuildInlineItems(line));
                doc.Blocks.Add(p);
            }

            return doc;
        }

        private void RebuildEditContextMenu()
        {
            var items = DocumentTextContextMenu.Items;
            items.Clear();
            items.Add(EditingWordMenu);

            var grouping = _tagsDictionary.GroupBy(x => x.Key.Substring(0, 2)).ToDictionary(x=> x.Key);

            var otherItems = new List<KeyValuePair<string, string>>();

            foreach (var group in grouping)
            {
                if (_tagsGroupDictionary.ContainsKey(group.Key))
                {
                    items.Add(BuildEditContextMenuGroup(group.Key, group.Value));
                }
                else
                {
                    otherItems.AddRange(group.Value);
                }
            }

            items.Add(BuildEditContextMenuGroup(OtherGroupTag, otherItems));
        }

        private MenuItem BuildEditContextMenuGroup(string nameTag, IEnumerable<KeyValuePair<string, string>> items)
        {
            var group = new MenuItem
            {
                Header = _tagsGroupDictionary[nameTag]
            };

            foreach (var x in items)
            {
                var item = new MenuItem
                {
                    Header = $"{x.Value} ({x.Key})",
                    Tag = x.Key
                };

                item.Click += TagMenuItem_OnClick;

                group.Items.Add(item);
            }

            return group;
        }

        private void TagMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var caret = DocumentText.CaretPosition;
            var caretPos = caret.GetTextRunLength(LogicalDirection.Backward);
            var block = DocumentText.CaretPosition.Paragraph ?? new Paragraph();
            var oldText = new TextRange(block.ContentStart, block.ContentEnd).Text;

            foreach (var inline in block.Inlines)
            {
                if (inline.ContentStart.GetOffsetToPosition(caret) >= 0
                    && inline.ContentEnd.GetOffsetToPosition(caret) <= 0)
                {
                    break;
                }

                caretPos += inline.ContentStart.GetOffsetToPosition(inline.ContentEnd);
            }

            var startPos = FindStartOfWord(oldText, caretPos);
            var wordSize = FindEndOfWord(oldText, startPos);

            var parts = oldText.Substring(startPos, wordSize).Split('_');

            var newWord = parts[0] + '_' + (sender as MenuItem)?.Tag;
            var newText = oldText.Substring(0, startPos) + newWord + oldText.Substring(startPos + wordSize);
            block.Inlines.Clear();
            block.Inlines.AddRange(BuildInlineItems(newText));
        }

        private static IEnumerable<Inline> BuildInlineItems(string sentence)
        {
            var list = new List<Inline>();
            var words = sentence.Split(' ');
            foreach (var word in words)
            {
                if (word.Contains("_"))
                {
                    var parts = word.Split('_');
                    list.Add(new Run(parts[0]));
                    list.Add(new Run("_"));
                    var tag = new Run(parts[1]) { Foreground = Brushes.Blue };
                    list.Add(tag);
                }
                else
                {
                    list.Add(new Run(word));
                }

                list.Add(new Run(" "));
            }

            return list;
        }

        private string GetText()
        {
            var document = DocumentText.Document;
            return new TextRange(document.ContentStart, document.ContentEnd).Text;
        }

        private static int FindStartOfWord(string text, int caret)
        {
            var startPos = FindLast(text.Substring(0, caret), new[] { " ", "\n" });
        
            if (startPos == -1)
            {
                startPos = 0;
            }
            else
            {
                startPos += 1;
            }

            return startPos;
        }

        private static int FindEndOfWord(string text, int start)
        {
            var index = FindFirst(text.Substring(start), new[] {" ", "\n"});

            if (index == -1)
            {
                return text.Length - start;
            }

            return index;
        }

        private static int FindFirst(string s, IEnumerable<string> subStrings)
        {
            return subStrings
                .Select(x => s.IndexOf(x, StringComparison.Ordinal))
                .Where(x => x != -1)
                .DefaultIfEmpty(-1)
                .Min();
        }

        private static int FindLast(string s, IEnumerable<string> subStrings)
        {
            return subStrings
                .Select(x => s.LastIndexOf(x, StringComparison.Ordinal))
                .Where(x => x != -1)
                .DefaultIfEmpty(-1)
                .Max();
        }
    }
}
