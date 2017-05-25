using System.Web.Mvc;
using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.UnitOfWork;

namespace SchoolWebUI.Controllers
{
    public class CourseController : Controller
    {
        public CourseController(BlCourseRepository repo)
        {
            UnitOfWork = repo.UnitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; set; }
        

        public ActionResult Index()
        {
            return View(UnitOfWork.Courses.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(UnitOfWork.Courses.Get(id));
        }

        public ActionResult Create()
        {
            UnitOfWork.Courses.Add(new Course());
            var complete = UnitOfWork.Complete();
            return View(complete);
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                UnitOfWork.Courses.Add(course);
                UnitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(UnitOfWork.Courses.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var toRemove = UnitOfWork.Courses.Get(id);
            UnitOfWork.Courses.Remove(toRemove);
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}