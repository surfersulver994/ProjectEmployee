using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectDemo.Models;

namespace ProjectDemo.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            using (NEWTEMPDBEntities dbModel = new NEWTEMPDBEntities())
            {
                return View(dbModel.Customers.ToList());
            }
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id)
        {

            using (NEWTEMPDBEntities dbModel = new NEWTEMPDBEntities())
            {
                return View(dbModel.Customers.Where(x => x.ID == id).FirstOrDefault());
            }
            //return View();
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                using (NEWTEMPDBEntities dbModel = new NEWTEMPDBEntities())
                {
                    dbModel.Customers.Add(customer);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            using (NEWTEMPDBEntities dbModel = new NEWTEMPDBEntities())
            {
                return View(dbModel.Customers.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {

                using (NEWTEMPDBEntities dbModel = new NEWTEMPDBEntities())
                {

                    dbModel.Entry(customer).State = System.Data.EntityState.Modified;
                    dbModel.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Delete/5
 
        public ActionResult Delete(int id)
        {
            using (NEWTEMPDBEntities dbModel = new NEWTEMPDBEntities())
            {
                return View(dbModel.Customers.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (NEWTEMPDBEntities dbModel = new NEWTEMPDBEntities())   
                {
                    Customer customer = dbModel.Customers.Where(x => x.ID == id).FirstOrDefault();
                    dbModel.Customers.Remove(customer);
                    dbModel.SaveChanges();
                }
                    
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
