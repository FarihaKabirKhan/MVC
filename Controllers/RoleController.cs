using Evidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evidence.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetRoles()
        {
            var db = new StudentInfoEntities2();
            var listRole = db.Roles.ToList();
            return Json(listRole, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetRoleById(int id)
        {
            var db = new StudentInfoEntities2();
            var oRole = db.Roles.Where(w => w.RoleId == id).FirstOrDefault();
            return Json(oRole, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertRole(Role model)//HttpPostedFileBase file)
        {
            object resdata = null;
            //HttpPostedFileBase file = Request.Files[0];
            //string picture = "";
            //if (model.file != null && model.file.ContentLength > 0)
            //{
            //    var fileName = Path.GetFileName(model.file.FileName);
            //    string fileLocation = Path.Combine(
            //        Server.MapPath("~/uploads"), fileName);
            //    model.file.SaveAs(fileLocation);

            //    picture = "/uploads/" + model.file.FileName;

        //    resdata = new { message = "image inserted successfully." };
        //}
        var db = new StudentInfoEntities2();
            var oRole = new Role();
            oRole.RoleName = model.RoleName;
            //oStudent.DoB = model.DoB;
            //oStudent.Picture = picture;
            //oStudent.StudentName = model.StudentName;
            db.Roles.Add(oRole);
            db.SaveChanges();
            return Json(resdata);
        }

        [HttpPost]
        public ActionResult UpdateRole(Role model)//HttpPostedFileBase file)
        {
            object resdata = null;
            ////HttpPostedFileBase file = Request.Files[0];
            //string picture = "";
            //if (model.file != null && model.file.ContentLength > 0)
            //{
            //    var fileName = Path.GetFileName(model.file.FileName);
            //    string fileLocation = Path.Combine(
            //        Server.MapPath("~/uploads"), fileName);
            //    model.file.SaveAs(fileLocation);

            //    picture = "/uploads/" + model.file.FileName;

            //    resdata = new { message = "image updated successfully." };
            //}
            var db = new StudentInfoEntities2();
            var oRole = db.Roles.Where(w => w.RoleId == model.RoleId).FirstOrDefault();
            if (oRole != null)
            {
                oRole.RoleName = model.RoleName;
                //oStudent.DoB = model.DoB;
                //oStudent.Picture = picture;
                //oStudent.StudentName = model.StudentName;
                db.SaveChanges();
            }

            return Json(resdata);
        }

        [HttpPost]
        public ActionResult DeleteRole(int id)
        {
            object resdata = null;
            var db = new StudentInfoEntities2();
            var oRole = db.Roles.Where(w => w.RoleId == id).FirstOrDefault();
            if (oRole != null)
            {
                db.Roles.Remove(oRole);
                db.SaveChanges();

                //var fileName = Path.GetFileName(oStudent.Picture);
                //string fileLocation = Path.Combine(
                //    Server.MapPath("~/uploads"), fileName);

                //// Check if file exists with its full path    
                //if (System.IO.File.Exists(fileLocation))
                //{
                //    // If file found, delete it    
                //    System.IO.File.Delete(fileLocation);
                //}

                resdata = new { message = "image deleted successfully." };
            }

            return Json(resdata);
        }

    }

}
