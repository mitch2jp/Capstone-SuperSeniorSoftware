using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Lab3
{
    //Jake Mitchell
    //Section 0002
    //10/14/2020
    public class Teacher
    {
        //data fields
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string lunchTicket;
        private string tShirtSize;
        private string tShirtColor;
        private string tShirtDescription;
        private int schoolID;


        //static data fields
        private static Teacher[] teacherArray = new Teacher[100];
        private static int pos = 0;


        //constructor(s)
        public Teacher(string firstName, string lastName, string emailAddress, string lunchTicket, string tShirtSize, string tShirtColor, string tShirtDescription, int schoolID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.lunchTicket = lunchTicket;
            this.tShirtSize = tShirtSize;
            this.tShirtColor = tShirtColor;
            this.tShirtDescription = tShirtDescription;


            teacherArray[pos++] = this;


        }

        

        //properties
        public string FirstName
        {
            get { return this.firstName;}
            set { this.firstName = value; }

        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }

        }

        public string EmailAddress
        {
            get { return this.emailAddress; }
            set { this.emailAddress = value; }

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

        public int SchoolID
        {
            get { return this.schoolID; }
            set { this.schoolID = value; }

        }
    }


    

}