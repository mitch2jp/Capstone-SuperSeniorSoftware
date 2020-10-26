using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Lab3
{

    //Jake Mitchell
    //Section 0002
    //10/14/2020
    public class Student
    {
        //data fields
        private string firstName;
        private string lastName;
        private string age;
        private string notes;
        private string lunchTicket;
        private string tShirtSize;
        private string tShirtColor;
        private string tShirtDescription;
        private string schoolID;
        private string teacherID;

        //static data fields
        public static Boolean studentExists;
        public static int currentStudent = 4;
        public static Student[] studentArray = new Student[100];
        public static int totalStudents = 4;

        

        //constructor(s)
        public Student(string firstName, string lastName, string age, string notes, string lunchTicket, string tShirtSize, string tShirtColor, string tShirtDescription, string schoolID, string teacherID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.notes = notes;
            this.lunchTicket = lunchTicket;
            this.tShirtSize = tShirtSize;
            this.tShirtColor = tShirtColor;
            this.tShirtDescription = tShirtDescription;
            this.schoolID = schoolID;
            this.teacherID = teacherID;

            

            studentArray[totalStudents] = this;
            totalStudents++;

          

        }

        
        //properties
        public string FirstName
        {
            get {return this.firstName;}

            set{ this.firstName = value;}
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }

        public string LunchTicket
        {
            get { return this.lunchTicket; }
            set { this.lunchTicket = value; }
        }

        public string TShirtSize
        {
            get { return this.tShirtSize; }
            set { this.tShirtSize = value; }

        }

        public string TShirtColor
        {
            get { return this.tShirtColor; }
            set { this.tShirtColor = value; }

        }

        public string TShirtDescription
        {

            get { return this.tShirtDescription; }
            set { this.tShirtDescription = value; }
        }

        public string SchoolID
        {
            get { return this.schoolID; }
            set { this.schoolID = value; }


        }

        public string TeacherID
        {
            get { return this.teacherID; }
            set { this.teacherID = value; }


        }

        
        

    }
}