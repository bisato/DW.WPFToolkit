using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace DW.WPFToolkit.Helpers
{
    public static class VisualTreeAssist
    {
        public static TParentType FindParent<TParentType>(object item) where TParentType : DependencyObject
        {
            var child = item as DependencyObject;
            if (child == null)
                return default(TParentType);

            var parent = VisualTreeHelper.GetParent(child);
            while (parent != null && !(parent is TParentType))
                parent = VisualTreeHelper.GetParent(parent);

            return parent != null ? (TParentType)parent : default(TParentType);
        }

        public static object FindNamedParent(object item, string name)
        {
            var child = item as DependencyObject;
            if (child == null ||
                string.IsNullOrWhiteSpace(name))
                return null;

            var parent = VisualTreeHelper.GetParent(child);
            while (parent != null)
            {
                if (HasName(parent, name))
                    return parent;
                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }

        public static TParentType FindNamedParent<TParentType>(object item, string name) where TParentType : DependencyObject
        {
            var foundItem = FindNamedParent(item, name);
            return foundItem is TParentType ? (TParentType)foundItem : default(TParentType);
        }

        public static List<TParentType> GetParents<TParentType>(object item) where TParentType : DependencyObject
        {
            var parents = new List<TParentType>();
            var parent = FindParent<TParentType>(item);
            while (parent != null)
            {
                parents.Add(parent);
                parent = FindParent<TParentType>(parent);
            }
            return parents;
        }

        public static int GetParentCount<TParentType>(object item) where TParentType : DependencyObject
        {
            return GetParents<TParentType>(item).Count;
        }

        public static List<TParentType> GetParentsUntil<TParentType, TEndType>(object item)
            where TParentType : DependencyObject
            where TEndType : DependencyObject
        {
            var parents = new List<TParentType>();

            var child = item as DependencyObject;
            if (child == null)
                return parents;

            var parent = VisualTreeHelper.GetParent(child);
            while (parent != null && !(parent is TEndType))
            {
                if (parent is TParentType)
                    parents.Add((TParentType)parent);
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parents;
        }

        public static int GetParentsUntilCount<TParentType, TEndType>(object item)
            where TParentType : DependencyObject
            where TEndType : DependencyObject
        {
            return GetParentsUntil<TParentType, TEndType>(item).Count;
        }

        public static TChildType FindChild<TChildType>(object item) where TChildType : DependencyObject
        {
            var parent = item as DependencyObject;
            if (parent == null)
                return default(TChildType);

            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; ++i)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is TChildType)
                    return (TChildType)child;
                
                var foundChild = FindChild<TChildType>(child);
                if (foundChild != null)
                    return foundChild;
            }

            return default(TChildType);
        }

        public static object FindNamedChild(object item, string name)
        {
            var parent = item as DependencyObject;
            if (parent == null ||
                string.IsNullOrWhiteSpace(name))
                return null;

            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; ++i)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (HasName(child, name))
                    return child;
                
                var foundChild = FindNamedChild(child, name);
                if (foundChild != null)
                    return foundChild;
            }

            return null;
        }

        public static TChildType FindNamedChild<TChildType>(object item, string name) where TChildType : DependencyObject
        {
            var foundItem = FindNamedChild(item, name);
            return foundItem is TChildType ? (TChildType)foundItem : default(TChildType);
        }

        public static List<TChildType> GetChilds<TChildType>(object item) where TChildType : DependencyObject
        {
            var childs = new List<TChildType>();
            GetChilds(item, childs);
            return childs;
        }

        private static void GetChilds<TChildType>(object item, ICollection<TChildType> target) where TChildType : DependencyObject
        {
            var parent = item as DependencyObject;
            if (parent == null)
                return;

            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; ++i)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is TChildType)
                    target.Add((TChildType)child);
                GetChilds(child, target);
            }
        }

        public static int GetChildsCount<TChildType>(object item) where TChildType : DependencyObject
        {
            return GetChilds<TChildType>(item).Count;
        }

        private static bool HasName(DependencyObject item, string name)
        {
            return item is FrameworkElement &&
                   ((FrameworkElement)item).Name == name;
        }
    }
}
