using HiEffAPI.Models;
using HiEffAPI.Services;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Cors;

namespace HiEffAPI.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class PLCInputController : ApiController
    {
        
        private DBClient dbClient;
        public PLCInputController()
        {
            dbClient = new DBClient();
        }

        // GET: api/TestInput
        public List<PLCInput> Get()
        {
            dbClient.GetPLCInputs();
            return dbClient.PLCInputs;
        }

        //// GET: api/TestInput/5
        //public TestInput Get(string _id)
        //{
        //    ObjectId id = ObjectId.Parse(_id);
        //    return dbClient.testInputs.Where(x => x.id == id).First();
        //}

        // POST: api/TestInput
        public void Post(PLCInput plcInput)
        {
            dbClient.InsertPLCInput(plcInput);
        }

        // PUT: api/TestInput/5
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {


            try
            {
                if (id == 0)
                {
                    PLCInput plcInput = new PLCInput();
                    var json = request.Content.ReadAsStringAsync().Result;
                    plcInput = JsonConvert.DeserializeObject<PLCInput>(json);
                    dbClient.UpdatePLCInput(plcInput);
                }
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }

            
            //id = 5b4fa581dae6883fe0efc663
            //return;
            //var a = value;
            //return a;

        }

        // DELETE: api/TestInput/5
        public void Delete(string _id)
        {
            ObjectId id = ObjectId.Parse(_id);
            dbClient.DeletePLCInput(id);
        }
    }
}
