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
    public class PLCOutput
    {
        [BsonId]
        public ObjectId? id { get; set; }
        public long? iPLC_STATUS { get; set; }

        public PLCOutput(BsonDocument result)
        {

            id = result["_id"].AsObjectId;
            if (!result["iPLC_STATUS"].IsBsonNull) iPLC_STATUS = result["iPLC_STATUS"].AsInt64;
            else iPLC_STATUS = null;
        }

        public PLCOutput()
        {
            id = null;
            iPLC_STATUS = null;
        }
    }
}
