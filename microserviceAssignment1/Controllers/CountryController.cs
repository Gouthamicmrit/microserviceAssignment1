using microserviceAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace microserviceAssignment1.Controllers
{
    [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {
        static List<Country> countrylist = new List<Country>()
        {
            new Country{Id=1, Name="India",Capital="Delhi"},
            new Country{Id=2, Name="Bangladesh",Capital="Dhaka"},
            new Country{Id=3, Name="Bhutan",Capital="Thimphu"},
            new Country{Id=4, Name="China",Capital="Beijing"},
        };
        [HttpGet]
        [Route("countrydetails")]

        public IEnumerable<Country> Get()
        {
            return countrylist;
        }

        [HttpGet]
        [Route("countrylist")]

        public HttpResponseMessage GetCountryList()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countrylist);
            return response;
        }

        [HttpGet]
        [Route("p")]
        public HttpResponseMessage GetP(int pid)
        {
            var country = countrylist.Find(x => x.Id == pid);

            if (country == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, pid);
            }
            return Request.CreateResponse(HttpStatusCode.OK, country);
            
        }


        public Country Post([FromBody] Country p)
        {
       
            countrylist.Add(p);
            return p;
        }

        public IEnumerable<Country> Put(int id, [FromBody] Country country )
     
        {
            countrylist[id - 1] = country;
            return countrylist;
        }

        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetID(int pid)
        {
            var country = countrylist.Find(x => x.Id == pid);

            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpGet]
        [Route("Name")]
        public IHttpActionResult GetName(int pid)
        {
            string country = countrylist.Where(x => x.Id == pid).SingleOrDefault()?.Name;

            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);

        }


        //[HttpGet]
        //[Route("NameById/{id}")]
        //public IHttpActionResult GetPersonName(int id)
        //{
        //    Person personobj = personlist.Find(item => item.Id == id);
        //    if (personobj != null)
        //    {
        //        return Ok(personobj.Name);
        //    }
        //    return NotFound();
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public IHttpActionResult Delete(int id)
        //{
        //    Person obj = personlist.Find(item => item.Id == id);
        //    if (obj != null)
        //    {
        //        bool isRemoved = personlist.Remove(obj);
        //        if (isRemoved)
        //        {
        //            return Ok(obj);
        //        }
        //    }
        //    return NotFound();
        //}


    }
}


