using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShEMWebAPI.Models
{
    public class Collection
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CollectionID { get; set; }
        public string UserID { get; set; }
    }
}