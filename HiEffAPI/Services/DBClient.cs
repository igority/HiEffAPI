using HiEffAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace HiEffAPI.Services
{
    public class DBClient
    {

        private IMongoClient _client;
        private IMongoDatabase _database;

        public List<PLCOutput> PLCOutputs { get; set; }
        public List<PLCInput> PLCInputs { get; set; }


        public DBClient()
        {

            ConnectToDB();
            //testInputs = GetTestInputs();
            //testOutputs = GetTestOutputs();
        }

        void ConnectToDB()
        {

            // Start("hiefficiency.srmtechsol.com", "root", "Welcome@321", 22);
            _client = new MongoClient();
            _database = _client.GetDatabase("Hi-Eff");
            //_database = _client.GetDatabase("hiefficiency");
            //Stop();

        }

        public List<PLCInput> GetPLCInputs()
        {
            List<PLCInput> _plcInputs = new List<PLCInput>();
            var collection = _database.GetCollection<BsonDocument>("PLC_inputs");
            var filter = new BsonDocument();
            var results = collection.Find(filter).Limit(100).ToList();
            if (results.Count > 0)
            {
                foreach (var result in results)
                {
                    PLCInput plcInput = new PLCInput(result);
                    _plcInputs.Add(plcInput);
                }
            }
            PLCInputs = _plcInputs;
            return _plcInputs;
        }

        public List<PLCOutput> GetPLCOutputs()
        {
            List<PLCOutput> _plcOutputs = new List<PLCOutput>();
            var collection = _database.GetCollection<BsonDocument>("PLC_outputs");
            var filter = new BsonDocument();
            var results = collection.Find(filter).Limit(100).ToList();
            if (results.Count > 0)
            {
                foreach (var result in results)
                {
                    PLCOutput plcOutput = new PLCOutput(result);
                    _plcOutputs.Add(plcOutput);
                }
            }
            PLCOutputs = _plcOutputs;
            return _plcOutputs;
        }

        public void UpdatePLCOutput(PLCOutput plcOutput)
        {
            var collection = _database.GetCollection<BsonDocument>("PLC_outputs");
            var filter = Builders<BsonDocument>.Filter.Eq("id", plcOutput.id);
            var update = Builders<BsonDocument>.Update.Set("iPLC_STATUS", plcOutput.iPLC_STATUS);
                        //.Set("output_int", testOutput.output_int)
                        //.Set("output_random", testOutput.output_random);

            //var update = Builders<BsonDocument>.Update.Set("order_status", order.order_status);
            var result = collection.UpdateMany(filter, update);
        }
        public void UpdatePLCInput(PLCInput plcInput)
        {
            var collection = _database.GetCollection<BsonDocument>("PLC_inputs");
            var filter = Builders<BsonDocument>.Filter.Eq("id", plcInput.id);
            var update = Builders<BsonDocument>.Update.Set("iPLC_STATUS", plcInput.iPLC_STATUS);
                            //.Set("input_int", plcInput.input_int);
                            //var update = Builders<BsonDocument>.Update.Set("order_status", order.order_status);
            var result = collection.UpdateMany(filter, update);
        }

        internal void InsertPLCInput(PLCInput pLCInput)
        {
            throw new NotImplementedException();
        }
        internal void InsertPLCOutput(PLCOutput pLCOutput)
        {
            throw new NotImplementedException();
        }
        internal void DeletePLCOutput(ObjectId id)
        {
            throw new NotImplementedException();
        }
        internal void DeletePLCInput(ObjectId id)
        {
            throw new NotImplementedException();
        }


    }
}