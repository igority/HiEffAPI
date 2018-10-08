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
    public class PLCOutputController : ApiController
    {
        private DBClient dbClient;
        public PLCOutputController()
        {
            dbClient = new DBClient();
        }

        // GET: api/PLCOutput
        public string Get()
        {

            dbClient.GetPLCOutputs();
            return JsonConvert.SerializeObject(dbClient.PLCOutputs);
            // return new string[] { "value1", "value2" };
        }

        // GET: api/TestOutput/5
        public string Get(string id)
        {
            dbClient.GetPLCOutputs();

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
            IEnumerable<PLCOutput> plcOutputs_filtered = dbClient.PLCOutputs.Where(x => x.id == obj_id);
            if (plcOutputs_filtered.Count() > 0)
            {
                return JsonConvert.SerializeObject(plcOutputs_filtered.First());
            } else
            {
                return null;
            }
            
        }

        // POST: api/PLCOutput
        public void Post(string json_plcOutput)
        {
            try
            {
                PLCOutput plcOutput = (PLCOutput)JsonConvert.DeserializeObject(json_plcOutput);
                dbClient.InsertPLCOutput(plcOutput);
            }
            catch (Exception ex)
            {
                //cannot parse object (invalid input string)
            }
        }

        // PUT: api/PLCOutput/5
        public void Put(int id, [FromBody]string value)
        {
            //id = 5b4fa581dae6883fe0efc663
            var a = value;

        }

        // DELETE: api/TestOutput/5
        public void Delete(string _id)
        {
            ObjectId id = ObjectId.Parse(_id);
            dbClient.DeletePLCOutput(id);
        }
    }
}
