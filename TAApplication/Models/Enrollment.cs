/**
 * Author:    Cole Hanlon
 * Partner:   Tyler Harkness
 * Date:      12/8/2022
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
 *
 * I, Cole Hanlon & Tyler harkness, certify that I have made modifications to this code based on course
 * guidance. The base code has been provided through tutorials from Microsoft Corporation. 
 *
 * File Contents
 *
 *      Defines a model to hold enrollment data
*/

namespace TAApplication.Models
{
    /// <summary>
    /// Class to represent an Enrollment database row
    /// </summary>
    public class Enrollment
    {
        public int ID { get; set; }
        public Course course { get; set; }
        public DateTime enrolledTime { get; set; }
        public int enrollment { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Enrollment()
        {

        }

        /// <summary>
        /// Constructor used when seeding database
        /// </summary>
        /// <param name="C"></param>
        /// <param name="t"></param>
        /// <param name="e"></param>
        public Enrollment(Course C, DateTime t, int e)
        {
            course = C; enrolledTime = t; enrollment = e; 
        }
    }
}
