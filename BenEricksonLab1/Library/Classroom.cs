using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenEricksonLab1.Library
{
    internal class Classroom
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        // Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Classroom()
        {
            this.Name = string.Empty;
            this.Students = new List<Student>();
        }

        /// <summary>
        /// Constructor for classroom that has been named, but does not have any students yet
        /// </summary>
        /// <param name="name"></param>
        public Classroom(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
        }

        /// <summary>
        /// Constructor for classroom that has both a name and students
        /// </summary>
        /// <param name="name"></param>
        /// <param name="students"></param>
        public Classroom(string name, List<Student> students)
        {
            this.Name = name;
            this.Students = students;
        }

        // Methods

        /// <summary>
        /// Get the average grade of all the students in this classroom
        /// </summary>
        /// <returns></returns>
        public double GetAverage()
        {
            // If the classroom does not have any students, return 0
            if (this.Students.Count == 0)
            {
                return 0;
            }

            double averageGrade = 0;

            foreach (Student currentStudent in this.Students)
            {
                averageGrade += currentStudent.GetAverageGrade();
            }

            averageGrade /= this.Students.Count;

            return averageGrade;
        }
    }
}
