using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenEricksonLab1
{
    internal class Program
    {

        static void Main(string[] args)
        {
             List<(string, double)> GradeBook = new List<(string, double)>();

            // Main Menu Loop
            string mainMenuInput = string.Empty;

            while (true)
            {
                // Reset the input variable to ensure that everything is fine between loops.
                mainMenuInput = string.Empty;

                // Display options to the user
                Console.WriteLine("\n\nWelcome to the Grade Manager. Options:");
                Console.WriteLine("1: View all grades.");
                Console.WriteLine("2: Add a grade.");
                Console.WriteLine("3: Get the class average.");
                Console.WriteLine("4: Get the top grade.");
                Console.WriteLine("5: Get the bottom grade.");
                Console.WriteLine("6: Remove a student from the class.");
                Console.WriteLine("7: Edit the grade of an existing student.");
                Console.WriteLine("Or type \"Q\" to exit the program.");

                mainMenuInput = Console.ReadLine();

                // Check if the user wanted to exit the app, and break the loop
                if (mainMenuInput == "Q" || mainMenuInput == "q")
                {
                    break;
                }

                // Make sure that the user's input is within the expected range for our options
                if (int.TryParse(mainMenuInput, out int parsedInput))
                {
                    if (parsedInput < 1 || parsedInput > 7)
                    {
                        Console.WriteLine("Your input did not correspond to any of the given options. Please try again.\n");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Your input did not correspond to any of the given options. Please try again.\n");
                    continue;
                }

                // Match the user's input to the corresponding option, and call that method
                if (mainMenuInput == "1")
                {
                    AllGrades(GradeBook);
                }
                else if (mainMenuInput == "2")
                {
                    AddGrade(GradeBook);
                }
                else if (mainMenuInput == "3")
                {
                    ClassAverage(GradeBook);
                }
                else if (mainMenuInput == "4")
                {
                    TopGrade(GradeBook);
                }
                else if (mainMenuInput == "5")
                {
                    BottomGrade(GradeBook);
                }
                else if (mainMenuInput == "6")
                {
                    RemoveStudent(GradeBook);
                }
                else if (mainMenuInput == "7")
                {
                    EditGrade(GradeBook);
                }
                else
                {
                    Console.WriteLine("Your input could not be recognized. Please try again.");
                    continue;
                }
            }
        }

        public static void AllGrades(List<(string, double)> GradeBook)
        {
            Console.WriteLine("List of students: ");

            for (int i = 0; i < GradeBook.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {GradeBook[i].Item1} has a grade of: {GradeBook[i].Item2}");
            }
        }

        public static void AddGrade(List<(string, double)> GradeBook)
        {
            Console.WriteLine("Enter the student's name: ");
            string studentName = Console.ReadLine();
            double studentGrade = 0;

            // Loop to make sure that input for grade is a valid double
            while (true)
            {
                Console.WriteLine("Please enter the student's grade: ");
                string rawGradeInput = Console.ReadLine();

                // Try to parse the input into a double, and place it into the studentGrade variable if it is
                if (!double.TryParse(rawGradeInput, out studentGrade))
                {
                    Console.WriteLine("Grade invalid. Please enter a valid grade.");
                }
                else
                {
                    // If input is a double, break out of the loop
                    break;
                }
            }

            GradeBook.Add((studentName, studentGrade));
            Console.WriteLine($"{studentName} has been added into the grade book with a grade of {studentGrade}");
        }

        public static void ClassAverage(List<(string, double)> GradeBook)
        {
            // If there are no entries in the GradeBook, don't calculate the average
            // Done to avoid dividing by 0
            if (GradeBook.Count == 0)
            {
                Console.WriteLine("Cannot compute average unless without entries in the gradebook.");
                return;
            }

            double gradeSum = 0;
            for (int i = 0; i < GradeBook.Count; i++)
            {
                gradeSum += GradeBook[i].Item2;
            }

            Console.WriteLine($"The class average is: {gradeSum / GradeBook.Count}");
        }

        public static void TopGrade(List<(string, double)> GradeBook)
        {
            double topGrade = 0;
            List<(string, double)> topStudents = new List<(string, double)>();

            // Iterate through the grade book and add the top students to a list.
            // If there is a tie, add both to the list of top students.
            for (int i = 0; i < GradeBook.Count; i++)
            {
                if (GradeBook[i].Item2 > topGrade)
                {
                    // We have a new top grade, so clear the list, and set the new top grade
                    topStudents.Clear();
                    topStudents.Add(GradeBook[i]);
                    topGrade = GradeBook[i].Item2;
                }
                else if (GradeBook[i].Item2 == topGrade)
                {
                    // There is a tie, so add the student to the list, and keep the same top grade
                    topStudents.Add(GradeBook[i]);
                }
            }

            // Loop through the top students and display them to the user
            for (int i = 0; i < topStudents.Count; i++)
            {
                Console.WriteLine($"{topStudents[i].Item1} has a grade of {topStudents[i].Item2}");
            }
        }

        public static void BottomGrade(List<(string, double)> GradeBook)
        {
            // Double is set to the max value to ensure that the lowest grade cannot be lower than the initial value
            double bottomGrade = double.MaxValue;
            List<(string, double)> bottomStudents = new List<(string, double)>();

            // Iterate through the grade book and add the bottom students to a list.
            // If there is a tie, add both to the list of bottom students.
            for (int i = 0; i < GradeBook.Count; i++)
            {
                if (GradeBook[i].Item2 < bottomGrade)
                {
                    // We have a new bottom grade, so clear the list, and set the new bottom grade
                    bottomStudents.Clear();
                    bottomStudents.Add(GradeBook[i]);
                    bottomGrade = GradeBook[i].Item2;
                }
                else if (GradeBook[i].Item2 == bottomGrade)
                {
                    // There is a tie, so add the student to the list, and keep the same bottom grade
                    bottomStudents.Add(GradeBook[i]);
                }
            }

            // Loop through the bottom students and display them to the user
            for (int i = 0; i < bottomStudents.Count; i++)
            {
                Console.WriteLine($"{bottomStudents[i].Item1} has a grade of {bottomStudents[i].Item2}");
            }
        }

        public static void RemoveStudent(List<(string, double)> GradeBook)
        {
            Console.WriteLine("Please enter the student's name you would like removed.");
            string targetedStudent = Console.ReadLine();
            int? studentIndex = null;

            for (int i = 0; i < GradeBook.Count; i++)
            {
                if (GradeBook[i].Item1 == targetedStudent)
                {
                    studentIndex = i;
                    break;
                }
            }

            if (studentIndex == null)
            {
                Console.WriteLine("The student specified could not be found.");
            }
            else
            {
                GradeBook.RemoveAt((int)studentIndex);
                Console.WriteLine($"{targetedStudent} was removed from the gradebook.");
            }
        }

        public static void EditGrade(List<(string, double)> GradeBook)
        {
            Console.WriteLine("Please enter the name of the student you would like to edit.");
            string targetedStudent = Console.ReadLine();
            int? studentIndex = null;

            for (int i = 0; i < GradeBook.Count; i++)
            {
                if (GradeBook[i].Item1 == targetedStudent)
                {
                    studentIndex = i;
                    break;
                }
            }

            if (studentIndex == null)
            {
                Console.WriteLine("Your student could not be found.");
            }
            else
            {
                double updatedGrade = 0;
                while (true)
                {
                    Console.WriteLine($"What is {targetedStudent}'s new grade?");
                    string rawGradeInput = Console.ReadLine();

                    if (!double.TryParse(rawGradeInput, out updatedGrade))
                    {
                        Console.WriteLine("Your input was an invalid grade. Please try again.");
                    }
                    else
                    {
                        break;
                    }
                }

                GradeBook[(int)studentIndex] = (targetedStudent, updatedGrade);
                Console.WriteLine($"{targetedStudent}'s grade is now {updatedGrade}.");
            }
        }
    }
}
