using articals.Core;
using articals.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace articals.Controllers
{
    public class CatigoryController : Controller
    {
        private readonly IDataHelper<Catigory> dataHelper;

        public CatigoryController(IDataHelper<Catigory> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
        // GET: CatigoryController
        public ActionResult Index()
        {
            return View(dataHelper.GetAllData());
        }

        // GET: CatigoryController/Details/5
        //public ActionResult Details(int id)//delet it becoause one صنف
        //{
        //    return View();
        //}

        // GET: CatigoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatigoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Catigory collection)
        {
            try
            {
                var result= dataHelper.Add(collection);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CatigoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatigoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Catigory collection)
        {
            try
            {
                var result = dataHelper.Edit(id,collection);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CatigoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatigoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Catigory collection)
        {
            try
            {
                var result = dataHelper.Delete(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
