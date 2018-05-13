using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using PostingSite.ViewModels;
using PostingSite.Context;

namespace PostingSite.Controllers
{
    public class SearchController : ApiController
    {
        //Search All 
        //Get ONE
        //Create 
        //Update  
        //Delete Ads
        //public IEnumerable<Models.Ad> Search


        [System.Web.Http.Route("Ads")]
        [System.Web.Http.HttpGet]
        // GET: Search
        public IHttpActionResult ReturnAllAds([FromUri]SearchParameters Parameters)
        {
            using (var db = new DataContext())
            {
                /*IQueryable*/
                var query = db.Ads.AsQueryable();

                if (!String.IsNullOrEmpty(Parameters.Title))
                {
                    query = query.Where(w => w.Title.ToString() == Parameters.Title.ToString());
                }

                if (!String.IsNullOrEmpty(Parameters.Category))
                {
                    query = query.Where(w => w.Category.ToString() == Parameters.Category.ToString());
                }

                if (!String.IsNullOrEmpty(Parameters.Location))
                {
                    query = query.Where(w => w.Location.ToString() == Parameters.Location.ToString());
                }

                if (!String.IsNullOrEmpty(Parameters.Content))
                {
                    query = query.Where(w => w.Description.ToString().Contains(Parameters.Content.ToString()));
                }

                return Ok(query);
            }


        }

    }
}