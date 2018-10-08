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
        public ObjectId? id { get; set; }
        public long? iPLC_STATUS { get; set; }

        public PLCInput()
        {
            id = null;
            //input_bool = false;
            //input_int = 0;
        }

        public PLCInput(BsonDocument result)
        {
            id = result["_id"].AsObjectId;
            iPLC_STATUS = result["iPLC_STATUS"].AsInt64;
        }
    }
}
