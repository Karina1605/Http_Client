using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDbExample.Models
{
    public class User
    {

        public ObjectId Id { get; set; }

        public string LogIn { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateTime? Born { get; set; }

        public string ProfilePthotoPath { get; set; }

        public byte[] ProfilePhoto { get; set; }

        public string SelfDescription { get; set; }

        public bool HasImage()
        {
            return ProfilePthotoPath != null;
        }
    }
}
