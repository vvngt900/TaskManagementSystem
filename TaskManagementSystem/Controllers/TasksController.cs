using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.Data.Entities;
using TaskManagementSystem.Data;
using Task = TaskManagementSystem.Data.Entities.Task;
using TaskManagementSystem.ViewModels;
using TaskManagementSystem.Helpers;


namespace TaskManagementSystem.Controllers
{
    public class TasksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Task
        public async Task<ActionResult> Index()
        {
            return View(await db.Tasks.ToListAsync());
        }

        // GET: Task/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            // Assuming you have a logged-in user and can access their department.
            //var user = GetLoggedInUser(); // Implement a method to get the logged-in user.

            //var departmentId = user.DepartmentId; // Assuming you have a DepartmentId property in your user model.

            var departments = db.Departments.ToList();
            var teamMembers = db.Users.Where(u => u.DepartmentID == 2).ToList();
            var viewModel = new TaskCreateViewModel
            {
                Departments = new SelectList(departments, "DepartmentId", "Name"),
                TeamMembers = new MultiSelectList(teamMembers, "UserId", "Username")
            };

            return View(viewModel);
        }


        // POST: Task/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TaskID,Title,DeadlineDate,Attachment")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(task);
        }


        //Revised
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string folderPath = Server.MapPath("~/Attachments");
                string attachmentPath = FileUploadHelper.SaveFile(model.AttachmentFile, folderPath);

                var task = new Task
                {
                    Title = model.TaskTitle,
                    DeadlineDate = model.DeadlineDate,
                    Attachment = attachmentPath, // Save the attachment path
                    Department = db.Departments.Find(model.DepartmentId), // Set the Department
                };

                foreach (var userId in model.SelectedTeamMembers)
                {
                    var user = db.Users.Find(userId);
                    if (user != null)
                    {
                        task.AssignedUsers.Add(user);
                    }
                }

                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index"); // Redirect to a success page.
            }

            var departments = db.Departments.ToList();
            var teamMembers = db.Users.Where(u => u.DepartmentID == model.DepartmentId).ToList();
            model.Departments = new SelectList(departments, "DepartmentId", "Name");
            model.TeamMembers = new MultiSelectList(teamMembers, "UserID", "Username");
            return View(model); // Return to the form with error messages.
        }




        // GET: Task/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Task/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TaskID,Title,DeadlineDate,Attachment")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Task/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Task task = await db.Tasks.FindAsync(id);
            db.Tasks.Remove(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
