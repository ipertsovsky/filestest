using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Http;


namespace test
{ 
    public class RecordsController : ApiController 
    { 
        public IEnumerable<string> Get() 
        { 
            return new string[] { }; 
        }

        public IHttpActionResult Get(string id)
        {

            var contents = FileManager.FileContentList;
            //•	GET /records/gender - returns records sorted by gender
            //•	GET /records/birthdate - returns records sorted by birthdate
            //•	GET /records/name - returns records sorted by name

            return Ok(new { results = contents });
        }

        // POST api/records 
        public void Post([FromBody]string value) 
        {
            //POST /records - Post a single data line in any of the 3 formats supported by your existing code
            FileManager.AddLine(value);
        }

        public void Put(int id, [FromBody]string value) 
        { 
        } 

        public void Delete(int id) 
        { 
        } 
    } 
}