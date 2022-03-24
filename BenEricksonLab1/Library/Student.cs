using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenEricksonLab1.Library
{
    internal class Student
    {
        public string Name { get; set; }
        public List<Assignment> Assignments { get; set; }

        // Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Student()
        {
            this.Name = string.Empty;
            this.Assignments = new List<Assignment>();
        }

        /// <summary>
        /// Constructor for student who has a name but has no assignments yet
        /// </summary>
        /// <param name="name"></param>
        public Student(string name)
        {
            this.Name = name;
            this.Assignments = new List<Assignment>();
        }

        /// <summary>
        /// Constructor for student who has both a name and assignments
        /// </summary>
        /// <param name="name"></param>
        /// <param name="assignments"></param>
        public Student (string name, List<Assignment> assignments)
        {
            this.Name = name;
            this.Assignments = assignments;
        }

        // Methods

        public double GetAverageGrade()
        {
            // If the student does not have any assignments, return 0
            if (this.Assignments.Count == 0)
            {
                return 0;
            }

            double averageGrade = 0;
            int gradedAssignments = 0;

            foreach (Assignment currentAssignment in this.Assignments)
            {
                if (currentAssignment.Grade != null)
                {
                    averageGrade += currentAssignment.Grade ?? 0;
                }
                gradedAssignments++;
            }

            averageGrade /= gradedAssignments;

            return averageGrade;
        }
    }
}
