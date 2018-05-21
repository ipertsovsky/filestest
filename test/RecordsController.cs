using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using System.Web.Http;


namespace test
{ 
    public class RecordsController : ApiController 
    {
        
        //need to inject/pass IRepository
        public RecordsController()
        {
        }

        public IEnumerable<string> Get() 
        { 
            return new string[] { }; 
        }

        public HttpResponseMessage Get(string id)
        {
            var property = typeof(test.FileContentsModel).GetProperty(id, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (property == null)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid sort field");
            else
            { 
                var orderedContents = FileManager.FileContentList.OrderBy(x => property.GetValue(x, null));
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(orderedContents));
            }
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