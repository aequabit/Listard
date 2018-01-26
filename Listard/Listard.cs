using System;
using System.Text;

namespace ListardTest
{
    public class Listard
    {
        /// <summary>
        /// Internal data array.
        /// </summary>
        private int[] Data;

        /// <summary>
        /// Gets the amount of elements in the list.
        /// </summary>
        /// <returns>The amount of elements in the list.</returns>
        public int Count
        {
            get => Data.Length;
        }

        /// <summary>
        /// Initializes a new list.
        /// </summary>
        public Listard()
        {
            Data = new int[0];
        }

        /// <summary>
        /// Adds one or more elements to the list.
        /// </summary>
        /// <param name="values">Elements to add.</param>
        public void Add(params int[] values)
        {
            // Iterate over all values and add each to the list
            foreach (var value in values)
            {
                // Increase the size of the array by one
                Array.Resize(ref Data, Data.Length + 1);

                // Write the value to the last index
                Data[Data.Length - 1] = value;
            }
        }

        /// <summary>
        /// Gets the element at the given index.
        /// </summary>
        /// <param name="index">Index of the element to get.</param>
        /// <returns>The element at the given index.</returns>
        public int ElementAt(int index)
        {
            // Throw an Exception the index is larger than the list
            if (index >= Data.Length)
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");

            // Return the value at the given index
            return Data[index];
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
        /// <returns>The index of the element, -1 if no element was found.</returns>
        public int FindElement(int value)
        {
            throw new NotImplementedException("Listard->FindElement: Not implemented");
        }

        /// <summary>
        /// Replaces the element at the specified index.
        /// </summary>
        /// <param name="index">Index of the element to replace.</param>
        /// <param name="value">Value to replace the element with.</param>
        public void Replace(int index, int value)
        {
            // Throw an Exception the index is larger than the list
            if (index >= Data.Length)
                throw new IndexOutOfRangeException("Index was outside the bounds of the list.");

            Data[index] = value;
        }

        /// <summary>
        /// Returns the list as a human-readable string.
        /// </summary>
        /// <returns>The list as a human-readable string.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var element in Data)
                sb.Append(element + ", ");

            return sb.ToString().Trim(',', ' ');
        }
    }
}
