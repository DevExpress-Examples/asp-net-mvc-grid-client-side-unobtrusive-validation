using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E4924.Models
{
    public class Person
    {
        [Required]
        public int ID { set; get; }
        [Required]
        public string Name { set; get; }
        public string CompanyName { set; get; }
        [Custom(MinAge = 18)]
        public DateTime BirthDate { set; get; }
        public bool CheckAge { set; get; }
    }
}