using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NLPTextEditor
{
    public partial class TagsInfoWindow : Window
    {
        public DictionaryContext db = new DictionaryContext();
        public ObservableCollection<Tag> Tags { get; set; }
        public bool OrderAsc { get; set; } = true;

        public TagsInfoWindow()
        {
            InitializeComponent();
            Tags = new ObservableCollection<Tag>(db.Tags);
            DataContext = this;
        }

        private void TableHeader_Click(object sender, RoutedEventArgs e)
        {
            OrderAsc = !OrderAsc;
            var bindingInfo = (sender as GridViewColumnHeader).Column.DisplayMemberBinding as System.Windows.Data.Binding;
            string bindingPropertyName = bindingInfo.Path.Path;
            Func<Tag, object> keySelector = x => x.GetPropertyValue(bindingPropertyName);
            var sortedWordDictionary = OrderAsc ? Tags.OrderBy(keySelector) : Tags.OrderByDescending(keySelector);
            Tags.Update(sortedWordDictionary.ToList());
        }

        private void TagsListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((sender as ListView).SelectedItem is Tag tag)
            {
                var result = new EditTagWindow(tag).ShowDialog();
                if (result == true)
                {
                    db.Entry(tag).State = System.Data.Entity.EntityState.Modified;
                }
            }
        }

        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
            var tag = new Tag("", "");
            var result = new EditTagWindow(tag).ShowDialog();
            if (result == true)
            {
                Tags.Add(tag);
                db.Tags.Add(tag);
            }
        }

        private void RemoveTag_Click(object sender, RoutedEventArgs e)
        {
            if (TagsListView.SelectedItem is Tag tag)
            {
                Tags.Remove(tag);
                db.Tags.Remove(tag);
            }
        }

        protected override void OnClosed(EventArgs e) => db.SaveChanges();
    }
}
