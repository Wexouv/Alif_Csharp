using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations.Schema;

// The table columns
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public static class SqlHelper
{
    // The context to use the db
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DZ;User ID=sa;Password=qwerty112!");
        }
    }

    // Creates new entity
    public static async Task Create(Student newUser)
    {
        using var db = new StudentContext();
        await db.AddAsync(newUser); // Add 
        await db.SaveChangesAsync(); // Save changes
        IO.Debug($"Creted user {newUser.Name}");
    }


    public static async Task<Student> FindById(int id)
    {
        using var db = new StudentContext();

        var curUser = await  db.Students.FindAsync(id); // Find user by id
        if (curUser == null) throw new Exception($"User with id: {id} not found.");

        return curUser;
    }
    public static async Task DeleteById(int id)
    {
        using var db = new StudentContext();
        db.Remove(await FindById(id)); // Remove the user, if found

        var v = await db.SaveChangesAsync();
        if (v > 0) IO.Debug("User deleted"); // If chages were made
    }

    public static async Task PrintAll()
    {
        using var db = new StudentContext();
        var studentsList = await db.Students.ToListAsync(); // Get list of students

        // Print all found users
        foreach (var i in studentsList)
            IO.Print($"Name: {i.Name} Age: {i.Age}", ConsoleColor.Green);
    }

    // Finds Student by id and changes it to the newStudent
    public static async Task Update(int id, Student newSudent) {
        using var db = new StudentContext();

        var curUser = await FindById(id);
        // Apply the changes to the student
        curUser.Name = newSudent.Name;
        curUser.Age = newSudent.Age;

        // Apply the changes to the database
        db.Update(curUser);
        int v = await db.SaveChangesAsync();
        if (v > 0) IO.Debug("User updated");
    }
}

class Program
{
    static async Task Main()
    {
        // Create
        await SqlHelper.Create(new Student() { Name = "Elon", Age = 17 });
        await SqlHelper.Create(new Student() { Name = "Qrbon", Age = 25 });
        await SqlHelper.Create(new Student() { Name = "Mark", Age = 23 });
        await SqlHelper.Create(new Student() { Name = "Sayvali", Age = 15 });
        await SqlHelper.PrintAll();

        IO.Print("\n");

        await SqlHelper.DeleteById(1);
        await SqlHelper.Update(2, new Student() { Name = "MODIF", Age = 100 });
        await SqlHelper.PrintAll();
    }
}
