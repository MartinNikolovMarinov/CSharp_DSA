using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> peopleByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> peopleByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();

    public PersonCollection() { }

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.peopleByEmail.ContainsKey(email))
        {
            return false;
        }

        var person = new Person() 
        {
            Email = email, 
            Name = name, 
            Age = age, 
            Town = town
        };

        // add person by email:
        this.peopleByEmail.Add(email, person);

        // add person by domain:
        string domain = ExtractDomain(email);
        this.peopleByEmailDomain.AppendValueToKey(domain, person);

        // add person by name and town:
        string nameAndTown = name + town;
        this.peopleByNameAndTown.AppendValueToKey(nameAndTown, person);

        // add person by age:
        this.peopleByAge.AppendValueToKey(age, person);
        return true;
    }

    public int Count 
    { 
        get { return this.peopleByEmail.Count; }
    }

    public Person FindPerson(string email)
    {
        if (!this.peopleByEmail.ContainsKey(email))
        {
            return null;
        }
       
        return this.peopleByEmail[email];
    }

    public bool DeletePerson(string email)
    {
        if (!this.peopleByEmail.ContainsKey(email))
        {
            return false;
        }

        Person person = this.FindPerson(email);

        this.peopleByEmail.Remove(email);
        if (this.peopleByAge[person.Age].Count == 1)
            this.peopleByAge.Remove(person.Age);
        else 
            this.peopleByAge[person.Age].Remove(person);

        if (this.peopleByEmailDomain[ExtractDomain(email)].Count == 1)
            this.peopleByEmailDomain.Remove(ExtractDomain(email));
        else
            this.peopleByEmailDomain[ExtractDomain(email)].Remove(person);

        if (this.peopleByNameAndTown[person.Name + person.Town].Count == 1)
            this.peopleByNameAndTown.Remove(person.Name + person.Town);
        else 
            this.peopleByNameAndTown[person.Name + person.Town].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (!this.peopleByEmailDomain.ContainsKey(emailDomain))
        {
            return Enumerable.Empty<Person>();
        }

        return this.peopleByEmailDomain[emailDomain];
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        string nameAndTown = name + town;
        if (!this.peopleByNameAndTown.ContainsKey(nameAndTown))
        {
            return Enumerable.Empty<Person>();
        }

        return this.peopleByNameAndTown[nameAndTown];
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var ageRanges = peopleByAge.Range(startAge, true, endAge, true);

        foreach (var ageRange in ageRanges)
        {
            foreach (var person in ageRange.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        var ageRanges = peopleByAge.Range(startAge, true, endAge, true);

        foreach (var ageRange in ageRanges)
        {
            foreach (var person in ageRange.Value)
            {
                if (person.Town == town)
                {
                    yield return person;
                }
            }
        }
    }

    private static string ExtractDomain(string email)
    {
        int indexOfAt = email.LastIndexOf("@");
        string domain = email.Substring(indexOfAt + 1, email.Length - indexOfAt - 1);
        return domain;
    }
}
