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
    public class TestInputController : ApiController
    {
        
        private DBClient dbClient;
        public TestInputController()
        {
            dbClient = new DBClient();
        }

        // GET: api/TestInput
        public List<TestInput> Get()
        {
            dbClient.GetTestInputs();
            return dbClient.testInputs;
        }

        //// GET: api/TestInput/5
        //public TestInput Get(string _id)
        //{
        //    ObjectId id = ObjectId.Parse(_id);
        //    return dbClient.testInputs.Where(x => x.id == id).First();
        //}

        // POST: api/TestInput
        public void Post(TestInput testInput)
        {
            dbClient.InsertTestInput(testInput);
        }

        // PUT: api/TestInput/5
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {


            try
            {
                if (id == 0)
                {
                    TestInput testInput = new TestInput();
                    var json = request.Content.ReadAsStringAsync().Result;
                    testInput = JsonConvert.DeserializeObject<TestInput>(json);
                    dbClient.UpdateTestInput(testInput);
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
            dbClient.DeleteTestInput(id);
        }
    }
}
