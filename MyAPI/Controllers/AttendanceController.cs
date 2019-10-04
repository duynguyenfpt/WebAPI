using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPI.Controllers
{
    public class AttendanceController : ApiController
    {
        private dbFoodEntities db = new dbFoodEntities();

        // GET: api/FakeAPIs  
        public IQueryable<FakeAPI> GetFakeAPIs()
        {
            return db.FakeAPIs;
        }



        // PUT: api/FakeAPIs/5  

        public HttpResponseMessage PutFakeAPI(FakeAPI FakeAPI)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }


            db.Entry(FakeAPI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST: api/FakeAPIs  

        //public HttpResponseMessage PostFakeAPI(FakeAPI FakeAPI)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        db.FakeAPIs.Add(FakeAPI);
        //        db.SaveChanges();
        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, FakeAPI);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = FakeAPI.FakeAPIID }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //}

        //// DELETE: api/FakeAPIs/5  

        //public HttpResponseMessage DeleteFakeAPI(FakeAPI FakeAPI)
        //{
        //    FakeAPI remove_FakeAPI = db.FakeAPIs.Find(FakeAPI.FakeAPIID);
        //    if (remove_FakeAPI == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.FakeAPIs.Remove(remove_FakeAPI);
        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool FakeAPIExists(int id)
        //{
        //    return db.FakeAPIs.Count(e => e.FakeAPIID == id) > 0;
        //}
    }
}
