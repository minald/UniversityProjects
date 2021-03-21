using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NLPTextEditor
{
    public partial class TagPairsInfoWindow : Window
    {
        public DictionaryContext db = new DictionaryContext();
        public ObservableCollection<TagPair> TagPairs { get; set; }
        public bool OrderAsc { get; set; } = true;

        public TagPairsInfoWindow(List<TagPair> tagPairs)
        {
            InitializeComponent();
            TagPairs = new ObservableCollection<TagPair>(tagPairs);
            DataContext = this;
        }

        private void TableHeader_Click(object sender, RoutedEventArgs e)
        {
            OrderAsc = !OrderAsc;
            var bindingInfo = (sender as GridViewColumnHeader).Column.DisplayMemberBinding as System.Windows.Data.Binding;
            string bindingPropertyName = bindingInfo.Path.Path;
            Func<TagPair, object> keySelector = x => x.GetPropertyValue(bindingPropertyName);
            var sortedWordDictionary = OrderAsc ? TagPairs.OrderBy(keySelector) : TagPairs.OrderByDescending(keySelector);
            TagPairs.Update(sortedWordDictionary.ToList());
        }
    }
}
