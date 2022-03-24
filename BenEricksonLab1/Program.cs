using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenEricksonLab1.Library;

namespace BenEricksonLab1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Initialize classroom list
            List<Classroom> classrooms = new List<Classroom>();

            // Main Menu
            while (true)
            {
                Console.WriteLine("Main Menu Options:");
                Console.WriteLine("\t1: List classrooms");
                Console.WriteLine("\t2: Add classroom");
                Console.WriteLine("\t3: Remove classrooms");
                Console.WriteLine("\t4: Show a classroom's details");
                Console.WriteLine("\nType 'Q' to Quit.");

                string mainMenuInput = Console.ReadLine();
                // Initialize variable to a number that doesn't correspond to an option
                int mainMenuOption = 10;

                // Check to see if we should continue to the options
                if (mainMenuInput == "Q" || mainMenuInput == "q")
                {
                    break;
                }
                else if (!int.TryParse(mainMenuInput, out mainMenuOption))
                {
                    Console.WriteLine("Invalid input. Please try again.\n\n");
                    continue;
                }

                // Check input against options
                switch (mainMenuOption) 
                {
                    case 1:
                        // List classrooms

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        // If there are no classrooms, don't continue
                        if (classrooms.Count == 0)
                        {
                            Console.WriteLine("There are no classrooms to list.");
                        }

                        for (int i = 0; i < classrooms.Count; i++)
                        {
                            Console.WriteLine($"Classroom #{i + 1}: {classrooms[i].Name}");
                        }

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 2:
                        // Add a classroom

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine("Please enter the new classroom's name.");
                        string newClassroomName = Console.ReadLine();

                        Classroom newClassroom = new Classroom(newClassroomName);
                        classrooms.Add(newClassroom);

                        Console.WriteLine($"{newClassroomName} has been added.");

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 3:
                        // Remove a classroom

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine("Please enter the name of the classroom you want to remove.");
                        string targetedClassroom = Console.ReadLine();

                        for (int i = 0; i <= classrooms.Count; i++)
                        {
                            // If i equals the count of classroom, then the targeted classroom is not present in our list
                            if (i == classrooms.Count)
                            {
                                Console.WriteLine("Targeted classroom does not exist.");
                                break;
                            }

                            if (classrooms[i].Name == targetedClassroom)
                            {
                                classrooms.RemoveAt(i);
                                Console.WriteLine($"Classroom {targetedClassroom} has been removed.");
                                break;
                            }
                        }

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 4:
                        // Show a classroom's details

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine("Please enter the name of the classroom you would like to view in more detail.");
                        string selectedClassroom = Console.ReadLine();

                        for (int i = 0; i <= classrooms.Count; i++)
                        {
                            // If i equals the count of classroom, then the targeted classroom is not present in our list
                            if (i == classrooms.Count)
                            {
                                Console.WriteLine("Selected classroom does not exist.");
                                break;
                            }

                            if (classrooms[i].Name == selectedClassroom)
                            {
                                ClassroomMenu(classrooms[i]);
                                break;
                            }
                        }


                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    default:
                        Console.WriteLine("Please select one of the options.\n\n");
                        break;
                }
            }
        }    

        public static void ClassroomMenu(Classroom chosenClassroom)
        {
            while (true)
            {
                // Classroom Menu
                Console.WriteLine("Classroom Menu Options:");
                Console.WriteLine("\t1: View all students");
                Console.WriteLine("\t2: Add a student");
                Console.WriteLine("\t3: Remove a student");
                Console.WriteLine("\t4: Compare two students");
                Console.WriteLine("\t5: Show the average grade");
                Console.WriteLine("\t6: Show student with best average grade");
                Console.WriteLine("\t7: Show student with worst average grade");
                Console.WriteLine("\t8: View the details of one student");
                Console.WriteLine("\nType 'Q' to return to Main Menu");

                string classroomMenuInput = Console.ReadLine();
                // Initialize variable to a number that doesn't correspond to an option
                int classroomMenuOption = 10;

                if (classroomMenuInput == "Q" || classroomMenuInput == "q")
                {
                    // Add whitespace to console
                    Console.WriteLine("\n\n");

                    break;
                }
                else if (!int.TryParse(classroomMenuInput, out classroomMenuOption))
                {
                    Console.WriteLine("Invalid input. PLease try again.\n\n");
                    continue;
                }

                // Check for each menu option
                switch (classroomMenuOption) 
                {
                    case 1:
                        // View all students

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        // If there are no students, let the user know
                        if (chosenClassroom.Students.Count == 0)
                        {
                            Console.WriteLine("There are no students to list.");
                        }

                        for (int i = 0; i < chosenClassroom.Students.Count; i++)
                        {
                            Console.WriteLine($"{chosenClassroom.Students[i].Name} has an average grade of {chosenClassroom.Students[i].GetAverageGrade()}");
                        }

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 2:
                        // Add a student

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine("Please enter the name of the student that you would like to add.");
                        string studentName = Console.ReadLine();

                        chosenClassroom.Students.Add(new Student(studentName));

                        Console.WriteLine($"{studentName} has been added to the current classroom.");

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 3:
                        // Remove a student

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine("Please enter the name of the student that you would like to remove.");
                        string targetedStudent = Console.ReadLine();

                        for (int i = 0; i <= chosenClassroom.Students.Count; i++)
                        {
                            if (i == chosenClassroom.Students.Count)
                            {
                                Console.WriteLine("Student could not be found.");
                                break;
                            }

                            if (chosenClassroom.Students[i].Name == targetedStudent)
                            {
                                chosenClassroom.Students.RemoveAt(i);

                                Console.WriteLine($"{targetedStudent} has been removed from this classroom.");
                                break;
                            }
                        }

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 4:
                        // Compare two students

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine("Please enter the name of the first student.");
                        string firstStudentName = Console.ReadLine();

                        Console.WriteLine("Please enter the name of the second student.");
                        string secondStudentName = Console.ReadLine();

                        int? firstStudentIndex = null;
                        int? secondStudentIndex = null;

                        for (int i = 0; i <= chosenClassroom.Students.Count; i++)
                        {
                            if (i == chosenClassroom.Students.Count)
                            {
                                Console.WriteLine("Your students could not be identified.");
                                break;
                            }

                            if (chosenClassroom.Students[i].Name == firstStudentName)
                            {
                                firstStudentIndex = i;
                            }

                            if (chosenClassroom.Students[i].Name == secondStudentName)
                            {
                                secondStudentIndex = i;
                            }
                        }

                        if (firstStudentIndex != null && secondStudentIndex != null)
                        {
                            Console.WriteLine($"{firstStudentName} has an average grade of {chosenClassroom.Students[firstStudentIndex ?? 0].GetAverageGrade()}.");
                            Console.WriteLine($"{secondStudentName} has an average grade of {chosenClassroom.Students[secondStudentIndex ?? 0].GetAverageGrade()}.");
                        }

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 5:
                        // Show the average grade

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine($"The average grade of this classroom is {chosenClassroom.GetAverage()}");

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 6:
                        // Show the student with the best average grade

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        int bestStudentIndex = 0;
                        double bestAverageGrade = 0;

                        for (int i = 0; i < chosenClassroom.Students.Count; i++)
                        {
                            if (chosenClassroom.Students[i].GetAverageGrade() > bestAverageGrade)
                            {
                                bestAverageGrade = chosenClassroom.Students[i].GetAverageGrade();
                                bestStudentIndex = i;
                            }
                        }

                        Console.WriteLine($"The student with the best average grade is {chosenClassroom.Students[bestStudentIndex].Name} with a grade of {bestAverageGrade}");

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 7:
                        // Show the student with the worst average grade

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        int worstStudentIndex = 0;
                        double worstAverageGrade = 0;

                        for (int i = 0; i < chosenClassroom.Students.Count; i++)
                        {
                            if (chosenClassroom.Students[i].GetAverageGrade() < worstAverageGrade)
                            {
                                worstAverageGrade = chosenClassroom.Students[i].GetAverageGrade();
                                worstStudentIndex = i;
                            }
                        }

                        Console.WriteLine($"The student with the best average grade is {chosenClassroom.Students[worstStudentIndex].Name} with a grade of {worstAverageGrade}");

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 8:
                        // View the details of one student

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine("Please enter the name of the student you would like to view.");
                        string chosenStudent = Console.ReadLine();

                        for (int i = 0; i <= chosenClassroom.Students.Count; i++)
                        {
                            if (i == chosenClassroom.Students.Count)
                            {
                                Console.WriteLine("Your student could not be found.");
                                break;
                            }

                            if (chosenClassroom.Students[i].Name == chosenStudent)
                            {
                                StudentMenu(chosenClassroom.Students[i]);
                            }
                        }

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                }
            }
        }

        public static void StudentMenu(Student chosenStudent)
        {
            while (true)
            {
                // Student Menu
                Console.WriteLine("Student Menu Options:");
                Console.WriteLine("\t1: Show summary of the student");
                Console.WriteLine("\t2: Assign assignment to the student");
                Console.WriteLine("\t3: Unassign assignment from the student");
                Console.WriteLine("\t4: Show the student's assignments");
                Console.WriteLine("\t5: Grade one of the student's assignments");
                Console.WriteLine("\t6: Show the student's assignment with the best grade");
                Console.WriteLine("\t7: Show the student's assignment with the worst grade");
                Console.WriteLine("\nType 'Q' to return to the Classroom Menu");

                string studentMenuInput = Console.ReadLine();
                int studentMenuOption = 10;

                if (studentMenuInput == "Q" || studentMenuInput == "q")
                {
                    break;
                }
                else if (!int.TryParse(studentMenuInput, out studentMenuOption))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

                // Student menu options
                switch (studentMenuOption) 
                {
                    case 1:
                        // Show summary of the student

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine($"The student's name is {chosenStudent.Name}, and their average grade is {chosenStudent.GetAverageGrade()}.");

                        // List student's assignments
                        for (int i = 0; i < chosenStudent.Assignments.Count; i++)
                        {
                            Console.WriteLine($"This assignment's name is {chosenStudent.Assignments[i].AssignmentName}, and the grade is {chosenStudent.Assignments[i].Grade ?? 0}.");
                        }

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 2:
                        // Assign assignment to the student

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine("What is the name of the assignment you would like to assign?");
                        string assignmentName = Console.ReadLine();

                        chosenStudent.Assignments.Add(new Assignment(assignmentName));

                        Console.WriteLine($"{assignmentName} has been assigned to {chosenStudent.Name}");

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 3:
                        // Unnasign assignment from the studnet

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine("What is the name of the assignment you would like to unnasign?");
                        string unnasigningAssignment = Console.ReadLine();

                        for (int i = 0; i <= chosenStudent.Assignments.Count; i++)
                        {
                            if (i == chosenStudent.Assignments.Count)
                            {
                                Console.WriteLine("Targeted assignment could not be found.");
                                break;
                            }

                            if (chosenStudent.Assignments[i].AssignmentName == unnasigningAssignment)
                            {
                                chosenStudent.Assignments.RemoveAt(i);

                                Console.WriteLine($"{unnasigningAssignment} has been unassigned.");
                                break;
                            }
                        }

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 4:
                        // Show the student's assignments

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        for (int i = 0; i < chosenStudent.Assignments.Count; i++)
                        {
                            Console.WriteLine($"This assignment's name is {chosenStudent.Assignments[i].AssignmentName}, and the grade is {chosenStudent.Assignments[i].Grade ?? 0}.");
                        }

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 5:
                        // Grade one of the student's assignments

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        Console.WriteLine("What is the assignment you would like to grade?");
                        string gradingAssignment = Console.ReadLine();
                        int? assignmentIndex = null;

                        for (int i = 0; i <= chosenStudent.Assignments.Count; i++)
                        {
                            if (i == chosenStudent.Assignments.Count)
                            {
                                Console.WriteLine("Your assignment could not be found.");
                                break;
                            }

                            if (chosenStudent.Assignments[i].AssignmentName == gradingAssignment)
                            {
                                assignmentIndex = i;
                                break;
                            }
                        }

                        if (assignmentIndex != null)
                        {
                            while (true)
                            {
                                Console.WriteLine("Please enter the grade for this assignment.");
                                string inputGrade = Console.ReadLine();
                                double gradeActual = 0;

                                if (!double.TryParse(inputGrade, out gradeActual))
                                {
                                    Console.WriteLine("Input not a valid grade.");
                                }
                                else
                                {
                                    chosenStudent.Assignments[assignmentIndex ?? 0].Grade = gradeActual;
                                    break;
                                }
                            }
                        }

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 6:
                        // Show assignment with the best grade

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        double highestGrade = 0;
                        int highestGradeIndex = 0;

                        for (int i = 0; i < chosenStudent.Assignments.Count; i++)
                        {
                            if (chosenStudent.Assignments[i].Grade > highestGrade)
                            {
                                highestGrade = chosenStudent.Assignments[i].Grade ?? 0;
                                highestGradeIndex = i;
                            }
                        }

                        Console.WriteLine($"The assignment with the highest grade is {chosenStudent.Assignments[highestGradeIndex].AssignmentName} with a grade of {highestGrade}.");

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    case 7:
                        // Show assignment with the worst grade

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        double lowestGrade = double.MaxValue;
                        int lowestGradeIndex = 0;

                        for (int i = 0; i < chosenStudent.Assignments.Count; i++)
                        {
                            if (chosenStudent.Assignments[i].Grade < lowestGrade && chosenStudent.Assignments[i].Grade != null)
                            {
                                lowestGrade = chosenStudent.Assignments[i].Grade ?? 0;
                                lowestGradeIndex = i;
                            }
                        }

                        Console.WriteLine($"The assignment with the lowest grade is {chosenStudent.Assignments[lowestGradeIndex].AssignmentName} with a grade of {lowestGrade}.");

                        // Add whitespace to console
                        Console.WriteLine("\n\n");

                        break;
                    default:
                        Console.WriteLine("Please choose one of the options.");
                        break;
                }
            }
        }
    }
}
