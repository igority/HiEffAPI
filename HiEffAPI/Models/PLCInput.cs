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
    public class PLCInput
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public long? iPLC_STATUS { get; set; }

        public PLCInput()
        {
            id = "";

        }

        public PLCInput(BsonDocument result)
        {
            ObjectId _id = result["_id"].AsObjectId;
            id = _id.ToString();
            iPLC_STATUS = result["iPLC_STATUS"].AsInt64;
        }
    }
}
