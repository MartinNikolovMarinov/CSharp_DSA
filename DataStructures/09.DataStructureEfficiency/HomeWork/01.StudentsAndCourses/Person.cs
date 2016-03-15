namespace _01.StudentsAndCourses
{
    using System;

    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName = null, string lastName = null) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int CompareTo(Person other)
        {
            int lastNameDiff = this.LastName.CompareTo(other.LastName);
            int firstNameDiff = this.FirstName.CompareTo(other.FirstName);

            if (lastNameDiff > 0 || lastNameDiff < 0)
                return lastNameDiff;
            else
                return firstNameDiff;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
