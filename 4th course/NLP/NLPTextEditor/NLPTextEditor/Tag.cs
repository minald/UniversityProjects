using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NLPTextEditor
{
    public class Tag : INotifyPropertyChanged
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

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
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

        private string nextTags;
        public string NextTags
        {
            get { return nextTags; }
            set
            {
                nextTags = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

        public Tag() { }

        public Tag(string name, string description)
        {
            Name = name;
            Description = description;
            Amount = 0;
        }

        public void AddNewTag(string newNextTag)
        {
            Amount++;
            if(NextTags == null)
            {
                NextTags = "";
            }
            var tagsArray = NextTags.Split(',').ToList();
            if (!NextTags.Contains(newNextTag + "_"))
            {
                if (String.IsNullOrEmpty(NextTags))
                {
                    NextTags += newNextTag + "_1";
                }
                else
                {
                    NextTags += "," + newNextTag + "_1";
                }
            }
            else
            {
                string currentTag = tagsArray.FirstOrDefault(x => x.StartsWith(newNextTag));
                if (currentTag != null)
                {
                    tagsArray.Remove(currentTag);
                    int underscoreIndex = currentTag.IndexOf('_');
                    string amount = currentTag.Substring(underscoreIndex + 1);
                    int newAmount = Int32.Parse(amount) + 1;
                    currentTag = currentTag.Replace(amount, newAmount.ToString());
                    tagsArray.Add(currentTag);
                    NextTags = String.Join(",", tagsArray.ToArray());
                }
            }
        }
    }
}
