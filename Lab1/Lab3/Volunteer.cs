using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Security.Cryptography;

namespace Lab3
{
    //Jake Mitchell
    //Section 0002
    //10/14/2020
    public class Volunteer
    {

        //data fields
        private int volunteerID;
        private string firstName;
        private string lastName;
        private string tShirtSize;
        private string tShirtColor;
        private string tShirtDescription;


        //static data fields
        private static int nextID = 5;
        private static Volunteer[] volunteerArray = new Volunteer[100];
        private static int pos = 0;




        //constructor(s)
        public Volunteer(string firstName, string lastName, string tShirtSize, string tShirtColor, string tShirtDescription)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.tShirtSize = tShirtSize;
            this.tShirtColor = tShirtColor;
            this.tShirtDescription = tShirtDescription;

            this.volunteerID = nextID;
            nextID++;

            volunteerArray[pos++] = this;



        }

        //properties
        public int VolunteerID
        {
            get { return this.volunteerID; }
            set { this.volunteerID = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }

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


    }
}