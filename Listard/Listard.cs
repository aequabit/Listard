using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Listard
{
    public class Listard<T> : IEnumerable
    {
        /// <summary>
        /// Internal data array.
        /// </summary>
        T[] Data = new T[0];

        /// <summary>
        /// Gets the amount of elements in the list.
        /// </summary>
        /// <returns>The amount of elements in the list.</returns>
        public int Count
        {
            get => Data.Length;
        }

        /// <summary>
        /// Array operator overload.
        /// </summary>
        /// <param name="index">Index of the element to get.</param>
        public T this[int index]
        {
            get => ElementAt(index);
            set => Replace(index, value);
        }

        /// <summary>
        /// Adds one or more elements to the list.
        /// </summary>
        /// <param name="values">Elements to add.</param>
        public void Add(params T[] values)
        {
            // Increase the size of the array by the length of the values
            Array.Resize(ref Data, Data.Length + values.Length);

            // Iterate over all values and add each to the list
            for (var i = Data.Length - values.Length; i < Data.Length; i++)
                Data[i] = values[i - (Data.Length - values.Length)]; // Write the value to the last index
        }

        /// <summary>
        /// Checks if an element is in the list.
        /// </summary>
        /// <param name="element">Element to check for.</param>
        /// <returns>True if the element exists, false otherwise.</returns>
        public bool Contains(T element) => Data.Contains(element);

        /// <summary>
        /// Inserts one or more elements at the given index.
        /// </summary>
        /// <param name="index">Index to add the elements at.</param>
        /// <param name="values">Elements to add.</param>
        public void Insert(int index, params T[] values)
        {
            // Throw an Exception the index is larger than the list
            if (index > Data.Length)
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");

            // Increase the size of the array by one
            Array.Resize(ref Data, Data.Length + values.Length);

            // Iterate over all elements after the given index and move them forward by one
            for (var i = Data.Length - 1; i > index; i--)
                Data[i] = Data[i - values.Length];

            // Set each value at the given index
            for (var i = index; i < index + values.Length; i++)
                Data[i] = values[i - index];
        }

        /// <summary>
        /// Gets the element at the given index.
        /// </summary>
        /// <param name="index">Index of the element to get.</param>
        /// <returns>The element at the given index.</returns>
        public T ElementAt(int index)
        {
            // Throw an Exception the index is larger than the list
            if (index >= Data.Length)
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");

            // Return the value at the given index
            return Data[index];
        }

        /// <summary>
        /// Gets the last element in the list.
        /// </summary>
        /// <returns>The last element in the list.</returns>
        public T Last()
        {
            if (Data.Length == 0)
                throw new IndexOutOfRangeException("No element in the list.");

            return Data[Data.Length - 1];
        }

        /// <summary>
        /// Removes one or more elements from the list.
        /// </summary>
        /// <param name="indices">Indices of the items to remove.</param>
        public void RemoveAt(params int[] indices)
        {
            // Iterate over all indices and try to remove the element at each
            foreach (var index in indices)
            {
                // Throw an Exception the index is larger than the list
                if (index >= Data.Length)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the list.");

                // Iterate over all elements after the given index and move them back by one
                for (var i = index; i < Data.Length - 1; i++)
                    Data[i] = Data[i + 1];

                // Decrease the size of the array by one
                Array.Resize(ref Data, Data.Length - 1);
            }
        }

        /// <summary>
        /// Searches for an element by it's value.
        /// </summary>
        /// <param name="value">Value to search for.</param>
        /// <returns>The index of the element, a default instance if no element was found.</returns>
        public T FindElement(T value)
        {
            // Iterate over all elements
            foreach (var element in Data)
            {
                // If the element is equal to the value, return it
                if (element.Equals(value))
                    return element;
            }

            // If no matching element was found, return null
            return default(T);
        }

        /// <summary>
        /// Replaces the element at the specified index.
        /// </summary>
        /// <param name="index">Index of the element to replace.</param>
        /// <param name="value">Value to replace the element with.</param>
        public void Replace(int index, T value)
        {
            // Throw an Exception the index is larger than the list
            if (index >= Data.Length)
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");

            // Replace the element
            Data[index] = value;
        }

        /// <summary>
        /// Gets the list as a human-readable string.
        /// </summary>
        /// <returns>The list as a human-readable string.</returns>
        public override string ToString()
        {
            // Create a StringBuilder
            var sb = new StringBuilder();

            // Add the string representation of all elements to the builder
            foreach (var element in Data)
                sb.Append(element.ToString() + ", ");

            // Trim the string and return it
            return sb.ToString().Trim(',', ' ');
        }

        /// <summary>
        /// Gets the Enumerator of the list.
        /// </summary>
        /// <returns>The Enumerator of the list.</returns>
        IEnumerator IEnumerable.GetEnumerator() => Data.GetEnumerator();
    }
}
