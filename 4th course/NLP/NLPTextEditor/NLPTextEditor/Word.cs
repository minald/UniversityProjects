using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace NLPTextEditor
{
    public class Word : INotifyPropertyChanged
    {
        #region Properties

        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string canonical;
        public string Canonical
        {
            get { return canonical; }
            set
            {
                canonical = value;
                OnPropertyChanged();
            }
        }

        private string canonicalTag;
        public string CanonicalTag
        {
            get { return canonicalTag; }
            set
            {
                canonicalTag = value;
                OnPropertyChanged();
            }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }

        private string tags;

        public string Tags
        {
            get { return tags; }
            set
            {
                tags = value;
                OnPropertyChanged();
            }
        }

        public string[] TagsArr => tags.Split(',');

        private string files;

        public string Files
        {
            get => files;
            set
            {
                files = value;
                OnPropertyChanged();
            }
        }

        public string[] FilesArr => files.Split(',');

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

        public Word() { }

        public Word(string name, int amount, string tag, string file, string canonicalTag = null)
        {
            Name = name;
            Amount = amount;
            tags = tag;
            files = file;
            Canonical = NLPEngine.LemmatizeWord(name, tag);
            CanonicalTag = NLPEngine.TagWord(Canonical);
        }

        public void IncrementAmountAndAddNewTagAndFile(string newTag, string newFile)
        {
            Amount++;
            var tagsArray = tags.Split(',').ToList();
            if (!(new Regex($@"(^{newTag}_)|(,{ newTag}_)").Match(tags).Success))
            {
                tags += "," + newTag + "_1";
            }
            else
            {
                string currentTag = tagsArray.First(x => x.StartsWith(newTag));
                tagsArray.Remove(currentTag);
                int underscoreIndex = currentTag.IndexOf('_');
                string amount = currentTag.Substring(underscoreIndex + 1);
                int newAmount = Int32.Parse(amount) + 1;
                currentTag = currentTag.Replace(amount, newAmount.ToString());
                tagsArray.Add(currentTag);
                tags = String.Join(",", tagsArray.ToArray());
            }

            if (!files.Split(',').Contains(newFile))
            {
                files += "," + newFile;
            }
        }

        public void MergeWith(Word oldWordDbo)
        {
            var flies = oldWordDbo.FilesArr.Concat(FilesArr).Distinct();
            var tags = oldWordDbo.TagsArr.Concat(TagsArr).Distinct();

            Files = string.Join(",", flies);
            Tags = string.Join(",", tags);
            Amount += oldWordDbo.Amount;
        }
    }
}
