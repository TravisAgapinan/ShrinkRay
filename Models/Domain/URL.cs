using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace URLShortener.Models.Domain
{
    public class URL
    {
        public string  Url { get; set; }
        public int ID { get; set; }
        public string Slug { get; set; }
        public DateTime Created { get; set; }
    }
}