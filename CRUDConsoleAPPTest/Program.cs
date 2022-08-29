using CRUDConsoleAPPTest;

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

var StudentContext = new StudentDBContext();

Main();

void Main()
{
    Console.WriteLine("\n.........STUDENT MANAGEMENT CONSOLE...................\n");

    Console.WriteLine(" 0: To Exit\t\n 1: To GetAll Student\t\n 2: To Create Student\t\n 3: Update Student By ID\t\n 4: Delete Student By ID");

    Console.WriteLine("\nInput Command");
    var userInput = Console.ReadLine();

    switch (userInput)
    {
        case "0":
            Console.WriteLine("Exiting App......");
            break;
        case "1":
            GetStudent(StudentContext);
            break;
        case "2":
            CreateStudent(StudentContext);
            break;
        case "3":
            Console.Write(" Input ID: ");
            UpdateStudent(StudentContext, Console.ReadLine());
            break;
        case "4":
            Console.Write(" Input ID: ");
            DeleteStudent(StudentContext, Console.ReadLine());
            break;
        default:
            Console.Clear();
            Console.WriteLine("Wrong Input");
            Main();
            break;
    }
}

//UpdateStudent(StudentContext, int.Parse(Console.ReadLine()));
//DeleteStudent(StudentContext, int.Parse(Console.ReadLine()));
//GetStudent(StudentContext);
//CreateStudent(StudentContext);

void GetStudent(StudentDBContext? db)
{
    Console.Clear();
    var student = db.Student;

    if (!student.Any())
    {
        Console.WriteLine("NoStudentFound");
    }
    else
    {
        foreach (var ward in db.Student)
        {
            Console.WriteLine(ward.ToString());
        }
    }

    Main();
}

void CreateStudent(StudentDBContext? db)
{
    var student = db.Student;

    Student? ward = new()
    {
        FirstName = CustomInput("First Name: "),
        LastName = CustomInput("Last Name: "),
        Age = int.Parse(CustomInput("Age: ")),
        Status = CustomInput("Status: ")
    };
    student.Add(ward);

    db.SaveChanges();

    Main();
}

void UpdateStudent(StudentDBContext? db, string? id)
{
    var StudentId = int.TryParse(id, out var result);


    if (StudentId)
    {
        var studentWard = db.Student;

        var ward = studentWard.Find(result);

        if (ward == null)
        {
            Console.Clear();
            Console.WriteLine("The Student Matching This ID Does Not Exist");
            Main();
        }

        ward.FirstName = CustomInput("First Name: ");
        ward.LastName = CustomInput("Last Name: ");
        ward.Age = int.Parse(CustomInput("Age: "));
        ward.Status = CustomInput("Status: ");

        db.Update(ward);

        db.SaveChanges();
        Main();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Not A Number/ID");
        Main();
    }

}

void DeleteStudent(StudentDBContext db, string? id)
{
    var StudentId = int.TryParse(id, out var result);

    if (StudentId)
    {
        var ward = db.Student;

        var studentWard = ward.Find(result);

        if (studentWard == null)
        {
            Console.Clear();
            Console.WriteLine("The Student Matching This ID Does Not Exist");
            Main();
        }
        Console.Clear();
        db.Remove(studentWard);
        db.SaveChanges();
        Main();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Not A Number/ID");
        Main();
    }
}



string CustomInput(string? input)
{
    Console.Write(input);
    return Console.ReadLine();
}
