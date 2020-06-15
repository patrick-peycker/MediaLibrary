using MediaLibrary.CrossCutting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MediaLibrary.Web.Controllers
{
    public class MediasController : Controller
    {
        private readonly HttpClient Client = new HttpClient();
        private const string BaseUrl = "https://localhost:44348/api/media";

        // GET: Medias
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var httpResponse = await Client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve Medias");
			}

            var content = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<Media>>(content);

            return View();
        }

        // GET: Medias/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
   //         if (model is null)
   //         {
   //             return View("NotFound");
			//}

            return View();
        }

        // GET: Medias/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Medias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
    //            if (ModelState.IsValid)
    //            {
    //                TempData["Message"] = "The media was added successfully";
    //                return RedirectionToAction("Details", new { id = collection.Id})
				//}
            }
            catch
            {
                return View();
            }
        }

        // GET: Medias/Edit/5
        public ActionResult Edit(int id)
        {
            // if (model is null)
            // {
            // return View("NotFound");
            // }
            return View();
        }

        // POST: Medias/Edit/5
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

        // GET: Medias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Medias/Delete/5
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
