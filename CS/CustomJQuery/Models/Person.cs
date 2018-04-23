using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomJQuery.Models
{
    public class Person
    {
        // Fields...
        private bool _CheckAge;
        private DateTime _BirthDate;
        private string _CompanyName;
        private string _Name;
        private int _ID;
        [Required]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        [Required]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        [CustomAttribute(MinDate=20)]
        public DateTime BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }

        public bool CheckAge
        {
            get { return _CheckAge; }
            set { _CheckAge = value; }
        }
    }
}