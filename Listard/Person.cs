using System;

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

        public override string ToString()
        {
            return $"{Name}, {Gender}, {DateOfBirth:dd.MM.yyyy}";
        }
    }
}
