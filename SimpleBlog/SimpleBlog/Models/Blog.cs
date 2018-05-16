using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SimpleBlog.Models
{
    public class Blog
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }     

        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        [JsonProperty(PropertyName = "createdAt")]
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
