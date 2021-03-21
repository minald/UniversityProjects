using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NLPTextEditor
{
    public static class Extensions
    {
        public static object GetPropertyValue(this object source, string propertyName)
            => source.GetType().GetProperty(propertyName).GetValue(source, null);

        public static void Update<T>(this ObservableCollection<T> collection, List<T> list)
        {
            collection.Clear();
            list.ForEach(x => collection.Add(x));
        }
    }
}
