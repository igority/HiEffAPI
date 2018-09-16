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
using System.Web.Http.Cors;

namespace HiEffAPI.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class TestOutputController : ApiController
    {
        private DBClient dbClient;
        public TestOutputController()
        {
            dbClient = new DBClient();
        }

        // GET: api/TestOutput
        public string Get()
        {

            dbClient.GetTestOutputs();
            return JsonConvert.SerializeObject(dbClient.testOutputs);
            // return new string[] { "value1", "value2" };
        }

        // GET: api/TestOutput/5
        public string Get(string id)
        {
            dbClient.GetTestOutputs();

            ObjectId obj_id;
            try
            {
                obj_id = ObjectId.Parse(id);
                //5b4fa581dae6883fe0efc663
            }
            catch (Exception ex)
            {
                obj_id = ObjectId.Empty;
            }
            IEnumerable<TestOutput> testOutputs_filtered = dbClient.testOutputs.Where(x => x.id == obj_id);
            if (testOutputs_filtered.Count() > 0)
            {
                return JsonConvert.SerializeObject(testOutputs_filtered.First());
            } else
            {
                return null;
            }
            
        }

        // POST: api/TestOutput
        public void Post(string json_testOutput)
        {
            try
            {
                TestOutput testOutput = (TestOutput)JsonConvert.DeserializeObject(json_testOutput);
                dbClient.InsertTestOutput(testOutput);
            }
            catch (Exception ex)
            {
                //cannot parse object (invalid input string)
            }
        }

        // PUT: api/TestOutput/5
        public void Put(int id, [FromBody]string value)
        {
            //id = 5b4fa581dae6883fe0efc663
            var a = value;

        }

        // DELETE: api/TestOutput/5
        public void Delete(string _id)
        {
            ObjectId id = ObjectId.Parse(_id);
            dbClient.DeleteTestOutput(id);
        }
    }
}
