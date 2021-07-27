using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace KilimoHigh.Controllers
{
    public class HomeController : Controller
    {
        StudentRegisterEntities db = new StudentRegisterEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentRegister()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult EditStudent(int Id )
        {
            var data = db.Students.Find(Id);
            return PartialView(data);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SaveEditStudentRegister(Student data)
        {
            var test = db.Students.Find(data.Id);
            test.SecondName = data.SecondName;
            test.Fname = data.Fname;
            test.SirName = data.SirName;
            test.GurdianPhone = data.GurdianPhone;
            test.StreamId = data.StreamId;
            db.SaveChanges();
            return PartialView("StudentRegister");

        }

        public ActionResult SearchByStream()
        {
            return PartialView();
        }

        public ActionResult SingleStreamData()
        {
            return PartialView();
        }
        public ActionResult SingleStudentData()
        {
           // var datas = db.Students.Where(e=>e.Id == data.Id).ToList();
            return PartialView();
        }
        public ActionResult ShowStreamDataView(ClassStream data)
        {
            var datas = db.ClassStreams.Where(e => e.Id == data.Id).ToList();
            return PartialView("~/Views/Home/ClassStreamsData2.cshtml", datas);

        }
        public ActionResult ShowStudentDataView(Student data)
        {
            var datas = db.Students.Where(e => e.Id == data.Id).ToList();
            return PartialView("~/Views/Home/ClassStudentData2.cshtml", datas);
        }

        public ActionResult ShowSpecificStreamDataView(Student data)
        {
            var datas = db.Students.Where(e => e.StreamId == data.StreamId).ToList();
            return PartialView("~/Views/Home/ClassStudentData2.cshtml", datas);

        }
        public ActionResult DeleteStudent(int Id)
        {
            var data = db.Students.Find(Id);
            db.Students.Remove(data);
            db.SaveChanges();
            return PartialView("StudentRegister");
        }


        public ActionResult SaveClassStream(ClassStream data)
        {
            data.DateAdded = DateTime.Now;
            db.ClassStreams.Add(data);
            db.SaveChanges();
            return PartialView("Index");
        }
        public ActionResult SaveStudentRegister(Student data)
        {
            data.DateAdded = DateTime.Now;
            db.Students.Add(data);
            db.SaveChanges();
            return PartialView("StudentRegister");
        }



    }
}