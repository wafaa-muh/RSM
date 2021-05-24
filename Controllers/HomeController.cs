using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Recruitment_System_Management1.Models;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            return View(db.Categories.ToList());
        }

        public ActionResult Details(int JobId)
        {
            var job = db.Jobs.Find(JobId);

            if (job == null)
            {
                return HttpNotFound();
            }
            Session["JobId"] = JobId;
            return View(job);
        }

        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(string Message)
        {
            var UserId = User.Identity.GetUserId();
            var JobId = (int)Session["JobId"];

            var check = db.ApplyForJobs.Where(a => a.JobId == JobId && a.UserId == UserId).ToList();

            if (check.Count < 1)
            {
                var job = new ApplyForJob();

                job.UserId = UserId;
                job.JobId = JobId;
                job.Message = Message;
                job.ApplyDate = DateTime.Now;

                db.ApplyForJobs.Add(job);
                db.SaveChanges();
                ViewBag.Result = "Added Successfully!";
            }
            else
            {
                ViewBag.Result = "You Have Applied For This Job!";
            }
            




            return View();
        }


        [Authorize]
        public ActionResult GetJobsByUser()
        {
            var UserId = User.Identity.GetUserId();
            var Jobs = db.ApplyForJobs.Where(a => a.UserId == UserId);
            return View(Jobs.ToList());
        }

        public ActionResult DetailsOfJob(int id)
        {
            var job = db.ApplyForJobs.Find(id);

            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }


        public ActionResult GetJobsByPublisher()
        {
            var UserID = User.Identity.GetUserId();

            var Jobs = from app in db.ApplyForJobs
                       join job in db.Jobs
                       on app.JobId equals job.Id
                       where job.User.Id == UserID
                       select app;

            return View(Jobs.ToList());
        }


        public ActionResult Edit(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [HttpPost]
        public ActionResult Edit(ApplyForJob job)
        {
            if (ModelState.IsValid)
            {
                job.ApplyDate = DateTime.Now;
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetJobsByUser");
            }
            return View(job);
        }



        public ActionResult Delete(int id)
        {
            var job = db.ApplyForJobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(ApplyForJob job
            )
        {

            // TODO: Add delete logic here
            var myJob = db.ApplyForJobs.Find(job.Id);
            db.ApplyForJobs.Remove(myJob);
            db.SaveChanges();
            return RedirectToAction("GetJobsByUser");

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}