using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E4924.Models
{
    public class CustomAttribute : ValidationAttribute, IClientValidatable
    {
        public int MinAge { set; get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Person p = validationContext.ObjectInstance as Person;
            if (p == null)
                return new ValidationResult("Internal  error");
            if (!p.CheckAge)
                return ValidationResult.Success;
            TimeSpan ts = DateTime.Now - p.BirthDate;
            if (ts.TotalDays / 365 < MinAge)
                return new ValidationResult("Age must be more than " + MinAge.ToString());
            else
                return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRangeDateRule("Age must be more than " + MinAge.ToString(), MinAge);
        }

        public class ModelClientValidationRangeDateRule : ModelClientValidationRule
        {
            public ModelClientValidationRangeDateRule(string errorMessage, int minAge)
            {
                ErrorMessage = errorMessage;
                ValidationType = "rangedate";
                ValidationParameters["minage"] = minAge;
            }
        }
    }
}