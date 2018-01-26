using System;
using System.Collections;
using System.Text;

namespace ListardTest
{
    public enum Gender
    {
        Male,
        Female
    }

    public struct Person
    {
        public string Name;
        public Gender Gender;
        public DateTime DateOfBirth;

        public string ToString()
        {
            return $"{Name}, {Gender}, {DateOfBirth:dd.MM.yyyy}";
        }
    }
}
