using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace URLShortener.Models
{  //request model only uses URL because that is all thats needed from client
   //all other paramaters will be generated on server side. 
    public class URLRequestModel
    {
        [Required] //Server side validation
        public string URL { get; set; }
    }
}