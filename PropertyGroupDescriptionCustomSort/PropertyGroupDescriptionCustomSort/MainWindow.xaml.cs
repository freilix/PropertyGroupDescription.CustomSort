using System;
using System.Collections;
using System.Windows;
using System.Windows.Data;

namespace PropertyGroupDescriptionCustomSort
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var propertyGroupDescriptionNotWorking = IsNotWorking();
            var propertyGroupDescriptionWorking = IsWorking();

            InitializeComponent();
        }

        private PropertyGroupDescription IsNotWorking()
        {
            var propertyGroupDescription = new PropertyGroupDescription();
            // propertyGroupDescription.CustomSort = new CollectionViewGroupStringComparer();
            return propertyGroupDescription;
        }

        private PropertyGroupDescription IsWorking()
        {
            var propertyGroupDescription = new PropertyGroupDescription();
            var propertyInfo = propertyGroupDescription.GetType().GetProperty("CustomSort");
            propertyInfo?.SetValue(propertyGroupDescription, new CollectionViewGroupStringComparer());
            return propertyGroupDescription;
        }

        private class CollectionViewGroupStringComparer : IComparer
        {
            public int Compare(object o1, object o2)
            {
                var group1 = o1 as CollectionViewGroup;
                var group2 = o2 as CollectionViewGroup;
                if (group1 == null || group2 == null)
                    return 0;

                var name1 = group1.Name.ToString();
                var name2 = group2.Name.ToString();
                return string.Compare(name1, name2, StringComparison.CurrentCulture);
            }
        }
    }
}
