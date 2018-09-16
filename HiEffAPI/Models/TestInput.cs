using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace HiEffAPI.Models
{
    public class TestInput
    {
        [BsonId]
        public ObjectId? id { get; set; }
        public bool? input_bool { get; set; }
        public int? input_int { get; set; }

        public TestInput()
        {
            id = null;
            //input_bool = false;
            //input_int = 0;
        }

        public TestInput(BsonDocument result)
        {
            id = result["_id"].AsObjectId;
            input_bool = result["input_bool"].AsBoolean;
            input_int = result["input_int"].AsInt32;
        }
    }
}
