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


        [System.Web.Http.Route("Ads/Search")]
        [System.Web.Http.HttpGet]
        // GET: Search
        public IHttpActionResult GetAdsSearch([FromUri]string title, string category, string location, string content)
        {
            using (var db = new DataContext())
            {
                var query = db.Ads.AsQueryable();

                if (!String.IsNullOrEmpty(title))
                {
                    query = query.Where(w => w.Title.ToString().Contains(title));
                }

                if (!String.IsNullOrEmpty(category))
                {
                    query = query.Where(w => w.Category.ToString().Contains(category));
                }

                if (!String.IsNullOrEmpty(location))
                {
                    query = query.Where(w => w.Location.ToString().Contains(location));
                }

                if (!String.IsNullOrEmpty(content))
                {
                    query = query.Where(w => w.Description.ToString().Contains(content));
                }

                var results = query.ToList();
                if (results.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(query);
                }
            }


        }

    }
}