using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System;

public class Student
{
    public Student() { }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    /* Adds new student to the table */
    static async Task Add(Student student)
    {
        using (IDbConnection db = new SqlConnection(cnnString)) {
            string insertQuery = "INSERT INTO [dbo].[Students] ([Name], [Age]) VALUES (@name, @age)";
            await db.QueryAsync(insertQuery, new { student.Name, student.Age });
        }
    }

    static async Task Remove(Student student) {
        using (IDbConnection db = new SqlConnection(cnnString)) {
            string removeQuery = "DELETE FROM students WHERE Name = @name";
            await db.QueryAsync(removeQuery, new { name = student.Name });
        }
    }

    static async Task Update(Student student) {
        using (IDbConnection db = new SqlConnection(cnnString)) {
            var newStudent = GetStudent(); // Get a new student

            string updateQuery = "UPDATE students SET Name = @Name, Age = @Age Where Name = @oldName";
            await db.QueryAsync(updateQuery, new { oldName = student.Name, Name = newStudent.Name, Age = newStudent.Age });
        }
    }
    /* This method prints the students table */
    static async Task Print()
    {
        using (IDbConnection db = new SqlConnection(cnnString)) {
            string printQuery = "SELECT * FROM Students";
            List<Student> list = (await db.QueryAsync<Student>(printQuery)).ToList();

            foreach (var student in list)
                Console.WriteLine($"Id: {student.Id}\tName: {student.Name}\tAge: {student.Age}");
        }
    }
    public const string cnnString = "Server=localhost; Initial catalog=DZ; User=sa; password=qwerty112!";

    static Student GetStudent()
    {
        var name = IO.GetInput<string>("Name: ");
        var age = IO.GetInput<int>("Age: ");

        return new Student(name, age);
    }

    static void ShowMenu()
    {
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("1.Add\t2.Remove\t3.Print\t4.Update");
    }
    static async Task Main()
    {
        bool running = true;

        while (running) {
            ShowMenu();
            var cmd = Console.ReadLine();

            switch (cmd) {
                case "1":
                    await Add(GetStudent()); // C - 1
                    break;
                case "2":
                    await Remove(GetStudent()); // D - 4
                    break;
                case "3":
                    await Print(); // R - 2
                    break;
                case "4":
                    await Update(GetStudent()); // U - 3
                    break;
                default:
                    IO.Print("Invalid input", ConsoleColor.Red);
                    running = false;
                    break;
            }
        }
    }
}
