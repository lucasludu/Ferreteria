using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Ferreteria.View.Utiles
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSorted;
        private ListSortDirection sortDirection;
        private PropertyDescriptor sortProperty;

        public SortableBindingList() : base() { }
        public SortableBindingList(IList<T> list) : base(list) { }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => isSorted;
        protected override ListSortDirection SortDirectionCore => sortDirection;
        protected override PropertyDescriptor SortPropertyCore => sortProperty;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            if (Items is List<T> list)
            {
                var property = typeof(T).GetProperty(prop.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (property != null)
                {
                    list.Sort((x, y) =>
                    {
                        int result = Comparer<object>.Default.Compare(property.GetValue(x), property.GetValue(y));
                        return direction == ListSortDirection.Ascending ? result : -result;
                    });
                }

                isSorted = true;
                sortProperty = prop;
                sortDirection = direction;

                // Notificar que la lista ha cambiado
                ResetBindings();
            }
        }

        protected override void RemoveSortCore()
        {
            isSorted = false;
            sortProperty = null;
            sortDirection = ListSortDirection.Ascending;
        }
    }
}
