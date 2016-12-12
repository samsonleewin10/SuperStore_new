using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperStore.Models;
using Microsoft.ApplicationInsights;

namespace SuperStore.Controllers
{
    public class RecordsController : Controller
    {
		private ApplicationDbContext db = new ApplicationDbContext();

		private TelemetryClient telemetry = new TelemetryClient();

        public ActionResult Index()
        {
			telemetry.TrackEvent("View Purchase Record");
			return View (db.Records.ToList());
        }

        public ActionResult Details(int id)
        {
            return View (record);
        }

        public ActionResult Create()
        {
			telemetry.TrackEvent("Attempt to Purchase");
            return View ();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try {
				telemetry.TrackEvent("Made a Purchase");
				db.Records.Add(record);
				db.SaveChanges();
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try {
				db.Entry(record).State = EntityState.Modified;
				db.SaveChanges();
                return RedirectToAction ("Index");
            } catch {
                return View (record);
            }
        }

        public ActionResult Delete(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View (record);
            }
        }
    }
}