﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDiary
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }

    }



    public class Student
    {
        //internal readonly string FirstName;


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comments { get; set; }


        public string Math { get; set; }
        public string Technology { get; set; }
        public string Physics { get; set; }
        public string PolishLang { get; set; }
        public string ForeignLang { get; set; }
        public string AddActive { get; set; }

        public string ClassStudent { get; set; }
        public Address Address { get; set; }


    }
   

 
}
