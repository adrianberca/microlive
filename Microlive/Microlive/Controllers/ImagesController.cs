using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microlive.BusinessLogic.ModelCore;
using Microlive.Model;

namespace Microlive.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {
            return View();
        }

        // GET: Images/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Images/Create
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }


        // POST: Images/Create
        [HttpPost]
        public  Task<ActionResult> Create(int id)
        {
            return null;
        }

       
        public async Task<ActionResult> Function1()
        {
            Image image = new Image
            {
                Id = new Guid("3222b146-bc7c-4e8f-a874-a1d25793e340"),
                AspNetUserId = "3222b146-bc7c-4e8f-a874-a1d25793e340",
                Path = "D:/DEVENTURE/CBT Fresh/CBT.Web/CBT.BusinessLogic",
                Description = "First Image"
            };

            var result = await ImageCore.Instance().CreateAsync(image);

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Upload()
        {
            return View();
        }
        // GET: Images/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Images/Edit/5
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

        // GET: Images/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Images/Delete/5
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
