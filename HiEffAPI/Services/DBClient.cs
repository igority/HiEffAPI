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

        public List<TestOutput> testOutputs { get; set; }
        public List<TestInput> testInputs { get; set; }


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

        public List<TestInput> GetTestInputs()
        {
            List<TestInput> _testInputs = new List<TestInput>();
            var collection = _database.GetCollection<BsonDocument>("Test-Input");
            var filter = new BsonDocument();
            var results = collection.Find(filter).Limit(100).ToList();
            if (results.Count > 0)
            {
                foreach (var result in results)
                {
                    TestInput testInput = new TestInput(result);
                    _testInputs.Add(testInput);
                }
            }
            testInputs = _testInputs;
            return _testInputs;
        }

        public List<TestOutput> GetTestOutputs()
        {
            List<TestOutput> _testOutputs = new List<TestOutput>();
            var collection = _database.GetCollection<BsonDocument>("Test-Output");
            var filter = new BsonDocument();
            var results = collection.Find(filter).Limit(100).ToList();
            if (results.Count > 0)
            {
                foreach (var result in results)
                {
                    TestOutput testOutput = new TestOutput(result);
                    _testOutputs.Add(testOutput);
                }
            }
            testOutputs = _testOutputs;
            return _testOutputs;
        }

        public void UpdateTestOutput(TestOutput testOutput)
        {
            var collection = _database.GetCollection<BsonDocument>("Test-Output");
            var filter = Builders<BsonDocument>.Filter.Eq("id", testOutput.id);
            var update = Builders<BsonDocument>.Update.Set("output_bool", testOutput.output_bool).Set("output_int", testOutput.output_int).Set("output_random", testOutput.output_random);
            //var update = Builders<BsonDocument>.Update.Set("order_status", order.order_status);
            var result = collection.UpdateMany(filter, update);
        }
        public void UpdateTestInput(TestInput testInput)
        {
            var collection = _database.GetCollection<BsonDocument>("Test-Input");
            var filter = Builders<BsonDocument>.Filter.Eq("id", testInput.id);
            var update = Builders<BsonDocument>.Update.Set("input_bool", testInput.input_bool).Set("input_int", testInput.input_int);
            //var update = Builders<BsonDocument>.Update.Set("order_status", order.order_status);
            var result = collection.UpdateMany(filter, update);
        }

        internal void InsertTestInput(TestInput testInput)
        {
            throw new NotImplementedException();
        }
        internal void InsertTestOutput(TestOutput testOutput)
        {
            throw new NotImplementedException();
        }
        internal void DeleteTestOutput(ObjectId id)
        {
            throw new NotImplementedException();
        }
        internal void DeleteTestInput(ObjectId id)
        {
            throw new NotImplementedException();
        }


    }
}