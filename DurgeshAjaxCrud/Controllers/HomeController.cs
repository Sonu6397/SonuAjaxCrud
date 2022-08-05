using DurgeshAjaxCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DurgeshAjaxCrud.Controllers
{
    public class HomeController : Controller
    {
        DurgeshAjaxEntities _context = new DurgeshAjaxEntities();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(_context.users.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(user user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_context.users.FirstOrDefault(x => x.Id == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(user user)
        {
            var data = _context.users.FirstOrDefault(x => x.Id == user.Id);
            if (data != null)
            {
                data.Name = user.Name;
                data.State = user.State;
                data.Country = user.Country;
                data.Age = user.Age;
                _context.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _context.users.FirstOrDefault(x => x.Id == ID);
            _context.users.Remove(data);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
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