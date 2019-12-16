using E4924.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E4924.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private IList<Person> Persons
        {
            get
            {
                if (HttpContext.Session["list"] == null)
                {
                    List<Person> persons = new List<Person>();

                    for (int i = 0; i < 20; i++)
                        persons.Add(new Person()
                        {
                            ID = i,
                            Name = string.Format("PersonName {0}", i),
                            CheckAge = i % 2 == 0,
                            CompanyName = "Company" + i,
                            BirthDate = new DateTime(1990, 6, 1)
                        });

                    HttpContext.Session["list"] = persons;
                }

                return (IList<Person>)HttpContext.Session["list"];
            }
            set
            {
                HttpContext.Session["list"] = value;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = Persons;
            return PartialView("_GridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(Person item)
        {
            var model = Persons;
            if (ModelState.IsValid)
            {
                try
                {
                    Persons.Add(item);
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(Person item)
        {
            var model = Persons;
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    Person p = model.Where(x => x.ID == item.ID).First();
                    p.Name = item.Name;
                    p.CompanyName = item.CompanyName;
                    p.BirthDate = item.BirthDate;
                    p.CheckAge = item.CheckAge;

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(int ID)
        {
            var model = Persons;
            try
            {
                // Insert here a code to delete the item from your model
                Persons.Remove(Persons.First(x => x.ID == ID));
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }

            return PartialView("_GridViewPartial", model);
        }
    }
}