using System;
using System.Collections;
using System.Collections.Generic;

namespace WhatAreDelegates
{
    public delegate bool AgeDelegate(int age);
    public delegate bool GenderDelegate(string gender);
    class Program
    {
        static void Main(string[] args)
        {
            List<MyObject> peopleObjects = new List<MyObject> {
                new MyObject() { Name = "Joe", Age = 41, Gender = "M" },
                new MyObject() { Name = "Nancy", Age = 36, Gender = "F" },
                new MyObject() { Name = "April", Age = 19, Gender = "F" },
                new MyObject() { Name = "Jon", Age = 22, Gender = "M" },
                new MyObject() { Name = "Rob", Age = 26, Gender = "M" },
                new MyObject() { Name = "Wilma", Age = 22, Gender = "F" },
                new MyObject() { Name = "Tim", Age = 17, Gender = "M" },
                new MyObject() { Name = "Velma", Age = 22, Gender = "F" }
            };

            Console.WriteLine("Even Ages");
            foreach (MyObject personObject in AgeCheck(peopleObjects, even => even % 2 == 0 ))
                Console.WriteLine($"Name: {personObject.Name} : Age: {personObject.Age} : Gender: {personObject.Gender}");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Odd Ages");
            foreach (MyObject personObject in AgeCheck(peopleObjects, odd => odd % 2 != 0))
                Console.WriteLine($"Name: {personObject.Name} : Age: {personObject.Age} : Gender: {personObject.Gender}");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Men");
            foreach (MyObject personObject in GenderCheck(peopleObjects, gender => gender == "M"))
                Console.WriteLine($"Name: {personObject.Name} : Age: {personObject.Age} : Gender: {personObject.Gender}");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Women");
            foreach (MyObject personObject in GenderCheck(peopleObjects, gender => gender == "F"))
                Console.WriteLine($"Name: {personObject.Name} : Age: {personObject.Age} : Gender: {personObject.Gender}");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Press a key to continue...");
            Console.ReadLine();
        }

        static IEnumerable<MyObject> AgeCheck(List<MyObject> people, AgeDelegate checkAge)
        {
            foreach (MyObject person in people)
                if (checkAge(person.Age))
                    yield return person;
        }

        static IEnumerable<MyObject> GenderCheck(List<MyObject> people, GenderDelegate checkGender)
        {
            foreach (MyObject person in people)
                if (checkGender(person.Gender))
                    yield return person;
        }
        public class MyObject
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
        }
    }
}
