using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Ferreteria.View.Utiles
{
    /// <summary>
    /// Extención de la clase SortableBindingList que permite, además del ordenamiento y 
    /// la búsqueda de sus elementos, el filtrado de los mismos. Para esto utiliza un
    /// predicado basado en el tipo del objeto contenido en la lista.
    /// </summary>
    /// <typeparam name="T">Clase a instanciar</typeparam>
    public class ExtendedBindingList<T> : SortableBindingList<T>
    {
        private List<T> invisibleItems = new List<T>();

        /// <summary>
        /// Crea una nueva instancia vacia basada en el tipo dado.
        /// </summary>
        public ExtendedBindingList() : base(new List<T>())
        {
            
        }

        /// <summary>
        /// Crea una nueva instancia utilizando la lista del tipo pasado.
        /// </summary>
        /// <param name="enumeration">Enumeración con la lista original.</param>
        public ExtendedBindingList(IEnumerable<T> enumeration) : base(new List<T>(enumeration)) 
        {
            
        }

        /// <summary>
        /// Aplica un filtro a la colección de objetos subyacentes de acuerdo
        /// al criterio pasado.
        /// </summary>
        /// <param name="filterPredicate">delegate con la funcionalidad que 
        /// decide cunado un objeto de la lista se debe filtrar o no</param>
        public void SimpleFilter(Predicate<T> filterPredicate)
        {
            // reset filter, add all invisble items to BindingList
            foreach (T item in this.invisibleItems)
                base.Items.Add(item);

            this.invisibleItems.Clear();

            // apply filter, if predicate != null
            if (filterPredicate != null)
            {
                // loop all items in bindingList
                for (int idx = Items.Count - 1; idx >= 0; --idx)
                {
                    // check if it needs to be included or not
                    if (!filterPredicate(Items[idx]))
                    {
                        // add to invisibleItems
                        this.invisibleItems.Add(Items[idx]);

                        // remove from bindingList
                        Items.RemoveAt(idx);
                    }
                }
            }

            // fire reset list (for ui)  
            base.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
    }
}
