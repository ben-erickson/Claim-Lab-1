using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenEricksonLab1.Library
{
    internal class Assignment
    {
        public string AssignmentName { get; set; }
        public double? Grade { get; set; }

        // Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Assignment()
        {
            this.AssignmentName = string.Empty;
            this.Grade = null;
        }

        /// <summary>
        /// Constructor for assignment that exists, but has not yet been graded
        /// </summary>
        /// <param name="name"></param>
        public Assignment(string name)
        {
            this.AssignmentName = name;
            this.Grade = null;
        }

        /// <summary>
        /// Constructor for assignment that has a name and has been graded
        /// </summary>
        /// <param name="name"></param>
        /// <param name="grade"></param>
        public Assignment(string name, double grade)
        {
            this.AssignmentName = name;
            this.Grade = grade;
        }
    }
}
