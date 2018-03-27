using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Listard
{
    public class Listard<T> : IEnumerable<T>
    {
        /// <summary>
        /// Internal data array.
        /// </summary>
        T[] _data = new T[0];

        /// <summary>
        /// Gets the amount of elements in the list.
        /// </summary>
        /// <returns>The amount of elements in the list.</returns>
        public int Count
        {
            get => _data.Length;
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
            Array.Resize(ref _data, _data.Length + values.Length);

            // Iterate over all values and add each to the list
            for (var i = _data.Length - values.Length; i < _data.Length; i++)
                _data[i] = values[i - (_data.Length - values.Length)]; // Write the value to the last index
        }

        /// <summary>
        /// Checks if an element is in the list.
        /// </summary>
        /// <param name="element">Element to check for.</param>
        /// <returns>True if the element exists, false otherwise.</returns>
        public bool Contains(T element) => _data.Contains(element);

        /// <summary>
        /// Inserts one or more elements at the given index.
        /// </summary>
        /// <param name="index">Index to add the elements at.</param>
        /// <param name="values">Elements to add.</param>
        public void Insert(int index, params T[] values)
        {
            // Throw an Exception the index is larger than the list
            if (index > _data.Length)
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");

            // Increase the size of the array by one
            Array.Resize(ref _data, _data.Length + values.Length);

            // Iterate over all elements after the given index and move them forward by one
            for (var i = _data.Length - 1; i > index; i--)
                _data[i] = _data[i - values.Length];

            // Set each value at the given index
            for (var i = index; i < index + values.Length; i++)
                _data[i] = values[i - index];
        }

        /// <summary>
        /// Gets the element at the given index.
        /// </summary>
        /// <param name="index">Index of the element to get.</param>
        /// <returns>The element at the given index.</returns>
        public T ElementAt(int index)
        {
            // Throw an Exception the index is larger than the list
            if (index >= _data.Length)
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");

            // Return the value at the given index
            return _data[index];
        }

        /// <summary>
        /// Gets the last element in the list.
        /// </summary>
        /// <returns>The last element in the list.</returns>
        public T Last()
        {
            if (_data.Length == 0)
                throw new IndexOutOfRangeException("No element in the list.");

            return _data[_data.Length - 1];
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
                if (index >= _data.Length)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the list.");

                // Iterate over all elements after the given index and move them back by one
                for (var i = index; i < _data.Length - 1; i++)
                    _data[i] = _data[i + 1];

                // Decrease the size of the array by one
                Array.Resize(ref _data, _data.Length - 1);
            }
        }

        /// <summary>
        /// Removes all elements from the list.
        /// </summary>
        public void Clear()
        {
            _data = new T[0];
        }

        /// <summary>
        /// Searches for an element by it's value.
        /// </summary>
        /// <param name="value">Value to search for.</param>
        /// <returns>The index of the element, a default instance if no element was found.</returns>
        public T FindElement(T value)
        {
            // Iterate over all elements
            foreach (var element in _data)
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
            if (index >= _data.Length)
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");

            // Replace the element
            _data[index] = value;
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
            foreach (var element in _data)
                sb.Append(element.ToString() + ", ");

            // Trim the string and return it
            return sb.ToString().Trim(',', ' ');
        }

        /// <summary>
        /// Gets the enumerator of the list.
        /// </summary>
        /// <returns>The enumerator of the list.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Gets the generic enumerator of the list.
        /// </summary>
        /// <returns>The enumerator of the list.</returns>
        public IEnumerator<T> GetEnumerator() => _data.Cast<T>().GetEnumerator();
    }
}