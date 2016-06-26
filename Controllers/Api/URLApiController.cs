using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using URLShortener.Models;
using URLShortener.Models.Domain;
using URLShortener.Models.Responses;
using URLShortener.Services;
using URLShortener.Services.Interfaces;

namespace URLShortener.Controllers.Api
{

    [RoutePrefix("api")]
    public class URLApiController : ApiController
    {
        private IURLService _URLService { get; set; }
        public URLApiController()
        {
            //unable to inject. issue with unity api controller
            //temp fix of instantiating it/making new instance of
            _URLService = new URLService();
        }


        //insert URL into DB
        [Route("create"), HttpPost]
        public HttpResponseMessage InsertURL(URLRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = _URLService.Insert(model);

            return Request.CreateResponse(response); //at this point model will be serialized as JSON
        }

        // Get Slug by Url
        [Route("{url}"), HttpGet]
        public HttpResponseMessage GetSlug(string url)
        {

            ItemResponse<URL> response = new ItemResponse<URL>();

            response.Item = _URLService.GetByUrl(url);

            return Request.CreateResponse(response);
        }

    }
}
