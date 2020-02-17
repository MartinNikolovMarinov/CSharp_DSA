using System;
using System.Linq;

class PlayWithPersons
{
    static void Main()
    {
        var persons = new PersonCollection();
        var isAdded = persons.AddPerson("pesho@gmail.com", "Pesho", 28, "Plovdiv");
        persons.AddPerson("kiro@yahoo.co.uk", "Kiril", 22, "Plovdiv");
        persons.AddPerson("asen@gmail.com", "Asen", 22, "Sofia");
        Person person = persons.FindPerson("non-existing person");
        person = persons.FindPerson("pesho@gmail.com");
        var personsGmail = persons.FindPersons("gmail.com");
        var personsPeshoPlovdiv = persons.FindPersons("Pesho", "Plovdiv");
        var personsPeshoSofia = persons.FindPersons("Pesho", "Sofia");
        var personsKiroPlovdiv = persons.FindPersons("Kiro", "Plovdiv");
        var personsAge22To28 = persons.FindPersons(22, 28);
        var personsAge22To28Plovdiv = persons.FindPersons(22, 28, "Plovdiv");
        var isDeleted = persons.DeletePerson("pesho@gmail.com");
        isDeleted = persons.DeletePerson("pesho@gmail.com");
        person = persons.FindPerson("pesho@gmail.com");
        
        personsGmail = persons.FindPersons("gmail.com");
        //CollectionAssert.AreEqual(
        //    new string[] { "asen@gmail.com" },
        //    personsGmail.Select(p => p.Email).ToList());
    }
}
